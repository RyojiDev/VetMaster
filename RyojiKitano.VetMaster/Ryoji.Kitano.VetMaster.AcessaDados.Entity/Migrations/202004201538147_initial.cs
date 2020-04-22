namespace Ryoji.Kitano.VetMaster.AcessaDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VET_VETERINARIOs",
                c => new
                    {
                        VET_ID = c.Int(nullable: false, identity: true),
                        VET_NOME = c.String(nullable: false, maxLength: 40),
                        VET_ANIMAL_ATENDIDO = c.String(nullable: false, maxLength: 40),
                        VET_DATA_HORA_ATENDIMENTO = c.DateTime(nullable: false),
                        VET_CRV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VET_ID);
            
            CreateTable(
                "dbo.ANM_Animais",
                c => new
                    {
                        ANM_ID = c.Int(nullable: false, identity: true),
                        Idade = c.Int(nullable: false),
                        ANM_RAÇA = c.String(nullable: false, maxLength: 40),
                        ANM_NOME_DONO = c.String(maxLength: 40),
                        ANM_VETERINARIO_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ANM_ID)
                .ForeignKey("dbo.VET_VETERINARIOs", t => t.ANM_VETERINARIO_ID, cascadeDelete: true)
                .Index(t => t.ANM_VETERINARIO_ID);
            
            CreateTable(
                "dbo.PRT_PRONTUARIOS",
                c => new
                    {
                        PRT_ID = c.Int(nullable: false, identity: true),
                        AnimalAtendido = c.String(nullable: false, maxLength: 40),
                        PRT_DATA_HORA_ATENDIMENTO = c.DateTime(nullable: false),
                        Observacoes = c.String(),
                        IdVeterinario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PRT_ID)
                .ForeignKey("dbo.VET_VETERINARIOs", t => t.IdVeterinario, cascadeDelete: true)
                .Index(t => t.IdVeterinario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PRT_PRONTUARIOS", "IdVeterinario", "dbo.VET_VETERINARIOs");
            DropForeignKey("dbo.ANM_Animais", "ANM_VETERINARIO_ID", "dbo.VET_VETERINARIOs");
            DropIndex("dbo.PRT_PRONTUARIOS", new[] { "IdVeterinario" });
            DropIndex("dbo.ANM_Animais", new[] { "ANM_VETERINARIO_ID" });
            DropTable("dbo.PRT_PRONTUARIOS");
            DropTable("dbo.ANM_Animais");
            DropTable("dbo.VET_VETERINARIOs");
        }
    }
}
