using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace Sannel.House.Control.Http
{
	public sealed class HttpServer : IDisposable
	{
		private uint port;
		private StreamSocketListener socket;
		private Dictionary<String, IRought> roughts = new Dictionary<string, IRought>();
		private IRought defaultRought;

		public HttpServer(uint port, IRought defaultRought = null)
		{
			this.port = port;
			this.defaultRought = defaultRought;
			if (defaultRought == null)
			{
				this.defaultRought = new Rought404();
			}
			socket = new StreamSocketListener();
			socket.Control.KeepAlive = true;
			socket.Control.NoDelay = true;
			socket.ConnectionReceived += onConnectionReceived;
		}

		public void RegisterRought(IRought rought)
		{
			roughts[rought.Path] = rought;
		}

		private async Task<HttpRequest> getRequestAsync(IInputStream stream)
		{
			StringBuilder req = new StringBuilder();
			uint len = 8192;
			byte[] data = new byte[len];
			IBuffer buffer = data.AsBuffer();
			uint dataRead = len;
			using (IInputStream input = stream)
			{
				while (dataRead == len)
				{
					await input.ReadAsync(buffer, len, InputStreamOptions.Partial);
					req.Append(Encoding.UTF8.GetString(data, 0, (int)buffer.Length));
					dataRead = buffer.Length;
				}
			}

			HttpRequest request = new HttpRequest();
			var lines = req.ToString().Split('\n');
			var queue = new Queue<String>(lines);
			req = null;
			if(queue.Count > 0)
			{
				var parts = queue.Dequeue()?.Split(' ');
				if (parts?.Length > 0)
				{
					HttpRequestType type;
					if (Enum.TryParse<HttpRequestType>(parts[0], out type))
					{
						request.RequestType = type;
					}
					if (parts.Length > 1)
					{
						var path = parts[1]?.ToLower();
						if (path != null)
						{
							var spath = path;
							if (path.Contains('?'))
							{
								var index = path.IndexOf('?');
								spath = path.Substring(0, index);
							}
							request.Path = spath;
							var l = spath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
							var first = l.FirstOrDefault();
							request.RootPath = first;
						}
					}
				}

				String line = queue.Dequeue();
				while (!String.IsNullOrWhiteSpace(line))
				{
					if (line.Contains(':'))
					{
						request.AddHeader(line.Trim());
					}
				}
				String sdata = "";
				while(queue.Count > 0)
				{
					sdata += queue.Dequeue();
				}
				request.Data = sdata;
			}

			return request;
		}

		private String getResponseTextForStatusCode(int statusCode)
		{
			switch (statusCode)
			{
				case 404:
					return "404 Not Found";

				case 401:
					return "401 Access Denied";

				case 200:
					return "200 OK";

				default:
					return "500 Server Error";
			}
		}

		private async Task writeResponseAsync(IOutputStream stream, HttpResponse response)
		{
			using(var sw = new StreamWriter(stream.AsStreamForWrite()))
			{
				await sw.WriteLineAsync($"HTTP/1.1 {getResponseTextForStatusCode(response.StatusCode)}");
				if (!response.CanCache)
				{
					await sw.WriteLineAsync("Cache-Control: no-store, no-cache");
				}
				switch (response.ContentType)
				{
					case ContentType.Json:
						await sw.WriteLineAsync("Content-Type: application/json");
						break;

					case ContentType.Html:
						await sw.WriteLineAsync("Content-Type: text/html; charset=utf-8");
						break;

					case ContentType.Javascript:
						await sw.WriteLineAsync("Content-Type: application/javascript");
						break;

					case ContentType.Css:
						await sw.WriteLineAsync("Content-Type: text/css");
						break;

					default:
						await sw.WriteLineAsync("Content-Type: text/txt");
						break;
				}
				await sw.WriteLineAsync("Accept-Ranges: bytes");
				await sw.WriteLineAsync($"Date: {response.LastUpdated: dd MMM yyyy hh:mm:ss} GMT");
				await sw.WriteLineAsync("Server: House Server");

				foreach(var key in response.Headers.Keys)
				{
					await sw.WriteLineAsync($"{key}: {response.Headers[key]}");
				}

				if (response.Output != null)
				{
					await sw.WriteLineAsync($"Content-Length: {response.Output.Length}");
					await sw.WriteLineAsync();

					await sw.WriteAsync(response.Output.ToString());
				}
				await sw.FlushAsync();

				/*Cache-Control:no-store, no-cache
Content-Length:551
Content-Type:application/json
Date:Sun, 17 Apr 2016 23:23:47 GMT
Server:Microsoft-HTTPAPI/2.0*/
			}
		}

		private async void onConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
		{
			using (var socket = args.Socket)
			{
				HttpRequest request;
				using (var inputStream = socket.InputStream)
				{
					request = await getRequestAsync(inputStream);
				}

				if(request.Path == null)
				{
					return;
				}

				HttpResponse response = new HttpResponse();

				try
				{
					if (roughts.ContainsKey(request.RootPath))
					{
						await roughts[request.RootPath].RequestAsync(request, response);
					}
					else
					{
						await defaultRought.RequestAsync(request, response);
					}
				}
				catch(Exception ex)
				{
					response = new HttpResponse();
					var err = new Error500(ex);
					await err.RequestAsync(request, response);
				}

				using (var outStream = socket.OutputStream)
				{
					await writeResponseAsync(outStream, response);
				}
			}
		}

		public async Task StartAsync()
		{
			await socket.BindServiceNameAsync(port.ToString());
		}

		public void Dispose()
		{
			socket.Dispose();
		}
	}
}
