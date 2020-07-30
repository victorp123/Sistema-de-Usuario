namespace Projeto2WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaTabelaUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        cod_cliente = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 8000, unicode: false),
                        sobrenome = c.String(nullable: false, maxLength: 8000, unicode: false),
                        cpf = c.String(nullable: false, maxLength: 8000, unicode: false),
                        telResidencial = c.String(maxLength: 8000, unicode: false),
                        telCelular = c.String(nullable: false, maxLength: 8000, unicode: false),
                        rg = c.String(nullable: false, maxLength: 8000, unicode: false),
                        email = c.String(maxLength: 8000, unicode: false),
                        cod_cidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cod_cliente)
                .ForeignKey("dbo.Cidades", t => t.cod_cidade, cascadeDelete: true)
                .Index(t => t.cod_cidade);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "cod_cidade", "dbo.Cidades");
            DropIndex("dbo.Usuarios", new[] { "cod_cidade" });
            DropTable("dbo.Usuarios");
        }
    }
}
