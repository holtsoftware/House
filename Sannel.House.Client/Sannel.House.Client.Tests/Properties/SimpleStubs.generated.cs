using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubIServerContext : IServerContext
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::System.Threading.Tasks.Task<bool> global::Sannel.House.Client.Interfaces.IServerContext.LoginAsync(string username, string password)
        {
            return ((LoginAsync_String_String_Delegate)_stubs[nameof(LoginAsync_String_String_Delegate)]).Invoke(username, password);
        }

        public delegate global::System.Threading.Tasks.Task<bool> LoginAsync_String_String_Delegate(string username, string password);

        public StubIServerContext LoginAsync(LoginAsync_String_String_Delegate del)
        {
            _stubs[nameof(LoginAsync_String_String_Delegate)] = del;
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
    }
}

namespace Sannel.House.Client.Interfaces
{
    [CompilerGenerated]
    public class StubIShellViewModel : IShellViewModel
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

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
    }
}