namespace MVC.EF.Mappings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaPessoaFisica : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoId = c.Guid(nullable: false),
                        Logradouro = c.String(nullable: false, maxLength: 150, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 100, unicode: false),
                        Complemento = c.String(nullable: false, maxLength: 100, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 8, unicode: false),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaId = c.Guid(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        NegarCredito = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "dbo.PessoaJuridica",
                c => new
                    {
                        PessoaJuridicaId = c.Guid(nullable: false),
                        Cnpj = c.String(maxLength: 14, unicode: false),
                        RazaoSocial = c.String(maxLength: 100, unicode: false),
                        PessoaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaJuridicaId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.PessoaEndereco",
                c => new
                    {
                        PessoaId = c.Guid(nullable: false),
                        EnderecoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PessoaId, t.EnderecoId })
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .Index(t => t.PessoaId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.PessoaJuridicaEndereco",
                c => new
                    {
                        PessoaJuridicaId = c.Guid(nullable: false),
                        EnderecoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PessoaJuridicaId, t.EnderecoId })
                .ForeignKey("dbo.PessoaJuridica", t => t.PessoaJuridicaId)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .Index(t => t.PessoaJuridicaId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.PessoaFisica",
                c => new
                    {
                        PessoaId = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Cpf = c.String(maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PessoaFisica", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.PessoaJuridica", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.PessoaJuridicaEndereco", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.PessoaJuridicaEndereco", "PessoaJuridicaId", "dbo.PessoaJuridica");
            DropForeignKey("dbo.PessoaEndereco", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.PessoaEndereco", "PessoaId", "dbo.Pessoa");
            DropIndex("dbo.PessoaFisica", new[] { "PessoaId" });
            DropIndex("dbo.PessoaJuridicaEndereco", new[] { "EnderecoId" });
            DropIndex("dbo.PessoaJuridicaEndereco", new[] { "PessoaJuridicaId" });
            DropIndex("dbo.PessoaEndereco", new[] { "EnderecoId" });
            DropIndex("dbo.PessoaEndereco", new[] { "PessoaId" });
            DropIndex("dbo.PessoaJuridica", new[] { "PessoaId" });
            DropTable("dbo.PessoaFisica");
            DropTable("dbo.PessoaJuridicaEndereco");
            DropTable("dbo.PessoaEndereco");
            DropTable("dbo.PessoaJuridica");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Endereco");
        }
    }
}
