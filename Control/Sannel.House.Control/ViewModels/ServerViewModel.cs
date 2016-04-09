using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using System.IO;

namespace Sannel.House.Control.ViewModels
{
	public class ServerViewModel : Screen
	{
		DatagramSocket dsocket = null;

		public ServerViewModel()
		{
			
		}

		private async void Socket_MessageReceived(Windows.Networking.Sockets.DatagramSocket sender, Windows.Networking.Sockets.DatagramSocketMessageReceivedEventArgs args)
		{
			using (var ds = args.GetDataStream())
			{
				using (var sr = new StreamReader(ds.AsStreamForRead()))
				{
					var result = await sr.ReadToEndAsync();
				}
			}
		}

		public async void Start()
		{
			Stop(); // stop any service that may be running;
			dsocket = new DatagramSocket();
			dsocket.MessageReceived += Socket_MessageReceived;
			await dsocket.BindServiceNameAsync("19082");
		}

		public void Stop()
		{
			dsocket?.Dispose();
		}
	}
}
