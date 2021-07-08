using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace udpServer.Server
{
	class Server
	{
		private int serverPort;
		private Socket sock;
		private UdpClient listen;
		private IPEndPoint ep;
		public Server(int _serverPort)
		{
			this.serverPort = _serverPort;
			this.sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			this.listen = new UdpClient(this.serverPort);
			this.ep = new IPEndPoint(IPAddress.Any, this.serverPort);
		}

		public Socket getSock()
		{
			return this.sock;
		}

		public string startListen()
		{
			byte[] recv = this.listen.Receive(ref this.ep);
			return Encoding.ASCII.GetString(recv, 0, recv.Length);
		}
	}
}
