using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ids
{
    [System.SerializableAttribute()]
    [XmlType("restriction", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public partial class Restriction
    {
        [XmlAttribute("base", Namespace ="http://www.w3.org/2001/XMLSchema")]
        public string Base { 
            get; 
            set; 
        }

        
        [System.Xml.Serialization.XmlElementAttribute("enumeration", Order = 1)]
        public System.Collections.ObjectModel.Collection<Enumeration> Enumeration { get; set; } = new();
      
        [System.Xml.Serialization.XmlElementAttribute("pattern", Order = 2)]
        public System.Collections.ObjectModel.Collection<Pattern> Pattern { get; set; } = new();

        [System.Xml.Serialization.XmlElementAttribute("minInclusive", Order = 3)]
        public System.Collections.ObjectModel.Collection<Pattern> MinInclusive { get; set; } = new();

        [System.Xml.Serialization.XmlElementAttribute("maxInclusive", Order = 4)]
        public System.Collections.ObjectModel.Collection<Pattern> MaxInclusive { get; set; } = new();

        [System.Xml.Serialization.XmlElementAttribute("minExclusive", Order = 5)]
        public System.Collections.ObjectModel.Collection<Pattern> MinExclusive { get; set; } = new();

        [System.Xml.Serialization.XmlElementAttribute("maxExclusive", Order = 6)]
        public System.Collections.ObjectModel.Collection<Pattern> MaxExclusive { get; set; } = new();
        
        [System.Xml.Serialization.XmlElementAttribute("length", Order = 7)]
        public System.Collections.ObjectModel.Collection<Length> Length { get; set; } = new();

        [System.Xml.Serialization.XmlElementAttribute("minLength", Order = 8)]
        public System.Collections.ObjectModel.Collection<MinLength> MinLength { get; set; } = new();

        [System.Xml.Serialization.XmlElementAttribute("maxLength", Order = 9)]
        public System.Collections.ObjectModel.Collection<MaxLength> MaxLength { get; set; } = new();

    }

    [System.SerializableAttribute()]
    [XmlType("enumeration", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public partial class Enumeration
    {
        [XmlAttribute("value", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [XmlType("pattern", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public partial class Pattern
    {
        [XmlAttribute("value", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [XmlType("minInclusive", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public partial class MinInclusive
    {
        [XmlAttribute("value", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [XmlType("maxInclusive", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public partial class MaxInclusive
    {
        [XmlAttribute("value", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [XmlType("minExclusive", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public partial class MinExclusive
    {
        [XmlAttribute("value", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [XmlType("maxExclusive", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public partial class MaxExclusive
    {
        [XmlAttribute("value", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [XmlType("length", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public partial class Length
    {
        [XmlAttribute("value", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [XmlType("minLength", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public partial class MinLength
    {
        [XmlAttribute("value", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [XmlType("maxLength", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public partial class MaxLength
    {
        [XmlAttribute("value", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string Value { get; set; }
    }
}
