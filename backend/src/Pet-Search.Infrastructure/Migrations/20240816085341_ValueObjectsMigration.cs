using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pet_Search.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ValueObjectsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "social_network");

            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "volunteers");

            migrationBuilder.RenameColumn(
                name: "is_vaccinated",
                table: "pets",
                newName: "health_info_is_vaccinated");

            migrationBuilder.RenameColumn(
                name: "is_castrated",
                table: "pets",
                newName: "health_info_is_castrated");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "pets",
                newName: "phone_number_country_code");

            migrationBuilder.RenameColumn(
                name: "health_info",
                table: "pets",
                newName: "phone_number_area_code");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "pets",
                newName: "address_post_code");

            migrationBuilder.AddColumn<string>(
                name: "phone_number_area_code",
                table: "volunteers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phone_number_country_code",
                table: "volunteers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "social_networks_list",
                table: "volunteers",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address_city",
                table: "pets",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address_country",
                table: "pets",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone_number_area_code",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "phone_number_country_code",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "social_networks_list",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "address_city",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "address_country",
                table: "pets");

            migrationBuilder.RenameColumn(
                name: "health_info_is_vaccinated",
                table: "pets",
                newName: "is_vaccinated");

            migrationBuilder.RenameColumn(
                name: "health_info_is_castrated",
                table: "pets",
                newName: "is_castrated");

            migrationBuilder.RenameColumn(
                name: "phone_number_country_code",
                table: "pets",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "phone_number_area_code",
                table: "pets",
                newName: "health_info");

            migrationBuilder.RenameColumn(
                name: "address_post_code",
                table: "pets",
                newName: "address");

            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "volunteers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "social_network",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    link = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_social_network", x => x.id);
                    table.ForeignKey(
                        name: "fk_social_network_volunteers_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "volunteers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_social_network_volunteer_id",
                table: "social_network",
                column: "volunteer_id");
        }
    }
}
