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
    public class StubIHumiditySensor : IHumiditySensor
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Threading.Tasks.Task<double> global::Sannel.House.Thermostat.Base.Interfaces.IHumiditySensor.GetHumidityAsync()
        {
            return ((GetHumidityAsync_Delegate)_stubs[nameof(GetHumidityAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<double> GetHumidityAsync_Delegate();

        public StubIHumiditySensor GetHumidityAsync(GetHumidityAsync_Delegate del)
        {
            _stubs[nameof(GetHumidityAsync_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Thermostat.Base.Interfaces.ISensor.IsInitalized
        {
            get
            {
                return ((ISensor_IsInitalized_Get_Delegate)_stubs[nameof(ISensor_IsInitalized_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool ISensor_IsInitalized_Get_Delegate();

        public StubIHumiditySensor IsInitalized_Get(ISensor_IsInitalized_Get_Delegate del)
        {
            _stubs[nameof(ISensor_IsInitalized_Get_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<bool> global::Sannel.House.Thermostat.Base.Interfaces.ISensor.InitializeAsync()
        {
            return ((ISensor_InitializeAsync_Delegate)_stubs[nameof(ISensor_InitializeAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> ISensor_InitializeAsync_Delegate();

        public StubIHumiditySensor InitializeAsync(ISensor_InitializeAsync_Delegate del)
        {
            _stubs[nameof(ISensor_InitializeAsync_Delegate)] = del;
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            ((IDisposable_Dispose_Delegate)_stubs[nameof(IDisposable_Dispose_Delegate)]).Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIHumiditySensor Dispose(IDisposable_Dispose_Delegate del)
        {
            _stubs[nameof(IDisposable_Dispose_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Thermostat.Base.Interfaces
{
    [CompilerGenerated]
    public class StubIPressureSensor : IPressureSensor
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Threading.Tasks.Task<double> global::Sannel.House.Thermostat.Base.Interfaces.IPressureSensor.GetPressureAsync()
        {
            return ((GetPressureAsync_Delegate)_stubs[nameof(GetPressureAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<double> GetPressureAsync_Delegate();

        public StubIPressureSensor GetPressureAsync(GetPressureAsync_Delegate del)
        {
            _stubs[nameof(GetPressureAsync_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Thermostat.Base.Interfaces.ISensor.IsInitalized
        {
            get
            {
                return ((ISensor_IsInitalized_Get_Delegate)_stubs[nameof(ISensor_IsInitalized_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool ISensor_IsInitalized_Get_Delegate();

        public StubIPressureSensor IsInitalized_Get(ISensor_IsInitalized_Get_Delegate del)
        {
            _stubs[nameof(ISensor_IsInitalized_Get_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<bool> global::Sannel.House.Thermostat.Base.Interfaces.ISensor.InitializeAsync()
        {
            return ((ISensor_InitializeAsync_Delegate)_stubs[nameof(ISensor_InitializeAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> ISensor_InitializeAsync_Delegate();

        public StubIPressureSensor InitializeAsync(ISensor_InitializeAsync_Delegate del)
        {
            _stubs[nameof(ISensor_InitializeAsync_Delegate)] = del;
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            ((IDisposable_Dispose_Delegate)_stubs[nameof(IDisposable_Dispose_Delegate)]).Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIPressureSensor Dispose(IDisposable_Dispose_Delegate del)
        {
            _stubs[nameof(IDisposable_Dispose_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Thermostat.Base.Interfaces
{
    [CompilerGenerated]
    public class StubISensor : ISensor
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        bool global::Sannel.House.Thermostat.Base.Interfaces.ISensor.IsInitalized
        {
            get
            {
                return ((IsInitalized_Get_Delegate)_stubs[nameof(IsInitalized_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IsInitalized_Get_Delegate();

        public StubISensor IsInitalized_Get(IsInitalized_Get_Delegate del)
        {
            _stubs[nameof(IsInitalized_Get_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<bool> global::Sannel.House.Thermostat.Base.Interfaces.ISensor.InitializeAsync()
        {
            return ((InitializeAsync_Delegate)_stubs[nameof(InitializeAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> InitializeAsync_Delegate();

        public StubISensor InitializeAsync(InitializeAsync_Delegate del)
        {
            _stubs[nameof(InitializeAsync_Delegate)] = del;
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            ((IDisposable_Dispose_Delegate)_stubs[nameof(IDisposable_Dispose_Delegate)]).Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubISensor Dispose(IDisposable_Dispose_Delegate del)
        {
            _stubs[nameof(IDisposable_Dispose_Delegate)] = del;
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

        global::System.Threading.Tasks.Task<global::System.Collections.Generic.IList<global::Sannel.House.Thermostat.Base.Models.Device>> global::Sannel.House.Thermostat.Base.Interfaces.IServerSource.GetDevicesAsync()
        {
            return ((GetDevicesAsync_Delegate)_stubs[nameof(GetDevicesAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IList<global::Sannel.House.Thermostat.Base.Models.Device>> GetDevicesAsync_Delegate();

        public StubIServerSource GetDevicesAsync(GetDevicesAsync_Delegate del)
        {
            _stubs[nameof(GetDevicesAsync_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Thermostat.Base.Interfaces
{
    [CompilerGenerated]
    public class StubISyncService : ISyncService
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        public event global::System.EventHandler<global::Sannel.House.Thermostat.Base.Models.LogEventArgs> LogMessage;

        protected void On_LogMessage(object sender, LogEventArgs args)
        {
            global::System.EventHandler<global::Sannel.House.Thermostat.Base.Models.LogEventArgs> handler = LogMessage;
            if (handler != null) { handler(sender, args); }
        }

        public void LogMessage_Raise(object sender, LogEventArgs args)
        {
            On_LogMessage(sender, args);
        }

        global::System.Threading.Tasks.Task<bool> global::Sannel.House.Thermostat.Base.Interfaces.ISyncService.LoginAsync()
        {
            return ((LoginAsync_Delegate)_stubs[nameof(LoginAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> LoginAsync_Delegate();

        public StubISyncService LoginAsync(LoginAsync_Delegate del)
        {
            _stubs[nameof(LoginAsync_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<bool> global::Sannel.House.Thermostat.Base.Interfaces.ISyncService.SyncDevicesAsync()
        {
            return ((SyncDevicesAsync_Delegate)_stubs[nameof(SyncDevicesAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> SyncDevicesAsync_Delegate();

        public StubISyncService SyncDevicesAsync(SyncDevicesAsync_Delegate del)
        {
            _stubs[nameof(SyncDevicesAsync_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Thermostat.Base.Interfaces
{
    [CompilerGenerated]
    public class StubITemperatureSensor : ITemperatureSensor
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Threading.Tasks.Task<double> global::Sannel.House.Thermostat.Base.Interfaces.ITemperatureSensor.GetTemperatureCelsiusAsync()
        {
            return ((GetTemperatureCelsiusAsync_Delegate)_stubs[nameof(GetTemperatureCelsiusAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<double> GetTemperatureCelsiusAsync_Delegate();

        public StubITemperatureSensor GetTemperatureCelsiusAsync(GetTemperatureCelsiusAsync_Delegate del)
        {
            _stubs[nameof(GetTemperatureCelsiusAsync_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<double> global::Sannel.House.Thermostat.Base.Interfaces.ITemperatureSensor.GetTemperatureFahrenheitAsync()
        {
            return ((GetTemperatureFahrenheitAsync_Delegate)_stubs[nameof(GetTemperatureFahrenheitAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<double> GetTemperatureFahrenheitAsync_Delegate();

        public StubITemperatureSensor GetTemperatureFahrenheitAsync(GetTemperatureFahrenheitAsync_Delegate del)
        {
            _stubs[nameof(GetTemperatureFahrenheitAsync_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Thermostat.Base.Interfaces.ISensor.IsInitalized
        {
            get
            {
                return ((ISensor_IsInitalized_Get_Delegate)_stubs[nameof(ISensor_IsInitalized_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool ISensor_IsInitalized_Get_Delegate();

        public StubITemperatureSensor IsInitalized_Get(ISensor_IsInitalized_Get_Delegate del)
        {
            _stubs[nameof(ISensor_IsInitalized_Get_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<bool> global::Sannel.House.Thermostat.Base.Interfaces.ISensor.InitializeAsync()
        {
            return ((ISensor_InitializeAsync_Delegate)_stubs[nameof(ISensor_InitializeAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> ISensor_InitializeAsync_Delegate();

        public StubITemperatureSensor InitializeAsync(ISensor_InitializeAsync_Delegate del)
        {
            _stubs[nameof(ISensor_InitializeAsync_Delegate)] = del;
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            ((IDisposable_Dispose_Delegate)_stubs[nameof(IDisposable_Dispose_Delegate)]).Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubITemperatureSensor Dispose(IDisposable_Dispose_Delegate del)
        {
            _stubs[nameof(IDisposable_Dispose_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Thermostat.Base.Interfaces
{
    [CompilerGenerated]
    public class StubITempreatureHumidityPressureSensor : ITempreatureHumidityPressureSensor
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Threading.Tasks.Task<double> global::Sannel.House.Thermostat.Base.Interfaces.ITemperatureSensor.GetTemperatureCelsiusAsync()
        {
            return ((ITemperatureSensor_GetTemperatureCelsiusAsync_Delegate)_stubs[nameof(ITemperatureSensor_GetTemperatureCelsiusAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<double> ITemperatureSensor_GetTemperatureCelsiusAsync_Delegate();

        public StubITempreatureHumidityPressureSensor GetTemperatureCelsiusAsync(ITemperatureSensor_GetTemperatureCelsiusAsync_Delegate del)
        {
            _stubs[nameof(ITemperatureSensor_GetTemperatureCelsiusAsync_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<double> global::Sannel.House.Thermostat.Base.Interfaces.ITemperatureSensor.GetTemperatureFahrenheitAsync()
        {
            return ((ITemperatureSensor_GetTemperatureFahrenheitAsync_Delegate)_stubs[nameof(ITemperatureSensor_GetTemperatureFahrenheitAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<double> ITemperatureSensor_GetTemperatureFahrenheitAsync_Delegate();

        public StubITempreatureHumidityPressureSensor GetTemperatureFahrenheitAsync(ITemperatureSensor_GetTemperatureFahrenheitAsync_Delegate del)
        {
            _stubs[nameof(ITemperatureSensor_GetTemperatureFahrenheitAsync_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<double> global::Sannel.House.Thermostat.Base.Interfaces.IHumiditySensor.GetHumidityAsync()
        {
            return ((IHumiditySensor_GetHumidityAsync_Delegate)_stubs[nameof(IHumiditySensor_GetHumidityAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<double> IHumiditySensor_GetHumidityAsync_Delegate();

        public StubITempreatureHumidityPressureSensor GetHumidityAsync(IHumiditySensor_GetHumidityAsync_Delegate del)
        {
            _stubs[nameof(IHumiditySensor_GetHumidityAsync_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<double> global::Sannel.House.Thermostat.Base.Interfaces.IPressureSensor.GetPressureAsync()
        {
            return ((IPressureSensor_GetPressureAsync_Delegate)_stubs[nameof(IPressureSensor_GetPressureAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<double> IPressureSensor_GetPressureAsync_Delegate();

        public StubITempreatureHumidityPressureSensor GetPressureAsync(IPressureSensor_GetPressureAsync_Delegate del)
        {
            _stubs[nameof(IPressureSensor_GetPressureAsync_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Thermostat.Base.Interfaces.ISensor.IsInitalized
        {
            get
            {
                return ((ISensor_IsInitalized_Get_Delegate)_stubs[nameof(ISensor_IsInitalized_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool ISensor_IsInitalized_Get_Delegate();

        public StubITempreatureHumidityPressureSensor IsInitalized_Get(ISensor_IsInitalized_Get_Delegate del)
        {
            _stubs[nameof(ISensor_IsInitalized_Get_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<bool> global::Sannel.House.Thermostat.Base.Interfaces.ISensor.InitializeAsync()
        {
            return ((ISensor_InitializeAsync_Delegate)_stubs[nameof(ISensor_InitializeAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> ISensor_InitializeAsync_Delegate();

        public StubITempreatureHumidityPressureSensor InitializeAsync(ISensor_InitializeAsync_Delegate del)
        {
            _stubs[nameof(ISensor_InitializeAsync_Delegate)] = del;
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            ((IDisposable_Dispose_Delegate)_stubs[nameof(IDisposable_Dispose_Delegate)]).Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubITempreatureHumidityPressureSensor Dispose(IDisposable_Dispose_Delegate del)
        {
            _stubs[nameof(IDisposable_Dispose_Delegate)] = del;
            return this;
        }
    }
}