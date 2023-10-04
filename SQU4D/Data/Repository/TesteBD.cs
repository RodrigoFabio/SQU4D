using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace SQU4D.Data.Repository
{
    public class TesteBD
    {
        private readonly string _strConexao;
        private readonly IConfiguration _configuration;

        public TesteBD(IConfiguration configuration)
        {
            _configuration = configuration;
            _strConexao = _configuration.GetConnectionString("stringConexaoBD");
        }

        //public bool testaBD()
        //{
        //    try
        //    {
             
        //        VerificarEAtualizarBancoDeDados();
                
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erro: {ex.Message}");
        //        return false;
        //    }
        //}

        public bool VerificarEAtualizarBancoDeDados()
        {
            try
            {

                using (SqlConnection conexao = new SqlConnection(_strConexao))
                {
                    conexao.Open();

                    // Verifica se o banco de dados existe
                    string scriptVerificacaoBanco = $@"
                    IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SQU4D')
                    BEGIN
                        CREATE DATABASE SQU4D;
                    END";

                    using (SqlCommand comando = new SqlCommand(scriptVerificacaoBanco, conexao))
                    {
                        comando.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }

            // Cria a tabela se ela não existir
            //string scriptCriacaoTabela = $@"
            //USE SQU4D;
            //IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MinhaTabela')
            //BEGIN
            //    CREATE TABLE MinhaTabela (
            //        ID INT PRIMARY KEY IDENTITY(1,1),
            //        Nome NVARCHAR(100)
            //    );
            //END";

            //    using (SqlCommand comando = new SqlCommand(scriptCriacaoTabela, conexao))
            //    {
            //        comando.ExecuteNonQuery();
            //    }
            //}
        }

    }
}
