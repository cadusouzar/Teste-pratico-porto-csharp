using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Empresarial.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastroDeContainers",
                columns: table => new
                {
                    ContainerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ContainerNumber = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroDeContainers", x => x.ContainerID);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoDeContainers",
                columns: table => new
                {
                    MovementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContainerNumber = table.Column<string>(nullable: false),
                    TypeOfMovement = table.Column<int>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: false),
                    CadastroDeContainerContainerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoDeContainers", x => x.MovementID);
                    table.ForeignKey(
                        name: "FK_MovimentacaoDeContainers_CadastroDeContainers_CadastroDeContainerContainerID",
                        column: x => x.CadastroDeContainerContainerID,
                        principalTable: "CadastroDeContainers",
                        principalColumn: "ContainerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoDeContainers_CadastroDeContainerContainerID",
                table: "MovimentacaoDeContainers",
                column: "CadastroDeContainerContainerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacaoDeContainers");

            migrationBuilder.DropTable(
                name: "CadastroDeContainers");
        }
    }
}
