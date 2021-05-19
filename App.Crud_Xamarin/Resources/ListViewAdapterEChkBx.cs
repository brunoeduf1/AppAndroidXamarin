using Android.App;
using Android.Views;
using Android.Widget;
using App.Crud_Xamarin.Resources.Model;
using System.Collections.Generic;
using System;

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
            View view = convertView;
            MyViewHolder holder;

            if (view != null)
            {
                holder = view.Tag as MyViewHolder;
                holder.mCheckBox.Tag = position;
            }
            else
            {
                holder = new MyViewHolder();
                view = this.context.LayoutInflater.Inflate(Resource.Layout.ListViewLayoutEChkBx, null);

                holder.mCheckBox = view.FindViewById<CheckBox>(Resource.Id.checkBoxEmp);
                holder.mCheckBox.Tag = position;

                view.Tag = holder;
            }

            var lvtxtNomeE = view.FindViewById<TextView>(Resource.Id.txtvNomeE);
            var lvtxtCnpj = view.FindViewById<TextView>(Resource.Id.txtvCnpj);
            var lvtxtEnderecoE = view.FindViewById<TextView>(Resource.Id.txtvEnderecoE);
            var lvtxtFun = view.FindViewById<TextView>(Resource.Id.textvFun);
          
            lvtxtNomeE.Text = "Empresa: " + empresas[position].Nome;
            lvtxtCnpj.Text = "CNPJ: " + empresas[position].Cnpj;
            lvtxtEnderecoE.Text = "Endereco: " + empresas[position].Endereco;
            lvtxtFun.Text = "Funcionario: " + empresas[position].FuncionarioEmpresa;

            CheckBox checkBoxEmp = view.FindViewById<CheckBox>(Resource.Id.checkBoxEmp);

            Empresa empresa = this.empresas[position];

            holder.mCheckBox.Tag = position;
            holder.mCheckBox.Checked = empresas[position].Checkado;
           
            holder.mCheckBox.SetOnCheckedChangeListener(null);
            holder.mCheckBox.Checked = empresa.Checkado;
            holder.mCheckBox.SetOnCheckedChangeListener(new CheckedChangeListener(this.context, empresas));

            return view;
        }

        public class MyViewHolder : Java.Lang.Object
        {
            public CheckBox mCheckBox { get; set; }
        }

        private class CheckedChangeListener : Java.Lang.Object, CompoundButton.IOnCheckedChangeListener
        {
            private Activity activity;
            private List<Empresa> list;

            public CheckedChangeListener(Activity activity, List<Empresa> datalist)
            {
                this.activity = activity;
                this.list = datalist;
            }

            public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
            {
                Int32 position = 1;

                if (isChecked)
                {
                    string strMyObject = buttonView.Tag.ToString();
                    System.Diagnostics.Debug.WriteLine("Conteudo do Tag = " + strMyObject);

                    try
                    {
                        position = Int32.Parse(strMyObject);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Unable to parse");
                    }

                    Empresa item = list[position];
                    item.Checkado = true;
                    list[position].Checkado = true;

                    string text = string.Format("{0} Marcado.", item.Nome);
                    Toast.MakeText(this.activity, text, ToastLength.Short).Show();
                }

                else
                {
                    string strMyObject = buttonView.Tag.ToString();

                    try
                    {
                        position = Int32.Parse(strMyObject);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Unable to parse");
                    }

                    list[position].Checkado = false;
                }
            }
        }

        private void MBtn_Click(object sender, System.EventArgs e)
        {
            foreach (Empresa model in empresas)
            {
                if (model.Checkado)
                {
                    System.Diagnostics.Debug.WriteLine("selected item = " + model.Nome);
                }
            }
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
    }
}