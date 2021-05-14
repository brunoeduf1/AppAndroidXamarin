using Android.Util;
using App.Crud_Xamarin.Resources.Model;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace App.Crud_Xamarin.Resources.DataBaseHelper
{
    public class DataBase
    {
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CriarBancoDeDados()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Funcionarios.db")))
                {
                    conexao.CreateTable<Funcionario>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InserirFuncionario(Funcionario funcionario)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Funcionarios.db")))
                {
                    conexao.Insert(funcionario);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Funcionario> GetFuncionarios()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Funcionarios.db")))
                {
                    return conexao.Table<Funcionario>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool AtualizarFuncionario(Funcionario funcionario)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Funcionarios.db")))
                {
                    conexao.Query<Funcionario>("UPDATE Aluno set Nome=?, Cpf=?, Email=?, Endereco=? Where Id=?", funcionario.Nome, funcionario.Cpf, funcionario.Email, funcionario.Endereco, funcionario.Id);
                    //conexao.Update(funcionario);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool DeletarFuncionario(Funcionario funcionario)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Funcionarios.db")))
                {
                    conexao.Delete(funcionario);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool GetFuncionario(int Id)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Funcionarios.db")))
                {
                    conexao.Query<Funcionario>("SELECT * FROM Funcionario Where Id=?", Id);
                    //conexao.Update(funcionario);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

    }
}