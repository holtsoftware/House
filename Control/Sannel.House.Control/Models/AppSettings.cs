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
			if (PropertyChanged != null)
			{
				lock (PropertyChanged)
				{
					PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(property));
				}
			}
		}

		private void setBoolean(bool value, [CallerMemberName]String key = null)
		{
			settings.Values[key] = value;
			firePropertyChanged(key);
		}

		private bool getBoolean([CallerMemberName]String key = null, bool def = false)
		{
			bool? b = settings.Values[key] as bool?;
			if (b.HasValue)
			{
				return b.Value;
			}

			settings.Values[key] = def;

			return def;
		}

		private int getInt([CallerMemberName]String key = null, int def = 0)
		{
			int? b = settings.Values[key] as int?;
			if (b.HasValue)
			{
				return b.Value;
			}

			settings.Values[key] = def;

			return def;
		}

		private void setInt(int value, [CallerMemberName]String key = null)
		{
			settings.Values[key] = value;
			firePropertyChanged(key);
		}

		private long getLong([CallerMemberName]String key = null, long def = 0)
		{
			long? b = settings.Values[key] as long?;
			if (b.HasValue)
			{
				return b.Value;
			}

			settings.Values[key] = def;

			return def;
		}

		private void setLong(long value, [CallerMemberName]String key = null)
		{
			settings.Values[key] = value;
			firePropertyChanged(key);
		}

		private String getString([CallerMemberName]String key = null, String def = null)
		{
			String s = settings.Values[key] as String;
			if (s != null)
			{
				return s;
			}

			return def;
		}

		private void setString(String value, [CallerMemberName]String key = null)
		{
			if (value == null)
			{
				settings.Values[key] = null;
			}
			else
			{
				settings.Values[key] = value;
			}
		}

		public String Username
		{
			get
			{
				return getString();
			}
			set
			{
				setString(value);
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
				return getString();
			}
			set
			{
				setString(value);
			}
		}

		public bool AutoLogin
		{
			get
			{
				return getBoolean();
			}
			set
			{
				setBoolean(value);
			}
		}

		public string WUndergroundState
		{
			get
			{
				return getString();
			}
			internal set
			{
				setString(value);
			}
		}

		public string WUndergroundCity
		{
			get
			{
				return getString();
			}
			internal set
			{
				setString(value);
			}
		}
	}
}
