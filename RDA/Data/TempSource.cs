﻿using System;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RDA.Data {

  public class TempSource {

    #region Properties
    public String ID { get; set; }
    public String Name { get; set; }
    public Description Text { get; set; }
    public String IconFilename { get; set; }
    #endregion

    #region Constructor
    public TempSource(XElement element) {
      this.ID = element.XPathSelectElement("Values/Standard/GUID").Value;
      this.Name = element.XPathSelectElement("Values/Standard/Name").Value;
      switch (element.Element("Template").Value) {
        case "AssetPool":
          // no text available
          break;
        case "Expedition":
          this.Text = new Description(element.XPathSelectElement("Values/Expedition/ExpeditionName").Value);
          break;
        default:
          throw new NotImplementedException();
      }
      //var textID =
      //this.Text = element.XPathSelectElement("Values/Text/LocaText/English/Text")?.Value;
      //if (String.IsNullOrEmpty(this.Text)) this.Text = element.XPathSelectElement("Values/Expedition/ExpeditionName")?.Value;

      this.IconFilename = element.XPathSelectElement("Values/Standard/IconFilename")?.Value;
    }
    #endregion

    #region Public Methods
    public XElement ToXml() {
      var result = new XElement("Source");
      result.Add(new XAttribute("ID", this.ID));
      result.Add(new XElement("Name", this.Name));
      result.Add(new XElement("Text", this.Text));
      result.Add(new XElement("IconFilename", this.IconFilename));
      return result;
    }
    #endregion

  }

}