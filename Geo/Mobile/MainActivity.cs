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

namespace Mobile
{
    [Activity(Label = "ЕАВД", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button _btnSubmit;
        EditText _txtLogin;
        EditText _txtPass;
        TextView _textInet;
        bool _isInet;
        bool _flag;
        AsyncTimer timer;
        int _counter = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            InitControls();
            _isInet = IsInetOk();
            _flag = false;
            _btnSubmit.Click += BtnSubmit_Click;
            _txtLogin.AfterTextChanged += TxtLogin_AfterTextChanged;
            _txtPass.AfterTextChanged += TxtPass_AfterTextChanged;
            if (!_isInet)
            {
                _btnSubmit.SetTextColor(Color.ParseColor("#DCDCDC")); 
                timer = new AsyncTimer(OnTimer, 0, 700);
            }
            else
            {
                timer.Cancel();
            }
        }

        private async Task OnTimer()
        {
            if (_isInet)
            {
                timer.Cancel();
            }

            RunOnUiThread(() => {

                if (_flag)
                {
                    _textInet.Text = "Нет подключения к интернету";
                }
                else
                {
                    _textInet.Text = "";
                }
                _flag = !_flag;
                _counter++;
            });            
        }                    


        bool IsInetOk()
        {
            if (_counter == 25) return true;
            else return false;
        }

        void InitControls()
        {
            _btnSubmit = FindViewById<Button>(Resource.Id.btn_logIn);
            _btnSubmit.Enabled = false;
            _txtLogin = FindViewById<EditText>(Resource.Id.etxt_logIn);
            _txtPass = FindViewById<EditText>(Resource.Id.etxt_password);
            _textInet = FindViewById<TextView>(Resource.Id.tw_isInetOk);
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
            if (_txtLogin.Text.Length > 0 && _txtPass.Text.Length > 0)
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


        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Не готово...", ToastLength.Long).Show();
        }
    }
}

