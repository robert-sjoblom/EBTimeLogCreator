using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace EBTimeLogCreator
{
    public class AccountView : ContentPage
    {
        public Entry Username { get; }
        public Entry Password { get; }
        public View UserInfo { get; }

        public AccountView()
        {
            Expander userInfo = new Expander
            {
                Header = new Label
                {
                    Text = "Account",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    TextColor = Color.DarkCyan,
                    Padding = new Thickness(0, 35, 0, 0)
                }
            };

            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };

            panel.Children.Add(new Label
            {
                Text = "Username",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            });

            panel.Children.Add(Username = new Entry
            {
                Placeholder = "Username",
                Keyboard = Keyboard.Email,
                Text = GetValueFromSecureStorageAndWait("username")
            });

            panel.Children.Add(new Label
            {
                Text = "Password",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            });

            panel.Children.Add(Password = new Entry
            {
                Placeholder = "Password",
                IsPassword = true,
                Text = GetValueFromSecureStorageAndWait("password")
            });

            userInfo.Content = panel;

            UserInfo = userInfo;
        }

        // HACK this is an antipattern, but we'll do it like this for now
        // 2020-11-17
        private string GetValueFromSecureStorageAndWait(string value)
        {
            Task<string> task = GetValueAsync(value);
            task.Wait();
            return task.Result;
        }

        private async Task<string> GetValueAsync(string value)
        {
            try
            {
                return await SecureStorage.GetAsync(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal string AuthString()
        {
            StringBuilder str = new StringBuilder();
            _ = str.Append(Username.Text);
            _ = str.Append(":");
            _ = str.Append(Password.Text);

            byte[] bytes = Encoding.Default.GetBytes(str.ToString());

            string base64String = Convert.ToBase64String(bytes);

            return "Basic " + base64String;
        }

        public async void SaveCredentials()
        {
            await SaveCredentialAsync(Username, "username");
            await SaveCredentialAsync(Password, "password");
        }

        private async Task SaveCredentialAsync(Entry entry, string key)
        {
            if (!string.IsNullOrWhiteSpace(entry.Text))
            {
                try
                {
                    await SecureStorage.SetAsync(key, entry.Text);
                }

                catch (Exception)
                {
                    DependencyService.Get<IMessage>()
                                     .ShortAlert("Failed to store user credentials");
                }
            }
        }

    }
}
