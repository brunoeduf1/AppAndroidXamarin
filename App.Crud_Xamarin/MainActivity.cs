using Android.App;
using Android.OS;
using Android.Widget;

namespace App.Crud_Xamarin
{
    [Activity(Label = "App.Crud_Xamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

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

