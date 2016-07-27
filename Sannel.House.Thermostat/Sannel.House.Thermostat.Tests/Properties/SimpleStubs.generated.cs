using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Sannel.House.Thermostat.Base.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Sannel.House.Thermostat.Base.Enums;

namespace Sannel.House.Thermostat.Base.Interfaces
{
    [CompilerGenerated]
    public class StubIDataContext : IDataContext
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::Microsoft.EntityFrameworkCore.DbSet<global::Sannel.House.Thermostat.Base.Models.Device> global::Sannel.House.Thermostat.Base.Interfaces.IDataContext.Devices
        {
            get
            {
                return ((Devices_Get_Delegate)_stubs[nameof(Devices_Get_Delegate)]).Invoke();
            }

            set
            {
                ((Devices_Set_Delegate)_stubs[nameof(Devices_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::Microsoft.EntityFrameworkCore.DbSet<global::Sannel.House.Thermostat.Base.Models.Device> Devices_Get_Delegate();

        public StubIDataContext Devices_Get(Devices_Get_Delegate del)
        {
            _stubs[nameof(Devices_Get_Delegate)] = del;
            return this;
        }

        public delegate void Devices_Set_Delegate(global::Microsoft.EntityFrameworkCore.DbSet<global::Sannel.House.Thermostat.Base.Models.Device> value);

        public StubIDataContext Devices_Set(Devices_Set_Delegate del)
        {
            _stubs[nameof(Devices_Set_Delegate)] = del;
            return this;
        }

        int global::Sannel.House.Thermostat.Base.Interfaces.IDataContext.SaveChanges()
        {
            return ((SaveChanges_Delegate)_stubs[nameof(SaveChanges_Delegate)]).Invoke();
        }

        public delegate int SaveChanges_Delegate();

        public StubIDataContext SaveChanges(SaveChanges_Delegate del)
        {
            _stubs[nameof(SaveChanges_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<int> global::Sannel.House.Thermostat.Base.Interfaces.IDataContext.SaveChangesAsync(global::System.Threading.CancellationToken cancellationToken)
        {
            return ((SaveChangesAsync_CancellationTokenCancellationToken_Delegate)_stubs[nameof(SaveChangesAsync_CancellationTokenCancellationToken_Delegate)]).Invoke(cancellationToken);
        }

        public delegate global::System.Threading.Tasks.Task<int> SaveChangesAsync_CancellationTokenCancellationToken_Delegate(global::System.Threading.CancellationToken cancellationToken);

        public StubIDataContext SaveChangesAsync(SaveChangesAsync_CancellationTokenCancellationToken_Delegate del)
        {
            _stubs[nameof(SaveChangesAsync_CancellationTokenCancellationToken_Delegate)] = del;
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            ((IDisposable_Dispose_Delegate)_stubs[nameof(IDisposable_Dispose_Delegate)]).Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIDataContext Dispose(IDisposable_Dispose_Delegate del)
        {
            _stubs[nameof(IDisposable_Dispose_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Thermostat.Base.Interfaces
{
    [CompilerGenerated]
    public class StubIAppSettings : IAppSettings
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        string global::Sannel.House.Thermostat.Base.Interfaces.IAppSettings.ServerUrl
        {
            get
            {
                return ((ServerUrl_Get_Delegate)_stubs[nameof(ServerUrl_Get_Delegate)]).Invoke();
            }

            set
            {
                ((ServerUrl_Set_Delegate)_stubs[nameof(ServerUrl_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate string ServerUrl_Get_Delegate();

        public StubIAppSettings ServerUrl_Get(ServerUrl_Get_Delegate del)
        {
            _stubs[nameof(ServerUrl_Get_Delegate)] = del;
            return this;
        }

        public delegate void ServerUrl_Set_Delegate(string value);

        public StubIAppSettings ServerUrl_Set(ServerUrl_Set_Delegate del)
        {
            _stubs[nameof(ServerUrl_Set_Delegate)] = del;
            return this;
        }

        string global::Sannel.House.Thermostat.Base.Interfaces.IAppSettings.Username
        {
            get
            {
                return ((Username_Get_Delegate)_stubs[nameof(Username_Get_Delegate)]).Invoke();
            }

            set
            {
                ((Username_Set_Delegate)_stubs[nameof(Username_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate string Username_Get_Delegate();

        public StubIAppSettings Username_Get(Username_Get_Delegate del)
        {
            _stubs[nameof(Username_Get_Delegate)] = del;
            return this;
        }

        public delegate void Username_Set_Delegate(string value);

        public StubIAppSettings Username_Set(Username_Set_Delegate del)
        {
            _stubs[nameof(Username_Set_Delegate)] = del;
            return this;
        }

        string global::Sannel.House.Thermostat.Base.Interfaces.IAppSettings.Password
        {
            get
            {
                return ((Password_Get_Delegate)_stubs[nameof(Password_Get_Delegate)]).Invoke();
            }

            set
            {
                ((Password_Set_Delegate)_stubs[nameof(Password_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate string Password_Get_Delegate();

        public StubIAppSettings Password_Get(Password_Get_Delegate del)
        {
            _stubs[nameof(Password_Get_Delegate)] = del;
            return this;
        }

        public delegate void Password_Set_Delegate(string value);

        public StubIAppSettings Password_Set(Password_Set_Delegate del)
        {
            _stubs[nameof(Password_Set_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Thermostat.Base.Interfaces
{
    [CompilerGenerated]
    public class StubIServerSource : IServerSource
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        bool global::Sannel.House.Thermostat.Base.Interfaces.IServerSource.IsAuthenticated
        {
            get
            {
                return ((IsAuthenticated_Get_Delegate)_stubs[nameof(IsAuthenticated_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IsAuthenticated_Get_Delegate();

        public StubIServerSource IsAuthenticated_Get(IsAuthenticated_Get_Delegate del)
        {
            _stubs[nameof(IsAuthenticated_Get_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<global::Sannel.House.Thermostat.Base.Enums.LoginStatus> global::Sannel.House.Thermostat.Base.Interfaces.IServerSource.LoginAsync(string username, string password)
        {
            return ((LoginAsync_String_String_Delegate)_stubs[nameof(LoginAsync_String_String_Delegate)]).Invoke(username, password);
        }

        public delegate global::System.Threading.Tasks.Task<global::Sannel.House.Thermostat.Base.Enums.LoginStatus> LoginAsync_String_String_Delegate(string username, string password);

        public StubIServerSource LoginAsync(LoginAsync_String_String_Delegate del)
        {
            _stubs[nameof(LoginAsync_String_String_Delegate)] = del;
            return this;
        }
    }
}