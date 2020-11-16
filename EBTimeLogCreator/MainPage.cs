using System;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;
namespace EBTimeLogCreator
{
    public class MainPage : ContentPage
    {
        private readonly Entry description;
        private readonly Button submitButton;
        private readonly AccountView accountView;
        private readonly TimeEntryRestService TimeEntryRestService = new TimeEntryRestService();

        public MainPage()
        {
            Padding = new Thickness(20);
            accountView = new AccountView();

            StackLayout mainView = new StackLayout
            {
                Spacing = 15
            };

            mainView.Children.Add(accountView.UserInfo);

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
                Placeholder = "Description",
            });

            mainView.Children.Add(submitButton = new Button
            {
                Text = "Submit",
                IsEnabled = false
            });


            // Check if user/pass is present for all fields
            description.PropertyChanged += OnDescriptionChange;
            accountView.Username.PropertyChanged += OnDescriptionChange;
            accountView.Password.PropertyChanged += OnDescriptionChange;

            submitButton.Clicked += OnSubmit;

            Content = mainView;
        }

        private void OnDescriptionChange(object sender, PropertyChangedEventArgs e)
        {
            string enteredText = description.Text;

            if (!CredentialsExist())
            {
                submitButton.IsEnabled = false;
                return;
            }

            submitButton.IsEnabled = !string.IsNullOrEmpty(enteredText);

        }

        private async void OnSubmit(object sender, EventArgs e)
        {

            TimeEntry entry = new TimeEntry(description.Text);
            HttpResponseMessage response = await TimeEntryRestService.SaveTimeLogAsync(entry, accountView.AuthString());

            if (response.IsSuccessStatusCode)
            {
                DependencyService.Get<IMessage>().ShortAlert("That went okay!");
                description.Text = "";
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert("That could have gone better.");
            }
        }

        private bool CredentialsExist()
        {
            return IsUsernamePresent() && IsPasswordPresent();
        }

        private bool IsUsernamePresent()
        {
            return !string.IsNullOrEmpty(accountView.Username.Text);
        }

        private bool IsPasswordPresent()
        {
            return !string.IsNullOrEmpty(accountView.Password.Text);
        }
    }
}
