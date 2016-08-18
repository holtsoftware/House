using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Sannel.House.Client.Models;

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubIBaseViewModel : IBaseViewModel
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        bool global::Sannel.House.Client.Interfaces.IBaseViewModel.IsBusy
        {
            get
            {
                return ((IsBusy_Get_Delegate)_stubs[nameof(IsBusy_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IsBusy_Get_Delegate();

        public StubIBaseViewModel IsBusy_Get(IsBusy_Get_Delegate del)
        {
            _stubs[nameof(IsBusy_Get_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedTo(object arg)
        {
            ((NavigatedTo_Object_Delegate)_stubs[nameof(NavigatedTo_Object_Delegate)]).Invoke(arg);
        }

        public delegate void NavigatedTo_Object_Delegate(object arg);

        public StubIBaseViewModel NavigatedTo(NavigatedTo_Object_Delegate del)
        {
            _stubs[nameof(NavigatedTo_Object_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedFrom()
        {
            ((NavigatedFrom_Delegate)_stubs[nameof(NavigatedFrom_Delegate)]).Invoke();
        }

        public delegate void NavigatedFrom_Delegate();

        public StubIBaseViewModel NavigatedFrom(NavigatedFrom_Delegate del)
        {
            _stubs[nameof(NavigatedFrom_Delegate)] = del;
            return this;
        }

        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void On_PropertyChanged(object sender)
        {
            global::System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) { handler(sender, null); }
        }

        public void PropertyChanged_Raise(object sender)
        {
            On_PropertyChanged(sender);
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubIErrorViewModel : IErrorViewModel
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Collections.ObjectModel.ObservableCollection<string> global::Sannel.House.Client.Interfaces.IErrorViewModel.ErrorKeys
        {
            get
            {
                return ((ErrorKeys_Get_Delegate)_stubs[nameof(ErrorKeys_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Collections.ObjectModel.ObservableCollection<string> ErrorKeys_Get_Delegate();

        public StubIErrorViewModel ErrorKeys_Get(ErrorKeys_Get_Delegate del)
        {
            _stubs[nameof(ErrorKeys_Get_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Client.Interfaces.IErrorViewModel.HasErrors
        {
            get
            {
                return ((HasErrors_Get_Delegate)_stubs[nameof(HasErrors_Get_Delegate)]).Invoke();
            }

            set
            {
                ((HasErrors_Set_Delegate)_stubs[nameof(HasErrors_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate bool HasErrors_Get_Delegate();

        public StubIErrorViewModel HasErrors_Get(HasErrors_Get_Delegate del)
        {
            _stubs[nameof(HasErrors_Get_Delegate)] = del;
            return this;
        }

        public delegate void HasErrors_Set_Delegate(bool value);

        public StubIErrorViewModel HasErrors_Set(HasErrors_Set_Delegate del)
        {
            _stubs[nameof(HasErrors_Set_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Client.Interfaces.IBaseViewModel.IsBusy
        {
            get
            {
                return ((IBaseViewModel_IsBusy_Get_Delegate)_stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IBaseViewModel_IsBusy_Get_Delegate();

        public StubIErrorViewModel IsBusy_Get(IBaseViewModel_IsBusy_Get_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedTo(object arg)
        {
            ((IBaseViewModel_NavigatedTo_Object_Delegate)_stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)]).Invoke(arg);
        }

        public delegate void IBaseViewModel_NavigatedTo_Object_Delegate(object arg);

        public StubIErrorViewModel NavigatedTo(IBaseViewModel_NavigatedTo_Object_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedFrom()
        {
            ((IBaseViewModel_NavigatedFrom_Delegate)_stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)]).Invoke();
        }

        public delegate void IBaseViewModel_NavigatedFrom_Delegate();

        public StubIErrorViewModel NavigatedFrom(IBaseViewModel_NavigatedFrom_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)] = del;
            return this;
        }

        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void On_PropertyChanged(object sender)
        {
            global::System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) { handler(sender, null); }
        }

        public void PropertyChanged_Raise(object sender)
        {
            On_PropertyChanged(sender);
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubIHomeViewModel : IHomeViewModel
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        bool global::Sannel.House.Client.Interfaces.IBaseViewModel.IsBusy
        {
            get
            {
                return ((IBaseViewModel_IsBusy_Get_Delegate)_stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IBaseViewModel_IsBusy_Get_Delegate();

        public StubIHomeViewModel IsBusy_Get(IBaseViewModel_IsBusy_Get_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedTo(object arg)
        {
            ((IBaseViewModel_NavigatedTo_Object_Delegate)_stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)]).Invoke(arg);
        }

        public delegate void IBaseViewModel_NavigatedTo_Object_Delegate(object arg);

        public StubIHomeViewModel NavigatedTo(IBaseViewModel_NavigatedTo_Object_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedFrom()
        {
            ((IBaseViewModel_NavigatedFrom_Delegate)_stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)]).Invoke();
        }

        public delegate void IBaseViewModel_NavigatedFrom_Delegate();

        public StubIHomeViewModel NavigatedFrom(IBaseViewModel_NavigatedFrom_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)] = del;
            return this;
        }

        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void On_PropertyChanged(object sender)
        {
            global::System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) { handler(sender, null); }
        }

        public void PropertyChanged_Raise(object sender)
        {
            On_PropertyChanged(sender);
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubINavigationService : INavigationService
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        void global::Sannel.House.Client.Interfaces.INavigationService.Navigate<T>(object parameter)
        {
            ((Navigate_Object_Delegate<T>)_stubs[nameof(Navigate_Object_Delegate<T>)]).Invoke(parameter);
        }

        public delegate void Navigate_Object_Delegate<T>(object parameter) where T : IBaseViewModel;

        public StubINavigationService Navigate<T>(Navigate_Object_Delegate<T> del) where T : IBaseViewModel
        {
            _stubs[nameof(Navigate_Object_Delegate<T>)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.INavigationService.Navigate<T>()
        {
            ((Navigate_Delegate<T>)_stubs[nameof(Navigate_Delegate<T>)]).Invoke();
        }

        public delegate void Navigate_Delegate<T>() where T : IBaseViewModel;

        public StubINavigationService Navigate<T>(Navigate_Delegate<T> del) where T : IBaseViewModel
        {
            _stubs[nameof(Navigate_Delegate<T>)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.INavigationService.Navigate(global::System.Type t, object parameter)
        {
            ((Navigate_Type_Object_Delegate)_stubs[nameof(Navigate_Type_Object_Delegate)]).Invoke(t, parameter);
        }

        public delegate void Navigate_Type_Object_Delegate(global::System.Type t, object parameter);

        public StubINavigationService Navigate(Navigate_Type_Object_Delegate del)
        {
            _stubs[nameof(Navigate_Type_Object_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.INavigationService.Navigate(global::System.Type t)
        {
            ((Navigate_Type_Delegate)_stubs[nameof(Navigate_Type_Delegate)]).Invoke(t);
        }

        public delegate void Navigate_Type_Delegate(global::System.Type t);

        public StubINavigationService Navigate(Navigate_Type_Delegate del)
        {
            _stubs[nameof(Navigate_Type_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.INavigationService.ClearHistory()
        {
            ((ClearHistory_Delegate)_stubs[nameof(ClearHistory_Delegate)]).Invoke();
        }

        public delegate void ClearHistory_Delegate();

        public StubINavigationService ClearHistory(ClearHistory_Delegate del)
        {
            _stubs[nameof(ClearHistory_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubILoginViewModel : ILoginViewModel
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        string global::Sannel.House.Client.Interfaces.ILoginViewModel.Username
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

        public StubILoginViewModel Username_Get(Username_Get_Delegate del)
        {
            _stubs[nameof(Username_Get_Delegate)] = del;
            return this;
        }

        public delegate void Username_Set_Delegate(string value);

        public StubILoginViewModel Username_Set(Username_Set_Delegate del)
        {
            _stubs[nameof(Username_Set_Delegate)] = del;
            return this;
        }

        string global::Sannel.House.Client.Interfaces.ILoginViewModel.Password
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

        public StubILoginViewModel Password_Get(Password_Get_Delegate del)
        {
            _stubs[nameof(Password_Get_Delegate)] = del;
            return this;
        }

        public delegate void Password_Set_Delegate(string value);

        public StubILoginViewModel Password_Set(Password_Set_Delegate del)
        {
            _stubs[nameof(Password_Set_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Client.Interfaces.ILoginViewModel.StayLoggedIn
        {
            get
            {
                return ((StayLoggedIn_Get_Delegate)_stubs[nameof(StayLoggedIn_Get_Delegate)]).Invoke();
            }

            set
            {
                ((StayLoggedIn_Set_Delegate)_stubs[nameof(StayLoggedIn_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate bool StayLoggedIn_Get_Delegate();

        public StubILoginViewModel StayLoggedIn_Get(StayLoggedIn_Get_Delegate del)
        {
            _stubs[nameof(StayLoggedIn_Get_Delegate)] = del;
            return this;
        }

        public delegate void StayLoggedIn_Set_Delegate(bool value);

        public StubILoginViewModel StayLoggedIn_Set(StayLoggedIn_Set_Delegate del)
        {
            _stubs[nameof(StayLoggedIn_Set_Delegate)] = del;
            return this;
        }

        global::System.Windows.Input.ICommand global::Sannel.House.Client.Interfaces.ILoginViewModel.LoginCommand
        {
            get
            {
                return ((LoginCommand_Get_Delegate)_stubs[nameof(LoginCommand_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Windows.Input.ICommand LoginCommand_Get_Delegate();

        public StubILoginViewModel LoginCommand_Get(LoginCommand_Get_Delegate del)
        {
            _stubs[nameof(LoginCommand_Get_Delegate)] = del;
            return this;
        }

        global::System.Collections.ObjectModel.ObservableCollection<string> global::Sannel.House.Client.Interfaces.IErrorViewModel.ErrorKeys
        {
            get
            {
                return ((IErrorViewModel_ErrorKeys_Get_Delegate)_stubs[nameof(IErrorViewModel_ErrorKeys_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Collections.ObjectModel.ObservableCollection<string> IErrorViewModel_ErrorKeys_Get_Delegate();

        public StubILoginViewModel ErrorKeys_Get(IErrorViewModel_ErrorKeys_Get_Delegate del)
        {
            _stubs[nameof(IErrorViewModel_ErrorKeys_Get_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Client.Interfaces.IErrorViewModel.HasErrors
        {
            get
            {
                return ((IErrorViewModel_HasErrors_Get_Delegate)_stubs[nameof(IErrorViewModel_HasErrors_Get_Delegate)]).Invoke();
            }

            set
            {
                ((IErrorViewModel_HasErrors_Set_Delegate)_stubs[nameof(IErrorViewModel_HasErrors_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate bool IErrorViewModel_HasErrors_Get_Delegate();

        public StubILoginViewModel HasErrors_Get(IErrorViewModel_HasErrors_Get_Delegate del)
        {
            _stubs[nameof(IErrorViewModel_HasErrors_Get_Delegate)] = del;
            return this;
        }

        public delegate void IErrorViewModel_HasErrors_Set_Delegate(bool value);

        public StubILoginViewModel HasErrors_Set(IErrorViewModel_HasErrors_Set_Delegate del)
        {
            _stubs[nameof(IErrorViewModel_HasErrors_Set_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Client.Interfaces.IBaseViewModel.IsBusy
        {
            get
            {
                return ((IBaseViewModel_IsBusy_Get_Delegate)_stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IBaseViewModel_IsBusy_Get_Delegate();

        public StubILoginViewModel IsBusy_Get(IBaseViewModel_IsBusy_Get_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedTo(object arg)
        {
            ((IBaseViewModel_NavigatedTo_Object_Delegate)_stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)]).Invoke(arg);
        }

        public delegate void IBaseViewModel_NavigatedTo_Object_Delegate(object arg);

        public StubILoginViewModel NavigatedTo(IBaseViewModel_NavigatedTo_Object_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedFrom()
        {
            ((IBaseViewModel_NavigatedFrom_Delegate)_stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)]).Invoke();
        }

        public delegate void IBaseViewModel_NavigatedFrom_Delegate();

        public StubILoginViewModel NavigatedFrom(IBaseViewModel_NavigatedFrom_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)] = del;
            return this;
        }

        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void On_PropertyChanged(object sender)
        {
            global::System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) { handler(sender, null); }
        }

        public void PropertyChanged_Raise(object sender)
        {
            On_PropertyChanged(sender);
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubIServerContext : IServerContext
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Threading.Tasks.Task<global::System.Tuple<bool, string>> global::Sannel.House.Client.Interfaces.IServerContext.LoginAsync(string username, string password)
        {
            return ((LoginAsync_String_String_Delegate)_stubs[nameof(LoginAsync_String_String_Delegate)]).Invoke(username, password);
        }

        public delegate global::System.Threading.Tasks.Task<global::System.Tuple<bool, string>> LoginAsync_String_String_Delegate(string username, string password);

        public StubIServerContext LoginAsync(LoginAsync_String_String_Delegate del)
        {
            _stubs[nameof(LoginAsync_String_String_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task global::Sannel.House.Client.Interfaces.IServerContext.LogOffAsync()
        {
            return ((LogOffAsync_Delegate)_stubs[nameof(LogOffAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task LogOffAsync_Delegate();

        public StubIServerContext LogOffAsync(LogOffAsync_Delegate del)
        {
            _stubs[nameof(LogOffAsync_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<global::System.Collections.Generic.IList<string>> global::Sannel.House.Client.Interfaces.IServerContext.GetRolesAsync()
        {
            return ((GetRolesAsync_Delegate)_stubs[nameof(GetRolesAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IList<string>> GetRolesAsync_Delegate();

        public StubIServerContext GetRolesAsync(GetRolesAsync_Delegate del)
        {
            _stubs[nameof(GetRolesAsync_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<global::Sannel.House.Client.Models.ClientProfile> global::Sannel.House.Client.Interfaces.IServerContext.GetProfileAsync()
        {
            return ((GetProfileAsync_Delegate)_stubs[nameof(GetProfileAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<global::Sannel.House.Client.Models.ClientProfile> GetProfileAsync_Delegate();

        public StubIServerContext GetProfileAsync(GetProfileAsync_Delegate del)
        {
            _stubs[nameof(GetProfileAsync_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<global::System.Collections.Generic.IList<global::Sannel.House.Client.Models.TemperatureSetting>> global::Sannel.House.Client.Interfaces.IServerContext.GetTemperatureSettingsAsync()
        {
            return ((GetTemperatureSettingsAsync_Delegate)_stubs[nameof(GetTemperatureSettingsAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IList<global::Sannel.House.Client.Models.TemperatureSetting>> GetTemperatureSettingsAsync_Delegate();

        public StubIServerContext GetTemperatureSettingsAsync(GetTemperatureSettingsAsync_Delegate del)
        {
            _stubs[nameof(GetTemperatureSettingsAsync_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task global::Sannel.House.Client.Interfaces.IServerContext.PutTemperatureSettingsAsync(global::Sannel.House.Client.Models.TemperatureSetting setting)
        {
            return ((PutTemperatureSettingsAsync_TemperatureSetting_Delegate)_stubs[nameof(PutTemperatureSettingsAsync_TemperatureSetting_Delegate)]).Invoke(setting);
        }

        public delegate global::System.Threading.Tasks.Task PutTemperatureSettingsAsync_TemperatureSetting_Delegate(global::Sannel.House.Client.Models.TemperatureSetting setting);

        public StubIServerContext PutTemperatureSettingsAsync(PutTemperatureSettingsAsync_TemperatureSetting_Delegate del)
        {
            _stubs[nameof(PutTemperatureSettingsAsync_TemperatureSetting_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubISettings : ISettings
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Uri global::Sannel.House.Client.Interfaces.ISettings.ServerUrl
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

        public delegate global::System.Uri ServerUrl_Get_Delegate();

        public StubISettings ServerUrl_Get(ServerUrl_Get_Delegate del)
        {
            _stubs[nameof(ServerUrl_Get_Delegate)] = del;
            return this;
        }

        public delegate void ServerUrl_Set_Delegate(global::System.Uri value);

        public StubISettings ServerUrl_Set(ServerUrl_Set_Delegate del)
        {
            _stubs[nameof(ServerUrl_Set_Delegate)] = del;
            return this;
        }

        string global::Sannel.House.Client.Interfaces.ISettings.AuthzCookieValue
        {
            get
            {
                return ((AuthzCookieValue_Get_Delegate)_stubs[nameof(AuthzCookieValue_Get_Delegate)]).Invoke();
            }

            set
            {
                ((AuthzCookieValue_Set_Delegate)_stubs[nameof(AuthzCookieValue_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate string AuthzCookieValue_Get_Delegate();

        public StubISettings AuthzCookieValue_Get(AuthzCookieValue_Get_Delegate del)
        {
            _stubs[nameof(AuthzCookieValue_Get_Delegate)] = del;
            return this;
        }

        public delegate void AuthzCookieValue_Set_Delegate(string value);

        public StubISettings AuthzCookieValue_Set(AuthzCookieValue_Set_Delegate del)
        {
            _stubs[nameof(AuthzCookieValue_Set_Delegate)] = del;
            return this;
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubISettingsViewModel : ISettingsViewModel
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        string global::Sannel.House.Client.Interfaces.ISettingsViewModel.ServerUrl
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

        public StubISettingsViewModel ServerUrl_Get(ServerUrl_Get_Delegate del)
        {
            _stubs[nameof(ServerUrl_Get_Delegate)] = del;
            return this;
        }

        public delegate void ServerUrl_Set_Delegate(string value);

        public StubISettingsViewModel ServerUrl_Set(ServerUrl_Set_Delegate del)
        {
            _stubs[nameof(ServerUrl_Set_Delegate)] = del;
            return this;
        }

        global::System.Windows.Input.ICommand global::Sannel.House.Client.Interfaces.ISettingsViewModel.ContinueCommand
        {
            get
            {
                return ((ContinueCommand_Get_Delegate)_stubs[nameof(ContinueCommand_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Windows.Input.ICommand ContinueCommand_Get_Delegate();

        public StubISettingsViewModel ContinueCommand_Get(ContinueCommand_Get_Delegate del)
        {
            _stubs[nameof(ContinueCommand_Get_Delegate)] = del;
            return this;
        }

        global::System.Collections.ObjectModel.ObservableCollection<string> global::Sannel.House.Client.Interfaces.IErrorViewModel.ErrorKeys
        {
            get
            {
                return ((IErrorViewModel_ErrorKeys_Get_Delegate)_stubs[nameof(IErrorViewModel_ErrorKeys_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Collections.ObjectModel.ObservableCollection<string> IErrorViewModel_ErrorKeys_Get_Delegate();

        public StubISettingsViewModel ErrorKeys_Get(IErrorViewModel_ErrorKeys_Get_Delegate del)
        {
            _stubs[nameof(IErrorViewModel_ErrorKeys_Get_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Client.Interfaces.IErrorViewModel.HasErrors
        {
            get
            {
                return ((IErrorViewModel_HasErrors_Get_Delegate)_stubs[nameof(IErrorViewModel_HasErrors_Get_Delegate)]).Invoke();
            }

            set
            {
                ((IErrorViewModel_HasErrors_Set_Delegate)_stubs[nameof(IErrorViewModel_HasErrors_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate bool IErrorViewModel_HasErrors_Get_Delegate();

        public StubISettingsViewModel HasErrors_Get(IErrorViewModel_HasErrors_Get_Delegate del)
        {
            _stubs[nameof(IErrorViewModel_HasErrors_Get_Delegate)] = del;
            return this;
        }

        public delegate void IErrorViewModel_HasErrors_Set_Delegate(bool value);

        public StubISettingsViewModel HasErrors_Set(IErrorViewModel_HasErrors_Set_Delegate del)
        {
            _stubs[nameof(IErrorViewModel_HasErrors_Set_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Client.Interfaces.IBaseViewModel.IsBusy
        {
            get
            {
                return ((IBaseViewModel_IsBusy_Get_Delegate)_stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IBaseViewModel_IsBusy_Get_Delegate();

        public StubISettingsViewModel IsBusy_Get(IBaseViewModel_IsBusy_Get_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedTo(object arg)
        {
            ((IBaseViewModel_NavigatedTo_Object_Delegate)_stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)]).Invoke(arg);
        }

        public delegate void IBaseViewModel_NavigatedTo_Object_Delegate(object arg);

        public StubISettingsViewModel NavigatedTo(IBaseViewModel_NavigatedTo_Object_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedFrom()
        {
            ((IBaseViewModel_NavigatedFrom_Delegate)_stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)]).Invoke();
        }

        public delegate void IBaseViewModel_NavigatedFrom_Delegate();

        public StubISettingsViewModel NavigatedFrom(IBaseViewModel_NavigatedFrom_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)] = del;
            return this;
        }

        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void On_PropertyChanged(object sender)
        {
            global::System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) { handler(sender, null); }
        }

        public void PropertyChanged_Raise(object sender)
        {
            On_PropertyChanged(sender);
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubIShellViewModel : IShellViewModel
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        bool global::Sannel.House.Client.Interfaces.IShellViewModel.IsBusy
        {
            get
            {
                return ((IsBusy_Get_Delegate)_stubs[nameof(IsBusy_Get_Delegate)]).Invoke();
            }

            set
            {
                ((IsBusy_Set_Delegate)_stubs[nameof(IsBusy_Set_Delegate)]).Invoke(value);
            }

            get
            {
                return ((IBaseViewModel_IsBusy_Get_Delegate)_stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IsBusy_Get_Delegate();

        public StubIShellViewModel IsBusy_Get(IsBusy_Get_Delegate del)
        {
            _stubs[nameof(IsBusy_Get_Delegate)] = del;
            return this;
        }

        public delegate void IsBusy_Set_Delegate(bool value);

        public StubIShellViewModel IsBusy_Set(IsBusy_Set_Delegate del)
        {
            _stubs[nameof(IsBusy_Set_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Client.Interfaces.IShellViewModel.IsPaneOpen
        {
            get
            {
                return ((IsPaneOpen_Get_Delegate)_stubs[nameof(IsPaneOpen_Get_Delegate)]).Invoke();
            }

            set
            {
                ((IsPaneOpen_Set_Delegate)_stubs[nameof(IsPaneOpen_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate bool IsPaneOpen_Get_Delegate();

        public StubIShellViewModel IsPaneOpen_Get(IsPaneOpen_Get_Delegate del)
        {
            _stubs[nameof(IsPaneOpen_Get_Delegate)] = del;
            return this;
        }

        public delegate void IsPaneOpen_Set_Delegate(bool value);

        public StubIShellViewModel IsPaneOpen_Set(IsPaneOpen_Set_Delegate del)
        {
            _stubs[nameof(IsPaneOpen_Set_Delegate)] = del;
            return this;
        }

        global::Sannel.House.Client.Interfaces.IUser global::Sannel.House.Client.Interfaces.IShellViewModel.User
        {
            get
            {
                return ((User_Get_Delegate)_stubs[nameof(User_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::Sannel.House.Client.Interfaces.IUser User_Get_Delegate();

        public StubIShellViewModel User_Get(User_Get_Delegate del)
        {
            _stubs[nameof(User_Get_Delegate)] = del;
            return this;
        }

        global::System.Collections.ObjectModel.ObservableCollection<global::Sannel.House.Client.Models.MenuItem> global::Sannel.House.Client.Interfaces.IShellViewModel.MenuTop
        {
            get
            {
                return ((MenuTop_Get_Delegate)_stubs[nameof(MenuTop_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Collections.ObjectModel.ObservableCollection<global::Sannel.House.Client.Models.MenuItem> MenuTop_Get_Delegate();

        public StubIShellViewModel MenuTop_Get(MenuTop_Get_Delegate del)
        {
            _stubs[nameof(MenuTop_Get_Delegate)] = del;
            return this;
        }

        global::System.Collections.ObjectModel.ObservableCollection<global::Sannel.House.Client.Models.MenuItem> global::Sannel.House.Client.Interfaces.IShellViewModel.MenuBottom
        {
            get
            {
                return ((MenuBottom_Get_Delegate)_stubs[nameof(MenuBottom_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Collections.ObjectModel.ObservableCollection<global::Sannel.House.Client.Models.MenuItem> MenuBottom_Get_Delegate();

        public StubIShellViewModel MenuBottom_Get(MenuBottom_Get_Delegate del)
        {
            _stubs[nameof(MenuBottom_Get_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IShellViewModel.MenuItemClick(global::Sannel.House.Client.Models.MenuItem item)
        {
            ((MenuItemClick_MenuItem_Delegate)_stubs[nameof(MenuItemClick_MenuItem_Delegate)]).Invoke(item);
        }

        public delegate void MenuItemClick_MenuItem_Delegate(global::Sannel.House.Client.Models.MenuItem item);

        public StubIShellViewModel MenuItemClick(MenuItemClick_MenuItem_Delegate del)
        {
            _stubs[nameof(MenuItemClick_MenuItem_Delegate)] = del;
            return this;
        }

        public delegate bool IBaseViewModel_IsBusy_Get_Delegate();

        public StubIShellViewModel IsBusy_Get(IBaseViewModel_IsBusy_Get_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedTo(object arg)
        {
            ((IBaseViewModel_NavigatedTo_Object_Delegate)_stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)]).Invoke(arg);
        }

        public delegate void IBaseViewModel_NavigatedTo_Object_Delegate(object arg);

        public StubIShellViewModel NavigatedTo(IBaseViewModel_NavigatedTo_Object_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedFrom()
        {
            ((IBaseViewModel_NavigatedFrom_Delegate)_stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)]).Invoke();
        }

        public delegate void IBaseViewModel_NavigatedFrom_Delegate();

        public StubIShellViewModel NavigatedFrom(IBaseViewModel_NavigatedFrom_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)] = del;
            return this;
        }

        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void On_PropertyChanged(object sender)
        {
            global::System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) { handler(sender, null); }
        }

        public void PropertyChanged_Raise(object sender)
        {
            On_PropertyChanged(sender);
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubITemperatureSettingViewModel : ITemperatureSettingViewModel
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::Sannel.House.Client.Models.TemperatureSetting global::Sannel.House.Client.Interfaces.ITemperatureSettingViewModel.SundayDefault
        {
            get
            {
                return ((SundayDefault_Get_Delegate)_stubs[nameof(SundayDefault_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::Sannel.House.Client.Models.TemperatureSetting SundayDefault_Get_Delegate();

        public StubITemperatureSettingViewModel SundayDefault_Get(SundayDefault_Get_Delegate del)
        {
            _stubs[nameof(SundayDefault_Get_Delegate)] = del;
            return this;
        }

        global::Sannel.House.Client.Models.TemperatureSetting global::Sannel.House.Client.Interfaces.ITemperatureSettingViewModel.MondayDefault
        {
            get
            {
                return ((MondayDefault_Get_Delegate)_stubs[nameof(MondayDefault_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::Sannel.House.Client.Models.TemperatureSetting MondayDefault_Get_Delegate();

        public StubITemperatureSettingViewModel MondayDefault_Get(MondayDefault_Get_Delegate del)
        {
            _stubs[nameof(MondayDefault_Get_Delegate)] = del;
            return this;
        }

        global::Sannel.House.Client.Models.TemperatureSetting global::Sannel.House.Client.Interfaces.ITemperatureSettingViewModel.TuesdayDefault
        {
            get
            {
                return ((TuesdayDefault_Get_Delegate)_stubs[nameof(TuesdayDefault_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::Sannel.House.Client.Models.TemperatureSetting TuesdayDefault_Get_Delegate();

        public StubITemperatureSettingViewModel TuesdayDefault_Get(TuesdayDefault_Get_Delegate del)
        {
            _stubs[nameof(TuesdayDefault_Get_Delegate)] = del;
            return this;
        }

        global::Sannel.House.Client.Models.TemperatureSetting global::Sannel.House.Client.Interfaces.ITemperatureSettingViewModel.WednesdayDefault
        {
            get
            {
                return ((WednesdayDefault_Get_Delegate)_stubs[nameof(WednesdayDefault_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::Sannel.House.Client.Models.TemperatureSetting WednesdayDefault_Get_Delegate();

        public StubITemperatureSettingViewModel WednesdayDefault_Get(WednesdayDefault_Get_Delegate del)
        {
            _stubs[nameof(WednesdayDefault_Get_Delegate)] = del;
            return this;
        }

        global::Sannel.House.Client.Models.TemperatureSetting global::Sannel.House.Client.Interfaces.ITemperatureSettingViewModel.ThursdayDefault
        {
            get
            {
                return ((ThursdayDefault_Get_Delegate)_stubs[nameof(ThursdayDefault_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::Sannel.House.Client.Models.TemperatureSetting ThursdayDefault_Get_Delegate();

        public StubITemperatureSettingViewModel ThursdayDefault_Get(ThursdayDefault_Get_Delegate del)
        {
            _stubs[nameof(ThursdayDefault_Get_Delegate)] = del;
            return this;
        }

        global::Sannel.House.Client.Models.TemperatureSetting global::Sannel.House.Client.Interfaces.ITemperatureSettingViewModel.FridayDefault
        {
            get
            {
                return ((FridayDefault_Get_Delegate)_stubs[nameof(FridayDefault_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::Sannel.House.Client.Models.TemperatureSetting FridayDefault_Get_Delegate();

        public StubITemperatureSettingViewModel FridayDefault_Get(FridayDefault_Get_Delegate del)
        {
            _stubs[nameof(FridayDefault_Get_Delegate)] = del;
            return this;
        }

        global::Sannel.House.Client.Models.TemperatureSetting global::Sannel.House.Client.Interfaces.ITemperatureSettingViewModel.SaturdayDefault
        {
            get
            {
                return ((SaturdayDefault_Get_Delegate)_stubs[nameof(SaturdayDefault_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::Sannel.House.Client.Models.TemperatureSetting SaturdayDefault_Get_Delegate();

        public StubITemperatureSettingViewModel SaturdayDefault_Get(SaturdayDefault_Get_Delegate del)
        {
            _stubs[nameof(SaturdayDefault_Get_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.ITemperatureSettingViewModel.Refresh()
        {
            ((Refresh_Delegate)_stubs[nameof(Refresh_Delegate)]).Invoke();
        }

        public delegate void Refresh_Delegate();

        public StubITemperatureSettingViewModel Refresh(Refresh_Delegate del)
        {
            _stubs[nameof(Refresh_Delegate)] = del;
            return this;
        }

        global::System.Windows.Input.ICommand global::Sannel.House.Client.Interfaces.ITemperatureSettingViewModel.UpdateDefaultCommand
        {
            get
            {
                return ((UpdateDefaultCommand_Get_Delegate)_stubs[nameof(UpdateDefaultCommand_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Windows.Input.ICommand UpdateDefaultCommand_Get_Delegate();

        public StubITemperatureSettingViewModel UpdateDefaultCommand_Get(UpdateDefaultCommand_Get_Delegate del)
        {
            _stubs[nameof(UpdateDefaultCommand_Get_Delegate)] = del;
            return this;
        }

        global::System.Collections.ObjectModel.ObservableCollection<string> global::Sannel.House.Client.Interfaces.IErrorViewModel.ErrorKeys
        {
            get
            {
                return ((IErrorViewModel_ErrorKeys_Get_Delegate)_stubs[nameof(IErrorViewModel_ErrorKeys_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Collections.ObjectModel.ObservableCollection<string> IErrorViewModel_ErrorKeys_Get_Delegate();

        public StubITemperatureSettingViewModel ErrorKeys_Get(IErrorViewModel_ErrorKeys_Get_Delegate del)
        {
            _stubs[nameof(IErrorViewModel_ErrorKeys_Get_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Client.Interfaces.IErrorViewModel.HasErrors
        {
            get
            {
                return ((IErrorViewModel_HasErrors_Get_Delegate)_stubs[nameof(IErrorViewModel_HasErrors_Get_Delegate)]).Invoke();
            }

            set
            {
                ((IErrorViewModel_HasErrors_Set_Delegate)_stubs[nameof(IErrorViewModel_HasErrors_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate bool IErrorViewModel_HasErrors_Get_Delegate();

        public StubITemperatureSettingViewModel HasErrors_Get(IErrorViewModel_HasErrors_Get_Delegate del)
        {
            _stubs[nameof(IErrorViewModel_HasErrors_Get_Delegate)] = del;
            return this;
        }

        public delegate void IErrorViewModel_HasErrors_Set_Delegate(bool value);

        public StubITemperatureSettingViewModel HasErrors_Set(IErrorViewModel_HasErrors_Set_Delegate del)
        {
            _stubs[nameof(IErrorViewModel_HasErrors_Set_Delegate)] = del;
            return this;
        }

        bool global::Sannel.House.Client.Interfaces.IBaseViewModel.IsBusy
        {
            get
            {
                return ((IBaseViewModel_IsBusy_Get_Delegate)_stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IBaseViewModel_IsBusy_Get_Delegate();

        public StubITemperatureSettingViewModel IsBusy_Get(IBaseViewModel_IsBusy_Get_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_IsBusy_Get_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedTo(object arg)
        {
            ((IBaseViewModel_NavigatedTo_Object_Delegate)_stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)]).Invoke(arg);
        }

        public delegate void IBaseViewModel_NavigatedTo_Object_Delegate(object arg);

        public StubITemperatureSettingViewModel NavigatedTo(IBaseViewModel_NavigatedTo_Object_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedTo_Object_Delegate)] = del;
            return this;
        }

        void global::Sannel.House.Client.Interfaces.IBaseViewModel.NavigatedFrom()
        {
            ((IBaseViewModel_NavigatedFrom_Delegate)_stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)]).Invoke();
        }

        public delegate void IBaseViewModel_NavigatedFrom_Delegate();

        public StubITemperatureSettingViewModel NavigatedFrom(IBaseViewModel_NavigatedFrom_Delegate del)
        {
            _stubs[nameof(IBaseViewModel_NavigatedFrom_Delegate)] = del;
            return this;
        }

        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void On_PropertyChanged(object sender)
        {
            global::System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) { handler(sender, null); }
        }

        public void PropertyChanged_Raise(object sender)
        {
            On_PropertyChanged(sender);
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubIUser : IUser
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        bool global::Sannel.House.Client.Interfaces.IUser.IsLoggedIn
        {
            get
            {
                return ((IsLoggedIn_Get_Delegate)_stubs[nameof(IsLoggedIn_Get_Delegate)]).Invoke();
            }
        }

        public delegate bool IsLoggedIn_Get_Delegate();

        public StubIUser IsLoggedIn_Get(IsLoggedIn_Get_Delegate del)
        {
            _stubs[nameof(IsLoggedIn_Get_Delegate)] = del;
            return this;
        }

        string global::Sannel.House.Client.Interfaces.IUser.Name
        {
            get
            {
                return ((Name_Get_Delegate)_stubs[nameof(Name_Get_Delegate)]).Invoke();
            }
        }

        public delegate string Name_Get_Delegate();

        public StubIUser Name_Get(Name_Get_Delegate del)
        {
            _stubs[nameof(Name_Get_Delegate)] = del;
            return this;
        }

        global::System.Collections.ObjectModel.ObservableCollection<string> global::Sannel.House.Client.Interfaces.IUser.Groups
        {
            get
            {
                return ((Groups_Get_Delegate)_stubs[nameof(Groups_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Collections.ObjectModel.ObservableCollection<string> Groups_Get_Delegate();

        public StubIUser Groups_Get(Groups_Get_Delegate del)
        {
            _stubs[nameof(Groups_Get_Delegate)] = del;
            return this;
        }

        global::System.Collections.ObjectModel.ObservableCollection<global::Sannel.House.Client.Models.MenuItem> global::Sannel.House.Client.Interfaces.IUser.MenuTop
        {
            get
            {
                return ((MenuTop_Get_Delegate)_stubs[nameof(MenuTop_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Collections.ObjectModel.ObservableCollection<global::Sannel.House.Client.Models.MenuItem> MenuTop_Get_Delegate();

        public StubIUser MenuTop_Get(MenuTop_Get_Delegate del)
        {
            _stubs[nameof(MenuTop_Get_Delegate)] = del;
            return this;
        }

        global::System.Collections.ObjectModel.ObservableCollection<global::Sannel.House.Client.Models.MenuItem> global::Sannel.House.Client.Interfaces.IUser.MenuBottom
        {
            get
            {
                return ((MenuBottom_Get_Delegate)_stubs[nameof(MenuBottom_Get_Delegate)]).Invoke();
            }
        }

        public delegate global::System.Collections.ObjectModel.ObservableCollection<global::Sannel.House.Client.Models.MenuItem> MenuBottom_Get_Delegate();

        public StubIUser MenuBottom_Get(MenuBottom_Get_Delegate del)
        {
            _stubs[nameof(MenuBottom_Get_Delegate)] = del;
            return this;
        }

        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void On_PropertyChanged(object sender)
        {
            global::System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) { handler(sender, null); }
        }

        public void PropertyChanged_Raise(object sender)
        {
            On_PropertyChanged(sender);
        }
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubIUserManager : IUserManager
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Threading.Tasks.Task<bool> global::Sannel.House.Client.Interfaces.IUserManager.LoadProfileAsync()
        {
            return ((LoadProfileAsync_Delegate)_stubs[nameof(LoadProfileAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> LoadProfileAsync_Delegate();

        public StubIUserManager LoadProfileAsync(LoadProfileAsync_Delegate del)
        {
            _stubs[nameof(LoadProfileAsync_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task global::Sannel.House.Client.Interfaces.IUserManager.LogoffAsync()
        {
            return ((LogoffAsync_Delegate)_stubs[nameof(LogoffAsync_Delegate)]).Invoke();
        }

        public delegate global::System.Threading.Tasks.Task LogoffAsync_Delegate();

        public StubIUserManager LogoffAsync(LogoffAsync_Delegate del)
        {
            _stubs[nameof(LogoffAsync_Delegate)] = del;
            return this;
        }
    }
}