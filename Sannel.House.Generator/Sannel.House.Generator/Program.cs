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

			var generatorList = new List<GeneratorBase>();
			using (var serverSDKMethods = new ServerSDKMethodsGenerator(path))
			{
				using (var serverSDKTestMethods = new ServerSDKTestMethodsGenerator(path))
				{
					generatorList.Add(new ControllerGenerator());
					generatorList.Add(new ControllerTestsGenerator());
					generatorList.Add(new InterfaceGenerator());
					generatorList.Add(new ResultGenerator());
					generatorList.Add(new ResultsGenerator());
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
								foreach (var generator in generatorList)
								{
									generator.Generate(prop.Name, first, path);
								}
								serverSDKMethods.AddType(prop.Name, first);
								serverSDKTestMethods.AddType(prop.Name, first);
							}
						}
					}
				}
			}
		}
	}
}
