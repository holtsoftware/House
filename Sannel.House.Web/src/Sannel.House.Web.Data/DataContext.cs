using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Microsoft.Extensions.Configuration;

namespace Sannel.House.Web.Data
{
	public class DataContext : DbContext, IDataContext
	{
		public DbSet<Device> Devices
		{
			get;
			set;
		}
		
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
	}
}
