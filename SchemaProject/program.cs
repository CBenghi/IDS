using Ids;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

class Program
{
	static public void Main()
	{
		// this project depends on the execution of one of the repository targets defined in the /Build folder
		// If this project does not compile, start a terminal in the root folder and execute the `./build CompileSchemaProject` command.
		//
		Console.WriteLine("Hello IDS!");
		// CreateIds("some.ids");
		DirectoryInfo d = new DirectoryInfo("C:\\Data\\Dev\\BuildingSmart\\IDS\\Documentation\\testcases");

		foreach (var item in d.GetFiles("*.ids", SearchOption.AllDirectories))
		{
			var t = LoadOld(item);
			if (t == null)
				continue;
			var t2 = DoConvert(t);
			var nName = item.FullName.Replace("C:\\Data\\Dev\\BuildingSmart\\IDS\\Documentation\\testcases", "C:\\Data\\Dev\\BuildingSmart\\testcases");
			// try to fix the title
			if (t2.Info.Title == "Title")
			{
				t2.Info.Title = GetTitle(item);
			}

			WriteIds(nName, t2);
		}
	}

    private static string GetTitle(FileInfo item)
    {
		var t = item.Name.Replace(".ids", "");
		if (t.StartsWith("pass-"))
			t = t.Substring(5);
        else if (t.StartsWith("fail-"))
            t = t.Substring(5);
		var r = new Regex("(?<start>.*)(?<id>\\d)_(?<of>\\d)$");
		var m = r.Match(t);
		if (m.Success)
			t = $"{m.Groups["start"]}({m.Groups["id"]}/{m.Groups["of"]})";
		t = t.Replace("_", " ");
		t = FirstLetterToUpper(t);
        Debug.WriteLine(t);
		return t;
    }

    public static string FirstLetterToUpper(string str)
    {
        if (str == null)
            return null;

        if (str.Length > 1)
            return char.ToUpper(str[0]) + str.Substring(1);

        return str.ToUpper();
    }

    private static Ids.Ids DoConvert(OldIds.Ids t)
    {
        var po = InitIds(t.Info.Title);
		foreach (var spec in t.Specifications.Specification)
		{
			var nspec = DoConvert(spec);
			po.Specifications.Add(nspec);
        }
		return po;
    }

    private static SpecificationType DoConvert(OldIds.SpecificationType spec)
    {
        var ret = new SpecificationType();
		ret.Name = spec.Name;
		foreach (var item in spec.IfcVersion)
		{
			ret.IfcVersion.Add(item);
		}
		ret.Applicability = DoConvert(spec.Applicability, spec);
		ret.Requirements = DoConvert(spec.Requirements);
		return ret;
    }

    private static SpecificationTypeRequirements? DoConvert(OldIds.SpecificationTypeRequirements? requirements)
    {
        if (requirements == null) 
			return null;
		var ret = new SpecificationTypeRequirements();
		foreach (var item in DoConvert(requirements.Entity))
		{
			ret.Entity.Add(item);	
		}
        foreach (var item in DoConvert(requirements.Attribute))
        {
            ret.Attribute.Add(item);
        }
        foreach (var item in DoConvert(requirements.Classification))
        {
            ret.Classification.Add(item);
        }
        foreach (var item in DoConvert(requirements.Material))
        {
            ret.Material.Add(item);
        }
        foreach (var item in DoConvert(requirements.PartOf))
        {
            ret.PartOf.Add(item);
        }
        foreach (var item in DoConvert(requirements.Property))
        {
            ret.Property.Add(item);
        }
        return ret;
    }

    private static IEnumerable<RequirementsTypeProperty> DoConvert(Collection<OldIds.RequirementsTypeProperty> property)
    {
        foreach (var item in property)
        {
            var t = DoConvert(item);
            if (t is not null)
                yield return t;
        }
    }

  

    private static IEnumerable<RequirementsTypePartOf> DoConvert(Collection<OldIds.RequirementsTypePartOf> partOf)
    {
        foreach (var item in partOf)
        {
            var t = DoConvert(item);
            if (t is not null)
                yield return t;
        }
    }

   

    private static IEnumerable<RequirementsTypeMaterial> DoConvert(Collection<OldIds.RequirementsTypeMaterial> material)
    {
        foreach (var item in material)
        {
            var t = DoConvert(item);
            if (t is not null)
                yield return t;
        }
    }
   

    private static IEnumerable<RequirementsTypeClassification> DoConvert(Collection<OldIds.RequirementsTypeClassification> classification)
    {
        foreach (var item in classification)
        {
            var t = DoConvert(item);
            if (t is not null)
                yield return t;
        }
    }

    private static RequirementsTypeProperty DoConvert(OldIds.RequirementsTypeProperty item)
    {
        RequirementsTypeProperty ret = new RequirementsTypeProperty();
        ret.Value = DoConvert(item.Value);
        ret.Name = DoConvert(item.Name);
        ret.PropertySet = DoConvert(item.PropertySet);
        if (!string.IsNullOrEmpty(item.Measure))
            ret.DataType = item.Measure.ToUpperInvariant();
        if (!string.IsNullOrEmpty(item.DataType))
            ret.DataType = item.DataType.ToUpperInvariant();
        ret.Cardinality = DoConvert(item.MinOccurs, item.MaxOccurs);
        return ret;
    }

    private static RequirementsTypeMaterial DoConvert(OldIds.RequirementsTypeMaterial item)
    {
        RequirementsTypeMaterial ret = new();
        ret.Value = DoConvert(item.Value);
        ret.Cardinality = DoConvert(item.MinOccurs, item.MaxOccurs);
        return ret;
    }

    private static RequirementsTypePartOf DoConvert(OldIds.RequirementsTypePartOf item)
    {
        RequirementsTypePartOf ret = new();
        ret.Entity = DoConvert(item.Entity);
        if (ret.Entity is null)
        {
            var r = new Restriction();
            r.Pattern.Add(new Pattern() { Value = ".*" });
            EntityType t = new EntityType();
            t.Name = new IdsValue() { Restriction = r };
            ret.Entity = t;
        }

        ret.Relation = DoConvert(item.Relation);
        ret.Cardinality = DoConvertSimple(item.MinOccurs, item.MaxOccurs);
        return ret;
    }

    private static Relations? DoConvert(OldIds.Relations relation)
    {
        switch (relation)
        {
            case OldIds.Relations.IfcRelNests:
                return Relations.Ifcrelnests;
            case OldIds.Relations.IfcRelAggregates:
                return Relations.Ifcrelaggregates;
            case OldIds.Relations.IfcRelAssignsToGroup:
                return Relations.Ifcrelassignstogroup;
            case OldIds.Relations.IfcRelContainedInSpatialStructure:
                return Relations.Ifcrelcontainedinspatialstructure;
        }
        return null;
    }

    private static RequirementsTypeClassification DoConvert(OldIds.RequirementsTypeClassification item)
    {
		RequirementsTypeClassification ret = new();
		ret.System = DoConvert(item.System);
		ret.Value = DoConvert(item.Value);
		if (ret.System is null)
		{
			var r = new Restriction();
			r.Pattern.Add(new Pattern() { Value = ".*" });
			ret.System = new IdsValue() { Restriction = r };
		}
		
        ret.Cardinality = DoConvert(item.MinOccurs, item.MaxOccurs);
        return ret;
    }

    private static IEnumerable<RequirementsTypeAttribute> DoConvert(Collection<OldIds.RequirementsTypeAttribute> attribute)
    {
        foreach (var item in attribute)
        {
            var t = DoConvert(item);
            if (t is not null)
                yield return t;
        }
    }

    private static RequirementsTypeAttribute DoConvert(OldIds.RequirementsTypeAttribute item)
    {
        var ret = new RequirementsTypeAttribute();
		ret.Name = DoConvert(item.Name);
		ret.Value = DoConvert(item.Value);
		ret.Cardinality = DoConvert(item.MinOccurs, item.MaxOccurs);
		return ret;
    }

    private static ConditionalCardinality DoConvert(string minOccurs, string maxOccurs)
    {
		if (maxOccurs == "0")
			return ConditionalCardinality.Prohibited;
		if (minOccurs == "0")
			return ConditionalCardinality.Optional;
		return ConditionalCardinality.Required;
    }


    private static SimpleCardinality DoConvertSimple(string minOccurs, string maxOccurs)
    {
        if (maxOccurs == "0")
            return SimpleCardinality.Prohibited;
        return SimpleCardinality.Required;
    }

    private static IEnumerable<RequirementsTypeEntity?> DoConvert(Collection<OldIds.RequirementsTypeEntity> entity)
    {
		foreach (var ent in entity)
		{
			var t = DoConvert(ent);
			if (t is not null)
				yield return t;
		}
    }
    private static RequirementsTypeEntity DoConvert(OldIds.RequirementsTypeEntity entity)
	{
        var ret = new RequirementsTypeEntity();
		ret.Name = DoConvert(entity.Name);
		ret.SubType = DoConvert(entity.PredefinedType);
        return ret;
	}

    private static ApplicabilityType DoConvert(OldIds.ApplicabilityType applicability, OldIds.SpecificationType spec)
    {
        var ret = new ApplicabilityType();
		ret.MinOccurs = spec.MinOccurs;
		ret.MaxOccurs = spec.MaxOccurs;
		if (ret.MinOccurs == "1" && ret.MaxOccurs == "1")
			ret.MaxOccurs = "unbounded";
		ret.Entity = DoConvert(applicability.Entity);
		// todo: other types
		return ret;
    }

    private static EntityType? DoConvert(OldIds.EntityType? entity)
    {
        if (entity == null)	
			return null;
		var ret = new EntityType();
		ret.Name = DoConvert(entity.Name);
		ret.SubType = DoConvert(entity.PredefinedType);
		return ret;
    }

    private static IdsValue? DoConvert(OldIds.IdsValue? name)
    {
		if (name == null)
			return null;
		var ret = new IdsValue();
		if (!string.IsNullOrEmpty(name.SimpleValue))
		{
			ret.SimpleValue = name.SimpleValue;
		}
		ret.Restriction = name.Restriction.FirstOrDefault();
		
        return ret;
    }

    static private OldIds.Ids? LoadOld(FileInfo file)
	{
        var serializer = new XmlSerializer(typeof(OldIds.Ids));

        using (Stream reader = new FileStream(file.FullName, FileMode.Open))
        {
            // Call the Deserialize method to restore the object's state.
			var t  = serializer.Deserialize(reader) as OldIds.Ids;
			return t;
        }
    }

	static private void CreateIds(string filename)
    {
        var po = InitIds("Some title");
        var spec = CreateTypeSpec("IFCWALL");
        Ids.PropertyType p = new PropertyType();
        p.PropertySet = SimpleValueFromString("Pset_Some");
        p.Name = SimpleValueFromString("Prop");
        AddRequirement(spec, p);
        po.Specifications.Add(spec);
        WriteIds(filename, po);
    }

    private static void WriteIds(string filename, Ids.Ids po)
    {
        // Creates an instance of the XmlSerializer class;
        // specifies the type of object to serialize.
        XmlSerializer serializer = new XmlSerializer(typeof(Ids.Ids));
		
        TextWriter writer = new StreamWriter(filename);
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        // ns.Add("ids", "http://standards.buildingsmart.org/IDS");
        ns.Add("xs", "http://www.w3.org/2001/XMLSchema");
        ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
        serializer.Serialize(writer, po, ns);
        writer.Close();
    }

    private static void AddRequirement(SpecificationType spec, PropertyType p)
	{
		RequirementsTypeProperty rqp = new RequirementsTypeProperty();
		rqp.PropertySet = p.PropertySet;
		rqp.Name = p.Name;
		rqp.Cardinality = ConditionalCardinality.Required;
		spec.Requirements = new SpecificationTypeRequirements();
		spec.Requirements.Property.Add(rqp);
	}

	private static Ids.SpecificationType CreateTypeSpec(string typeName, params string[] schemas)
	{
		var spec = new Ids.SpecificationType();
		if (schemas.Any()) 
		{
			foreach (var sch in schemas)
			{
				spec.IfcVersion.Add(sch);
			}
		}
		else
		{
			spec.IfcVersion.Add("IFC4");
		}
		spec.Applicability = ApplicabilityType.CreateApplicabilityType(ApplicabilityType.ApplicabilityCardinality.Required);
		spec.Applicability.Entity = new Ids.EntityType() { Name = SimpleValueFromString(typeName) };
		return spec;
	}

	private static IdsValue SimpleValueFromString(string value)
	{
		IdsValue ret = new IdsValue();
		ret.SimpleValue = value;
		return ret;
	}

	private static Ids.Ids InitIds(string title)
	{
		var ret = new Ids.Ids();
		ret.Info = new Ids.IdsInfo();
		ret.Info.Title = title;
		ret.Info.Description = "Generated via code automation in the Ids Repository on github.";
		return ret;
	}
}