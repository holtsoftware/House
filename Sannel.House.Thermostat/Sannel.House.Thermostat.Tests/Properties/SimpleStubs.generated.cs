using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.ServerSDK;

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubIServerSettings : IServerSettings
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Uri global::Sannel.House.ServerSDK.IServerSettings.ServerUri
        {
            get
            {
                return ((ServerUri_Get_Delegate)_stubs[nameof(ServerUri_Get_Delegate)]).Invoke();
            }

            set
            {
                ((ServerUri_Set_Delegate)_stubs[nameof(ServerUri_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::System.Uri ServerUri_Get_Delegate();

        public StubIServerSettings ServerUri_Get(ServerUri_Get_Delegate del)
        {
            _stubs[nameof(ServerUri_Get_Delegate)] = del;
            return this;
        }

        public delegate void ServerUri_Set_Delegate(global::System.Uri value);

        public StubIServerSettings ServerUri_Set(ServerUri_Set_Delegate del)
        {
            _stubs[nameof(ServerUri_Set_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Thermostat
{
    [CompilerGenerated]
    public class StubIAppSettings : IAppSettings
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        string global::Sannel.House.Thermostat.IAppSettings.Username
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

        string global::Sannel.House.Thermostat.IAppSettings.Password
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

        global::System.Uri global::Sannel.House.ServerSDK.IServerSettings.ServerUri
        {
            get
            {
                return ((IServerSettings_ServerUri_Get_Delegate)_stubs[nameof(IServerSettings_ServerUri_Get_Delegate)]).Invoke();
            }

            set
            {
                ((IServerSettings_ServerUri_Set_Delegate)_stubs[nameof(IServerSettings_ServerUri_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::System.Uri IServerSettings_ServerUri_Get_Delegate();

        public StubIAppSettings ServerUri_Get(IServerSettings_ServerUri_Get_Delegate del)
        {
            _stubs[nameof(IServerSettings_ServerUri_Get_Delegate)] = del;
            return this;
        }

        public delegate void IServerSettings_ServerUri_Set_Delegate(global::System.Uri value);

        public StubIAppSettings ServerUri_Set(IServerSettings_ServerUri_Set_Delegate del)
        {
            _stubs[nameof(IServerSettings_ServerUri_Set_Delegate)] = del;
            return this;
        }
    }
}