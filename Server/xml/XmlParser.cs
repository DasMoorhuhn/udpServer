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


    private XmlElement createXmlElementWithTextLabel(string _nameOfElement, string _valueOfElement, XmlElement _master)
		{
      XmlElement createEl = doc.CreateElement(string.Empty, _nameOfElement, string.Empty);
      XmlText createText = doc.CreateTextNode(_valueOfElement);
      createEl.AppendChild(createText);
      _master.AppendChild(createEl);
      return _master;
    }

    private XmlElement createXmlElementWithTextLabel(string _nameOfElement, string _valueOfElement)
    {
      XmlElement createEl = doc.CreateElement(string.Empty, _nameOfElement, string.Empty);
      XmlText createText = doc.CreateTextNode(_valueOfElement);
      createEl.AppendChild(createText);
      return createEl;
    }

    private XmlElement createXmlElement(string _nameOfElement)
    {
      XmlElement createEl = doc.CreateElement(string.Empty, _nameOfElement, string.Empty);
      return createEl;
    }

    private XmlElement createXmlElement(string _nameOfElement, XmlElement _master)
    {
      XmlElement createEl = doc.CreateElement(string.Empty, _nameOfElement, string.Empty);
      _master.AppendChild(createEl);
      return _master;
    }


    public void createXmlDoc()
    {
      XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
      XmlElement root = doc.DocumentElement;
      doc.InsertBefore(xmlDeclaration, root);

      List<XmlElement> elementList = new List<XmlElement> { };

      elementList.Add(this.createXmlElement("body"));
      elementList.Add(this.createXmlElement("person"));
      elementList.Add(this.createXmlElementWithTextLabel("Name", "Peter"));
      elementList[1].AppendChild(elementList[2]);
      elementList[0].AppendChild(elementList[1]);
      doc.AppendChild(elementList[0]);

      doc.Save("C:\\Users\\Hendrik\\source\\repos\\udpServer\\Server\\xml\\document.xml");
    }
	}
}
