using Ids;
using SchemaProject.DocAutomation;
using SchemaProject.Helpers;
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
		var d = new DirectoryInfo("C:\\Data\\Dev\\BuildingSmart\\IDS\\Documentation\\testcases");

		using StreamWriter writer = File.CreateText("scripts.txt");
        foreach (var item in d.GetFiles("*.ids", SearchOption.AllDirectories))
		{
			var scr = IdsScript.ScriptFromIds(item);
			if (scr is null) 
				continue;
			scr.WriteTo(writer);
			writer.WriteLine("========================");
			var nName = item.FullName.Replace("C:\\Data\\Dev\\BuildingSmart\\IDS\\Documentation\\testcases", "C:\\Data\\Dev\\BuildingSmart\\testcases");
			var t2 = scr.GetIds();
			IdsHelpers.WriteIds(nName, t2);
		}
	}
}