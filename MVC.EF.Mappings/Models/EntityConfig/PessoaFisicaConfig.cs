using System.Data.Entity.ModelConfiguration;

namespace MVC.EF.Mappings.Models.EntityConfig
{
    public class PessoaFisicaConfig : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaConfig()
        {

            Property(c => c.Cpf)
                .HasMaxLength(11);

            Property(c => c.Nome)
                .HasMaxLength(100);

            Map(x =>
            {

                x.ToTable("PessoaFisica");

            });

        }
    }
}
