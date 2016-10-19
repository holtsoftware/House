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


		public MemberDeclarationSyntax createGetMethod(Type t, PropertyInfo[] pi)
		{
			var method = SF.MethodDeclaration(SF.ParseTypeName("Task"), $"Get{t.Name}AsyncTest")
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword), SF.Token(SyntaxKind.AsyncKeyword));

			foreach(var p in pi)
			{
				if (!p.ShouldIgnore())
				{
					var ts = p.GetTypeSyntax();
					method = method.AddBodyStatements(
						SF.LocalDeclarationStatement(
						Extensions.VariableDeclaration($"_{p.Name}",
							SF.EqualsValueClause(Extensions.GetDefaultValue(ts)),
							ts.ToString()
						)));
				}
			}


			var stub = SF.Identifier("stub");

			method = method.AddBodyStatements(
				SF.LocalDeclarationStatement(
					Extensions.VariableDeclaration(stub.Text,
						SF.EqualsValueClause(
							SF.ObjectCreationExpression(SF.ParseTypeName($"StubI{t.Name}"))
							.AddArgumentListArguments()
						)
					)).WithLeadingTrivia(SF.Comment("// Setup Stub"))
				);

			foreach(var p in pi)
			{
				if (!p.ShouldIgnore())
				{
					method = method.AddBodyStatements(
						SF.ExpressionStatement(
						SF.InvocationExpression(
							SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
								SF.IdentifierName(stub),
								SF.IdentifierName($"{p.Name}_Get")))
							.AddArgumentListArguments(
								SF.Argument(SF.ParenthesizedLambdaExpression(SF.IdentifierName($"_{p.Name}"	)))
							)
						),
						SF.ExpressionStatement(
							SF.InvocationExpression(
								SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
									SF.IdentifierName(stub),
									SF.IdentifierName($"{p.Name}_Set"))
							).AddArgumentListArguments(
								SF.Argument(
									SF.ParenthesizedLambdaExpression(
										SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
											SF.IdentifierName($"_{p.Name}"),
											SF.IdentifierName("v"))
									)
									.AddParameterListParameters(
										SF.Parameter(SF.Identifier("v"))
									)
								)
							)
						)
					);
				}
			}

			var create = SF.Identifier("create");

			method = method.AddBodyStatements(
				SF.LocalDeclarationStatement(
					Extensions.VariableDeclaration(create.Text,
						SF.EqualsValueClause(
							SF.ObjectCreationExpression(SF.ParseTypeName("StubICreateHelper"))
							.AddArgumentListArguments()
						)
					)
				).WithLeadingTrivia(SF.Comment("// create helper")),
				SF.ExpressionStatement(
					SF.InvocationExpression(
						SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
							SF.IdentifierName(create),
							SF.IdentifierName($"Create{t.Name}"))
					)
					.AddArgumentListArguments(
						SF.Argument(
							SF.ParenthesizedLambdaExpression(
								SF.IdentifierName(stub)
							)
						)
					)
				)
			);

			var settings = SF.Identifier("settings");

			method = method.AddBodyStatements(
				SF.LocalDeclarationStatement(
					Extensions.VariableDeclaration(settings.Text,
						SF.EqualsValueClause(
							SF.ObjectCreationExpression(SF.ParseTypeName("StubIServerSettings"))
							.AddArgumentListArguments()
						)
					)
				).WithLeadingTrivia(SF.Comment("// settings ")),
				SF.ExpressionStatement(
					SF.InvocationExpression(
						SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
							SF.IdentifierName(settings),
							SF.IdentifierName("ServerUri_Get"))
					)
					.AddArgumentListArguments(
						SF.Argument(
							SF.ParenthesizedLambdaExpression(
								SF.LiteralExpression(SyntaxKind.NullLiteralExpression)
							)
						)
					)
				)
			);

			var httpClient = SF.Identifier("httpClient");

			method = method.AddBodyStatements(
				SF.LocalDeclarationStatement(
					Extensions.VariableDeclaration(httpClient.Text,
						SF.EqualsValueClause(
							SF.ObjectCreationExpression(SF.ParseTypeName("StubIHttpClient"))
							.AddArgumentListArguments()
						)
					)
				).WithLeadingTrivia(SF.Comment("// Http Client"))
			);

			var serverContext = SF.Identifier("serverContext");
			method = method.AddBodyStatements(
				SF.LocalDeclarationStatement(
					Extensions.VariableDeclaration(serverContext.Text,
						SF.EqualsValueClause(
							SF.ObjectCreationExpression(SF.ParseTypeName("ServerContext"))
							.AddArgumentListArguments(
								SF.Argument(SF.IdentifierName(settings)),
								SF.Argument(SF.IdentifierName(create)),
								SF.Argument(SF.IdentifierName(httpClient))
							)
						)
					)
				).WithLeadingTrivia(SF.Comment("// Server "))
			);


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
