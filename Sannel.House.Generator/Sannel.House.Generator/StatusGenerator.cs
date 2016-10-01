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
	public class StatusGenerator : GeneratorBase
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
			var cu = SF.CompilationUnit();
			fileName = $"{t.Name}Status";

			var ns = SF.NamespaceDeclaration(SF.ParseName("Sannel.House.ServerSDK"))
				.WithLeadingTrivia(GetLicenseComment());

			var @enum = SF.EnumDeclaration(fileName)
				.WithModifiers(new SyntaxTokenList().Add(SF.Token(SyntaxKind.PublicKeyword)))
				.WithMembers(SF.SeparatedList<EnumMemberDeclarationSyntax>()
					.Add(SF.EnumMemberDeclaration("Unknown"))
					.Add(SF.EnumMemberDeclaration("ServerUriNotSet"))
					.Add(SF.EnumMemberDeclaration("NotLoggedIn"))
					.Add(SF.EnumMemberDeclaration("ServerUriIsNotValid"))
					.Add(SF.EnumMemberDeclaration("UnableToConnectToServer"))
					.Add(SF.EnumMemberDeclaration("Exception"))
					.Add(SF.EnumMemberDeclaration("Error"))
					.Add(SF.EnumMemberDeclaration("Success"))
				);
			ns = ns.AddMembers(@enum);
			cu = cu.AddMembers(ns);
			return cu;
		}
	}
}
