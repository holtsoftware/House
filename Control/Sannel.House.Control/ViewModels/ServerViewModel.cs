/*
   Copyright 2016 Adam Holt

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
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
