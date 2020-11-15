using System;
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
            });

            this.Content = mainView;
        }
    }
}
