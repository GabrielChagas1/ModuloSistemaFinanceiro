using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Model.DAO
{
    public class ClienteDAO : Obrigatorio<Cliente>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand Comando;

        //Construtor
        public ClienteDAO()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void CreateSql(Cliente objCliente)
        {

            string Create = $"INSERT INTO cliente(nome, endereco, telefone, cpf ) VALUES ({objCliente.Nome}, {objCliente.Endereco}, {objCliente.Telefone}, {objCliente.CPF})";
            try
            {
                Comando = new SqlCommand(Create, objConexaoDB.GetConnection());
                objConexaoDB.GetConnection().Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                objCliente.Estado = 1;
            }
            finally
            {
                objConexaoDB.CloseDB();
            }
        }

        public void Create(Cliente objCliente)
        {

            string Create = $"sp_cliente_adc {objCliente.Nome}, {objCliente.Endereco}, {objCliente.Telefone}, {objCliente.CPF}";
            try
            {
                Comando = new SqlCommand(Create, objConexaoDB.GetConnection());
                objConexaoDB.GetConnection().Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                objCliente.Estado = 1;
            }
            finally
            {
                objConexaoDB.CloseDB();
            }
        }

        public void Delete(Cliente objCliente)
        {
            string Delete = $"DELETE FROM cliente WHERE idCliente = {objCliente.IdCliente}";
            try
            {
                Comando = new SqlCommand(Delete, objConexaoDB.GetConnection());
                objConexaoDB.GetConnection().Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                objCliente.Estado = 1;
            }
            finally
            {
                objConexaoDB.CloseDB();
            }
        }

        public void Find(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente obj)
        {
            throw new NotImplementedException();
        }
    }
}
