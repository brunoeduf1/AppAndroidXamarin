using Android.App;
using Android.Views;
using Android.Widget;
using App.Crud_Xamarin.Resources.Model;
using System.Collections.Generic;

namespace App.Crud_Xamarin.Resources
{
    public class ListViewAdapterE : BaseAdapter
    {
        private readonly Activity context;
        private readonly List<Empresa> empresas;

        public ListViewAdapterE(Activity _context, List<Empresa> _empresas)
        {
            this.context = _context;
            this.empresas = _empresas;
        }

        public override int Count
        {
            get
            {
                return empresas.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return empresas[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.ListViewLayoutE, parent, false);

            var lvtxtNomeE = view.FindViewById<TextView>(Resource.Id.txtvNomeE);
            var lvtxtCnpj = view.FindViewById<TextView>(Resource.Id.txtvCnpj);
            var lvtxtEnderecoE = view.FindViewById<TextView>(Resource.Id.txtvEnderecoE);
            var lvtxtFun = view.FindViewById<TextView>(Resource.Id.textvFun);

            lvtxtNomeE.Text = "Empresa: " + empresas[position].Nome;
            lvtxtCnpj.Text = "CNPJ: " + empresas[position].Cnpj;
            lvtxtEnderecoE.Text = "Endereco: " + empresas[position].Endereco;
            //lvtxtFun.Text = "Funcionario: " + empresas[position].FuncionarioEmpresa;

            return view;

        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
    }
}