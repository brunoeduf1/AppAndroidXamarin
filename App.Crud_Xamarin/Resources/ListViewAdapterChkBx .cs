using Android.App;
using Android.Views;
using Android.Widget;
using App.Crud_Xamarin.Resources.Model;
using System.Collections.Generic;
using System;

namespace App.Crud_Xamarin.Resources
{
    public class ListViewAdapterChkBx : BaseAdapter
    {
        private readonly Activity context;
        private readonly List<Funcionario> funcionarios;

        public ListViewAdapterChkBx(Activity _context, List<Funcionario> _empresas)
        {
            this.context = _context;
            this.funcionarios = _empresas;
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
                view = this.context.LayoutInflater.Inflate(Resource.Layout.ListViewFuncionarioChkBx, null);

                holder.mCheckBox = view.FindViewById<CheckBox>(Resource.Id.checkBoxFun);
                holder.mCheckBox.Tag = position;

                view.Tag = holder;
            }

            var lvtxtNome = view.FindViewById<TextView>(Resource.Id.txtvNome);
            var lvtxtCpf = view.FindViewById<TextView>(Resource.Id.txtvCpf);
            var lvtxtEmail = view.FindViewById<TextView>(Resource.Id.txtvEmail);
            var lvtxtEndereco = view.FindViewById<TextView>(Resource.Id.txtvEndereco);

            lvtxtNome.Text = "Funcionario: " + funcionarios[position].Nome;
            lvtxtCpf.Text = "CPF: " + funcionarios[position].Cpf;
            lvtxtEmail.Text = "E-mail:" + funcionarios[position].Email;
            lvtxtEndereco.Text = "Endereco: " + funcionarios[position].Endereco;

            CheckBox checkBoxFun = view.FindViewById<CheckBox>(Resource.Id.checkBoxFun);

            Funcionario funcionario = this.funcionarios[position];

            holder.mCheckBox.Tag = position;
            holder.mCheckBox.Checked = funcionarios[position].Checkado;
           
            holder.mCheckBox.SetOnCheckedChangeListener(null);
            holder.mCheckBox.Checked = funcionario.Checkado;
            holder.mCheckBox.SetOnCheckedChangeListener(new CheckedChangeListener(this.context, funcionarios));

            return view;
        }

        public class MyViewHolder : Java.Lang.Object
        {
            public CheckBox mCheckBox { get; set; }
        }

        private class CheckedChangeListener : Java.Lang.Object, CompoundButton.IOnCheckedChangeListener
        {
            private Activity activity;
            private List<Funcionario> list;

            public CheckedChangeListener(Activity activity, List<Funcionario> datalist)
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
                    //System.Diagnostics.Debug.WriteLine("Conteudo do Tag = " + strMyObject);

                    try
                    {
                        position = Int32.Parse(strMyObject);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Unable to parse");
                    }

                    Funcionario item = list[position];
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
            foreach (Funcionario model in funcionarios)
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