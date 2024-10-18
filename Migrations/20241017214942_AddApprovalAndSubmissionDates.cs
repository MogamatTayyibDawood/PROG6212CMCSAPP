using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG6212CMCSAPP.Migrations
{
    /// <inheritdoc />
    public partial class AddApprovalAndSubmissionDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupportingDocument",
                table: "Claims");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Claims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "Claims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "Claims");

            migrationBuilder.AddColumn<byte[]>(
                name: "SupportingDocument",
                table: "Claims",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
