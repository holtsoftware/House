using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Sannel.House.Generator.Data;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Generator
{
	class Program
	{

		static void Main(string[] args)
		{
			Directory.CreateDirectory("Generated");
			Type t = typeof(TypeHelper);
			foreach(var type in t.Assembly.GetTypes())
			{
				if (!type.IsAbstract)
				{
					generateController(type);
				}
			}
		}

		private static void generateController(Type t)
		{
			ControllerGenerator cg = new ControllerGenerator();
			cg.Generate(t, $"Generated\\{t.Name}Controller.cs");
		}
	}
}
