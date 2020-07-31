namespace Projeto2WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaTabelaFuncionario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FuncionarioSistemas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Senha = c.String(),
                        Email = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FuncionarioSistemas");
        }
    }
}
