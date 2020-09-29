namespace ConsultaCnpjApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfiguracaodoBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atividade_Principal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpresaId = c.Int(nullable: false),
                        Text = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data_Situacao = c.String(),
                        Tipo = c.String(),
                        Nome = c.String(),
                        Uf = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        Situacao = c.String(),
                        Bairro = c.String(),
                        Logradouro = c.String(),
                        Numero = c.String(),
                        Cep = c.String(),
                        Municipio = c.String(),
                        Porte = c.String(),
                        Abertura = c.String(),
                        Natureza_Juridica = c.String(),
                        Fantasia = c.String(),
                        Cnpj = c.String(),
                        Ultima_Atualizacao = c.DateTime(nullable: false),
                        Status = c.String(),
                        Complemento = c.String(),
                        Efr = c.String(),
                        Motivo_Situacao = c.String(),
                        Situacao_Especial = c.String(),
                        Data_Situacao_Especial = c.String(),
                        Capital_Social = c.String(),
                        Billing_Id = c.Int(),
                        Extra_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Billings", t => t.Billing_Id)
                .ForeignKey("dbo.Extras", t => t.Extra_Id)
                .Index(t => t.Billing_Id)
                .Index(t => t.Extra_Id);
            
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Free = c.Boolean(nullable: false),
                        Database = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Extras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Atividades_Secundarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpresaId = c.Int(nullable: false),
                        Text = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Qsas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpresaId = c.Int(nullable: false),
                        Qual = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qsas", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Atividades_Secundarias", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Empresas", "Extra_Id", "dbo.Extras");
            DropForeignKey("dbo.Empresas", "Billing_Id", "dbo.Billings");
            DropForeignKey("dbo.Atividade_Principal", "EmpresaId", "dbo.Empresas");
            DropIndex("dbo.Qsas", new[] { "EmpresaId" });
            DropIndex("dbo.Atividades_Secundarias", new[] { "EmpresaId" });
            DropIndex("dbo.Empresas", new[] { "Extra_Id" });
            DropIndex("dbo.Empresas", new[] { "Billing_Id" });
            DropIndex("dbo.Atividade_Principal", new[] { "EmpresaId" });
            DropTable("dbo.Qsas");
            DropTable("dbo.Atividades_Secundarias");
            DropTable("dbo.Extras");
            DropTable("dbo.Billings");
            DropTable("dbo.Empresas");
            DropTable("dbo.Atividade_Principal");
        }
    }
}
