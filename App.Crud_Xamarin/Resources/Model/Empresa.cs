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
        public string FuncionarioEmpresa { get; set; }

        //Empresa
        public bool Selecionado { get; set; }

        //Funcionario no Checkbox
        public bool Checkado { get; set; }
    }
}