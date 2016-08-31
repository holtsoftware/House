using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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