using Microsoft.EntityFrameworkCore;
using Sannel.House.Thermostat.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Thermostat.Base.Models;

namespace Sannel.House.Thermostat.Data
{
    public class LocalDataContext : DbContext, IDataContext
    {
        public DbSet<Device> Devices
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Thermostat.db");
        }
    }
}
