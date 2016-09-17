using Sannel.House.Web.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Sannel.House.Web.Base;

namespace Sannel.House.Generator
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var path = "bin\\Generated";
			Directory.CreateDirectory(path);
			using (var serverSDKMethods = new ServerSDKMethodsGenerator(path))
			{
				var cont = new ControllerGenerator();
				var test = new ControllerTestsGenerator();
				var inter = new InterfaceGenerator();
				var t = typeof(IDataContext);
				var ti = t.GetTypeInfo();
				var props = ti.GetProperties();
				foreach (var prop in props)
				{
					if (String.Compare(prop.PropertyType.Name, "DbSet`1") == 0)
					{
						var first = prop.PropertyType.GenericTypeArguments.FirstOrDefault();
						if (first.Namespace.StartsWith("Sannel"))
						{
							var gen = prop.GetCustomAttribute<GenerationAttribute>();
							if (gen != null && gen.Ignore)
							{
								continue;
							}
							cont.Generate(prop.Name, first, "bin\\Generated");
							test.Generate(prop.Name, first, "bin\\Generated");
							inter.Generate(prop.Name, first, "bin\\Generated");
							serverSDKMethods.AddType(prop.Name, first);
						}
					}
				}
			}
		}
	}
}
