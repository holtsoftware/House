using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Newtonsoft.Json;
using Sannel.House.ServerSDK;
using Microsoft.EntityFrameworkCore;
using Sannel.House.Thermostat.Models;

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

        global::Windows.Foundation.IAsyncOperation<global::Sannel.House.ServerSDK.TemperatureEntryResult> global::Sannel.House.ServerSDK.IServerContext.PostTemperatureEntryAsync(global::Sannel.House.ServerSDK.ITemperatureEntry entry)
        {
            return ((PostTemperatureEntryAsync_ITemperatureEntry_Delegate)_stubs[nameof(PostTemperatureEntryAsync_ITemperatureEntry_Delegate)]).Invoke(entry);
        }

        public delegate global::Windows.Foundation.IAsyncOperation<global::Sannel.House.ServerSDK.TemperatureEntryResult> PostTemperatureEntryAsync_ITemperatureEntry_Delegate(global::Sannel.House.ServerSDK.ITemperatureEntry entry);

        public StubIServerContext PostTemperatureEntryAsync(PostTemperatureEntryAsync_ITemperatureEntry_Delegate del)
        {
            _stubs[nameof(PostTemperatureEntryAsync_ITemperatureEntry_Delegate)] = del;
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

namespace Sannel.House.Thermostat.Interfaces
{
    [CompilerGenerated]
    public class StubIAppSettings : IAppSettings
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        string global::Sannel.House.Thermostat.Interfaces.IAppSettings.Username
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

        string global::Sannel.House.Thermostat.Interfaces.IAppSettings.Password
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

        int global::Sannel.House.Thermostat.Interfaces.IAppSettings.DeviceId
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

        public StubIAppSettings DeviceId_Get(DeviceId_Get_Delegate del)
        {
            _stubs[nameof(DeviceId_Get_Delegate)] = del;
            return this;
        }

        public delegate void DeviceId_Set_Delegate(int value);

        public StubIAppSettings DeviceId_Set(DeviceId_Set_Delegate del)
        {
            _stubs[nameof(DeviceId_Set_Delegate)] = del;
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

namespace Sannel.House.Thermostat.Interfaces
{
    [CompilerGenerated]
    public class StubIDataContext : IDataContext
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::Microsoft.EntityFrameworkCore.DbSet<global::Sannel.House.Thermostat.Models.TemperatureEntry> global::Sannel.House.Thermostat.Interfaces.IDataContext.TemperatureEntries
        {
            get
            {
                return ((TemperatureEntries_Get_Delegate)_stubs[nameof(TemperatureEntries_Get_Delegate)]).Invoke();
            }

            set
            {
                ((TemperatureEntries_Set_Delegate)_stubs[nameof(TemperatureEntries_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::Microsoft.EntityFrameworkCore.DbSet<global::Sannel.House.Thermostat.Models.TemperatureEntry> TemperatureEntries_Get_Delegate();

        public StubIDataContext TemperatureEntries_Get(TemperatureEntries_Get_Delegate del)
        {
            _stubs[nameof(TemperatureEntries_Get_Delegate)] = del;
            return this;
        }

        public delegate void TemperatureEntries_Set_Delegate(global::Microsoft.EntityFrameworkCore.DbSet<global::Sannel.House.Thermostat.Models.TemperatureEntry> value);

        public StubIDataContext TemperatureEntries_Set(TemperatureEntries_Set_Delegate del)
        {
            _stubs[nameof(TemperatureEntries_Set_Delegate)] = del;
            return this;
        }

        int global::Sannel.House.Thermostat.Interfaces.IDataContext.SaveChanges()
        {
            return ((SaveChanges_Delegate)_stubs[nameof(SaveChanges_Delegate)]).Invoke();
        }

        public delegate int SaveChanges_Delegate();

        public StubIDataContext SaveChanges(SaveChanges_Delegate del)
        {
            _stubs[nameof(SaveChanges_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<int> global::Sannel.House.Thermostat.Interfaces.IDataContext.SaveChangesAsync(global::System.Threading.CancellationToken cancellationToken)
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

namespace Sannel.House.Thermostat.Interfaces
{
    [CompilerGenerated]
    public class StubITemperatureSensor : ITemperatureSensor
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        double global::Sannel.House.Thermostat.Interfaces.ITemperatureSensor.GetTemperatureCelsius()
        {
            return ((GetTemperatureCelsius_Delegate)_stubs[nameof(GetTemperatureCelsius_Delegate)]).Invoke();
        }

        public delegate double GetTemperatureCelsius_Delegate();

        public StubITemperatureSensor GetTemperatureCelsius(GetTemperatureCelsius_Delegate del)
        {
            _stubs[nameof(GetTemperatureCelsius_Delegate)] = del;
            return this;
        }

        double global::Sannel.House.Thermostat.Interfaces.ITemperatureSensor.GetHumidity()
        {
            return ((GetHumidity_Delegate)_stubs[nameof(GetHumidity_Delegate)]).Invoke();
        }

        public delegate double GetHumidity_Delegate();

        public StubITemperatureSensor GetHumidity(GetHumidity_Delegate del)
        {
            _stubs[nameof(GetHumidity_Delegate)] = del;
            return this;
        }

        double global::Sannel.House.Thermostat.Interfaces.ITemperatureSensor.GetPressure()
        {
            return ((GetPressure_Delegate)_stubs[nameof(GetPressure_Delegate)]).Invoke();
        }

        public delegate double GetPressure_Delegate();

        public StubITemperatureSensor GetPressure(GetPressure_Delegate del)
        {
            _stubs[nameof(GetPressure_Delegate)] = del;
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