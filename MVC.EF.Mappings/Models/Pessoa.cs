using System;
using System.Collections.Generic;

namespace MVC.EF.Mappings.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            PessoaId = Guid.NewGuid();
            PessoaJuridicaList = new List<PessoaJuridica>();
            EnderecoList = new List<Endereco>();

        }

        public Guid PessoaId { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public bool NegarCredito { get; set; }
        public virtual ICollection<PessoaJuridica> PessoaJuridicaList { get; set; }
        public virtual ICollection<Endereco> EnderecoList { get; set; }
    }
}