using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    class ConexaoDB
    {
        private static ConexaoDB objConexaoDB = null;
        private SqlConnection con;

        private ConexaoDB()
        {
            con = new SqlConnection("Data Source=LAPTOP-ELNKGOCG\\SQLEXPRESS; Initial Catalog=Financeiro; Intregrated Security=True");
        }

        public static ConexaoDB saberEstado()
        {
            if(objConexaoDB == null)
            {
                objConexaoDB = new ConexaoDB();
            }

            return objConexaoDB;
        }

        //Método para pegar a conexão
        public SqlConnection GetConnection()
        {
            return con;
        }

        //Método para fechar a conexão
        public void CloseDB()
        {
            objConexaoDB = null;
        }
    }
}
