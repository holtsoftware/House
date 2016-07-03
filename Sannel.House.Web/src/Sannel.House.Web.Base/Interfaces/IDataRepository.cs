using Sannel.House.Web.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base.Interfaces
{
	public interface IDataRepository
	{
		IQueryable<Device> GetAllDevices();
	}
}
