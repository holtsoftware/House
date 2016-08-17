﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Interfaces
{
	public interface IUserManager
	{
		Task<bool> LoadProfileAsync();

		Task<bool> Logoff();
	}
}
