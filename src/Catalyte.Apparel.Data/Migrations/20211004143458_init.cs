using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Catalyte.Apparel.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
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
                columns: new[] { "Id", "Active", "Category", "DateCreated", "DateModified", "Demographic", "Description", "GlobalProductCode", "Name", "PrimaryColorCode", "ReleaseDate", "SecondaryColorCode", "StyleNumber", "Type" },
                values: new object[,]
                {
                    { 1, false, "Running", new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(2779), new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(3587), "Women", null, "po-AUOXIJI", null, null, new DateTime(2021, 10, 4, 10, 34, 57, 443, DateTimeKind.Local).AddTicks(8295), null, "scILMWK", "Pant" },
                    { 2, false, "Baseball", new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4470), new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4473), "Men", null, "po-XRTNXKB", null, null, new DateTime(2021, 10, 4, 10, 34, 57, 447, DateTimeKind.Local).AddTicks(4399), null, "scDKCQC", "Pant" },
                    { 3, false, "Running", new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4514), new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4517), "Women", null, "po-FRCLRBY", null, null, new DateTime(2021, 10, 4, 10, 34, 57, 447, DateTimeKind.Local).AddTicks(4500), null, "scMWFKY", "Pant" },
                    { 4, false, "Baseball", new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4554), new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4558), "Men", null, "po-XDTUKIT", null, null, new DateTime(2021, 10, 4, 10, 34, 57, 447, DateTimeKind.Local).AddTicks(4542), null, "scRBYEF", "Pant" },
                    { 5, false, "Football", new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4579), new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4581), "Women", null, "po-KLHFUPD", null, null, new DateTime(2021, 10, 4, 10, 34, 57, 447, DateTimeKind.Local).AddTicks(4575), null, "scUJLSR", "Pant" },
                    { 6, false, "Football", new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4603), new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4605), "Men", null, "po-VNDZQUG", null, null, new DateTime(2021, 10, 4, 10, 34, 57, 447, DateTimeKind.Local).AddTicks(4599), null, "scHIWSG", "Pant" },
                    { 7, false, "Boxing", new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4727), new DateTime(2021, 10, 4, 14, 34, 57, 447, DateTimeKind.Utc).AddTicks(4728), "Women", null, "po-PEGMNBC", null, null, new DateTime(2021, 10, 4, 10, 34, 57, 447, DateTimeKind.Local).AddTicks(4716), null, "scKYEDE", "Pant" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "BillingCity", "BillingEmail", "BillingPhone", "BillingState", "BillingStreet", "BillingStreet2", "BillingZip", "DateCreated", "DateModified", "DeliveryCity", "DeliveryFirstName", "DeliveryLastName", "DeliveryState", "DeliveryStreet", "DeliveryStreet2", "DeliveryZip", "OrderDate" },
                values: new object[] { 1, "Atlanta", "customer@home.com", "(714) 345-8765", "GA", "123 Main", "Apt A", "31675", new DateTime(2021, 10, 4, 14, 34, 57, 449, DateTimeKind.Utc).AddTicks(6099), new DateTime(2021, 10, 4, 14, 34, 57, 449, DateTimeKind.Utc).AddTicks(6110), "Birmingham", "Max", "Space", "AL", "123 Hickley", null, 43690, new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}
