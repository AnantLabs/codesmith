using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace LinqToEdmx.Model.Storage
{
  /// <summary>
  /// <para>
  /// Regular expression: ((Documentation?, any)?)
  /// </para>
  /// </summary>
  public class PropertyRef : XTypedElement, IXMetaData
  {
    private static readonly Dictionary<XName, Type> LocalElementDictionary = new Dictionary<XName, Type>();

    private static FSM _validationStates;

    static PropertyRef()
    {
      BuildElementDictionary();
      InitFsm();
    }

    /// <summary>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((Documentation?, any)?)
    /// </para>
    /// </summary>
    public Documentation Documentation
    {
      get
      {
        var x = GetElement(XName.Get("Documentation", XMLNamespaceFactory.SSDL));
        return ((Documentation) (x));
      }
      set
      {
        SetElement(XName.Get("Documentation", XMLNamespaceFactory.SSDL), value);
      }
    }

    /// <summary>
    /// <para>
    /// Regular expression: ((Documentation?, any)?)
    /// </para>
    /// </summary>
    public IEnumerable<XElement> Any
    {
      get
      {
        return GetWildCards(WildCard.DefaultWildCard);
      }
    }

    /// <summary>
    /// <para>
    /// Occurrence: required
    /// </para>
    /// </summary>
    public string Name
    {
      get
      {
        var x = Attribute(XName.Get("Name", ""));
        return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
      }
      set
      {
        SetAttribute(XName.Get("Name", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
      }
    }

    #region IXMetaData Members

    Dictionary<XName, Type> IXMetaData.LocalElementsDictionary
    {
      get
      {
        return LocalElementDictionary;
      }
    }

    XName IXMetaData.SchemaName
    {
      get
      {
        return XName.Get("TPropertyRef", XMLNamespaceFactory.SSDL);
      }
    }

    SchemaOrigin IXMetaData.TypeOrigin
    {
      get
      {
        return SchemaOrigin.Fragment;
      }
    }

    ILinqToXsdTypeManager IXMetaData.TypeManager
    {
      get
      {
        return LinqToXsdTypeManager.Instance;
      }
    }

    FSM IXMetaData.GetValidationStates()
    {
      return _validationStates;
    }

    #endregion

    public static explicit operator PropertyRef(XElement xe)
    {
      return XTypedServices.ToXTypedElement<PropertyRef>(xe, LinqToXsdTypeManager.Instance);
    }

    public override XTypedElement Clone()
    {
      return XTypedServices.CloneXTypedElement(this);
    }

    private static void BuildElementDictionary()
    {
      LocalElementDictionary.Add(XName.Get("Documentation", XMLNamespaceFactory.SSDL), typeof (Documentation));
    }

    private static void InitFsm()
    {
      var transitions = new Dictionary<int, Transitions>();
      transitions.Add(1, new Transitions(new SingleTransition(XName.Get("Documentation", XMLNamespaceFactory.SSDL), 2), new SingleTransition(new WildCard("##other", XMLNamespaceFactory.SSDL), 3)));
      transitions.Add(2, new Transitions(new SingleTransition(new WildCard("##other", XMLNamespaceFactory.SSDL), 2)));
      transitions.Add(3, new Transitions(new SingleTransition(new WildCard("##other", XMLNamespaceFactory.SSDL), 3)));
      _validationStates = new FSM(1, new Set<int>(new[]
                                                   {
                                                     2, 1, 3
                                                   }), transitions);
    }
  }
}