// Helpers/Settings.cs
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace HamburgerMenu.Helpers
{
    public class Settings : INotifyPropertyChanged
    {
        private static Lazy<Settings> SettingsInstance = new Lazy<Settings>(() => new Settings());

        public static Settings Current => SettingsInstance.Value;

        private Settings()
        {
        }

        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            if(!string.IsNullOrWhiteSpace(propertyName))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        bool SetProperty<T>(T value, T defaultValue = default(T), [CallerMemberName] string propertyName = null)
        {
            if(string.IsNullOrWhiteSpace(propertyName)) return false;

            if(Equals(AppSettings.GetValueOrDefault<T>(propertyName, defaultValue), value)) return false;

            AppSettings.AddOrUpdateValue(propertyName, value);
            RaisePropertyChanged(propertyName);

            return true;
        }

        #endregion INotifyPropertyChanged

        T GetProperty<T>(T defaultValue = default(T), [CallerMemberName]string propertyName = null)
        {
            if(string.IsNullOrWhiteSpace(propertyName))
                return defaultValue;

            return AppSettings.GetValueOrDefault(propertyName, defaultValue);
        }

        public string UserName
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }
    }
}