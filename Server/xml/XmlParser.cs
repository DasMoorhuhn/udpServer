using System;
using System.Collections;
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
		}


    private XmlElement createXmlElementWithTextLabel(string _nameOfElement, string _valueOfElement, XmlDocument _doc)
		{
      XmlElement createEl = _doc.CreateElement(string.Empty, _nameOfElement, string.Empty);
      XmlText createText = _doc.CreateTextNode(_valueOfElement);
      createEl.AppendChild(createText);
      return createEl;
    }

    private XmlElement createXmlElement(string _nameOfElement, XmlDocument _doc)
    {
      XmlElement createEl = _doc.CreateElement(string.Empty, _nameOfElement, string.Empty);
      return createEl;
    }

    public void createXmlDoc()
		{
      //(1) the xml declaration is recommended, but not mandatory
      XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
      XmlElement root = doc.DocumentElement;
      doc.InsertBefore(xmlDeclaration, root);
      XmlElement[] elements = { }; 

      elements.Append(this.createXmlElement("body", doc));
      elements.Append(this.createXmlElementWithTextLabel("Hallo", "Eyyyy", doc));

      

      doc.Save("C:\\Users\\Hendrik\\source\\repos\\udpServer\\Server\\xml\\document.xml");
    }
	}
}
