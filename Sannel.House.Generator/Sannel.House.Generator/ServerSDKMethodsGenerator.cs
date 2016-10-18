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
		private SyntaxToken keyName = SF.Identifier("key");
		private SyntaxToken helperName = SF.Identifier("helper");
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

		private StatementSyntax[] createCommonResultIfStatments(Type t, PropertyInfo[] pi)
		{
			var key = pi.GetKeyProperty();
			var list = new List<StatementSyntax>();
			list.Add(SF.IfStatement(
					SF.BinaryExpression(SyntaxKind.EqualsExpression,
						SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
							SF.IdentifierName("settings"),
							SF.IdentifierName("ServerUri")
						),
						SF.LiteralExpression(SyntaxKind.NullLiteralExpression)
					),
					SF.Block(
						SF.ReturnStatement().WithExpression(
							SF.ObjectCreationExpression(SF.ParseTypeName($"{t.Name}Result"))
							.WithArgumentList(
								SF.ArgumentList()
								.AddArguments(
									SF.Argument(SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName($"{t.Name}Status"),
										SF.IdentifierName("ServerUriNotSet"))
									),
									SF.Argument(SF.LiteralExpression(SyntaxKind.NullLiteralExpression)),
									SF.Argument(SF.DefaultExpression(SF.ParseTypeName(key.PropertyType.Name)))
								)
							)
					))
				));

			list.Add(SF.IfStatement(
					SF.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression,
						SF.IdentifierName("IsAuthenticated")),
					SF.Block(
						SF.ReturnStatement().WithExpression(
							SF.ObjectCreationExpression(SF.ParseTypeName($"{t.Name}Result"))
							.WithArgumentList(
								SF.ArgumentList()
								.AddArguments(
									SF.Argument(SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName($"{t.Name}Status"),
										SF.IdentifierName("NotLoggedIn"))
									),
									SF.Argument(SF.LiteralExpression(SyntaxKind.NullLiteralExpression)),
									SF.Argument(SF.DefaultExpression(SF.ParseTypeName(key.PropertyType.Name)))
								)
							)
					))
				));

			var builder = SF.Identifier("builder");

			list.Add(SF.LocalDeclarationStatement(SF.VariableDeclaration(SF.ParseTypeName("UriBuilder")).AddVariables(SF.VariableDeclarator(builder))));

			list.Add(SF.TryStatement()
				.AddBlockStatements(
					SF.ExpressionStatement(
						SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
							SF.IdentifierName(builder),
							SF.ObjectCreationExpression(SF.ParseTypeName("UriBuilder"))
								.AddArgumentListArguments(
									SF.Argument(
										SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
											SF.IdentifierName("settings"),
											SF.IdentifierName("ServerUri")
										)
									)
								)
						)
					)
				)
				.AddCatches(
					SF.CatchClause()
						.WithDeclaration(SF.CatchDeclaration(SF.ParseTypeName("UriFormatException")))
						.WithBlock(SF.Block(
						SF.ReturnStatement().WithExpression(
							SF.ObjectCreationExpression(SF.ParseTypeName($"{t.Name}Result"))
							.WithArgumentList(
								SF.ArgumentList()
								.AddArguments(
									SF.Argument(SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName($"{t.Name}Status"),
										SF.IdentifierName("ServerUriIsNotValid"))
									),
									SF.Argument(SF.LiteralExpression(SyntaxKind.NullLiteralExpression)),
									SF.Argument(SF.DefaultExpression(SF.ParseTypeName(key.PropertyType.Name)))
								)
							)
						))
					),
					SF.CatchClause()
						.WithDeclaration(SF.CatchDeclaration(SF.ParseTypeName("InvalidOperationException")))
						.WithBlock(SF.Block(
						SF.ReturnStatement().WithExpression(
							SF.ObjectCreationExpression(SF.ParseTypeName($"{t.Name}Result"))
							.WithArgumentList(
								SF.ArgumentList()
								.AddArguments(
									SF.Argument(SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName($"{t.Name}Status"),
										SF.IdentifierName("ServerUriIsNotValid"))
									),
									SF.Argument(SF.LiteralExpression(SyntaxKind.NullLiteralExpression)),
									SF.Argument(SF.DefaultExpression(SF.ParseTypeName(key.PropertyType.Name)))
								)
							)
						)))
					)
				);

			


			/*
				HttpBaseProtocolFilter httpFilter = new HttpBaseProtocolFilter();
				httpFilter.CookieManager.SetCookie(cookie);*/

			return list.ToArray();
		}

		private StatementSyntax getPropertyValue(SyntaxToken obj, SyntaxToken jObject, String propertyName, Type propertyType)
		{
			String typeName = propertyType.Name;
			if (propertyType.GenericTypeArguments != null && propertyType.GenericTypeArguments.Length > 0)
			{
				if (propertyType.Name.StartsWith("Nullable"))
				{
					typeName = $"{propertyType.GenericTypeArguments[0]}?";
				}
			}
			return SF.ExpressionStatement(SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
					SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.IdentifierName(obj),
						SF.IdentifierName(propertyName)
					),
					SF.InvocationExpression(
						SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
							SF.IdentifierName(jObject),
							SF.GenericName("GetPropertyValue")
							.AddTypeArgumentListArguments(
								SF.ParseTypeName(typeName)
							)
						)
					).AddArgumentListArguments(
						SF.Argument(
							SF.InvocationExpression(
								SF.IdentifierName("nameof")
							).AddArgumentListArguments(
								SF.Argument(
									SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName(obj),
										SF.IdentifierName(propertyName)
									)
								)
							)
						)
					)
				));
		}

		private StatementSyntax[] createGetCall(Type t, PropertyInfo[] pi)
		{
			var result = SF.Identifier("result");
			var list = new List<StatementSyntax>();
			var key = pi.GetKeyProperty();
			list.Add(SF.ExpressionStatement(
				SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
					SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.IdentifierName("builder"),
						SF.IdentifierName("Path")
					),
					SF.InterpolatedStringExpression(SF.Token(SyntaxKind.InterpolatedStringStartToken))
						.AddContents(
							SF.InterpolatedStringText()
							.WithTextToken(
								SF.Token(SF.TriviaList(),
									SyntaxKind.InterpolatedStringTextToken,
									$"/api/{t.Name}/",
									$"/api/{t.Name}/",
									SF.TriviaList())),
							SF.Interpolation(SF.IdentifierName(keyName)))
						)
					)
				);
			list.Add(SF.LocalDeclarationStatement(
					SF.VariableDeclaration(SF.ParseTypeName("HttpClientResult"))
						.AddVariables(
							SF.VariableDeclarator(result)
								.WithInitializer(
									SF.EqualsValueClause(SF.LiteralExpression(SyntaxKind.NullLiteralExpression))
								)
						)
				));

			var ce = SF.Identifier("ce");

			list.Add(SF.TryStatement()
				.WithBlock(
					SF.Block(
					SF.ExpressionStatement(
						SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
							SF.IdentifierName(result),
							SF.AwaitExpression(
								SF.InvocationExpression(
									SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName("client"),
										SF.IdentifierName("GetAsync")
									)
								)
								.AddArgumentListArguments(
									SF.Argument(
										SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
											SF.IdentifierName("builder"),
											SF.IdentifierName("Uri")
										)
									)
								)
							)
					)
				)))
				.AddCatches(
					SF.CatchClause()
					.WithDeclaration(
						SF.CatchDeclaration(SF.IdentifierName("COMException"))
						.WithIdentifier(ce)
					)
					.AddBlockStatements(
						SF.IfStatement(
							SF.BinaryExpression(SyntaxKind.EqualsExpression,
								SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
									SF.IdentifierName(ce),
									SF.IdentifierName("HResult")
								),
								SF.LiteralExpression(SyntaxKind.NumericLiteralExpression,
									SF.Literal(-2147012867)
								)
							),
							SF.Block()
							.AddStatements(
								SF.ReturnStatement(
									SF.ObjectCreationExpression(SF.ParseTypeName($"{t.Name}Result"))
									.AddArgumentListArguments(
										SF.Argument(
											SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
												SF.IdentifierName($"{t.Name}Status"),
												SF.IdentifierName("UnableToConnectToServer"))
										),
										SF.Argument(
											SF.LiteralExpression(SyntaxKind.NullLiteralExpression)
										)
										,
										SF.Argument(
											SF.IdentifierName(keyName)
										),
										SF.Argument(
											SF.IdentifierName(ce)
										)
									)
								)
							)
						),
						SF.ReturnStatement(
							SF.ObjectCreationExpression(SF.ParseTypeName($"{t.Name}Result"))
							.AddArgumentListArguments(
								SF.Argument(
									SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName($"{t.Name}Status"),
										SF.IdentifierName("Exception"))
								),
								SF.Argument(
									SF.LiteralExpression(SyntaxKind.NullLiteralExpression)
								)
								,
								SF.Argument(
									SF.IdentifierName(keyName)
								),
								SF.Argument(
									SF.IdentifierName(ce)
								)
							)
						)
					),
				SF.CatchClause()
					.WithDeclaration(
						SF.CatchDeclaration(SF.IdentifierName("Exception"))
						.WithIdentifier(ce)
					)
					.AddBlockStatements(
						SF.ReturnStatement(
							SF.ObjectCreationExpression(SF.ParseTypeName($"{t.Name}Result"))
							.AddArgumentListArguments(
								SF.Argument(
									SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName($"{t.Name}Status"),
										SF.IdentifierName("Exception"))
								),
								SF.Argument(
									SF.LiteralExpression(SyntaxKind.NullLiteralExpression)
								)
								,
								SF.Argument(
									SF.IdentifierName(keyName)
								),
								SF.Argument(
									SF.IdentifierName(ce)
								)
							)
						)
					)
				).WithTrailingTrivia(SF.Whitespace(Environment.NewLine + Environment.NewLine))
			);

			var res = SF.Identifier("res");
			var token = SF.Identifier("token");
			var item = SF.Identifier("item");

			var setStatements = SF.Block();
			foreach (var prop in pi)
			{
				if (!prop.ShouldIgnore())
				{
					setStatements = setStatements.AddStatements(getPropertyValue(item, token, prop.Name, prop.PropertyType));
				}
			}

			var block = SF.Block()
				.AddStatements(
					SF.LocalDeclarationStatement(
						SF.VariableDeclaration(SF.IdentifierName("var"))
						.AddVariables(
							SF.VariableDeclarator(res)
							.WithInitializer(
								SF.EqualsValueClause(
									SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName(result),
										SF.IdentifierName("Content")
									)
								)
							)
						)
					).WithTrailingTrivia(SF.Whitespace(Environment.NewLine + Environment.NewLine)),
					SF.TryStatement()
					.AddBlockStatements(
						SF.LocalDeclarationStatement(
							SF.VariableDeclaration(SF.IdentifierName("var"))
							.AddVariables(
								SF.VariableDeclarator(token)
								.WithInitializer(
									SF.EqualsValueClause(
										SF.InvocationExpression(
											SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
												SF.IdentifierName("JObject"),
												SF.IdentifierName("Parse")
											)
										).AddArgumentListArguments(
											SF.Argument(SF.IdentifierName(res))
										)
									)
								)
							)
						),
						SF.LocalDeclarationStatement(
							SF.VariableDeclaration(SF.IdentifierName("var"))
							.AddVariables(
								SF.VariableDeclarator(item)
								.WithInitializer(
									SF.EqualsValueClause(
										SF.InvocationExpression(
											SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
												SF.IdentifierName(helperName),
												SF.IdentifierName($"Create{t.Name}")
											)
										).AddArgumentListArguments()
									)
								)
							)
						),
						SF.IfStatement(
							SF.BinaryExpression(SyntaxKind.EqualsExpression,
								SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
									SF.IdentifierName(token),
									SF.IdentifierName("Type")
								),
								SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
									SF.IdentifierName("JTokenType"),
									SF.IdentifierName("Object")
								)
							),
							setStatements
						),
						SF.ReturnStatement(
							SF.ObjectCreationExpression(SF.ParseTypeName($"{t.Name}Result"))
							.AddArgumentListArguments(
								SF.Argument(
									SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName($"{t.Name}Status"),
										SF.IdentifierName("Success"))
								),
								SF.Argument(
									SF.IdentifierName(item)
								)
								,
								SF.Argument(
									SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
										SF.IdentifierName(item),
										SF.IdentifierName(key.Name)
									)
								)
							)
						)
					)
					.AddCatches(
						SF.CatchClause()
						.WithDeclaration(
							SF.CatchDeclaration(SF.ParseTypeName("Exception"))
							.WithIdentifier(SF.Identifier("ex"))
						)
						.WithBlock(
							SF.Block(
								SF.ReturnStatement(
									SF.ObjectCreationExpression(SF.ParseTypeName($"{t.Name}Result"))
									.AddArgumentListArguments(
										SF.Argument(
											SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
												SF.IdentifierName($"{t.Name}Status"),
												SF.IdentifierName("Exception"))
										),
										SF.Argument(
											SF.LiteralExpression(SyntaxKind.NullLiteralExpression)
										)
										,
										SF.Argument(
											SF.IdentifierName(keyName)
										),
										SF.Argument(
											SF.IdentifierName("ex")
										)
									)
								)
							)
						)
					)
				);

			list.Add(SF.IfStatement(
				SF.BinaryExpression(SyntaxKind.EqualsExpression,
					SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.IdentifierName(result),
						SF.IdentifierName("StatusCode")
					),
					SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.IdentifierName("HttpStatusCode"),
						SF.IdentifierName("Ok")
					)
				),
				block
			)
			.WithElse(SF.ElseClause(SF.Block()
				.AddStatements(
					SF.ReturnStatement(
						SF.ObjectCreationExpression(SF.ParseTypeName($"{t.Name}Result"))
						.AddArgumentListArguments(
							SF.Argument(
								SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
									SF.IdentifierName($"{t.Name}Status"),
									SF.IdentifierName("Error"))
							),
							SF.Argument(
								SF.LiteralExpression(SyntaxKind.NullLiteralExpression)
							)
							,
							SF.Argument(
								SF.IdentifierName(keyName)
							)
						)
					)
				)
			)));

			return list.ToArray();
		}

		private MethodDeclarationSyntax createGetMethod(Type t, PropertyInfo[] pi)
		{

			var key = pi.GetKeyProperty();
			var method = SF.MethodDeclaration(
				SF.GenericName(SF.Identifier("IAsyncOperation"),
					SF.TypeArgumentList().AddArguments(
						SF.ParseTypeName($"{t.Name}Result")
						)
				),
				$"Get{t.Name}Async"
			).WithModifiers(
					SF.TokenList(
						SF.Token(
						SF.TriviaList(
								SF.Trivia(
									SF.DocumentationCommentTrivia(SyntaxKind.SingleLineDocumentationCommentTrivia)
									.AddContent(SF.XmlElement(SF.XmlElementStartTag(SF.XmlName("summary")), SF.XmlElementEndTag(SF.XmlName("summary")))
										.AddContent(
											SF.XmlText($"Gets the I{t.Name} asynchronous.")
										),
										SF.XmlElement(SF.XmlElementStartTag(SF.XmlName("param")), SF.XmlElementEndTag(SF.XmlName("param")))
											.AddStartTagAttributes(SF.XmlNameAttribute(keyName.Text)),
										SF.XmlElement(SF.XmlElementStartTag(SF.XmlName("returns")), SF.XmlElementEndTag(SF.XmlName("returns"))),
										SF.XmlText().AddTextTokens(SF.XmlTextNewLine(Environment.NewLine))
									)
								)
						),
						SyntaxKind.PublicKeyword,
						SF.TriviaList())
				));

			method = method.AddParameterListParameters(
				SF.Parameter(keyName).WithType(SF.ParseTypeName(pi.GetKeyProperty().PropertyType.Name)));

			var body = new List<StatementSyntax>();
			body.AddRange(createCommonResultIfStatments(t, pi));
			body.AddRange(createGetCall(t, pi));

			var amethod = SF.ParenthesizedLambdaExpression(SF.Block(body.ToArray()))
				.WithAsyncKeyword(SF.Token(SyntaxKind.AsyncKeyword));

			return method.AddBodyStatements(
				SF.ReturnStatement().WithExpression(
					SF.InvocationExpression(
					SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.InvocationExpression(SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
							SF.IdentifierName("Task"),
							SF.IdentifierName("Run")
						)).WithArgumentList(
							SF.ArgumentList().AddArguments(SF.Argument(amethod))
						),
						SF.IdentifierName("AsAsyncOperation")
					))
				)
			);
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
