using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Sannel.House.ServerSDK
{
	public interface IServerContext
	{
		IAsyncOperation<LoginResult> LoginAsync(String username, String password);

		bool IsAuthenticated
		{
			get;
		}

		IAsyncOperation<TemperatureEntryResult> PostTemperatureEntryAsync(ITemperatureEntry entry);
	}
}
