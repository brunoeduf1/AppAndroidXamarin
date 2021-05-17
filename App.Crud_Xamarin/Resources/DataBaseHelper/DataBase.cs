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

        // Definições para funcionários

        public bool CriarBancoDeDados()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
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
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
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
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
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
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
                {
                    conexao.Query<Funcionario>("UPDATE Funcionario set Nome=?, Cpf=?, Email=?, Endereco=? Where Id=?", funcionario.Nome, funcionario.Cpf, funcionario.Email, funcionario.Endereco, funcionario.Id);
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
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
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
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
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

        // Definições para empresas

        public bool CriarBancoDeDadosE()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
                {
                    conexao.CreateTable<Empresa>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InserirEmpresa(Empresa empresa)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
                {
                    conexao.Insert(empresa);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Empresa> GetEmpresas()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
                {
                    return conexao.Table<Empresa>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool AtualizarEmpresa(Empresa empresa)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
                {
                    conexao.Query<Empresa>("UPDATE Empresa set Nome=?, Cnpj=?, Endereco=? Where Id=?", empresa.Nome, empresa.Cnpj, empresa.Endereco, empresa.Id);
                    //conexao.Update(empresa);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool DeletarEmpresa(Empresa empresa)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
                {
                    conexao.Delete(empresa);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool GetEmpresa(int Id)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
                {
                    conexao.Query<Empresa>("SELECT * FROM Empresa Where Id=?", Id);
                    //conexao.Update(empresa);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        // Associando Funcionario na empresa e vice e versa
        public bool Match(int id_empresa, int id_funcionario)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "AppCrudXamarin.db")))
                {
                    conexao.Query<Match>("SELECT * FROM Empresa Where Id=?", id_empresa);
                    //conexao.Update(empresa);

                    conexao.Query<Match>("SELECT * FROM Funcionario Where Id=?", id_funcionario);

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