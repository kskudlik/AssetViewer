﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using System.Xml.XPath;
using AssetViewer.Data;

namespace AssetViewer.Templates {

  public partial class TemplateGuildhouseItem : UserControl {

    #region Properties
    public LinearGradientBrush RarityBrush {
      get {
        switch (this.Asset.XPathSelectElement("Values/Item/Rarity")?.Value) {
          case "Uncommon":
            return new LinearGradientBrush(new GradientStopCollection() {
              new GradientStop(Color.FromRgb(65, 89, 41), 0),
              new GradientStop(Color.FromRgb(42, 44, 39), 0.2),
              new GradientStop(Color.FromRgb(42, 44, 39), 1)
            }, 90);
          case "Rare":
            return new LinearGradientBrush(new GradientStopCollection() {
              new GradientStop(Color.FromRgb(50, 60, 83), 0),
              new GradientStop(Color.FromRgb(42, 44, 39), 0.2),
              new GradientStop(Color.FromRgb(42, 44, 39), 1)
            }, 90);
          case "Epic":
            return new LinearGradientBrush(new GradientStopCollection() {
              new GradientStop(Color.FromRgb(90, 65, 89), 0),
              new GradientStop(Color.FromRgb(42, 44, 39), 0.2),
              new GradientStop(Color.FromRgb(42, 44, 39), 1)
            }, 90);
          case "Legendary":
            return new LinearGradientBrush(new GradientStopCollection() {
              new GradientStop(Color.FromRgb(98, 66, 46), 0),
              new GradientStop(Color.FromRgb(42, 44, 39), 0.2),
              new GradientStop(Color.FromRgb(42, 44, 39), 1)
            }, 90);
          default:
            return null;
        }
      }
    }
    public String Icon {
      get { return $"/AssetViewer;component/Resources/{this.Asset.XPathSelectElement("Values/Standard/IconFilename").Value}"; }
    }
    public XElement Description {
      get { return this.Asset.XPathSelectElement("Values/Description"); }
    }
    public DataRarity Rarity {
      get {
        return new DataRarity(this.Asset);
      }
    }
    public DataAllocation Allocation {
      get { return new DataAllocation(this.Asset); }
    }
    public DataEffectTargets ItemEffect {
      get {
        if (this.Asset.XPathSelectElement("Values/ItemEffect/EffectTargets") == null) return null;
        return new DataEffectTargets(this.Asset);
      }
    }
    public DataProductivityUpgrade ProductivityUpgrade {
      get {
        if (this.Asset.XPathSelectElement("Values/FactoryUpgrade/ProductivityUpgrade") == null) return null;
        return new DataProductivityUpgrade(this.Asset);
      }
    }
    public DataIncidentFireIncreaseUpgrade IncidentFireIncreaseUpgrade {
      get {
        if (this.Asset.XPathSelectElement("Values/IncidentInfectableUpgrade/IncidentFireIncreaseUpgrade") == null) return null;
        return new DataIncidentFireIncreaseUpgrade(this.Asset);
      }
    }
    public DataAttractivenessUpgrade AttractivenessUpgrade {
      get {
        if (this.Asset.XPathSelectElement("Values/CultureUpgrade/AttractivenessUpgrade") == null) return null;
        return new DataAttractivenessUpgrade(this.Asset);
      }
    }
    #endregion

    #region Fields
    private readonly XElement Asset;
    #endregion

    #region Constructor
    public TemplateGuildhouseItem() {
      this.InitializeComponent();
    }
    public TemplateGuildhouseItem(XElement asset) {
      this.InitializeComponent();
      this.Asset = asset;
      this.DataContext = this;
    }
    #endregion

  }

}