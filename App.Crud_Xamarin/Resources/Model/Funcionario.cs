using SQLite;

namespace App.Crud_Xamarin.Resources.Model
{

    public class Funcionario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        public bool Selecionado { get; set; }

        public Empresa Empresa_list { get; }

    }
}