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

        public bool Find(Cliente objCliente)
        {
            bool IsRecord;
            string Find = $"SELECT * FROM cliente WHERE idCliente = {objCliente.IdCliente}";
            try
            {
                Comando = new SqlCommand(Find, objConexaoDB.GetConnection());
                objConexaoDB.GetConnection().Open();
                SqlDataReader reader = Comando.ExecuteReader();
                IsRecord = reader.Read();
                if (IsRecord)
                {
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.CPF = reader[4].ToString();
                    objCliente.Estado = 99;
                }
                else
                {
                    objCliente.Estado = 1;
                }
            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                objConexaoDB.CloseDB();
            }
            return IsRecord;
        }

        public List<Cliente> FindAll()
        {
            List<Cliente> listaCliente = new List<Cliente>();
            string FindAll = "SELECT * FROM cliente ORDER BY nome ASC";
            try
            {
                Comando = new SqlCommand(FindAll, objConexaoDB.GetConnection());
                objConexaoDB.GetConnection().Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.CPF = reader[4].ToString();
                    listaCliente.Add(objCliente);
                }
                
            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                objConexaoDB.CloseDB();
            }
            return listaCliente;
        }

        public void Update(Cliente objCliente)
        {
            string Update = $"UPDATE cliente SET nome = {objCliente.Nome}, endereco = {objCliente.Endereco}, telefone = {objCliente.Telefone}, cpf = {objCliente.CPF}";
            try
            {
                Comando = new SqlCommand(Update, objConexaoDB.GetConnection());
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
        //OUTRAS IMPLEMENTAÇÕES

        public bool findClientePorcpf(Cliente objCliente)
        {
            bool temRegistros;
            string find = "select*from cliente where cpf='" + objCliente.CPF + "'";
            try
            {
                Comando = new SqlCommand(find, objConexaoDB.GetConnection());
                objConexaoDB.GetConnection().Open();

                SqlDataReader reader = Comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.CPF = reader[4].ToString();

                    objCliente.Estado = 99;

                }
                else
                {
                    objCliente.Estado = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexaoDB.GetConnection().Close();
                objConexaoDB.CloseDB();
            }
            return temRegistros;
        }

        public List<Cliente> findAllCliente(Cliente objCLiente)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "select* from cliente where nome like '%" + objCLiente.Nome + "%' or cpf like '%" + objCLiente.CPF + "%' or idCliente like '%" + objCLiente.IdCliente + "%' ";
            try
            {

                Comando = new SqlCommand(findAll, objConexaoDB.GetConnection());
                objConexaoDB.GetConnection().Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Nome = reader[1].ToString();

                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.CPF = reader[4].ToString();
                    listaClientes.Add(objCliente);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.GetConnection().Close();
                objConexaoDB.CloseDB();
            }

            return listaClientes;

        }
    }
}
