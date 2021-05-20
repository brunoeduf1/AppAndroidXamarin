using Android.App;
using Android.Views;
using Android.Widget;
using App.Crud_Xamarin.Resources.Model;
using System.Collections.Generic;

namespace App.Crud_Xamarin.Resources
{
    public class ListViewAdapter : BaseAdapter
    {
        private readonly Activity context;
        private readonly List<Funcionario> funcionarios;

        public ListViewAdapter(Activity _context, List<Funcionario> _funcionarios)
        {
            this.context = _context;
            this.funcionarios = _funcionarios;
        }

        public override int Count
        {
            get
            {
                return funcionarios.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return funcionarios[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.ListViewFuncionario, parent, false);

            var lvtxtNome = view.FindViewById<TextView>(Resource.Id.txtvNome);
            var lvtxtCpf = view.FindViewById<TextView>(Resource.Id.txtvCpf);
            var lvtxtEmail = view.FindViewById<TextView>(Resource.Id.txtvEmail);
            var lvtxtEndereco = view.FindViewById<TextView>(Resource.Id.txtvEndereco);
            //var lvtxtvEmp = view.FindViewById<TextView>(Resource.Id.txtvEmp);

            lvtxtNome.Text = "Funcionario: " + funcionarios[position].Nome;
            lvtxtCpf.Text = "CPF: " + funcionarios[position].Cpf;
            lvtxtEmail.Text = "E-mail:" + funcionarios[position].Email;
            lvtxtEndereco.Text = "Endereco: " + funcionarios[position].Endereco;
            //lvtxtvEmp.Text = "Empresa: " + funcionarios[position].EmpresaFuncionario;

            return view;

        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
    }
}