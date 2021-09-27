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
                name: "BillingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillingStreet = table.Column<string>(type: "text", nullable: true),
                    BillingStreet2 = table.Column<string>(type: "text", nullable: true),
                    BillingCity = table.Column<string>(type: "text", nullable: true),
                    BillingState = table.Column<string>(type: "text", nullable: true),
                    BillingZip = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DeliveryStreet = table.Column<string>(type: "text", nullable: true),
                    DeliveryStreet2 = table.Column<string>(type: "text", nullable: true),
                    DeliveryCity = table.Column<string>(type: "text", nullable: true),
                    DeliveryState = table.Column<string>(type: "text", nullable: true),
                    DeliveryZip = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddress", x => x.Id);
                });

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
                    DeliveryAddressId = table.Column<int>(type: "integer", nullable: true),
                    BillingAddressId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_BillingAddress_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "BillingAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_DeliveryAddress_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "DeliveryAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, false, "Football", new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(594), new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(923), "Men", null, "po-YOJJZDP", null, null, new DateTime(2021, 9, 27, 15, 25, 52, 131, DateTimeKind.Local).AddTicks(8710), null, "scLEGUY", "Pant" },
                    { 2, false, "Boxing", new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1260), new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1261), "Women", null, "po-EOVXSOH", null, null, new DateTime(2021, 9, 27, 15, 25, 52, 134, DateTimeKind.Local).AddTicks(1237), null, "scBGVUZ", "Pant" },
                    { 3, false, "Basketball", new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1270), new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1270), "Men", null, "po-NDSSVMC", null, null, new DateTime(2021, 9, 27, 15, 25, 52, 134, DateTimeKind.Local).AddTicks(1266), null, "scMBCEC", "Pant" },
                    { 4, false, "Running", new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1277), new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1278), "Men", null, "po-SCGOOXO", null, null, new DateTime(2021, 9, 27, 15, 25, 52, 134, DateTimeKind.Local).AddTicks(1275), null, "scNRVVY", "Pant" },
                    { 5, false, "Boxing", new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1285), new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1286), "Women", null, "po-HNOAWEX", null, null, new DateTime(2021, 9, 27, 15, 25, 52, 134, DateTimeKind.Local).AddTicks(1283), null, "scANBDN", "Pant" },
                    { 6, false, "Football", new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1295), new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1296), "Women", null, "po-MSTPYZI", null, null, new DateTime(2021, 9, 27, 15, 25, 52, 134, DateTimeKind.Local).AddTicks(1293), null, "scDPGLJ", "Pant" },
                    { 7, false, "Boxing", new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1303), new DateTime(2021, 9, 27, 19, 25, 52, 134, DateTimeKind.Utc).AddTicks(1304), "Men", null, "po-MXXWNFE", null, null, new DateTime(2021, 9, 27, 15, 25, 52, 134, DateTimeKind.Local).AddTicks(1301), null, "scOOEGM", "Pant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ProductID",
                table: "LineItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_PurchaseID",
                table: "LineItems",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BillingAddressId",
                table: "Purchases",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_DeliveryAddressId",
                table: "Purchases",
                column: "DeliveryAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "BillingAddress");

            migrationBuilder.DropTable(
                name: "DeliveryAddress");
        }
    }
}
