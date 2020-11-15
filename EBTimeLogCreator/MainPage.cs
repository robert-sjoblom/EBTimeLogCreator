using System;
using System.ComponentModel;
using Xamarin.Forms;
namespace EBTimeLogCreator
{
    public class MainPage : ContentPage
    {
        private double fontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
        private Entry description;
        private Button submitButton;
        private AccountView accountView;

        public MainPage()
        {
            this.Padding = new Thickness(20);
            this.accountView = new AccountView();


            StackLayout mainView = new StackLayout
            {
                Spacing = 15
            };

            mainView.Children.Add(accountView.userInfo);

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
                IsEnabled = false
            });


            // Check if user/pass is present for all fields
            description.PropertyChanged += OnDescriptionChange;
            accountView.Username.PropertyChanged += OnDescriptionChange;
            accountView.Password.PropertyChanged += OnDescriptionChange;

            submitButton.Clicked += OnSubmit;

            this.Content = mainView;
        }

        private void OnDescriptionChange(object sender, PropertyChangedEventArgs e)
        {
            string enteredText = description.Text;

            if (!CredentialsExist())
            {
                submitButton.IsEnabled = false;
                return;
            }

            if (!string.IsNullOrEmpty(enteredText))
            {
                submitButton.IsEnabled = true;
            }
            else
            {
                submitButton.IsEnabled = false;
            }

        }

        private void OnSubmit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private bool CredentialsExist()
        {
            return (IsUsernamePresent() && IsPasswordPresent());
        }

        private bool IsUsernamePresent()
        {
            return !(string.IsNullOrEmpty(accountView.Username.Text));
        }

        private bool IsPasswordPresent()
        {
            return !(string.IsNullOrEmpty(accountView.Password.Text));
        }
    }
}
