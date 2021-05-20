using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using App.Crud_Xamarin.Resources;
using App.Crud_Xamarin.Resources.DataBaseHelper;
using App.Crud_Xamarin.Resources.Model;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using System.Collections.Generic;

namespace App.Crud_Xamarin
{
    [Activity(Label = "Cadastro de Funcionarios")]
    public class FuncionarioActivityChkBx : Activity
    {
        ListView lvDadosChkBx;
        List<Funcionario> listaFuncionarios = new List<Funcionario>();

        DataBase db;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CadFuncionarioChkBx);

            //criar banco de dados
            CriarBancoDadosE();

            lvDadosChkBx = FindViewById<ListView>(Resource.Id.lvDadosChkBx);

            var txtNome = FindViewById<EditText>(Resource.Id.txtNome);
            var txtCpf = FindViewById<EditText>(Resource.Id.txtCpf);
            var txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            var txtEndereco = FindViewById<EditText>(Resource.Id.txtEndereco);

            var btnIncluir = FindViewById<Button>(Resource.Id.btnIncluir2);
            var btnConfirmar = FindViewById<Button>(Resource.Id.btnConfirmar2);
            var btnRetornar = FindViewById<Button>(Resource.Id.btnRetornar2);

            CheckBox checkBoxFun = FindViewById<CheckBox>(Resource.Id.checkBoxFun);

            //carregar Dados
            CarregarDados();

            //botão Incluir
            btnIncluir.Click += delegate
            {
                Funcionario funcionario = new Funcionario()
                {
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Endereco = txtEndereco.Text,
                    Email = txtEmail.Text,
                    EmpresaFuncionario = "",
                };
                db.InserirFuncionario(funcionario);
                CarregarDados();
            };

            //evento itemClick do ListView
            lvDadosChkBx.ItemClick += (s, e) =>
            {
                for (int i = 0; i < lvDadosChkBx.Count; i++)
                {
                    if (e.Position == i)
                    {
                        lvDadosChkBx.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.MediumBlue);
                    }

                    else
                        lvDadosChkBx.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }

                //vinculando dados do listview 
                var lvtxtNome = e.View.FindViewById<TextView>(Resource.Id.txtvNome);
                var lvtxtCpf = e.View.FindViewById<TextView>(Resource.Id.txtvCpf);
                var lvtxtEndereco = e.View.FindViewById<TextView>(Resource.Id.txtvEndereco);
                var lvtxtEmail = e.View.FindViewById<TextView>(Resource.Id.txtvEmail);

                txtNome.Text = lvtxtNome.Text;
                txtNome.Tag = e.Id;
                txtCpf.Text = lvtxtCpf.Text;
                txtEmail.Text = lvtxtEmail.Text;
                txtEndereco.Text = lvtxtEndereco.Text;
            };

            //Botao confirmar
            btnConfirmar.Click += delegate
            {
                string selecionado = Selecionado();
                //System.Diagnostics.Debug.WriteLine("Conteudo do selecionado = " + selecionado);

                int[] checkado = new int[20];

                for (int i = 0; i < lvDadosChkBx.Count; i++)
                {
                    if (listaFuncionarios[i].Checkado)
                    {
                        checkado[i] = i;                      
                    }
                }

                for (int i = 0; i < lvDadosChkBx.Count; i++) //Corrigir -> Eliminar esse for e juntar as alterações no "for" de cima
                {
                    if (checkado[i] == i)
                    {
                        Funcionario funcionario = new Funcionario()
                        {
                            Id = listaFuncionarios[checkado[i]].Id,
                            Nome = listaFuncionarios[checkado[i]].Nome,
                            Cpf = listaFuncionarios[checkado[i]].Cpf,
                            Email = listaFuncionarios[checkado[i]].Email,
                            Endereco = listaFuncionarios[checkado[i]].Endereco,
                            EmpresaFuncionario = selecionado,
                        };

                        db.AtualizarFuncionario(funcionario);
                        CarregarDados();

                        listaFuncionarios[i].Checkado = false;
                    }
                }
            };

            btnRetornar.Click += delegate
            {
                StartActivity(typeof(EmpresaActivity));
            };

        }

        public string Selecionado()
        {
            string selecionado = Intent.GetStringExtra("nome2");

            return selecionado;
        }

        private void CriarBancoDadosE()
        {
            db = new DataBase();
            db.CriarBancoDeDadosE();
        }

        private void CarregarDados()
        {
            listaFuncionarios = db.GetFuncionarios();
            var adapter = new ListViewAdapterChkBx(this, listaFuncionarios);
            lvDadosChkBx.Adapter = adapter;
        }

    }
}