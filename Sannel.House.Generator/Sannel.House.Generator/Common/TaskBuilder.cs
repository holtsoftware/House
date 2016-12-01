using Sannel.House.Generator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Sannel.House.Generator.Common
{
	public class TaskBuilder : ITaskBuilder
	{
		public MethodDeclarationSyntax AsyncMethod(TypeArgumentListSyntax list, string name, params StatementSyntax[] statments)
		{
			throw new NotImplementedException();
		}
	}
}
