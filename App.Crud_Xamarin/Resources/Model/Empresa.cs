using SQLite;

namespace App.Crud_Xamarin.Resources.Model
{

    public class Empresa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
    }
}