using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
		}

		public void RegisterRought(IRought rought)
		{
			roughts[rought.Path] = rought;
		}

		private async Task<HttpRequest> getRequestAsync(IInputStream stream)
		{
			String line = "";
			HttpRequest request = new HttpRequest();
			using (var streamReader = new StreamReader(stream.AsStreamForRead()))
			{
				line = await streamReader.ReadLineAsync();
				var parts = line?.Split(' ');
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
							var uri = new Uri(path, UriKind.RelativeOrAbsolute);
							request.Path = uri.GetComponents(UriComponents.Path, UriFormat.UriEscaped);
						}
					}
				}
			}

			return request;
		}

		private async Task writeResponseAsync(IOutputStream stream, HttpResponse response)
		{
			using (var dw = new DataWriter(stream))
			{
				dw.WriteString($"HTTP/1.1 {response.StatusCode} OK\n");
				dw.WriteString("Cache-Control: no-store, no-cache\n");
				switch (response.ContentType)
				{
					case ContentType.Json:
						dw.WriteString("Content-Type: application/json\n");
						break;

					case ContentType.Html:
						dw.WriteString("Content-Type: text/html\n");
						break;

					default:
						dw.WriteString("Content-Type: text/txt\n");
						break;
				}
				dw.WriteString($"Date: {DateTime.UtcNow: dd MMM yyyy hh:mm:ss tt}\n");
				dw.WriteString("Server: House Server\n");
				dw.WriteString($"Content-Length: {response.Output.Length}\n");
				dw.WriteBuffer(response.Output);
				dw.WriteString("\n");
				await dw.FlushAsync();

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

				HttpResponse response = new HttpResponse();

				if (roughts.ContainsKey(request.Path))
				{

				}
				else
				{
					defaultRought.Request(request, response);
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
			socket.ConnectionReceived += onConnectionReceived;
		}

		public void Dispose()
		{
			socket.Dispose();
		}
	}
}
