using Sannel.House.Generator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Generator.Interfaces
{
    public interface ICombinedGenerator
    {
		/// <summary>
		/// Generates the file with the given properties
		/// </summary>
		/// <param name="props">The props.</param>
		/// <param name="folder">The folder.</param>
		void Generate(IList<PropertyWithName> props, String folder,ITestBuilder builder);
    }
}
