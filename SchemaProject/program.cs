using Ids;
using System.Xml.Serialization;

class Program
{
	static public void Main()
	{
        // this project depends on the execution of one of the repository targets defined in the /Build folder
        // If this project does not compile, start a terminal in the root folder and execute the `./build CompileSchemaProject` command.
		//
        Console.WriteLine("Hello IDS!");
		CreateIds("some.ids");
	}

	static private void CreateIds(string filename)
	{
		// Creates an instance of the XmlSerializer class;
		// specifies the type of object to serialize.
		XmlSerializer serializer = new XmlSerializer(typeof(Ids.Ids));
		TextWriter writer = new StreamWriter(filename);
		var po = InitIds("Some title");
		var spec = CreateTypeSpec("IFCWALL");
		Ids.PropertyType p = new PropertyType();
		p.PropertySet = SimpleValueFromString("Pset_Some");
		p.Name = SimpleValueFromString("Prop");
		AddRequirement(spec, p);
		po.Specifications.Add(spec);
		serializer.Serialize(writer, po);
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