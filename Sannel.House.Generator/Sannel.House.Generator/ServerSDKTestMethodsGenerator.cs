/* Copyright 2016 Sannel Software, L.L.C.

   Licensed under the Apache License, Version 2.0 (the ""License"");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an ""AS IS"" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Sannel.House.Generator
{
	public class ServerSDKTestMethodsGenerator : IDisposable
	{
		private StreamWriter writer;

		public ServerSDKTestMethodsGenerator(String baseDirectory)
		{
			var path = Path.Combine(baseDirectory, "ServerSDKTests");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			var serverContext = Path.Combine(path, "ServerContextTests.cs");

			if (File.Exists(serverContext))
			{
				File.Delete(serverContext);
			}

			writer = new StreamWriter(File.OpenWrite(serverContext));
		}

		private ExpressionSyntax getDefaultValue(TypeSyntax t)
		{
			String type = t.ToString();
			if(t is NullableTypeSyntax)
			{
				var nt = (NullableTypeSyntax)t;
				type = nt.ElementType.ToString();
			}
			switch (type)
			{
				case "Guid":
					return SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
					SF.IdentifierName("Guid"),
					SF.IdentifierName("Empty"));

				case "Int32":
				case "Int16":
				case "Int64":
					return SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(0));

				case "Float":
				case "Double":
				case "Decimal":
					return SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(0));

				case "DayOfWeek":
					return SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.IdentifierName("DayOfWeek"),
						SF.IdentifierName("Monday"));

				case "String":
					return SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.IdentifierName("String"),
						SF.IdentifierName("Empty"));

				case "Boolean":
					return SF.LiteralExpression(SyntaxKind.FalseLiteralExpression);
			}


			return SF.LiteralExpression(SyntaxKind.NullLiteralExpression);
		}

		public MemberDeclarationSyntax createGetMethod(Type t, PropertyInfo[] pi)
		{
			var method = SF.MethodDeclaration(SF.ParseTypeName("Task"), $"Get{t.Name}AsyncTest")
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword), SF.Token(SyntaxKind.AsyncKeyword));

			foreach(var p in pi)
			{
				if (!p.ShouldIgnore())
				{
					var ts = Extensions.GetTypeSyntax(p);
					method = method.AddBodyStatements(
						SF.LocalDeclarationStatement(
						Extensions.VariableDeclaration($"_{p.Name}",
							SF.EqualsValueClause(getDefaultValue(ts)),
							ts.ToString()
						)));
				}
			}

			return method;
		}

		public void AddType(String propertyName, Type t)
		{
			var cu = SF.CompilationUnit();
			var tn = SF.ParseTypeName(t.Name);
			var pi = t.GetProperties();

			cu = cu.AddMembers(createGetMethod(t, pi))
				.WithLeadingTrivia(SF.Trivia(SF.RegionDirectiveTrivia(true)
					.WithEndOfDirectiveToken(
						SF.Token(SF.TriviaList().Add(SF.PreprocessingMessage(t.Name)),
							SyntaxKind.EndOfDirectiveToken,
							SF.TriviaList())
					)
				));

			cu = cu.WithTrailingTrivia(
				SF.Trivia(
					SF.EndRegionDirectiveTrivia(true)
				)
				);

			cu.NormalizeWhitespace("\t", true).WriteTo(writer);
			writer.WriteLine();
			writer.WriteLine();

		}

		public void Dispose()
		{
			writer.Dispose();
		}
	}
}
