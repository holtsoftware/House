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

        global::Sannel.House.ServerSDK.ITemperatureSetting global::Sannel.House.ServerSDK.ICreateHelper.CreateTemperatureSetting()
        {
            return ((CreateTemperatureSetting_Delegate)_stubs[nameof(CreateTemperatureSetting_Delegate)]).Invoke();
        }

        public delegate global::Sannel.House.ServerSDK.ITemperatureSetting CreateTemperatureSetting_Delegate();

        public StubICreateHelper CreateTemperatureSetting(CreateTemperatureSetting_Delegate del)
        {
            _stubs[nameof(CreateTemperatureSetting_Delegate)] = del;
            return this;
        }

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

        global::Windows.Foundation.IAsyncOperation<global::Sannel.House.ServerSDK.TemperatureSettingResults> global::Sannel.House.ServerSDK.IServerContext.GetTemperatureSettingsAsync()
        {
            return ((GetTemperatureSettingsAsync_Delegate)_stubs[nameof(GetTemperatureSettingsAsync_Delegate)]).Invoke();
        }

        public delegate global::Windows.Foundation.IAsyncOperation<global::Sannel.House.ServerSDK.TemperatureSettingResults> GetTemperatureSettingsAsync_Delegate();

        public StubIServerContext GetTemperatureSettingsAsync(GetTemperatureSettingsAsync_Delegate del)
        {
            _stubs[nameof(GetTemperatureSettingsAsync_Delegate)] = del;
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

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubITemperatureSetting : ITemperatureSetting
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        long global::Sannel.House.ServerSDK.ITemperatureSetting.Id
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

        public delegate long Id_Get_Delegate();

        public StubITemperatureSetting Id_Get(Id_Get_Delegate del)
        {
            _stubs[nameof(Id_Get_Delegate)] = del;
            return this;
        }

        public delegate void Id_Set_Delegate(long value);

        public StubITemperatureSetting Id_Set(Id_Set_Delegate del)
        {
            _stubs[nameof(Id_Set_Delegate)] = del;
            return this;
        }

        short? global::Sannel.House.ServerSDK.ITemperatureSetting.DayOfWeek
        {
            get
            {
                return ((DayOfWeek_Get_Delegate)_stubs[nameof(DayOfWeek_Get_Delegate)]).Invoke();
            }

            set
            {
                ((DayOfWeek_Set_Delegate)_stubs[nameof(DayOfWeek_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate short? DayOfWeek_Get_Delegate();

        public StubITemperatureSetting DayOfWeek_Get(DayOfWeek_Get_Delegate del)
        {
            _stubs[nameof(DayOfWeek_Get_Delegate)] = del;
            return this;
        }

        public delegate void DayOfWeek_Set_Delegate(short? value);

        public StubITemperatureSetting DayOfWeek_Set(DayOfWeek_Set_Delegate del)
        {
            _stubs[nameof(DayOfWeek_Set_Delegate)] = del;
            return this;
        }

        int? global::Sannel.House.ServerSDK.ITemperatureSetting.Month
        {
            get
            {
                return ((Month_Get_Delegate)_stubs[nameof(Month_Get_Delegate)]).Invoke();
            }

            set
            {
                ((Month_Set_Delegate)_stubs[nameof(Month_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate int? Month_Get_Delegate();

        public StubITemperatureSetting Month_Get(Month_Get_Delegate del)
        {
            _stubs[nameof(Month_Get_Delegate)] = del;
            return this;
        }

        public delegate void Month_Set_Delegate(int? value);

        public StubITemperatureSetting Month_Set(Month_Set_Delegate del)
        {
            _stubs[nameof(Month_Set_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.ServerSDK.ITemperatureSetting.IsTimeOnly
        {
            get
            {
                return ((IsTimeOnly_Get_Delegate)_stubs[nameof(IsTimeOnly_Get_Delegate)]).Invoke();
            }

            set
            {
                ((IsTimeOnly_Set_Delegate)_stubs[nameof(IsTimeOnly_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate bool IsTimeOnly_Get_Delegate();

        public StubITemperatureSetting IsTimeOnly_Get(IsTimeOnly_Get_Delegate del)
        {
            _stubs[nameof(IsTimeOnly_Get_Delegate)] = del;
            return this;
        }

        public delegate void IsTimeOnly_Set_Delegate(bool value);

        public StubITemperatureSetting IsTimeOnly_Set(IsTimeOnly_Set_Delegate del)
        {
            _stubs[nameof(IsTimeOnly_Set_Delegate)] = del;
            return this;
        }

        global::System.DateTimeOffset? global::Sannel.House.ServerSDK.ITemperatureSetting.StartTime
        {
            get
            {
                return ((StartTime_Get_Delegate)_stubs[nameof(StartTime_Get_Delegate)]).Invoke();
            }

            set
            {
                ((StartTime_Set_Delegate)_stubs[nameof(StartTime_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::System.DateTimeOffset? StartTime_Get_Delegate();

        public StubITemperatureSetting StartTime_Get(StartTime_Get_Delegate del)
        {
            _stubs[nameof(StartTime_Get_Delegate)] = del;
            return this;
        }

        public delegate void StartTime_Set_Delegate(global::System.DateTimeOffset? value);

        public StubITemperatureSetting StartTime_Set(StartTime_Set_Delegate del)
        {
            _stubs[nameof(StartTime_Set_Delegate)] = del;
            return this;
        }

        global::System.DateTimeOffset? global::Sannel.House.ServerSDK.ITemperatureSetting.EndTime
        {
            get
            {
                return ((EndTime_Get_Delegate)_stubs[nameof(EndTime_Get_Delegate)]).Invoke();
            }

            set
            {
                ((EndTime_Set_Delegate)_stubs[nameof(EndTime_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::System.DateTimeOffset? EndTime_Get_Delegate();

        public StubITemperatureSetting EndTime_Get(EndTime_Get_Delegate del)
        {
            _stubs[nameof(EndTime_Get_Delegate)] = del;
            return this;
        }

        public delegate void EndTime_Set_Delegate(global::System.DateTimeOffset? value);

        public StubITemperatureSetting EndTime_Set(EndTime_Set_Delegate del)
        {
            _stubs[nameof(EndTime_Set_Delegate)] = del;
            return this;
        }

        double global::Sannel.House.ServerSDK.ITemperatureSetting.HeatTemperatureCelsius
        {
            get
            {
                return ((HeatTemperatureCelsius_Get_Delegate)_stubs[nameof(HeatTemperatureCelsius_Get_Delegate)]).Invoke();
            }

            set
            {
                ((HeatTemperatureCelsius_Set_Delegate)_stubs[nameof(HeatTemperatureCelsius_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate double HeatTemperatureCelsius_Get_Delegate();

        public StubITemperatureSetting HeatTemperatureCelsius_Get(HeatTemperatureCelsius_Get_Delegate del)
        {
            _stubs[nameof(HeatTemperatureCelsius_Get_Delegate)] = del;
            return this;
        }

        public delegate void HeatTemperatureCelsius_Set_Delegate(double value);

        public StubITemperatureSetting HeatTemperatureCelsius_Set(HeatTemperatureCelsius_Set_Delegate del)
        {
            _stubs[nameof(HeatTemperatureCelsius_Set_Delegate)] = del;
            return this;
        }

        double global::Sannel.House.ServerSDK.ITemperatureSetting.CoolTemperatureCelsius
        {
            get
            {
                return ((CoolTemperatureCelsius_Get_Delegate)_stubs[nameof(CoolTemperatureCelsius_Get_Delegate)]).Invoke();
            }

            set
            {
                ((CoolTemperatureCelsius_Set_Delegate)_stubs[nameof(CoolTemperatureCelsius_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate double CoolTemperatureCelsius_Get_Delegate();

        public StubITemperatureSetting CoolTemperatureCelsius_Get(CoolTemperatureCelsius_Get_Delegate del)
        {
            _stubs[nameof(CoolTemperatureCelsius_Get_Delegate)] = del;
            return this;
        }

        public delegate void CoolTemperatureCelsius_Set_Delegate(double value);

        public StubITemperatureSetting CoolTemperatureCelsius_Set(CoolTemperatureCelsius_Set_Delegate del)
        {
            _stubs[nameof(CoolTemperatureCelsius_Set_Delegate)] = del;
            return this;
        }

        global::System.DateTimeOffset global::Sannel.House.ServerSDK.ITemperatureSetting.DateCreated
        {
            get
            {
                return ((DateCreated_Get_Delegate)_stubs[nameof(DateCreated_Get_Delegate)]).Invoke();
            }

            set
            {
                ((DateCreated_Set_Delegate)_stubs[nameof(DateCreated_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::System.DateTimeOffset DateCreated_Get_Delegate();

        public StubITemperatureSetting DateCreated_Get(DateCreated_Get_Delegate del)
        {
            _stubs[nameof(DateCreated_Get_Delegate)] = del;
            return this;
        }

        public delegate void DateCreated_Set_Delegate(global::System.DateTimeOffset value);

        public StubITemperatureSetting DateCreated_Set(DateCreated_Set_Delegate del)
        {
            _stubs[nameof(DateCreated_Set_Delegate)] = del;
            return this;
        }

        global::System.DateTimeOffset global::Sannel.House.ServerSDK.ITemperatureSetting.DateModified
        {
            get
            {
                return ((DateModified_Get_Delegate)_stubs[nameof(DateModified_Get_Delegate)]).Invoke();
            }

            set
            {
                ((DateModified_Set_Delegate)_stubs[nameof(DateModified_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::System.DateTimeOffset DateModified_Get_Delegate();

        public StubITemperatureSetting DateModified_Get(DateModified_Get_Delegate del)
        {
            _stubs[nameof(DateModified_Get_Delegate)] = del;
            return this;
        }

        public delegate void DateModified_Set_Delegate(global::System.DateTimeOffset value);

        public StubITemperatureSetting DateModified_Set(DateModified_Set_Delegate del)
        {
            _stubs[nameof(DateModified_Set_Delegate)] = del;
            return this;
        }
    }
}