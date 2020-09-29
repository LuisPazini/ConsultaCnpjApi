namespace ConsultaCnpjApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfiguracaodoBD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Atividade_Principal", "Empresa_Id", "dbo.Empresas");
            DropForeignKey("dbo.Atividades_Secundarias", "Empresa_Id", "dbo.Empresas");
            DropForeignKey("dbo.Qsas", "Empresa_Id", "dbo.Empresas");
            DropIndex("dbo.Atividade_Principal", new[] { "Empresa_Id" });
            DropIndex("dbo.Atividades_Secundarias", new[] { "Empresa_Id" });
            DropIndex("dbo.Qsas", new[] { "Empresa_Id" });
            RenameColumn(table: "dbo.Atividade_Principal", name: "Empresa_Id", newName: "EmpresaId");
            RenameColumn(table: "dbo.Atividades_Secundarias", name: "Empresa_Id", newName: "EmpresaId");
            RenameColumn(table: "dbo.Qsas", name: "Empresa_Id", newName: "EmpresaId");
            AlterColumn("dbo.Atividade_Principal", "EmpresaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Atividades_Secundarias", "EmpresaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Qsas", "EmpresaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Atividade_Principal", "EmpresaId");
            CreateIndex("dbo.Atividades_Secundarias", "EmpresaId");
            CreateIndex("dbo.Qsas", "EmpresaId");
            AddForeignKey("dbo.Atividade_Principal", "EmpresaId", "dbo.Empresas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Atividades_Secundarias", "EmpresaId", "dbo.Empresas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Qsas", "EmpresaId", "dbo.Empresas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qsas", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Atividades_Secundarias", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Atividade_Principal", "EmpresaId", "dbo.Empresas");
            DropIndex("dbo.Qsas", new[] { "EmpresaId" });
            DropIndex("dbo.Atividades_Secundarias", new[] { "EmpresaId" });
            DropIndex("dbo.Atividade_Principal", new[] { "EmpresaId" });
            AlterColumn("dbo.Qsas", "EmpresaId", c => c.Int());
            AlterColumn("dbo.Atividades_Secundarias", "EmpresaId", c => c.Int());
            AlterColumn("dbo.Atividade_Principal", "EmpresaId", c => c.Int());
            RenameColumn(table: "dbo.Qsas", name: "EmpresaId", newName: "Empresa_Id");
            RenameColumn(table: "dbo.Atividades_Secundarias", name: "EmpresaId", newName: "Empresa_Id");
            RenameColumn(table: "dbo.Atividade_Principal", name: "EmpresaId", newName: "Empresa_Id");
            CreateIndex("dbo.Qsas", "Empresa_Id");
            CreateIndex("dbo.Atividades_Secundarias", "Empresa_Id");
            CreateIndex("dbo.Atividade_Principal", "Empresa_Id");
            AddForeignKey("dbo.Qsas", "Empresa_Id", "dbo.Empresas", "Id");
            AddForeignKey("dbo.Atividades_Secundarias", "Empresa_Id", "dbo.Empresas", "Id");
            AddForeignKey("dbo.Atividade_Principal", "Empresa_Id", "dbo.Empresas", "Id");
        }
    }
}
