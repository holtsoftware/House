using Sannel.House.Control.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Sannel.House.Control.Roughts
{
	public abstract class StaticContent : IRought
	{
		public abstract string Path
		{
			get;
		}

		public abstract ContentType ContentType { get; }

		public async Task RequestAsync(HttpRequest request, HttpResponse response)
		{
			try
			{
				response.StatusCode = 200;
				response.ContentType = ContentType;
				response.CanCache = true;
				var sf = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/http" + request.Path));
				var bp = await sf.GetBasicPropertiesAsync();
				response.LastUpdated = bp.DateModified.UtcDateTime;
				var sb = response.Output = new StringBuilder();
				using(var reader = new StreamReader((await sf.OpenReadAsync()).AsStreamForRead()))
				{
					sb.Append(await reader.ReadToEndAsync());
				}
			}
			catch(Exception ex)
			{
				response.StatusCode = 404;
				var sb = response.Output = new StringBuilder();
				sb.Append("<html><head><title>File Not Found</title></head><body><h1>File Not Found</h1>");
				sb.Append("<!--");
				sb.Append(ex.ToString());
				sb.Append("--></body></html>");
			}
		}
	}
}
