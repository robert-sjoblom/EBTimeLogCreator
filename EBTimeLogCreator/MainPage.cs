using System;
using Xamarin.Forms;
namespace EBTimeLogCreator
{
    public class MainPage : ContentPage
    {
        private Entry username;
        private Entry password;
        private double fontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
        private Entry description;
        private Button submitButton;

        public MainPage()
        {
            this.Padding = new Thickness(20);

            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };

            Expander userInfo = new Expander
            {
                Header = new Label
                {
                    Text = "Account",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    TextColor = Color.DarkCyan
                }
            };

            panel.Children.Add(new Label
            {
                Text = "Username",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            });

            panel.Children.Add(username = new Entry
            {
                Placeholder = "Username",
            });

            panel.Children.Add(new Label
            {
                Text = "Password",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            });

            panel.Children.Add(password = new Entry
            {
                Placeholder = "Password",
                IsPassword = true
            });

            userInfo.Content = panel;

            StackLayout mainView = new StackLayout
            {
               Spacing = 15
            };

            mainView.Children.Add(userInfo);


            mainView.Children.Add(new Label
            {
                Text = "Create a new EB timelog",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            });

            mainView.Children.Add(new Label
            {
                Text = "Description",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            });

             mainView.Children.Add(description = new Entry
            {
                Placeholder = "Description"
             });

            mainView.Children.Add(submitButton = new Button
            {
                Text = "Submit",
                BackgroundColor = Color.ForestGreen,
            });

            this.Content = mainView;
        }
    }
}
