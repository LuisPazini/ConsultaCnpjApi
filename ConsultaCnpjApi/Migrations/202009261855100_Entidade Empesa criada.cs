namespace ConsultaCnpjApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntidadeEmpesacriada : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        data_situacao = c.String(),
                        tipo = c.String(),
                        nome = c.String(),
                        uf = c.String(),
                        telefone = c.String(),
                        email = c.String(),
                        situacao = c.String(),
                        bairro = c.String(),
                        logradouro = c.String(),
                        numero = c.String(),
                        cep = c.String(),
                        municipio = c.String(),
                        porte = c.String(),
                        abertura = c.String(),
                        natureza_juridica = c.String(),
                        fantasia = c.String(),
                        cnpj = c.String(),
                        ultima_atualizacao = c.DateTime(nullable: false),
                        status = c.String(),
                        complemento = c.String(),
                        efr = c.String(),
                        motivo_situacao = c.String(),
                        situacao_especial = c.String(),
                        data_situacao_especial = c.String(),
                        capital_social = c.String(),
                        billing_free = c.Boolean(nullable: false),
                        billing_database = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empresas");
        }
    }
}
