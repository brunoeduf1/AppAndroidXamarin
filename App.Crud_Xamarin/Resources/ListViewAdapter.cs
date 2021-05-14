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
        private readonly List<Aluno> alunos;

        public ListViewAdapter(Activity _context, List<Aluno> _alunos)
        {
            this.context = _context;
            this.alunos = _alunos;
        }

        public override int Count
        {
            get
            {
                return alunos.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return alunos[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.ListViewLayout, parent, false);

            var lvtxtNome = view.FindViewById<TextView>(Resource.Id.txtvNome);
            var lvtxtIdade = view.FindViewById<TextView>(Resource.Id.txtvIdade);
            var lvtxtEmail = view.FindViewById<TextView>(Resource.Id.txtvEmail);

            lvtxtNome.Text = alunos[position].Nome;
            lvtxtIdade.Text = "" + alunos[position].Idade;
            lvtxtEmail.Text = alunos[position].Email;

            return view;

        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
    }
}