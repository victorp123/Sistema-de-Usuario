namespace Projeto2WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        cod_cidade = c.Int(nullable: false, identity: true),
                        nome_cidade = c.String(nullable: false, maxLength: 100),
                        uf_cidade = c.String(nullable: false, maxLength: 2),
                        cep_cidade = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.cod_cidade);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cidades");
        }
    }
}
