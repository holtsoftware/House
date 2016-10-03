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
						)))
				)
				);

			list.Add(SF.ExpressionStatement(
				SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
					SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.IdentifierName(builder),
						SF.IdentifierName("Path")
					),
					SF.LiteralExpression(SyntaxKind.StringLiteralExpression, SF.Literal($"/api/{t.Name}")))
				));


			/*
				HttpBaseProtocolFilter httpFilter = new HttpBaseProtocolFilter();
				httpFilter.CookieManager.SetCookie(cookie);*/

			return list.ToArray();
		}

		private StatementSyntax[] createGetCall(Type t, PropertyInfo[] pi)
		{
			var result = SF.Identifier("result");
			var list = new List<StatementSyntax>();
			list.Add(SF.LocalDeclarationStatement(
					SF.VariableDeclaration(SF.ParseTypeName("HttpResponseMessage"))
						.AddVariables(
							SF.VariableDeclarator(result)
								.WithInitializer(
									SF.EqualsValueClause(SF.LiteralExpression(SyntaxKind.NullLiteralExpression))
								)
						)
				));

			/*HttpResponseMessage result = null;
					try
					{
						result = await client.GetAsync(builder.Uri);
					}
					catch (COMException ce)
					{
						if (ce.HResult == -2147012867)
						{
							return new TemperatureSettingResults(TemperatureSettingStatus.UnableToConnectToServer, null)
							{
								Exception = ce
							};
						}

						return new TemperatureSettingResults(TemperatureSettingStatus.Exception, null)
						{
							Exception = ce
						};
					}*/
			return list.ToArray();
		}

		private MethodDeclarationSyntax createGetMethod(Type t, PropertyInfo[] pi)
		{

			var key = pi.GetKeyProperty();
			var keyName = SF.Identifier("key");
			var method = SF.MethodDeclaration(
				SF.GenericName(SF.Identifier("IAsyncOperation"),
					SF.TypeArgumentList().AddArguments(
						SF.ParseTypeName(t.Name)
						)
				),
				$"Get{t.Name}Async"
			);

			method = method.AddParameterListParameters(
				SF.Parameter(SF.Identifier("key")).WithType(SF.ParseTypeName(pi.GetKeyProperty().PropertyType.Name)))
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword));

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

			cu = cu.AddMembers(createGetMethod(t, pi));

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
