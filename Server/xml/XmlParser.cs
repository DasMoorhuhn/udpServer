using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace udpServer.Server.xml
{
	class XmlParser
	{
		XmlDocument doc;
		public XmlParser()
		{
			this.doc = new XmlDocument();
			doc.PreserveWhitespace = true;
		}

		public void createXmlDoc(XmlDocument _doc)
		{
		}
	}
}
