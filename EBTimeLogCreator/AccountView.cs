﻿using System;
using Xamarin.Forms;
namespace EBTimeLogCreator
{
    public class AccountView : ContentPage
    {
        private Entry username;
        private Entry password;
        public View userInfo { get; }

        public AccountView( )
        {
            Expander userInfo = new Expander
            {
                Header = new Label
                {
                    Text = "Account",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    TextColor = Color.DarkCyan
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

            this.userInfo = userInfo;
        }
    }
}
