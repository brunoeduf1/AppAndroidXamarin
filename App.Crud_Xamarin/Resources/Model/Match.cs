using SQLite;

namespace App.Crud_Xamarin.Resources.Model
{

    public class Match
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int EmpresaId { get; set; }
        public int FuncionarioId { get; set; }
    }
}