using System;
using Android.App;
using Android.Widget;
using EBTimeLogCreator.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace EBTimeLogCreator.Droid
{
    public class MessageAndroid : IMessage
    {
        public MessageAndroid()
        {
        }
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}
