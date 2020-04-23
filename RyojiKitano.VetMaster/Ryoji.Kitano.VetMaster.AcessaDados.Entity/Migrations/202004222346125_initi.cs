namespace Ryoji.Kitano.VetMaster.AcessaDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VET_VETERINARIOS",
                c => new
                    {
                        VET_ID = c.Int(nullable: false, identity: true),
                        VET_NOME = c.String(nullable: false, maxLength: 40),
                        VET_ANIMAL_ATENDIDO = c.String(nullable: false, maxLength: 40),
                        VET_DATA_HORA_ATENDIMENTO = c.DateTime(nullable: false),
                        VET_CRV = c.Int(nullable: false),
                        VETERINARIO_PRONTUARIO_ID = c.Int(nullable: false),
                        VET_ANIMAL_ID = c.Int(nullable: false),
                        Animal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.VET_ID)
                .ForeignKey("dbo.ANM_ANIMAIS", t => t.Animal_Id)
                .ForeignKey("dbo.PRT_PRONTUARIOS", t => t.VETERINARIO_PRONTUARIO_ID, cascadeDelete: true)
                .Index(t => t.VETERINARIO_PRONTUARIO_ID)
                .Index(t => t.Animal_Id);
            
            CreateTable(
                "dbo.ANM_ANIMAIS",
                c => new
                    {
                        ANM_ID = c.Int(nullable: false, identity: true),
                        IDADE = c.Int(),
                        ANM_RAÇA = c.String(nullable: false, maxLength: 40),
                        ANM_NOME_DONO = c.String(maxLength: 40),
                        ANM_VETERINARIO_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ANM_ID)
                .ForeignKey("dbo.VET_VETERINARIOS", t => t.ANM_VETERINARIO_ID, cascadeDelete: true)
                .Index(t => t.ANM_VETERINARIO_ID);
            
            CreateTable(
                "dbo.PRT_PRONTUARIOS",
                c => new
                    {
                        PRT_ID = c.Int(nullable: false, identity: true),
                        ANIMALATENDIDO = c.String(nullable: false, maxLength: 40),
                        PRT_DATA_HORA_ATENDIMENTO = c.DateTime(nullable: false),
                        OBSERVACOES = c.String(maxLength: 500),
                        PRT_VETERINARIO_ID = c.Int(nullable: false),
                        Veterinario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PRT_ID)
                .ForeignKey("dbo.VET_VETERINARIOS", t => t.Veterinario_Id)
                .Index(t => t.Veterinario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VET_VETERINARIOS", "VETERINARIO_PRONTUARIO_ID", "dbo.PRT_PRONTUARIOS");
            DropForeignKey("dbo.PRT_PRONTUARIOS", "Veterinario_Id", "dbo.VET_VETERINARIOS");
            DropForeignKey("dbo.VET_VETERINARIOS", "Animal_Id", "dbo.ANM_ANIMAIS");
            DropForeignKey("dbo.ANM_ANIMAIS", "ANM_VETERINARIO_ID", "dbo.VET_VETERINARIOS");
            DropIndex("dbo.PRT_PRONTUARIOS", new[] { "Veterinario_Id" });
            DropIndex("dbo.ANM_ANIMAIS", new[] { "ANM_VETERINARIO_ID" });
            DropIndex("dbo.VET_VETERINARIOS", new[] { "Animal_Id" });
            DropIndex("dbo.VET_VETERINARIOS", new[] { "VETERINARIO_PRONTUARIO_ID" });
            DropTable("dbo.PRT_PRONTUARIOS");
            DropTable("dbo.ANM_ANIMAIS");
            DropTable("dbo.VET_VETERINARIOS");
        }
    }
}
