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
	public class ResultGenerator : GeneratorBase
	{
		public override string DirectoryName
		{
			get
			{
				return "ServerSDK";
			}
		}

		protected String filename;
		public override string FileName
		{
			get
			{
				return filename;
			}
		}

		protected String StatusText
		{
			get
			{
				return "Status";
			}
		}

		protected String DataText
		{
			get
			{
				return "Data";
			}
		}

		protected String KeyText
		{
			get
			{
				return "Key";
			}
		}

		protected virtual String GetClassName(Type t)
		{
			return $"{t.Name}Result";
		}

		protected virtual TypeSyntax getDataType(Type t)
		{
			return SF.ParseTypeName($"I{t.Name}");
		}

		protected virtual ConstructorDeclarationSyntax generateConstructor(Type t)
		{
			var pi = t.GetProperties();
			var key = pi.GetKeyProperty();

			var status = SF.Identifier(StatusText.ToLower());
			var item = SF.Identifier(DataText.ToLower());
			var keyName = SF.Identifier(KeyText.ToLower());
			var cStatus = SF.Identifier(StatusText);
			var cItem = SF.Identifier(DataText);
			var cKeyName = SF.Identifier(KeyText);

			var con = SF.ConstructorDeclaration(filename);
			con = con.AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
				.AddParameterListParameters(
					SF.Parameter(status).WithType(SF.ParseTypeName($"{t.Name}Status")),
					SF.Parameter(item).WithType(getDataType(t)),
					SF.Parameter(keyName).WithType(SF.ParseTypeName(key.PropertyType.Name))
				);
			con = con.AddBodyStatements(
				SF.ExpressionStatement(
					SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
						SF.IdentifierName(cStatus),
						SF.IdentifierName(status))
				),
				SF.ExpressionStatement(
					SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
						SF.IdentifierName(cItem),
						SF.IdentifierName(item)
					)
				),
				SF.ExpressionStatement(
					SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
						SF.IdentifierName(cKeyName),
						SF.IdentifierName(keyName)
					)
				)
				);
			return con;
		}

		protected virtual PropertyDeclarationSyntax createStatusProperty(Type t)
		{
			var prop = SF.PropertyDeclaration(SF.ParseTypeName($"{t.Name}Status"), StatusText)
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
				.AddAccessorListAccessors(
					SF.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)),
					SF.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken))
				);

			return prop;
		}

		protected virtual PropertyDeclarationSyntax createDataProperty(Type t)
		{
			var prop = SF.PropertyDeclaration(getDataType(t), DataText)
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
				.AddAccessorListAccessors(
					SF.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)),
					SF.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken))
				);

			return prop;
		}
		protected virtual PropertyDeclarationSyntax createKeyProperty(Type t)
		{
			var pi = t.GetProperties();
			var key = pi.GetKeyProperty();
			var prop = SF.PropertyDeclaration(SF.ParseTypeName(key.PropertyType.Name), KeyText)
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
				.AddAccessorListAccessors(
					SF.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)),
					SF.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken))
				);

			return prop;
		}


		protected override CompilationUnitSyntax internalGenerate(string propertyName, Type t)
		{
			var cu = SF.CompilationUnit();
			filename = GetClassName(t);
			cu = cu.AddUsing("System")
				.WithLeadingTrivia(GetLicenseComment());
			cu = cu.AddUsings("System.Collections.Generic",
				"System.Linq",
				"System.Text",
				"System.Threading.Tasks");
			var ns = SF.NamespaceDeclaration(SF.ParseName("Sannel.House.ServerSDK"));
			var @class = SF.ClassDeclaration(filename)
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword), SF.Token(SyntaxKind.SealedKeyword));
			@class = @class.AddMembers(generateConstructor(t));
			@class = @class.AddMembers(createStatusProperty(t));
			@class = @class.AddMembers(createDataProperty(t));
			@class = @class.AddMembers(createKeyProperty(t));
			ns = ns.AddMembers(@class);
			cu = cu.AddMembers(ns);
			/*using System;
		public TemperatureEntryResult(TemperatureEntryStatus status, ITemperatureEntry entry, Guid id)
		{
			Status = status;
			Entry = entry;
			Id = id;
		}
		public TemperatureEntryStatus Status { get; set; }

		public ITemperatureEntry Entry { get; set; }

		public Guid Id { get; set; }
	}
}
*/
			return cu;
		}
	}
}
