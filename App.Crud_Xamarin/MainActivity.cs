using Android.App;
using Android.OS;
using Android.Widget;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace App.Crud_Xamarin
{
    [Activity(Label = "App.Crud_Xamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            AppCenter.Start("008b4d24-152a-409c-a0af-9c1871a9c32d", typeof(Analytics), typeof(Crashes));
            AppCenter.Start("008b4d24-152a-409c-a0af-9c1871a9c32d", typeof(Analytics), typeof(Crashes));

            Button btnCadEmpresa  = FindViewById<Button>(Resource.Id.btnCadEmpresa);
            Button btnCadFuncionario = FindViewById<Button>(Resource.Id.btnCadFuncionario);


            btnCadEmpresa.Click += BtnCadEmpresa_Click;
            btnCadFuncionario.Click += BtnCadFuncionario_Click;
        }

        private void BtnCadFuncionario_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(FuncionarioActivity));
        }

        private void BtnCadEmpresa_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(EmpresaActivity));
        }
    }
}

