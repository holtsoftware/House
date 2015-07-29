using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;

namespace House.Monitor
{
	public partial class MonitorListener : ServiceBase
	{
		public MonitorListener()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			UdpClient client = new UdpClient();
			client.Connect(IPAddress.Broadcast, )
		}

		protected override void OnStop()
		{
		}
	}
}
