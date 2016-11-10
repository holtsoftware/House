using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Web.Http;

namespace Sannel.House.ServerSDK
{
	public sealed partial class ServerContext
	{

		#region TemperatureEntry
		/// <summary>
		/// Gets the temperature entry asynchronous.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public IAsyncOperation<TemperatureEntryResult> GetTemperatureEntryAsync(Guid key)
		{
			return Task.Run(async () =>
			{

				var check = checkCommon();
				if(check.Item1 != RequestStatus.Success)
				{
					return new TemperatureEntryResult(check.Item1, null, default(Guid));
				}
				var builder = check.Item2;
				builder.Path = $"/api/TemperatureEntry/{key}";
				HttpClientResult result = null;
				try
				{
					result = await client.GetAsync(builder.Uri);
				}
				catch (COMException ce)
				{
					if (ce.HResult == -2147012867)
					{
						return new TemperatureEntryResult(RequestStatus.UnableToConnectToServer, null, key, ce);
					}

					return new TemperatureEntryResult(RequestStatus.Exception, null, key, ce);
				}
				catch (Exception ce)
				{
					return new TemperatureEntryResult(RequestStatus.Exception, null, key, ce);
				}

				if (result.StatusCode == HttpStatusCode.Ok)
				{
					var res = result.Content;
					try
					{
						var token = JObject.Parse(res);
						var item = helper.CreateTemperatureEntry();
						if (token.Type == JTokenType.Object)
						{
							item.Id = token.GetPropertyValue<Guid>(nameof(item.Id));
							item.DeviceId = token.GetPropertyValue<Int32>(nameof(item.DeviceId));
							item.TemperatureCelsius = token.GetPropertyValue<Double>(nameof(item.TemperatureCelsius));
							item.Humidity = token.GetPropertyValue<Double>(nameof(item.Humidity));
							item.Pressure = token.GetPropertyValue<Double>(nameof(item.Pressure));
							item.CreatedDateTime = token.GetPropertyValue<DateTimeOffset>(nameof(item.CreatedDateTime));
						}

						return new TemperatureEntryResult(RequestStatus.Success, item, item.Id);
					}
					catch (Exception ex)
					{
						return new TemperatureEntryResult(RequestStatus.Exception, null, key, ex);
					}
				}
				else
				{
					return new TemperatureEntryResult(RequestStatus.Error, null, key);
				}
			}

			).AsAsyncOperation();
		}
		#endregion

	}
}
