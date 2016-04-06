using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;
using Windows.Storage;

namespace Sannel.House.Control.Models
{
	public class AppSettings
	{
		private const String RESOURCE = "sannel.com/House";
		private ApplicationDataContainer settings;

		public static AppSettings Current { get; } = new AppSettings();

		private AppSettings()
		{
			settings = ApplicationData.Current.LocalSettings;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void firePropertyChanged(String property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}

		private void set<T>(T value, [CallerMemberName]String key = null)
		{
			settings.Values[key] = value;
			firePropertyChanged(key);
		}

		private T get<T>([CallerMemberName]String key = null, T def = default(T))
		{
			Object v = settings.Values[key];
			if(v is T)
			{
				return (T)v;
			}
			return def;
		}

		public String Username
		{
			get
			{
				return get<String>();
			}
			set
			{
				set<String>(value);
			}
		}


		public void StorePassword(String password)
		{
			try
			{
				var passwordVault = new Windows.Security.Credentials.PasswordVault();
				passwordVault.Add(new Windows.Security.Credentials.PasswordCredential(RESOURCE, Username, password));
			}
			catch { }
		}

		public void DeleteStoredPassword()
		{
			try
			{
				var passwordVault = new PasswordVault();
				var list = passwordVault.FindAllByResource(RESOURCE);
				foreach (var item in list)
				{
					if (String.Compare(item.UserName, Username, StringComparison.CurrentCultureIgnoreCase) == 0)
					{
						passwordVault.Remove(item);
					}
				}
			}
			catch { }
		}

		public string GetStoredPassword()
		{
			try
			{
				var passwordValut = new Windows.Security.Credentials.PasswordVault();
				var creds = passwordValut.Retrieve(RESOURCE, Username);
				return creds.Password;
			}
			catch
			{
				return null;
			}
		}

		public String WUndergroundApiKey
		{
			get
			{
				return get<String>();
			}
			set
			{
				set<String>(value);
			}
		}

		public string WUndergroundState
		{
			get
			{
				return get<String>();
			}
			set
			{
				set<String>(value);
			}
		}

		public string WUndergroundCity
		{
			get
			{
				return get<String>();
			}
			set
			{
				set<String>(value);
			}
		}
	}
}
