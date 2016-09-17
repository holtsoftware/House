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
	public class InterfaceGenerator : GeneratorBase
	{
		public override string DirectoryName
		{
			get
			{
				return "ServerSDK";
			}
		}

		private String fileName;

		public override string FileName
		{
			get
			{
				return fileName;
			}
		}

		protected override CompilationUnitSyntax internalGenerate(string propertyName, Type t)
		{
			fileName = $"I{t.Name}";
			var unit = SF.CompilationUnit();

			unit = unit.AddUsing("System").WithLeadingTrivia(getLicenseComment());
			unit = unit.AddUsings(
				"Newtonsoft.Json",
				"System");

			var @interface = SF.InterfaceDeclaration(fileName)
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword));

			var props = t.GetProperties();
			foreach(var prop in props)
			{
				if (!prop.ShouldIgnore())
				{
					@interface = @interface.AddMembers(
						SF.PropertyDeclaration(prop.GetTypeSyntax(), prop.Name)
						.WithAccessorList(
							SF.AccessorList()
							.AddAccessors(SF.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)))
							.AddAccessors(SF.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)))
						)
					);
				}
			}

			return unit.AddMembers(SF.NamespaceDeclaration(SF.IdentifierName("Sannel.House.ServerSDK")).AddMembers(@interface));
		}
	}
}
