using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG6212CMCSAPP.Migrations
{
    /// <inheritdoc />
    public partial class DocumentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "Claims");

            migrationBuilder.AddColumn<byte[]>(
                name: "DocumentData",
                table: "Claims",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentData",
                table: "Claims");

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
