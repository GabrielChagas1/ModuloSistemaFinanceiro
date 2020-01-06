using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Cliente
    {
        [Display(Name ="Código")]
        public long IdCliente { get => IdCliente; set => IdCliente = value; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get => Nome; set => Nome = value; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Endereco { get => Endereco; set => Endereco = value; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string CPF { get => CPF; set => CPF = value; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get => Telefone; set => Telefone = value; }

        public Cliente(){}

        public Cliente(long idCliente)
        {
            this.IdCliente = idCliente;
        }

        public Cliente(long idCliente, string nome, string cpf, string endereco, string telefone)
        {
            this.IdCliente = idCliente;
            this.Nome = nome;
            this.CPF = cpf;
            this.Endereco = endereco;
            this.Telefone = telefone;
        }
    }
}
