namespace ConsultaCnpjApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntidadesRelativascriadas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atividade_Principal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Atividades_Secundarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        free = c.Boolean(nullable: false),
                        database = c.Boolean(nullable: false),
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
                "dbo.Qsas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        qual = c.String(),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Empresas", "billing_Id", c => c.Int());
            AddColumn("dbo.Empresas", "extra_Id", c => c.Int());
            CreateIndex("dbo.Empresas", "billing_Id");
            CreateIndex("dbo.Empresas", "extra_Id");
            AddForeignKey("dbo.Empresas", "billing_Id", "dbo.Billings", "Id");
            AddForeignKey("dbo.Empresas", "extra_Id", "dbo.Extras", "Id");
            DropColumn("dbo.Empresas", "billing_free");
            DropColumn("dbo.Empresas", "billing_database");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empresas", "billing_database", c => c.Boolean(nullable: false));
            AddColumn("dbo.Empresas", "billing_free", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Empresas", "extra_Id", "dbo.Extras");
            DropForeignKey("dbo.Empresas", "billing_Id", "dbo.Billings");
            DropIndex("dbo.Empresas", new[] { "extra_Id" });
            DropIndex("dbo.Empresas", new[] { "billing_Id" });
            DropColumn("dbo.Empresas", "extra_Id");
            DropColumn("dbo.Empresas", "billing_Id");
            DropTable("dbo.Qsas");
            DropTable("dbo.Extras");
            DropTable("dbo.Billings");
            DropTable("dbo.Atividades_Secundarias");
            DropTable("dbo.Atividade_Principal");
        }
    }
}
