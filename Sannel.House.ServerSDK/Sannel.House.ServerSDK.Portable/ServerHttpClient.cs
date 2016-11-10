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
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	/// <summary>
	/// The client to use with ServerContext
	/// </summary>
	/// <seealso cref="Sannel.House.ServerSDK.IHttpClient" />
	/// <seealso cref="System.IDisposable" />
	public sealed class ServerHttpClient : IHttpClient, IDisposable
	{
		private HttpClientHandler handler = new HttpClientHandler();
		private HttpClient client;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerHttpClient"/> class.
		/// </summary>
		public ServerHttpClient()
		{
			client = new HttpClient(handler);
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
		public async Task<HttpClientResult> GetAsync(Uri requestUri)
		{
			var result = await client.GetAsync(requestUri);
			var data = await result.Content.ReadAsStringAsync();
			return new HttpClientResult()
			{
				StatusCode = result.StatusCode,
				Content = data
			};
		}

		/// <summary>
		/// Does a Post request asynchronous.
		/// </summary>
		/// <param name="requestUri">The request URI.</param>
		/// <param name="data">The data allowed to be null</param>
		/// <returns></returns>
		public async Task<HttpClientResult> PostAsync(Uri requestUri, IDictionary<string, string> data)
		{
			FormUrlEncodedContent content;
			if (data != null)
			{
				content = new FormUrlEncodedContent(data);
			}
			else
			{
				content = new FormUrlEncodedContent(new Dictionary<String, String>());
			}

			var result = await client.PostAsync(requestUri, content);
			var rdata = await result.Content.ReadAsStringAsync();

			return new HttpClientResult()
			{
				StatusCode = result.StatusCode,
				Content = rdata
			};
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
			var cookies = handler.CookieContainer.GetCookies(uri);
			foreach(Cookie cc in cookies)
			{
				if(String.Compare(cc.Name, cookieName, StringComparison.CurrentCultureIgnoreCase) == 0)
				{
					return cc.Value;
				}
			}

			return null;
		}
	}
}
