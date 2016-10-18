/* Copyright 2016 Sannel Software, L.L.C.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Sannel.House.ServerSDK
{
	/// <summary>
	/// The client to use with ServerContext
	/// </summary>
	/// <seealso cref="Sannel.House.ServerSDK.IHttpClient" />
	/// <seealso cref="System.IDisposable" />
	public sealed class ServerHttpClient : IHttpClient, IDisposable
	{
		private HttpBaseProtocolFilter httpFilter = new HttpBaseProtocolFilter();
		private HttpClient client;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerHttpClient"/> class.
		/// </summary>
		public ServerHttpClient()
		{
			client = new HttpClient(httpFilter);
		}

		public void Dispose()
		{
			client?.Dispose();
		}

		/// <summary>
		/// Does a Get request asynchronous.
		/// </summary>
		/// <param name="requestUri">The request URI.</param>
		/// <returns></returns>
		public IAsyncOperation<HttpClientResult> GetAsync(Uri requestUri)
		{
			return Task.Run(async () =>
			{
				var result = await client.GetAsync(requestUri);
				var data = await result.Content.ReadAsStringAsync();
				return new HttpClientResult()
				{
					StatusCode = result.StatusCode,
					Content = data
				};
			}).AsAsyncOperation();
		}

		/// <summary>
		/// Does a Post request asynchronous.
		/// </summary>
		/// <param name="requestUri">The request URI.</param>
		/// <param name="data">The data allowed to be null</param>
		/// <returns></returns>
		public IAsyncOperation<HttpClientResult> PostAsync(Uri requestUri, IDictionary<string, string> data)
		{
			return Task.Run(async () =>
			{
				HttpFormUrlEncodedContent content;
				if (data != null)
				{
					content = new HttpFormUrlEncodedContent(data);
				}
				else
				{
					content = new HttpFormUrlEncodedContent(new Dictionary<String, String>());
				}

				var result = await client.PostAsync(requestUri, content);
				var rdata = await result.Content.ReadAsStringAsync();

				return new HttpClientResult()
				{
					StatusCode = result.StatusCode,
					Content = rdata
				};
			}).AsAsyncOperation();
		}

		/// <summary>
		/// Gets the cookie value.
		/// </summary>
		/// <param name="uri">The URI of the cookie.</param>
		/// <param name="cookieName">Name of the cookie.</param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public string GetCookieValue(Uri uri, string cookieName)
		{
			var cookies = httpFilter.CookieManager.GetCookies(uri);
			var c = cookies.FirstOrDefault(i => String.Compare(i.Name, cookieName, true) == 0);
			if(c != null)
			{
				return c.Value;
			}

			return null;
		}
	}
}
