using System;
using udpServer.Server;
using System.Net.Sockets;

namespace udpServer
{
	class Program
	{
		static void Main(string[] args)
		{
			Server.Server server = new Server.Server(12000);
			Socket sock = server.getSock();
			Console.Title = "UDP Server";

			while (true)
			{
				string recv = server.startListen();
				Console.WriteLine(recv);
			}
		}
	}
}
