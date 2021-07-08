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
			Console.Title = "UDP Server";
			
													 
			while (true)
			{
				string recv = server.StartListen();
				server.sendTo("192.168.178.23", 12000, "Hallo");
				Console.WriteLine(recv);
				
			}
		}
	}
}
