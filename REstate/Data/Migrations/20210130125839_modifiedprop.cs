using Microsoft.EntityFrameworkCore.Migrations;

namespace REstate.Data.Migrations
{
    public partial class modifiedprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrivatePost",
                table: "Property",
                newName: "vendu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vendu",
                table: "Property",
                newName: "PrivatePost");
        }
    }
}
