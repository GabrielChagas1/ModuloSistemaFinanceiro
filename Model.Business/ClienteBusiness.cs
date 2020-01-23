using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class ClienteBusiness
    {
        private ClienteDAO objClienteDAO;

        public ClienteBusiness()
        {
            objClienteDAO = new ClienteDAO();

        }

        public void Create(Cliente objCliente)
        {
            bool verificacao = true;

            string nome = objCliente.Nome;
            if (nome == null)
            {
                objCliente.Estado = 20;
                return;
            }
            else
            {
                nome = objCliente.Nome.Trim();
                verificacao = nome.Length <= 30 && nome.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }

            }
            //end validar nome




            //begin validar endereco retorna estado=6
            string endereco = objCliente.Endereco;
            if (endereco == null)
            {
                objCliente.Estado = 60;
                return;
            }
            else
            {
                endereco = objCliente.Endereco.Trim();
                verificacao = endereco.Length <= 50 && endereco.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 6;
                    return;
                }

            }
            //end validar endereco

            //begin validar telefone retorna estado=7
            string telefone = objCliente.Telefone;
            if (telefone == null)
            {
                objCliente.Estado = 70;
                return;
            }
            else
            {
                telefone = objCliente.Telefone.Trim();
                verificacao = telefone.Length <= 15 && telefone.Length > 8;
                if (!verificacao)
                {
                    objCliente.Estado = 7;
                    return;
                }

            }
            //end validar telefone

            //begin verificar duplicidade retorna estado=8
            Cliente objClienteAux = new Cliente();
            objClienteAux.IdCliente = objCliente.IdCliente;
            verificacao = !objClienteDAO.Find(objClienteAux);
            if (!verificacao)
            {
                objCliente.Estado = 8;
                return;
            }
            //end validar duplicidade

            //begin verificar duplicidade CPF retorna estado=8
            Cliente objCliente1 = new Cliente();
            objCliente1.CPF = objCliente.CPF;
            verificacao = !objClienteDAO.FindClientePorcpf(objCliente1);
            if (!verificacao)
            {
                objCliente.Estado = 9;
                return;
            }
            //end validar duplicidade CPF

            //se nao tem erro
            objCliente.Estado = 99;
            objClienteDAO.Create(objCliente);
            return;
        }

        public void Update(Cliente objCliente)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string codigo = objCliente.IdCliente.ToString();
            long id = 0;
            if (codigo == null)
            {
                objCliente.Estado = 10;
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objCliente.IdCliente);
                    verificacao = codigo.Length > 0 && codigo.Length < 999999; ;


                    if (!verificacao)
                    {
                        objCliente.Estado = 1;
                        return;
                    }
                }
                catch (Exception e)
                {
                    objCliente.Estado = 100;
                    return;
                }

            }
            //end validar codigo


            //begin validar nome retorna estado=2
            string nome = objCliente.Nome;
            if (nome == null)
            {
                objCliente.Estado = 20;
                return;
            }
            else
            {
                nome = objCliente.Nome.Trim();
                verificacao = nome.Length <= 30 && nome.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }

            }
            //end validar nome




            //begin validar endereço retorna estado=6
            string endereco = objCliente.Endereco;
            if (endereco == null)
            {
                objCliente.Estado = 60;
                return;
            }
            else
            {
                endereco = objCliente.Endereco.Trim();
                verificacao = endereco.Length <= 50 && endereco.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 6;
                    return;
                }

            }
            //end validar endereco

            //begin validar telefone retorna estado=7
            string telefone = objCliente.Endereco;
            if (telefone == null)
            {
                objCliente.Estado = 70;
                return;
            }
            else
            {
                telefone = objCliente.Telefone.Trim();
                verificacao = telefone.Length <= 30 && telefone.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 7;
                    return;
                }

            }
            //end validar telefone

            //begin verificar duplicidade CPF retorna estado=8
            Cliente objCliente1 = new Cliente();
            objCliente1.CPF = objCliente.CPF;
            verificacao = !objClienteDAO.FindClientePorcpf(objCliente1);
            if (!verificacao)
            {
                objCliente.Estado = 9;
                return;
            }
            //end validar duplicidade CPF

            //se nao tem erro
            objCliente.Estado = 99;
            objClienteDAO.Update(objCliente);
            return;
        }

        public void Delete(Cliente objCliente)
        {
            bool verificacao = true;
            //verificando se existe
            Cliente objClienteAux = new Cliente();
            objClienteAux.IdCliente = objCliente.IdCliente;
            verificacao = objClienteDAO.Find(objClienteAux);
            if (!verificacao)
            {
                objCliente.Estado = 33;
                return;
            }


            objCliente.Estado = 99;
            objClienteDAO.Delete(objCliente);
            return;
        }

        public bool Find(Cliente objCliente)
        {
            return objClienteDAO.Find(objCliente);
        }

        public List<Cliente> FindAll()
        {
            return objClienteDAO.FindAll();
        }
        public List<Cliente> FindAllClientes(Cliente objCLiente)
        {
            return objClienteDAO.FindAllCliente(objCLiente);
        }
    }
}
