using System;
using System.Text;
using Xamarin.Forms;
namespace EBTimeLogCreator
{
    public class AccountView : ContentPage
    {
        public Entry Username { get; }
        public Entry Password { get; }
        public View userInfo { get; }

        public AccountView( )
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
                Keyboard = Keyboard.Email
            });

            panel.Children.Add(new Label
            {
                Text = "Password",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            });

            panel.Children.Add(Password = new Entry
            {
                Placeholder = "Password",
                IsPassword = true
            });

            userInfo.Content = panel;

            this.userInfo = userInfo;
        }

        internal string AuthString()
        {
            var str = new StringBuilder();
            str.Append(Username.Text);
            str.Append(":");
            str.Append(Password.Text);

            byte[] bytes = Encoding.Default.GetBytes(str.ToString());

            var base64String = System.Convert.ToBase64String(bytes);

            return "Basic " + base64String;
        }
    }
}
