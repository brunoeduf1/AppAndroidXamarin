using Android.App;
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
        ListView lvDados;
        List<Aluno> listaAlunos = new List<Aluno>();
        DataBase db;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //criar banco de dados
            CriarBancoDados();

            lvDados = FindViewById<ListView>(Resource.Id.lvDados);

            var txtNome = FindViewById<EditText>(Resource.Id.txtNome);
            var txtIdade = FindViewById<EditText>(Resource.Id.txtIdade);
            var txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);

            var btnIncluir = FindViewById<Button>(Resource.Id.btnIncluir);
            var btnEditar = FindViewById<Button>(Resource.Id.btnEditar);
            var btnDeletar = FindViewById<Button>(Resource.Id.btnDeletar);

            //carregar Dados
            CarregarDados();

            //botão Incluir
            btnIncluir.Click += delegate
            {
                Aluno aluno = new Aluno()
                {
                    Nome = txtNome.Text,
                    Idade = int.Parse(txtIdade.Text),
                    Email = txtEmail.Text
                };
                db.InserirAluno(aluno);
                CarregarDados();
            };

            //botão editar
            btnEditar.Click += delegate
            {
                Aluno aluno = new Aluno()
                {
                    Id = int.Parse(txtNome.Tag.ToString()),
                    Nome = txtNome.Text,
                    Idade = int.Parse(txtIdade.Text),
                    Email = txtEmail.Text
                };
                db.AtualizarAluno(aluno);
                CarregarDados();
            };

            //botão deletar
            btnDeletar.Click += delegate
            {
                Aluno aluno = new Aluno()
                {
                    Id = int.Parse(txtNome.Tag.ToString()),
                    Nome = txtNome.Text,
                    Idade = int.Parse(txtIdade.Text),
                    Email = txtEmail.Text
                };
                db.DeletarAluno(aluno);
                CarregarDados();
            };

            //evento itemClick do ListView
            lvDados.ItemClick += (s, e) =>
            {
                for (int i = 0; i < lvDados.Count; i++)
                {
                    if (e.Position == i)
                        lvDados.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Chocolate);
                    else
                        lvDados.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }

                //vinculando dados do listview 
                var lvtxtNome = e.View.FindViewById<TextView>(Resource.Id.txtvNome);
                var lvtxtIdade = e.View.FindViewById<TextView>(Resource.Id.txtvIdade);
                var lvtxtEmail = e.View.FindViewById<TextView>(Resource.Id.txtvEmail);

                txtNome.Text = lvtxtNome.Text;
                txtNome.Tag = e.Id;
                txtIdade.Text = lvtxtIdade.Text;
                txtEmail.Text = lvtxtEmail.Text;

            };

        }

        private void CriarBancoDados()
        {
            db = new DataBase();
            db.CriarBancoDeDados();
        }

        private void CarregarDados()
        {
            listaAlunos = db.GetAlunos();
            var adapter = new ListViewAdapter(this, listaAlunos);
            lvDados.Adapter = adapter;
        }
    }
}

