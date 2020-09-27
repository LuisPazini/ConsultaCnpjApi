namespace ConsultaCnpjApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracoesnosnomesdemetodos : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Empresas", new[] { "billing_Id" });
            DropIndex("dbo.Empresas", new[] { "extra_Id" });
            CreateIndex("dbo.Empresas", "Billing_Id");
            CreateIndex("dbo.Empresas", "Extra_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Empresas", new[] { "Extra_Id" });
            DropIndex("dbo.Empresas", new[] { "Billing_Id" });
            CreateIndex("dbo.Empresas", "extra_Id");
            CreateIndex("dbo.Empresas", "billing_Id");
        }
    }
}
