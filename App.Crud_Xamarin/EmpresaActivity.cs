using Android.App;
using Android.OS;
using Android.Widget;
using App.Crud_Xamarin.Resources;
using App.Crud_Xamarin.Resources.DataBaseHelper;
using App.Crud_Xamarin.Resources.Model;
using System.Collections.Generic;

namespace App.Crud_Xamarin
{
    [Activity(Label = "App.Crud_Xamarin")]
    public class EmpresaActivity : Activity
    {
        private ListView lvDadosE;
        List<Empresa> listaEmpresas = new List<Empresa>();
        DataBase db;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //criar banco de dados
            CriarBancoDados();

            lvDadosE = FindViewById<ListView>(Resource.Id.lvDadosE);

            var txtNomeE = FindViewById<EditText>(Resource.Id.txtNomeE);
            var txtCnpj = FindViewById<EditText>(Resource.Id.txtCnpj);
            var txtEnderecoE = FindViewById<EditText>(Resource.Id.txtEnderecoE);

            var btnIncluir = FindViewById<Button>(Resource.Id.btnIncluir);
            var btnEditar = FindViewById<Button>(Resource.Id.btnEditar);
            var btnDeletar = FindViewById<Button>(Resource.Id.btnDeletar);

            //carregar Dados
            CarregarDados();

            //botão Incluir
            btnIncluir.Click += delegate
            {
                Empresa empresa = new Empresa()
                {
                    Nome = txtNomeE.Text,
                    Cnpj = txtCnpj.Text,
                    Endereco = txtEnderecoE.Text,

                };
                db.InserirEmpresa(empresa);
                CarregarDados();
            };

            //botão editar
            btnEditar.Click += delegate
            {
                Empresa empresa = new Empresa()
                {
                    Id = int.Parse(txtNomeE.Tag.ToString()),
                    Nome = txtNomeE.Text,
                    Cnpj = txtCnpj.Text,
                    Endereco = txtEnderecoE.Text,
                };
                db.AtualizarEmpresa(empresa);
                CarregarDados();
            };

            //botão deletar
            btnDeletar.Click += delegate
            {
                Empresa empresa = new Empresa()
                {
                    Id = int.Parse(txtNomeE.Tag.ToString()),
                    Nome = txtNomeE.Text,
                    Cnpj = txtCnpj.Text,
                    Endereco = txtEnderecoE.Text,
                };
                db.DeletarEmpresa(empresa);
                CarregarDados();
            };

            //evento itemClick do ListView
            lvDadosE.ItemClick += (s, e) =>
            {
                for (int i = 0; i < lvDadosE.Count; i++)
                {
                    if (e.Position == i)
                        lvDadosE.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.MediumBlue);
                    else
                        lvDadosE.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }

                //vinculando dados do listview 
                var lvtxtNomeE = e.View.FindViewById<TextView>(Resource.Id.txtvNomeE);
                var lvtxtCnpj = e.View.FindViewById<TextView>(Resource.Id.txtvCnpj);
                var lvtxtEnderecoE = e.View.FindViewById<TextView>(Resource.Id.txtvEnderecoE);

                txtNomeE.Text = lvtxtNomeE.Text;
                txtNomeE.Tag = e.Id;
                txtCnpj.Text = lvtxtCnpj.Text;
                txtEnderecoE.Text = lvtxtEnderecoE.Text;

            };

        }

        private void CriarBancoDados()
        {
            db = new DataBase();
            db.CriarBancoDeDados();
        }

        private void CarregarDados()
        {
            listaEmpresas = db.GetEmpresas();
            var adapter = new ListViewAdapterE(this, listaEmpresas);
            lvDadosE.Adapter = adapter;
        }
    }
}

