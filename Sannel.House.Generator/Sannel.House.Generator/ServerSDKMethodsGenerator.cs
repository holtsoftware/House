using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using System.Reflection;

namespace Sannel.House.Generator
{
	public class ServerSDKMethodsGenerator : IDisposable
	{
		private StreamWriter writer;
		public ServerSDKMethodsGenerator(String baseDirectory)
		{
			var path = Path.Combine(baseDirectory, "ServerSDK");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			var serverContext = Path.Combine(path, "ServerContext.cs");

			if (File.Exists(serverContext))
			{
				File.Delete(serverContext);
			}

			writer = new StreamWriter(File.OpenWrite(serverContext));
		}



		public void AddType(String propertyName, Type t)
		{
			var cu = SF.CompilationUnit();

		}

		public void Dispose()
		{
			writer.Dispose();
		}
	}
}
