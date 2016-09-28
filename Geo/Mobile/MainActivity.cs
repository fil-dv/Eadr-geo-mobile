using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Mobile.Assets;

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
                timer = new AsyncTimer(OnTimer, 0, 1000);
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
                    _textInet.Text = "Click Start";
                }
                else
                {
                    _textInet.Text = "";
                }
                _flag = !_flag;
            });


            
        }                    
           
        

        //async Task<bool> FlashingText(bool flag)
        //{            
        //    return !flag;            
        //}


        bool IsInetOk()
        {
            return false;
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
            }
            else
            {
                _btnSubmit.Enabled = false;
            }
        }


        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Не готово...", ToastLength.Long).Show();
        }
    }
}

