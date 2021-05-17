using Android.App;
using Android.Views;
using Android.Widget;
using App.Crud_Xamarin.Resources.Model;
using System.Collections.Generic;

namespace App.Crud_Xamarin.Resources
{
    public class ListViewAdapterEChkBx : BaseAdapter
    {
        private readonly Activity context;
        private readonly List<Empresa> empresas;

        public ListViewAdapterEChkBx(Activity _context, List<Empresa> _empresas)
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
            View view;

            if (convertView == null)
            {
                view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.ListViewLayoutEChkBx, parent, false);
            }

            else
            {
                view = convertView;
            }

            var lvtxtNomeE = view.FindViewById<TextView>(Resource.Id.txtvNomeE);
            var lvtxtCnpj = view.FindViewById<TextView>(Resource.Id.txtvCnpj);
            var lvtxtEnderecoE = view.FindViewById<TextView>(Resource.Id.txtvEnderecoE);

            lvtxtNomeE.Text = empresas[position].Nome;
            lvtxtCnpj.Text = "" + empresas[position].Cnpj;
            lvtxtEnderecoE.Text = empresas[position].Endereco;

            CheckBox checkBoxEmp = view.FindViewById<CheckBox>(Resource.Id.checkBoxEmp);

            Empresa empresa = this.empresas[position];

            checkBoxEmp.Tag = position;
            checkBoxEmp.Tag = empresa.Nome;
            checkBoxEmp.Checked = empresa.Selecionado;

            checkBoxEmp.SetOnCheckedChangeListener(null);
            checkBoxEmp.SetOnCheckedChangeListener(new CheckedChangeListener(this.context));

            return view;
        }

        private class CheckedChangeListener : Java.Lang.Object, CompoundButton.IOnCheckedChangeListener
        {
            private Activity activity;

            public CheckedChangeListener(Activity activity)
            {
                this.activity = activity;
            }

            public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
            {
                if (isChecked)
                {
                    string name = (string)buttonView.Tag;
                    string text = string.Format("{0} Marcado.", name);
                    Toast.MakeText(this.activity, text, ToastLength.Short).Show();                   
                }
            }
        }

        public void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            ListView listView = sender as ListView;
            var view = listView.GetChildAt(e.Position);

            CheckBox chk = view.FindViewById<CheckBox>(Resource.Id.checkBoxEmp);
            chk.Checked = true;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
    }
}