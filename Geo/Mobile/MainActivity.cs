using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Mobile.Assets;
using Android.Graphics;
using Android.Net;

namespace Mobile
{
    [Activity(Label = "ЕАВД", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button _btnSubmit;
        TextView _twLogin;
        TextView _twPass;
        EditText _etxtLogin;
        EditText _etxtPass;
        TextView _textInet;
        bool _flag;
        AsyncTimer timer;
        ConnectivityManager _connectivityManager;
        NetworkInfo _activeConnection;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            InitControls();
            _flag = false;
            _btnSubmit.Click += BtnSubmit_Click;
            _etxtLogin.AfterTextChanged += TxtLogin_AfterTextChanged;
            _etxtPass.AfterTextChanged += TxtPass_AfterTextChanged;
            if (!IsOnline())
            {                
                timer = new AsyncTimer(OnTimer, 0, 700);
            }
        }

        private async Task OnTimer()
        {           

            RunOnUiThread(() => {

                bool onLine = IsOnline();
                SetControlsState(onLine);
                if (onLine)
                {                    
                    _textInet.Text = "";
                    if (timer != null)
                    {
                        timer.Cancel();
                    }
                }
                else
                {
                    Flash();
                }                
            });            
        }

        void Flash()
        {
            if (_flag)
            {
                _textInet.Text = "Нет подключения к интернету";
            }
            else
            {
                _textInet.Text = "";
            }
            _flag = !_flag;
        }

        bool IsOnline()
        {
            _connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            _activeConnection = _connectivityManager.ActiveNetworkInfo;
            bool isOnline = (_activeConnection != null) && _activeConnection.IsConnected;
            //Toast.MakeText(this, isOnline ? "есть" : "нет", ToastLength.Short).Show();
            return isOnline;            
        }

        void InitControls()
        {
            _btnSubmit = FindViewById<Button>(Resource.Id.btn_logIn);
            _btnSubmit.Enabled = false;
            _etxtLogin = FindViewById<EditText>(Resource.Id.etxt_logIn);
            _etxtPass = FindViewById<EditText>(Resource.Id.etxt_password);
            _textInet = FindViewById<TextView>(Resource.Id.tw_isInetOk);
            _twLogin = FindViewById<TextView>(Resource.Id.tw_logIn);
            _twPass = FindViewById<TextView>(Resource.Id.tw_password);
        }

        private void TxtPass_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            SetBtnEnable();
        }

        private void TxtLogin_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            SetBtnEnable();
        }

        void SetBtnEnable()
        {
            if (_etxtLogin.Text.Length > 0 && _etxtPass.Text.Length > 0)
            {
                _btnSubmit.Enabled = true;
                _btnSubmit.SetTextColor(Color.ParseColor("#000000"));
            }
            else
            {
                _btnSubmit.Enabled = false;
                _btnSubmit.SetTextColor(Color.ParseColor("#A9A9A9"));
            }
        }

        void SetControlsState(bool state)
        {
            if (state)
            {
                _etxtLogin.Visibility = ViewStates.Visible;
                _etxtPass.Visibility = ViewStates.Visible;
                _twLogin.SetTextColor(Color.ParseColor("#000000"));
                _twPass.SetTextColor(Color.ParseColor("#000000"));
                _btnSubmit.SetTextColor(Color.ParseColor("#000000"));
            }
            else
            {
                _etxtLogin.Visibility = ViewStates.Invisible;
                _etxtPass.Visibility = ViewStates.Invisible;
                _twLogin.SetTextColor(Color.ParseColor("#DCDCDC"));
                _twPass.SetTextColor(Color.ParseColor("#DCDCDC"));
                _btnSubmit.SetTextColor(Color.ParseColor("#DCDCDC"));
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Не готово...", ToastLength.Long).Show();
        }
    }
}

