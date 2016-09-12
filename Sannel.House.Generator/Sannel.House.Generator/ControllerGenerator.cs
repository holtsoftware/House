using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using System.Reflection;

namespace Sannel.House.Generator
{
	public class ControllerGenerator
	{
		public ControllerGenerator()
		{

		}

		private ConstructorDeclarationSyntax generateConstructor(SyntaxToken name, Type t)
		{
			var identifier = SF.Identifier("context");
			var parameter = SF.Parameter(identifier).WithType(SF.ParseTypeName("IDataContext"));

			var con = SF.ConstructorDeclaration(name);
			con = con.AddModifiers(SF.Token(SyntaxKind.PublicKeyword));
			con = con.AddParameterListParameters(parameter);
			var statment = SF.ExpressionStatement(SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
				SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SF.ThisExpression(), SF.IdentifierName(identifier.Text)),
				SF.IdentifierName(identifier.ValueText)));
			con = con.AddBodyStatements(statment);

			return con;
		}

		private MethodDeclarationSyntax generateGetMethod(String propertyName, Type t)
		{
			var method = SF.MethodDeclaration(SF.GenericName("IEnumerable").AddTypeArgumentListArguments(SF.ParseTypeName(t.Name)), "Get")
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword));

			var props = t.GetProperties();

			var forward = true;

			var dm = props.FirstOrDefault(i => String.Compare(i.Name, "DisplayOrder", true) == 0);
			if(dm == null)
			{
				dm = props.FirstOrDefault(i => String.Compare(i.Name, "Order", true) == 0);
			}

			if (dm == null)
			{
				dm = props.FirstOrDefault(i => String.Compare(i.Name, "DateCreated") == 0);
				forward = false;
			}

			if (dm == null)
			{
				dm = props.FirstOrDefault(i => String.Compare(i.Name, "CreatedDate") == 0);
				forward = false;
			}

			if(dm == null)
			{
				dm = props.FirstOrDefault(i => String.Compare(i.Name, "CreatedDateTime") == 0);
				forward = false;
			}

			if (dm != null)
			{
				var rStatement = SF.ReturnStatement(
					SF.InvocationExpression(
						SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
							SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
								SF.IdentifierName("context"),
								SF.IdentifierName(propertyName)
							),
							SF.IdentifierName((forward)?"OrderBy":"OrderByDescending")))
						.AddArgumentListArguments(
							SF.Argument(
								SF.SimpleLambdaExpression(
									SF.Parameter(SF.Identifier("i")),
									SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName("i"),
										SF.IdentifierName(dm.Name)
										)
									)
								)
						));
				method = method.AddBodyStatements(rStatement);
			}
			else
			{
				var rStatement = SF.ReturnStatement(SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
					SF.IdentifierName("context"),
					SF.IdentifierName(propertyName)));
				method = method.AddBodyStatements(rStatement);
			}

			return method;
		}

		public void Generate(String propertyName, Type t, String saveFolder)
		{
			var comment = SF.Comment($@"/* Copyright {DateTime.Now.Year} Sannel Software, L.L.C.

   Licensed under the Apache License, Version 2.0 (the ""License"");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an ""AS IS"" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/
");

			var unit = SF.NamespaceDeclaration(SF.ParseName("Sannel.House.Web.Controllers.api")).WithLeadingTrivia(comment);
			unit.GetLeadingTrivia().Add(comment);
			var @class = SF.ClassDeclaration($"{t.Name}Controller").AddModifiers(SF.Token(SyntaxKind.PublicKeyword)).AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("Controller")));

			@class = @class.AddMembers(SyntaxFactory.FieldDeclaration(
				new SyntaxList<AttributeListSyntax>(),
				SF.TokenList(SF.Token(SyntaxKind.PrivateKeyword)),
				SF.VariableDeclaration(
					SF.ParseTypeName("IDataContext"),
					SF.SeparatedList(new[] {
						SF.VariableDeclarator(SF.Identifier("context"))
					}))));
			@class = @class.AddMembers(generateConstructor(@class.Identifier, t));
			@class = @class.AddMembers(generateGetMethod(propertyName, t));

			//@class = @class.AddMembers(generateSeralizeMethod(t));

			var syntax = unit.AddMembers(@class).NormalizeWhitespace("\t", true);

			//var formattedNode = Formatter.Format(syntax, new AdhocWorkspace()
			//{

			//});
			using(StreamWriter writer = new StreamWriter(File.OpenWrite($"{saveFolder}\\{t.Name}Controller.cs")))
			{
				syntax.WriteTo(writer);
				//formattedNode.WriteTo(writer);
			}
		}
	}
}
