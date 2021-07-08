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
		private Socket sockUdp;
		private UdpClient listen;
		private IPEndPoint epIn;

		public Server(int _serverPort)
		{
			this.serverPort = _serverPort;
			this.sockUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			this.listen = new UdpClient(this.serverPort);
			this.epIn = new IPEndPoint(IPAddress.Any, this.serverPort);
		}

		~Server()
		{
			if (this.sockUdp.Connected)
			{
				this.sockUdp.Close();
			}
		}

		public void sendTo(string _ip, int _port, string _msg)
		{
			IPAddress broadcast = IPAddress.Parse(_ip);
			byte[] sendBuffer = Encoding.ASCII.GetBytes(_msg);
			IPEndPoint epOut = new IPEndPoint(broadcast, _port);
			this.sockUdp.SendTo(sendBuffer, epOut);				 
		}

		public string StartListen()
		{
			byte[] recv = this.listen.Receive(ref this.epIn);
			StringBuilder msg = new StringBuilder();
			msg.Append(Encoding.ASCII.GetString(recv, 0, recv.Length));
			msg.Append("|");
			msg.Append(this.epIn);
			return msg.ToString();
		}
	}
}
