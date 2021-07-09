using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace udpServer.Server
{
	class ServerLogic
	{
		public ServerLogic()
		{
			
		}

		public void getCommand(string recv, udpServer.Server.Server _server)
		{
			string[] splitRecv = recv.Split("|");
			string[] command = splitRecv[0].Split(";");
			string[] ipAndPort = splitRecv[1].Split(":");

			string ipAddr = ipAndPort[0];
			int port = Convert.ToInt32(ipAndPort[1]);

			if (command.Length == 3)
			{
				this.getAlive(ipAddr, port, command, _server);
			}
			else
			{
				if (command.Length == 4)
				{
					this.getCommand(command);
				}
				else
				{
					
				}
			}
		}

		private void getAlive(string _ip, int _port, string[] _command, udpServer.Server.Server _server)
		{
			string[] validIDs = _server.getValidIDs();
			ArrayList connectedDevices = _server.getConnectedDevices();
			string cmd = _command[0];
			string device = _command[1];
			string alive = _command[2];
			bool deviceInConnectedDevices = false;

			if (cmd == "CMD" && alive == "LIFE")
			{
				foreach (string valueInValidIDs in validIDs)
				{
					if (device == valueInValidIDs)
					{
						if (connectedDevices.Count != 0)
						{
							foreach (string valueInConnectedDevices in connectedDevices)
							{
								string[] splitString = valueInConnectedDevices.Split(";");
								if (splitString[0] == device)
								{
									deviceInConnectedDevices = true;
								}
							}
						}
						else
						{
							deviceInConnectedDevices = false;
						}
					}
				}
			}

			if (deviceInConnectedDevices)
			{
				this.oldDevice(_ip, device, connectedDevices, _server);
			}
			else
			{
				this.newDevice(_ip, device, connectedDevices, _server);
			}
		}

		private void newDevice(string _ip, string _device, ArrayList _connectedDevices, udpServer.Server.Server _server)
		{
			Console.WriteLine("New");
			_server.addConnectedDevices($"{_device};{_ip}");
		}

		private void oldDevice(string _ip, string _device, ArrayList _connectedDevices, udpServer.Server.Server _server)
		{
			Console.WriteLine("Old");

			foreach (string i in _connectedDevices)
			{
				string[] ip = i.Split(";");
				if (ip[1] != _ip)
				{
					_server.addConnectedDevices($"{_device};{_ip}");
				}
			}
		}

		private void getCommand(string[] command)
		{
		}
	}
}
