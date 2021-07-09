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
			Console.Title = "UDP Server";
			Server.Server server = new Server.Server(12000);
			ServerLogic logic = new Server.ServerLogic();
			Server.xml.XmlParser xmlParser = new Server.xml.XmlParser();
			xmlParser.createXmlDoc();
			
													 
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
