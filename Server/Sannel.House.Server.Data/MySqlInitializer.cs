using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Data
{
	public class MySqlInitializer : IDatabaseInitializer<MyContext>
	{
		public void InitializeDatabase(MyContext context)
		{
			if (!context.Database.Exists())
			{
				// if database did not exist before - create it
				context.Database.Create();
			}
			else
			{
				// query to check if MigrationHistory table is present in the database
				var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
				string.Format(
				  "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'",
				  "aspmysql"));

				// if MigrationHistory table is not there (which is the case first time we run) - create it
				if (migrationHistoryTableExists.FirstOrDefault() == 0)
				{
					context.Database.Delete();
					context.Database.Create();
				}
			}
		}
	}
}
