using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Newtonsoft.Json;

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubICreateHelper : ICreateHelper
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::Sannel.House.ServerSDK.ITemperatureEntry global::Sannel.House.ServerSDK.ICreateHelper.CreateTemperatureEntry()
        {
            return ((CreateTemperatureEntry_Delegate)_stubs[nameof(CreateTemperatureEntry_Delegate)]).Invoke();
        }

        public delegate global::Sannel.House.ServerSDK.ITemperatureEntry CreateTemperatureEntry_Delegate();

        public StubICreateHelper CreateTemperatureEntry(CreateTemperatureEntry_Delegate del)
        {
            _stubs[nameof(CreateTemperatureEntry_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubIHttpClient : IHttpClient
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        string global::Sannel.House.ServerSDK.IHttpClient.GetCookieValue(global::System.Uri uri, string cookieName)
        {
            return ((GetCookieValue_Uri_String_Delegate)_stubs[nameof(GetCookieValue_Uri_String_Delegate)]).Invoke(uri, cookieName);
        }

        public delegate string GetCookieValue_Uri_String_Delegate(global::System.Uri uri, string cookieName);

        public StubIHttpClient GetCookieValue(GetCookieValue_Uri_String_Delegate del)
        {
            _stubs[nameof(GetCookieValue_Uri_String_Delegate)] = del;
            return this;
        }

        global::Windows.Foundation.IAsyncOperation<global::Sannel.House.ServerSDK.HttpClientResult> global::Sannel.House.ServerSDK.IHttpClient.GetAsync(global::System.Uri requestUri)
        {
            return ((GetAsync_Uri_Delegate)_stubs[nameof(GetAsync_Uri_Delegate)]).Invoke(requestUri);
        }

        public delegate global::Windows.Foundation.IAsyncOperation<global::Sannel.House.ServerSDK.HttpClientResult> GetAsync_Uri_Delegate(global::System.Uri requestUri);

        public StubIHttpClient GetAsync(GetAsync_Uri_Delegate del)
        {
            _stubs[nameof(GetAsync_Uri_Delegate)] = del;
            return this;
        }

        global::Windows.Foundation.IAsyncOperation<global::Sannel.House.ServerSDK.HttpClientResult> global::Sannel.House.ServerSDK.IHttpClient.PostAsync(global::System.Uri requestUri, global::System.Collections.Generic.IDictionary<string, string> data)
        {
            return ((PostAsync_Uri_IDictionaryOfStringString_Delegate)_stubs[nameof(PostAsync_Uri_IDictionaryOfStringString_Delegate)]).Invoke(requestUri, data);
        }

        public delegate global::Windows.Foundation.IAsyncOperation<global::Sannel.House.ServerSDK.HttpClientResult> PostAsync_Uri_IDictionaryOfStringString_Delegate(global::System.Uri requestUri, global::System.Collections.Generic.IDictionary<string, string> data);

        public StubIHttpClient PostAsync(PostAsync_Uri_IDictionaryOfStringString_Delegate del)
        {
            _stubs[nameof(PostAsync_Uri_IDictionaryOfStringString_Delegate)] = del;
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            ((IDisposable_Dispose_Delegate)_stubs[nameof(IDisposable_Dispose_Delegate)]).Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIHttpClient Dispose(IDisposable_Dispose_Delegate del)
        {
            _stubs[nameof(IDisposable_Dispose_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubIServerContext : IServerContext
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::Windows.Foundation.IAsyncOperation<global::Sannel.House.ServerSDK.LoginResult> global::Sannel.House.ServerSDK.IServerContext.LoginAsync(string username, string password)
        {
            return ((LoginAsync_String_String_Delegate)_stubs[nameof(LoginAsync_String_String_Delegate)]).Invoke(username, password);
        }

        public delegate global::Windows.Foundation.IAsyncOperation<global::Sannel.House.ServerSDK.LoginResult> LoginAsync_String_String_Delegate(string username, string password);

        public StubIServerContext LoginAsync(LoginAsync_String_String_Delegate del)
        {
            _stubs[nameof(LoginAsync_String_String_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.ServerSDK.IServerContext.IsAuthenticated
        {
            get
            {
                return ((IsAuthenticated_Get_Delegate)_stubs[nameof(IsAuthenticated_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IsAuthenticated_Get_Delegate();

        public StubIServerContext IsAuthenticated_Get(IsAuthenticated_Get_Delegate del)
        {
            _stubs[nameof(IsAuthenticated_Get_Delegate)] = del;
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            ((IDisposable_Dispose_Delegate)_stubs[nameof(IDisposable_Dispose_Delegate)]).Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIServerContext Dispose(IDisposable_Dispose_Delegate del)
        {
            _stubs[nameof(IDisposable_Dispose_Delegate)] = del;
            return this;
        }
    }
}

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

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubITemperatureEntry : ITemperatureEntry
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Guid global::Sannel.House.ServerSDK.ITemperatureEntry.Id
        {
            get
            {
                return ((Id_Get_Delegate)_stubs[nameof(Id_Get_Delegate)]).Invoke();
            }

            set
            {
                ((Id_Set_Delegate)_stubs[nameof(Id_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::System.Guid Id_Get_Delegate();

        public StubITemperatureEntry Id_Get(Id_Get_Delegate del)
        {
            _stubs[nameof(Id_Get_Delegate)] = del;
            return this;
        }

        public delegate void Id_Set_Delegate(global::System.Guid value);

        public StubITemperatureEntry Id_Set(Id_Set_Delegate del)
        {
            _stubs[nameof(Id_Set_Delegate)] = del;
            return this;
        }

        int global::Sannel.House.ServerSDK.ITemperatureEntry.DeviceId
        {
            get
            {
                return ((DeviceId_Get_Delegate)_stubs[nameof(DeviceId_Get_Delegate)]).Invoke();
            }

            set
            {
                ((DeviceId_Set_Delegate)_stubs[nameof(DeviceId_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate int DeviceId_Get_Delegate();

        public StubITemperatureEntry DeviceId_Get(DeviceId_Get_Delegate del)
        {
            _stubs[nameof(DeviceId_Get_Delegate)] = del;
            return this;
        }

        public delegate void DeviceId_Set_Delegate(int value);

        public StubITemperatureEntry DeviceId_Set(DeviceId_Set_Delegate del)
        {
            _stubs[nameof(DeviceId_Set_Delegate)] = del;
            return this;
        }

        double global::Sannel.House.ServerSDK.ITemperatureEntry.TemperatureCelsius
        {
            get
            {
                return ((TemperatureCelsius_Get_Delegate)_stubs[nameof(TemperatureCelsius_Get_Delegate)]).Invoke();
            }

            set
            {
                ((TemperatureCelsius_Set_Delegate)_stubs[nameof(TemperatureCelsius_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate double TemperatureCelsius_Get_Delegate();

        public StubITemperatureEntry TemperatureCelsius_Get(TemperatureCelsius_Get_Delegate del)
        {
            _stubs[nameof(TemperatureCelsius_Get_Delegate)] = del;
            return this;
        }

        public delegate void TemperatureCelsius_Set_Delegate(double value);

        public StubITemperatureEntry TemperatureCelsius_Set(TemperatureCelsius_Set_Delegate del)
        {
            _stubs[nameof(TemperatureCelsius_Set_Delegate)] = del;
            return this;
        }

        double global::Sannel.House.ServerSDK.ITemperatureEntry.Humidity
        {
            get
            {
                return ((Humidity_Get_Delegate)_stubs[nameof(Humidity_Get_Delegate)]).Invoke();
            }

            set
            {
                ((Humidity_Set_Delegate)_stubs[nameof(Humidity_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate double Humidity_Get_Delegate();

        public StubITemperatureEntry Humidity_Get(Humidity_Get_Delegate del)
        {
            _stubs[nameof(Humidity_Get_Delegate)] = del;
            return this;
        }

        public delegate void Humidity_Set_Delegate(double value);

        public StubITemperatureEntry Humidity_Set(Humidity_Set_Delegate del)
        {
            _stubs[nameof(Humidity_Set_Delegate)] = del;
            return this;
        }

        double global::Sannel.House.ServerSDK.ITemperatureEntry.Pressure
        {
            get
            {
                return ((Pressure_Get_Delegate)_stubs[nameof(Pressure_Get_Delegate)]).Invoke();
            }

            set
            {
                ((Pressure_Set_Delegate)_stubs[nameof(Pressure_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate double Pressure_Get_Delegate();

        public StubITemperatureEntry Pressure_Get(Pressure_Get_Delegate del)
        {
            _stubs[nameof(Pressure_Get_Delegate)] = del;
            return this;
        }

        public delegate void Pressure_Set_Delegate(double value);

        public StubITemperatureEntry Pressure_Set(Pressure_Set_Delegate del)
        {
            _stubs[nameof(Pressure_Set_Delegate)] = del;
            return this;
        }

        global::System.DateTimeOffset global::Sannel.House.ServerSDK.ITemperatureEntry.CreatedDateTime
        {
            get
            {
                return ((CreatedDateTime_Get_Delegate)_stubs[nameof(CreatedDateTime_Get_Delegate)]).Invoke();
            }

            set
            {
                ((CreatedDateTime_Set_Delegate)_stubs[nameof(CreatedDateTime_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::System.DateTimeOffset CreatedDateTime_Get_Delegate();

        public StubITemperatureEntry CreatedDateTime_Get(CreatedDateTime_Get_Delegate del)
        {
            _stubs[nameof(CreatedDateTime_Get_Delegate)] = del;
            return this;
        }

        public delegate void CreatedDateTime_Set_Delegate(global::System.DateTimeOffset value);

        public StubITemperatureEntry CreatedDateTime_Set(CreatedDateTime_Set_Delegate del)
        {
            _stubs[nameof(CreatedDateTime_Set_Delegate)] = del;
            return this;
        }
    }
}