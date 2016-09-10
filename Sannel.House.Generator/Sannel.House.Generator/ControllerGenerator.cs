using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using System.IO;

namespace Sannel.House.Generator
{
	public class ControllerGenerator
	{
		public ControllerGenerator()
		{

		}

		private MethodDeclarationSyntax generateSeralizeMethod(Type t)
		{
			var identifier = SF.Identifier("item");
			var parameter = SF.Parameter(identifier).WithType(SF.ParseTypeName(t.Name));
			var pList = new SeparatedSyntaxList<ParameterSyntax>()
				.Add(parameter);

			var body = new List<StatementSyntax>();
			var objIdentifer = SF.Identifier("obj");

			var vd = SF.VariableDeclaration(SF.ParseTypeName("JObject"), SF.SeparatedList(new[] {
					SF.VariableDeclarator(
						objIdentifer, 
						null, 
						SF.EqualsValueClause(
							SF.ObjectCreationExpression(
								SF.Token(SyntaxKind.NewKeyword),
								SF.ParseTypeName("JObject"),
								SF.ArgumentList(),
								null)
							))
				}));
			body.Add(SF.LocalDeclarationStatement(vd));
			var props = t.GetProperties(System.Reflection.BindingFlags.Public);
			foreach(var p in props)
			{
				SF.InvocationExpression(
					SF.MemberAccessExpression(SyntaxKind.StringLiteralExpression, SF.IdentifierName(objIdentifer.ValueText), SF.IdentifierName("Add"))//,
						//SF.SeparatedList(
							//SF.ObjectCreationExpression(
							//	SF.Token(SyntaxKind.NewKeyword),
							//	SF.ParseTypeName("JParameter"),
							//	SF.ArgumentList(),
							//	null
							//	)
						//)
					);
			}

			body.Add(SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)));

			var d = SF.MethodDeclaration(
				SF.List<AttributeListSyntax>(), 
				SF.TokenList(SF.Token(SyntaxKind.PrivateKeyword)),
				SF.ParseTypeName("JObject"),
				null,
				SF.Identifier("serializeObject"),
				null,
				SF.ParameterList(pList),
				SF.List<TypeParameterConstraintClauseSyntax>(),
				SF.Block(body),
				null);
			return d;
		}

		public void Generate(Type t, String outputFile)
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

			@class = @class.AddMembers(generateSeralizeMethod(t));

			var syntax = unit.AddMembers(@class);

			var formattedNode = Formatter.Format(syntax, new AdhocWorkspace()
			{

			});
			using(StreamWriter writer = new StreamWriter(outputFile))
			{
				formattedNode.WriteTo(writer);
			}
		}
	}
}
