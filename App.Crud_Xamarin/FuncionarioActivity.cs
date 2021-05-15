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
    public class FuncionarioActivity : Activity
    {
        ListView lvDados;
        List<Funcionario> listaFuncionarios = new List<Funcionario>();
        DataBase db;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //criar banco de dados
            CriarBancoDados();

            lvDados = FindViewById<ListView>(Resource.Id.lvDados);

            var txtNome = FindViewById<EditText>(Resource.Id.txtNome);
            var txtCpf = FindViewById<EditText>(Resource.Id.txtCpf);
            var txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            var txtEndereco = FindViewById<EditText>(Resource.Id.txtEndereco);

            var btnIncluir = FindViewById<Button>(Resource.Id.btnIncluir);
            var btnEditar = FindViewById<Button>(Resource.Id.btnEditar);
            var btnDeletar = FindViewById<Button>(Resource.Id.btnDeletar);

            //carregar Dados
            CarregarDados();

            //botão Incluir
            btnIncluir.Click += delegate
            {
                Funcionario funcionario = new Funcionario()
                {
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Email = txtEmail.Text,
                    Endereco = txtEndereco.Text,

                };
                db.InserirFuncionario(funcionario);
                CarregarDados();
            };

            //botão editar
            btnEditar.Click += delegate
            {
                Funcionario funcionario = new Funcionario()
                {
                    Id = int.Parse(txtNome.Tag.ToString()),
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Email = txtEmail.Text,
                    Endereco = txtEndereco.Text,
                };
                db.AtualizarFuncionario(funcionario);
                CarregarDados();
            };

            //botão deletar
            btnDeletar.Click += delegate
            {
                Funcionario funcionario = new Funcionario()
                {
                    Id = int.Parse(txtNome.Tag.ToString()),
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Email = txtEmail.Text,
                    Endereco = txtEndereco.Text,
                };
                db.DeletarFuncionario(funcionario);
                CarregarDados();
            };

            //evento itemClick do ListView
            lvDados.ItemClick += (s, e) =>
            {
                for (int i = 0; i < lvDados.Count; i++)
                {
                    if (e.Position == i)
                        lvDados.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.MediumBlue);
                    else
                        lvDados.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }

                //vinculando dados do listview 
                var lvtxtNome = e.View.FindViewById<TextView>(Resource.Id.txtvNome);
                var lvtxtCpf = e.View.FindViewById<TextView>(Resource.Id.txtvCpf);
                var lvtxtEmail = e.View.FindViewById<TextView>(Resource.Id.txtvEmail);
                var lvtxtEndereco = e.View.FindViewById<TextView>(Resource.Id.txtvEndereco);

                txtNome.Text = lvtxtNome.Text;
                txtNome.Tag = e.Id;
                txtCpf.Text = lvtxtCpf.Text;
                txtEmail.Text = lvtxtEmail.Text;
                txtEndereco.Text = lvtxtEndereco.Text;

            };

        }

        private void CriarBancoDados()
        {
            db = new DataBase();
            db.CriarBancoDeDados();
        }

        private void CarregarDados()
        {
            listaFuncionarios = db.GetFuncionarios();
            var adapter = new ListViewAdapter(this, listaFuncionarios);
            lvDados.Adapter = adapter;
        }
    }
}

