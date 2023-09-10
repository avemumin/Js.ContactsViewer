using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Js.ContactsViewer.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCatName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubCatDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsManualyEditAvail = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryDescription", "CategoryName", "CreatedOn" },
                values: new object[,]
                {
                    { 1, "wszystko zwiazane z biznesem", "Business", new DateTime(2023, 9, 10, 19, 13, 9, 125, DateTimeKind.Local).AddTicks(4257) },
                    { 2, "Twoje prywaty", "Private", new DateTime(2023, 9, 10, 19, 13, 9, 125, DateTimeKind.Local).AddTicks(4260) },
                    { 3, "Gdy wybrane można utworzyć swoje widzi mi się", "Inne", new DateTime(2023, 9, 10, 19, 13, 9, 125, DateTimeKind.Local).AddTicks(4262) }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CreatedOn", "IsManualyEditAvail", "SubCatDescription", "SubCatName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 10, 19, 13, 9, 125, DateTimeKind.Local).AddTicks(4100), false, "Szef i wsio co z nim zwiazane", "Szef" },
                    { 2, new DateTime(2023, 9, 10, 19, 13, 9, 125, DateTimeKind.Local).AddTicks(4154), false, "Co tam klient chciał", "Klient" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDay", "CategoryId", "CreatedOn", "Email", "LastName", "Name", "Password", "Phone", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(1983, 9, 10, 19, 13, 9, 125, DateTimeKind.Local).AddTicks(4276), 1, new DateTime(2023, 9, 10, 19, 13, 9, 125, DateTimeKind.Local).AddTicks(4272), "john.doe@kukuryku.pl", "Doe", "John", "1234", "12345678", 1 },
                    { 2, new DateTime(1981, 6, 19, 19, 13, 9, 125, DateTimeKind.Local).AddTicks(4284), 1, new DateTime(2023, 9, 10, 19, 13, 9, 125, DateTimeKind.Local).AddTicks(4283), "sabinka.doe@kukuryku.pl", "Doe", "Sabina", "sabina", "22233344", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SubCategoryId",
                table: "Contacts",
                column: "SubCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SubCategories");
        }
    }
}
