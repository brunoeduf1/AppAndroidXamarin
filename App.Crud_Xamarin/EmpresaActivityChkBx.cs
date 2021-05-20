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
    [Activity(Label = "Cadastro de Empresas")]
    public class EmpresaActivityChkBx : Activity
    {
        ListView lvDadosEChkBx;
        List<Empresa> listaEmpresas = new List<Empresa>();

        DataBase db;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CadEmpresaChkBx);

            //criar banco de dados
            CriarBancoDadosE();

            lvDadosEChkBx = FindViewById<ListView>(Resource.Id.lvDadosEChkBx);

            var txtNomeE = FindViewById<EditText>(Resource.Id.txtNomeE);
            var txtCnpj = FindViewById<EditText>(Resource.Id.txtCnpj);
            var txtEnderecoE = FindViewById<EditText>(Resource.Id.txtEnderecoE);

            var btnIncluir = FindViewById<Button>(Resource.Id.btnIncluir);
            var btnConfirmar = FindViewById<Button>(Resource.Id.btnConfirmar);
            var btnRetornar = FindViewById<Button>(Resource.Id.btnRetornar);

            CheckBox checkBoxEmp = FindViewById<CheckBox>(Resource.Id.checkBoxEmp);

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
                    FuncionarioEmpresa = "",
                };
                db.InserirEmpresa(empresa);
                CarregarDados();
            };

            //evento itemClick do ListView
            lvDadosEChkBx.ItemClick += (s, e) =>
            {
                for (int i = 0; i < lvDadosEChkBx.Count; i++)
                {
                    if (e.Position == i)
                    {
                        lvDadosEChkBx.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.MediumBlue);
                    }

                    else
                        lvDadosEChkBx.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
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

            //Botao confirmar
            btnConfirmar.Click += delegate
            {
                string selecionado = Selecionado();
                System.Diagnostics.Debug.WriteLine("Conteudo do selecionado = " + selecionado);

                int[] checkado = new int[20];

                for (int i = 0; i < lvDadosEChkBx.Count; i++)
                {
                    if (listaEmpresas[i].Checkado)
                    {
                        checkado[i] = i;                      
                    }
                }

                for (int i = 0; i < lvDadosEChkBx.Count; i++) //Corrigir -> Eliminar esse for e juntar as alterações no "for" de cima
                {
                    if (checkado[i] == i)
                    {
                        Empresa empresa = new Empresa()
                        {
                            Id = listaEmpresas[checkado[i]].Id,
                            Nome = listaEmpresas[checkado[i]].Nome,
                            Cnpj = listaEmpresas[checkado[i]].Cnpj,
                            Endereco = listaEmpresas[checkado[i]].Endereco,
                            FuncionarioEmpresa = selecionado,
                        };

                        db.AtualizarEmpresa(empresa);
                        CarregarDados();

                        listaEmpresas[i].Checkado = false;
                    }
                }
            };

            btnRetornar.Click += delegate
            {
                StartActivity(typeof(FuncionarioActivity));
            };

        }

        public string Selecionado()
        {
            string selecionado = Intent.GetStringExtra("nome");

            return selecionado;
        }

        private void CriarBancoDadosE()
        {
            db = new DataBase();
            db.CriarBancoDeDadosE();
        }

        private void CarregarDados()
        {
            listaEmpresas = db.GetEmpresas();
            var adapter = new ListViewAdapterEChkBx(this, listaEmpresas);
            lvDadosEChkBx.Adapter = adapter;
        }

    }
}