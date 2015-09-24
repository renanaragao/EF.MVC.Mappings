using System;
using System.Collections.Generic;

namespace MVC.EF.Mappings.Models
{
    public class PessoaFisica : Pessoa
    {

        public string Nome { get; set; }
        public string Cpf { get; set; }
        
    }
}