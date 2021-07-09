using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace udpServer.Server.xml
{
	class XmlParser
	{
		XmlDocument doc;
    private string xmlPath;
		public XmlParser()
		{
      this.doc = new XmlDocument();
      xmlPath = "C:\\Users\\Hendrik\\source\\repos\\udpServer\\Server\\xml\\document.xml";

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

    private XmlElement createStucture(string _rootName, string _middleName, string[] _value)
		{
      List<XmlElement> bodyList = new List<XmlElement> { };
      List<XmlElement> elementList = new List<XmlElement> { };
      bodyList.Add(this.createXmlElement(_rootName));
      bodyList.Add(this.createXmlElement(_middleName));

      foreach (string i in _value)
			{
        elementList.Add(this.createXmlElementWithTextLabel($"ID", i));
      }

      for (int i = 0; i <= (_value.Length -1); i++)
			{
        bodyList[1].AppendChild(elementList[i]);
			}

      bodyList[0].AppendChild(bodyList[1]);
      return bodyList[0];
    }

    private int countElements()
    {
      XDocument _doc = XDocument.Load(xmlPath);
      var count = _doc.Descendants("body").Descendants("devices").Descendants("ID").Count();
      return count;
    }













    public void createXmlDoc(string[] _value)
    {
      doc.AppendChild(this.createStucture("body", "devices", _value));

      doc.Save(xmlPath);
    }

    public string[] getElements()
		{
      XDocument doc = XDocument.Load(xmlPath);
      List<string> list = doc.Descendants("body").Descendants("devices").Descendants("ID").Select(node => node.Value).ToList();
      string[] newList = { };
      foreach (string i in list)
      {
        newList.Append(i);
			}
      return newList;
    }
	}
}
