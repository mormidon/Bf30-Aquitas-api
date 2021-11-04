﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace Catalyte.Aquitas.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AquitasUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AquitasUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Industry = table.Column<string>(type: "text", nullable: true),
                    EmployeeSize = table.Column<int>(type: "integer", nullable: false),
                    IsPrivateCompany = table.Column<bool>(type: "boolean", nullable: false),
                    Reviews = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Sku = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Demographic = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PrimaryColorCode = table.Column<string>(type: "text", nullable: true),
                    SecondaryColorCode = table.Column<string>(type: "text", nullable: true),
                    StyleNumber = table.Column<string>(type: "text", nullable: true),
                    GlobalProductCode = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BillingStreet = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingStreet2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingCity = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BillingState = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    BillingZip = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    BillingEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingPhone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    DeliveryFirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeliveryLastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeliveryStreet = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeliveryStreet2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeliveryCity = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeliveryState = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    DeliveryZip = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    CardNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    CVV = table.Column<int>(type: "integer", nullable: false),
                    Expiration = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CardHolder = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaseID = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItems_Purchases_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Category", "DateCreated", "DateModified", "Demographic", "Description", "GlobalProductCode", "Name", "PrimaryColorCode", "ReleaseDate", "SecondaryColorCode", "Sku", "StyleNumber", "Type" },
                values: new object[,]
                {
                    { 1, false, "Skateboarding", new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(4355), new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(4847), "Men", null, "po-JZGOCQO", null, null, new DateTime(2021, 10, 30, 15, 36, 57, 108, DateTimeKind.Local).AddTicks(3271), null, "SHL-100-Blue", "scLFDVY", "Pant" },
                    { 2, false, "Soccer", new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5435), new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5436), "Women", null, "po-DWEMRNT", null, null, new DateTime(2021, 10, 30, 15, 36, 57, 110, DateTimeKind.Local).AddTicks(5277), null, "SHL-100-Red", "scFYYPL", "Pant" },
                    { 3, false, "Football", new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5447), new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5448), "Women", null, "po-DGGQMOV", null, null, new DateTime(2021, 10, 30, 15, 36, 57, 110, DateTimeKind.Local).AddTicks(5443), null, "HOV-AB-KJ", "scKILFU", "Pant" },
                    { 4, false, "Football", new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5455), new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5456), "Women", null, "po-BXECFTK", null, null, new DateTime(2021, 10, 30, 15, 36, 57, 110, DateTimeKind.Local).AddTicks(5453), null, "TLX-DRESS-SM", "scIBFTG", "Pant" },
                    { 5, false, "Football", new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5462), new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5463), "Men", null, "po-BIZRDQH", null, null, new DateTime(2021, 10, 30, 15, 36, 57, 110, DateTimeKind.Local).AddTicks(5460), null, "ATK-34-RD", "scZWELP", "Pant" },
                    { 6, false, "Baseball", new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5472), new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5473), "Women", null, "po-NTGWAVE", null, null, new DateTime(2021, 10, 30, 15, 36, 57, 110, DateTimeKind.Local).AddTicks(5470), null, "TRE-33-LRG", "scBTMGT", "Pant" },
                    { 7, false, "Football", new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5479), new DateTime(2021, 10, 30, 20, 36, 57, 110, DateTimeKind.Utc).AddTicks(5480), "Women", null, "po-EBXFARJ", null, null, new DateTime(2021, 10, 30, 15, 36, 57, 110, DateTimeKind.Local).AddTicks(5478), null, "TRE-30-SM", "scALORX", "Pant" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "BillingCity", "BillingEmail", "BillingPhone", "BillingState", "BillingStreet", "BillingStreet2", "BillingZip", "CVV", "CardHolder", "CardNumber", "DateCreated", "DateModified", "DeliveryCity", "DeliveryFirstName", "DeliveryLastName", "DeliveryState", "DeliveryStreet", "DeliveryStreet2", "DeliveryZip", "Expiration", "OrderDate" },
                values: new object[] { 1, "Atlanta", "customer@home.com", "(714) 345-8765", "GA", "123 Main", "Apt A", "31675", 456, "Max Perkins", "1435678998761234", new DateTime(2021, 10, 30, 20, 36, 57, 112, DateTimeKind.Utc).AddTicks(2094), new DateTime(2021, 10, 30, 20, 36, 57, 112, DateTimeKind.Utc).AddTicks(2103), "Birmingham", "Max", "Space", "AL", "123 Hickley", null, 43690, "11/21", new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "DateCreated", "DateModified", "ProductID", "PurchaseID", "Quantity" },
                values: new object[] { 1, new DateTime(2021, 10, 30, 20, 36, 57, 111, DateTimeKind.Utc).AddTicks(6625), new DateTime(2021, 10, 30, 20, 36, 57, 111, DateTimeKind.Utc).AddTicks(6631), 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ProductID",
                table: "LineItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_PurchaseID",
                table: "LineItems",
                column: "PurchaseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AquitasUsers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}