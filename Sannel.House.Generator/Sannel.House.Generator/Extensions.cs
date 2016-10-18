﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sannel.House.Web.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Sannel.House.Generator
{
	public static class Extensions
	{
		public static PropertyInfo GetSortProperty(this PropertyInfo[] props, out bool isForward)
		{
			isForward = true;
			if (props == null)
			{
				return null;
			}

			var dm = props.FirstOrDefault(i => String.Compare(i.Name, "DisplayOrder", true) == 0);
			if (dm == null)
			{
				dm = props.FirstOrDefault(i => String.Compare(i.Name, "Order", true) == 0);
			}

			if (dm == null)
			{
				dm = props.FirstOrDefault(i => String.Compare(i.Name, "DateCreated") == 0);
				isForward = false;
			}

			if (dm == null)
			{
				dm = props.FirstOrDefault(i => String.Compare(i.Name, "CreatedDate") == 0);
				isForward = false;
			}

			if (dm == null)
			{
				dm = props.FirstOrDefault(i => String.Compare(i.Name, "CreatedDateTime") == 0);
				isForward = false;
			}

			return dm;
		}

		public static PropertyInfo GetKeyProperty(this PropertyInfo[] props)
		{
			if (props == null)
			{
				return null;
			}

			foreach (var p in props)
			{
				var attr = p.GetCustomAttribute(typeof(KeyAttribute));
				if (attr != null)
				{
					return p;
				}
			}

			return null;
		}

		public static TypeSyntax GetTypeSyntax(this PropertyInfo info)
		{
			if(info == null)
			{
				throw new ArgumentNullException(nameof(info));
			}

			Type t = info.PropertyType;

			if (t.GenericTypeArguments != null && t.GenericTypeArguments.Length > 0)
			{
				if(String.Compare(t.Name, "Nullable`1") == 0)
				{
					return SF.ParseTypeName($"{t.GenericTypeArguments.First().Name}?");
				}

				throw new Exception($"Type {t.FullName} is not supported right now.");
			}
			else
			{
				return SF.ParseTypeName(t.Name);
			}
		}

		public static CompilationUnitSyntax AddUsing(this CompilationUnitSyntax unit, String namesp)
		{
			return unit.AddUsings(SF.UsingDirective(SF.IdentifierName(namesp)));
		}

		public static CompilationUnitSyntax AddUsings(this CompilationUnitSyntax unit, params String[] usings)
		{
			foreach (var u in usings)
			{
				unit = unit.AddUsings(SF.UsingDirective(SF.IdentifierName(u)));
			}
			return unit;
		}

		public static ArgumentListSyntax AddArgument(this ArgumentListSyntax syntax, String name)
		{
			return syntax.AddArguments(SF.Argument(SF.IdentifierName(name)));
		}

		public static ExpressionSyntax LiteralForProperty(this Random rand, Type t, String name)
		{
			if (t == typeof(bool))
			{
				return (rand.Next(1, 10) >= 5) ? SF.LiteralExpression(SyntaxKind.TrueLiteralExpression) : SF.LiteralExpression(SyntaxKind.FalseLiteralExpression);
			}
			if (t == typeof(String))
			{
				return SF.LiteralExpression(SyntaxKind.StringLiteralExpression, SF.Literal(rand.NextString(10, 50)));
			}
			if (t == typeof(int) || t == typeof(short) || t == typeof(long) || t == typeof(int?))
			{
				return SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(rand.Next(1, 100)));
			}
			if (t == typeof(float) || t == typeof(double) || t == typeof(decimal))
			{
				return SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(rand.NextDouble()));
			}
			if (t == typeof(Guid))
			{
				return SF.InvocationExpression(
					SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.IdentifierName("Guid"),
						SF.IdentifierName("NewGuid")
					)).AddArgumentListArguments();
			}

			if (t == typeof(DateTime) || t == typeof(DateTime?))
			{
				if (String.Compare(name, "CreatedDate", true) == 0 ||
					String.Compare(name, "CreatedDateTime", true) == 0 ||
					String.Compare(name, "ModifiedDate", true) == 0 ||
					String.Compare(name, "ModifiedDateTime", true) == 0)
				{
					return SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.IdentifierName("DateTime"),
						SF.IdentifierName("Now"));
				}
				return SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
					SF.IdentifierName("DateTime"),
					SF.IdentifierName("Min"));
			}
			if (t == typeof(DateTimeOffset) || t == typeof(DateTimeOffset?))
			{
				if (String.Compare(name, "CreatedDate", true) == 0 ||
					String.Compare(name, "CreatedDateTime", true) == 0 ||
					String.Compare(name, "ModifiedDate", true) == 0 ||
					String.Compare(name, "ModifiedDateTime", true) == 0)
				{
					return SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SF.IdentifierName("DateTimeOffset"),
						SF.IdentifierName("Now"));
				}
				return SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
					SF.IdentifierName("DateTimeOffset"),
					SF.IdentifierName("Min"));
			}
			
			if(t == typeof(DayOfWeek?) || t == typeof(DayOfWeek))
			{
				return SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
					SF.IdentifierName("DayOfWeek"),
					SF.IdentifierName(Enum.GetName(typeof(DayOfWeek), rand.Next(1,7))));
			}

			throw new Exception($"Unsupported type {t.Name}");

		}

		public static VariableDeclarationSyntax VariableDeclaration(String name, String createType, ArgumentListSyntax list, String declareType = "var")
		{
			return SF.VariableDeclaration(SF.IdentifierName(declareType))
				.AddVariables(SF.VariableDeclarator(name)
					.WithInitializer(SF.EqualsValueClause(
						SF.ObjectCreationExpression(SF.ParseTypeName(createType))
						.WithArgumentList(list)
						)));
		}
		public static VariableDeclarationSyntax VariableDeclaration(String name, EqualsValueClauseSyntax equals, String declareType = "var")
		{
			return SF.VariableDeclaration(SF.IdentifierName(declareType))
				.AddVariables(SF.VariableDeclarator(name)
					.WithInitializer(equals)
				);
		}

		public static VariableDeclaratorSyntax VariableDeclarator(String name, String createType, ArgumentListSyntax list, String declareType = "var")
		{
			return SF.VariableDeclarator(declareType)
					.WithInitializer(SF.EqualsValueClause(
						SF.ObjectCreationExpression(SF.ParseTypeName(createType))
						.WithArgumentList(list)
						));
		}

		public static AssignmentExpressionSyntax SetPropertyValue(IdentifierNameSyntax name, String propertyName, ExpressionSyntax value)
		{
			return SF.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
				SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
				name,
				SF.IdentifierName(propertyName)),
				value);

		}

		public static MemberAccessExpressionSyntax MemberAccess(String name, String property)
		{
			return MemberAccess(SF.IdentifierName(name), SF.IdentifierName(property));
		}

		public static MemberAccessExpressionSyntax MemberAccess(ExpressionSyntax left, SimpleNameSyntax right)
		{
			return SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, left, right);
		}

		public static bool ShouldIgnore(this PropertyInfo pi)
		{
			var att = pi.GetCustomAttribute<GenerationAttribute>();
			return att != null && att.Ignore;
		}

		public static ExpressionSyntax ToExpression(this int number)
		{
			return SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(number));
		}
	}
}