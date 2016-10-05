/* Copyright 2016 Sannel Software, L.L.C.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	public sealed class TemperatureEntryResults
	{
		public TemperatureEntryResults(TemperatureEntryStatus status, IList<ITemperatureEntry> data, Guid key)
		{
			Status = status;
			Data = data;
			Key = key;
		}

		public TemperatureEntryResults(TemperatureEntryStatus status, IList<ITemperatureEntry> data, Guid key, Exception exception)
		{
			Status = status;
			Data = data;
			Key = key;
			Exception = exception;
		}

		public TemperatureEntryStatus Status
		{
			get;
			set;
		}

		public IList<ITemperatureEntry> Data
		{
			get;
			set;
		}

		public Guid Key
		{
			get;
			set;
		}

		public Exception Exception
		{
			get;
			set;
		}
	}
}