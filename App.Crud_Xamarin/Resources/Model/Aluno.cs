using SQLite;

namespace App.Crud_Xamarin.Resources.Model
{

    public class Aluno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
    }
}