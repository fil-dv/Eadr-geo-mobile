using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Mobile
{
    [Activity(Label = " ", MainLauncher = true, Icon = "@drawable/logo")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button btnSubmit = FindViewById<Button>(Resource.Id.btn_logIn);

            btnSubmit.Click += BtnSubmit_Click;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Не готово...", ToastLength.Long).Show();
        }
    }
}

