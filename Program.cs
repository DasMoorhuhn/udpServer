using System;
using udpServer.Server;
using System.Net.Sockets;
using System.Collections;

namespace udpServer
{
	class Program
	{
		static void Main(string[] args)
		{
			Server.Server server = new Server.Server(12000);
			ServerLogic logic = new Server.ServerLogic();
			Console.Title = "UDP Server";
			
													 
			while (true)
			{
				string recv = server.StartListen();
				logic.getCommand(recv, server);
				ArrayList value = server.getConnectedDevices();
				foreach (string i in value)
				{
					Console.WriteLine(i);
				}
			}
		}
	}
}
