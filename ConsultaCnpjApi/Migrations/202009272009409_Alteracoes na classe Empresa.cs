namespace ConsultaCnpjApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracoesnaclasseEmpresa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empresas", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empresas", "Discriminator");
        }
    }
}
