using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REstate.Data.Migrations
{
    public partial class addedvente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vente",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdenCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDeTlf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropertyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vente_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vente_PropertyID",
                table: "Vente",
                column: "PropertyID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vente");
        }
    }
}
