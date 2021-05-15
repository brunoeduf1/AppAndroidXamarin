using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using App.Crud_Xamarin.Resources;
using App.Crud_Xamarin.Resources.DataBaseHelper;
using App.Crud_Xamarin.Resources.Model;
using System.Collections.Generic;

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
            SetContentView(Resource.Layout.CadFuncionario);
        }

        private void BtnCadEmpresa_Click(object sender, System.EventArgs e)
        {
            SetContentView(Resource.Layout.CadEmpresa);
        }
    }
}

