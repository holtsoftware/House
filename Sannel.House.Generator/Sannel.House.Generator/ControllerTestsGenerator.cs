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
	public class ControllerTestsGenerator : GeneratorBase
	{
		public override string DirectoryName
		{
			get
			{
				return "Tests";
			}
		}

		private String filename;

		public override string FileName
		{
			get
			{
				return filename;
			}
		}

		private MethodDeclarationSyntax generateGetTest(String controllerName, String propertyName, Type t)
		{
			var context = SF.Identifier("context");
			var controller = SF.Identifier("controller");
			var var1 = SF.Identifier("var1");
			var var2 = SF.Identifier("var2");
			var var3 = SF.Identifier("var3");
			var method = SF.MethodDeclaration(SF.ParseTypeName("void"), "GetTest")
				.AddAttributeLists(SF.AttributeList().AddAttributes(SF.Attribute(SF.IdentifierName("Test"))))
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword));

			var blocks = SF.Block();

			var variable1 = Extensions.VariableDeclaration(var1.Text, t.Name, SF.ArgumentList());
			blocks = blocks.AddStatements(SF.LocalDeclarationStatement(variable1));
			var variable2 = Extensions.VariableDeclaration(var2.Text, t.Name, SF.ArgumentList());
			blocks = blocks.AddStatements(SF.LocalDeclarationStatement(variable2));
			var variable3 = Extensions.VariableDeclaration(var3.Text, t.Name, SF.ArgumentList());
			blocks = blocks.AddStatements(SF.LocalDeclarationStatement(variable3));

			var rand = new Random();
			List<ExpressionStatementSyntax> var1Sets = new List<ExpressionStatementSyntax>();
			List<ExpressionStatementSyntax> var2Sets = new List<ExpressionStatementSyntax>();
			List<ExpressionStatementSyntax> var3Sets = new List<ExpressionStatementSyntax>();

			var props = t.GetProperties();
			foreach(var p in props)
			{
				if (!p.ShouldIgnore())
				{
					var1Sets.Add(SF.ExpressionStatement(Extensions.SetPropertyValue(SF.IdentifierName(var1), p.Name, rand.LiteralForProperty(p.PropertyType, p.Name))));
					var2Sets.Add(SF.ExpressionStatement(Extensions.SetPropertyValue(SF.IdentifierName(var2), p.Name, rand.LiteralForProperty(p.PropertyType, p.Name))));
					var3Sets.Add(SF.ExpressionStatement(Extensions.SetPropertyValue(SF.IdentifierName(var3), p.Name, rand.LiteralForProperty(p.PropertyType, p.Name))));
				}
			}
			var1Sets[0] = var1Sets[0].WithLeadingTrivia(SF.Comment("//var1"));
			var2Sets[0] = var2Sets[0].WithLeadingTrivia(SF.Comment("//var2"));
			var3Sets[0] = var3Sets[0].WithLeadingTrivia(SF.Comment("//var3"));

			blocks = blocks.AddStatements(var1Sets.ToArray());
			blocks = blocks.AddStatements(var2Sets.ToArray());
			blocks = blocks.AddStatements(var3Sets.ToArray());

			bool isForward = false;
			var prop = props.GetSortProperty(out isForward);
			if(prop != null)
			{
				if (isForward)
				{
					int i = 1;
					blocks = blocks.AddStatements(SF.ExpressionStatement(Extensions.SetPropertyValue(SF.IdentifierName(var3), prop.Name, i.ToExpression()))
						.WithLeadingTrivia(SF.Comment("//Fix Order")));
					i++;
					blocks = blocks.AddStatements(SF.ExpressionStatement(Extensions.SetPropertyValue(SF.IdentifierName(var2), prop.Name, i.ToExpression())));
					i++;
					blocks = blocks.AddStatements(SF.ExpressionStatement(Extensions.SetPropertyValue(SF.IdentifierName(var1), prop.Name, i.ToExpression())));
				}
				else
				{
					var order = SF.Identifier("order");
					blocks = blocks.AddStatements(SF.LocalDeclarationStatement(Extensions.VariableDeclaration(order.Text, SF.EqualsValueClause(Extensions.MemberAccess("DateTimeOffset", "Now"))))
						.WithLeadingTrivia(SF.Comment("//Fix Order")));

					blocks = blocks.AddStatements(SF.ExpressionStatement(Extensions.SetPropertyValue(SF.IdentifierName(var3), prop.Name, SF.IdentifierName(order))));

					blocks = blocks.AddStatements(SF.ExpressionStatement(
						Extensions.SetPropertyValue(SF.IdentifierName(var2), prop.Name, SF.InvocationExpression(Extensions.MemberAccess(order.Text, "AddDays"))
							.AddArgumentListArguments(SF.Argument((-1).ToExpression())))));
					blocks = blocks.AddStatements(SF.ExpressionStatement(
						Extensions.SetPropertyValue(SF.IdentifierName(var1), prop.Name, SF.InvocationExpression(Extensions.MemberAccess(order.Text, "AddDays"))
							.AddArgumentListArguments(SF.Argument((-2).ToExpression())))));
				}
			}

			blocks = blocks.AddStatements(
				SF.ExpressionStatement(SF.InvocationExpression(Extensions.MemberAccess(
				Extensions.MemberAccess(context.Text, propertyName),
				SF.IdentifierName("Add"))).WithArgumentList(
					SF.ArgumentList().AddArgument(var1.Text))
					).WithLeadingTrivia(SF.Comment("// Add and save entities")),
				SF.ExpressionStatement(
					SF.InvocationExpression(
						Extensions.MemberAccess(
							Extensions.MemberAccess(
								context.Text,
								propertyName
							),
							SF.IdentifierName("Add")
						)
					)
					.WithArgumentList(
						SF.ArgumentList()
							.AddArgument(var2.Text)
					)
				),
				SF.ExpressionStatement(
					SF.InvocationExpression(
						Extensions.MemberAccess(
							Extensions.MemberAccess(
								context.Text,
								propertyName
							),
							SF.IdentifierName("Add")
						)
					)
					.WithArgumentList(
						SF.ArgumentList()
							.AddArgument(var3.Text)
					)
				),
				SF.ExpressionStatement(
					SF.InvocationExpression(
						Extensions.MemberAccess(
							context.Text,
							"SaveChanges"
						)
					)
				)
					);

			var @using2 = SF.UsingStatement(blocks)
				.WithDeclaration(Extensions.VariableDeclaration(controller.Text, 
					controllerName, 
					SF.ArgumentList().AddArgument(context.Text)));

			var @using = SF.UsingStatement(SF.Block(@using2))
				.WithDeclaration(Extensions.VariableDeclaration(context.Text, "MockDataContext", SF.ArgumentList(), "IDataContext"));

			method = method.AddBodyStatements(@using);

			return method;
		}

		protected override CompilationUnitSyntax internalGenerate(string propertyName, Type t)
		{
			var controllerName = $"{t.Name}Controller";
			filename = $"{controllerName}Tests";
			var unit = SF.CompilationUnit();

			unit = unit.AddUsing("System").WithLeadingTrivia(getLicenseComment());
			unit = unit.AddUsings(
					"NUnit.Framework",
					"Sannel.House.Web.Base.Interfaces",
					"Sannel.House.Web.Base.Models",
					"Sannel.House.Web.Controllers.api",
					"Sannel.House.Web.Mocks",
					"System.Collections.Generic",
					"System.Linq",
					"System.Threading.Tasks");

			var @class = SF.ClassDeclaration(filename)
				.AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
				.AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("TestBase")))
				.AddAttributeLists(SF.AttributeList().AddAttributes(SF.Attribute(SF.IdentifierName("TestFixture"))));

			@class = @class.AddMembers(generateGetTest(controllerName, propertyName, t));
			
			return unit.AddMembers(SF.NamespaceDeclaration(SF.IdentifierName("Sannel.House.Web.Tests")).AddMembers(@class));
		}
	}
}
