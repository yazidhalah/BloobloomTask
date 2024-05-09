using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupCurrency",
                columns: table => new
                {
                    LookupCurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupCurrencyCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LookupCurrencyConversionRateToUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupCurrency", x => x.LookupCurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "LookupFrame",
                columns: table => new
                {
                    LookupFrameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupFrameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LookupFrameDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LookupFrameStock = table.Column<int>(type: "int", nullable: false),
                    LookupFramePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupFrame", x => x.LookupFrameId);
                });

            migrationBuilder.CreateTable(
                name: "LookupLensType",
                columns: table => new
                {
                    LookupLensTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupLensTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupLensType", x => x.LookupLensTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookupPrescriptionType",
                columns: table => new
                {
                    LookupPrescriptionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupPrescriptionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupPrescriptionType", x => x.LookupPrescriptionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookupLens",
                columns: table => new
                {
                    LookupLensId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupLensColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LookupLensDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LookupLensStock = table.Column<int>(type: "int", nullable: false),
                    LookupLensPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LookupPrescriptionTypeId = table.Column<int>(type: "int", nullable: false),
                    LookupLensTypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupLens", x => x.LookupLensId);
                    table.ForeignKey(
                        name: "FK_LookupLens_LookupLensType_LookupLensTypeId",
                        column: x => x.LookupLensTypeId,
                        principalTable: "LookupLensType",
                        principalColumn: "LookupLensTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LookupLens_LookupPrescriptionType_LookupPrescriptionTypeId",
                        column: x => x.LookupPrescriptionTypeId,
                        principalTable: "LookupPrescriptionType",
                        principalColumn: "LookupPrescriptionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCart",
                columns: table => new
                {
                    TransactionCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionCartUserId = table.Column<int>(type: "int", nullable: false),
                    LookupFrameId = table.Column<int>(type: "int", nullable: false),
                    LookupLensId = table.Column<int>(type: "int", nullable: false),
                    TransactionCartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LookupCurrencyId = table.Column<int>(type: "int", nullable: false),
                    TransactionCartQuantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCart", x => x.TransactionCartId);
                    table.ForeignKey(
                        name: "FK_TransactionCart_LookupCurrency_LookupCurrencyId",
                        column: x => x.LookupCurrencyId,
                        principalTable: "LookupCurrency",
                        principalColumn: "LookupCurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionCart_LookupFrame_LookupFrameId",
                        column: x => x.LookupFrameId,
                        principalTable: "LookupFrame",
                        principalColumn: "LookupFrameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionCart_LookupLens_LookupLensId",
                        column: x => x.LookupLensId,
                        principalTable: "LookupLens",
                        principalColumn: "LookupLensId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LookupCurrency",
                columns: new[] { "LookupCurrencyId", "CreateDate", "CreateId", "EditDate", "EditId", "LookupCurrencyConversionRateToUSD", "LookupCurrencyCurrencyCode", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3537), null, null, null, 1.0m, "USD", 1 },
                    { 2, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3539), null, null, null, 0.80m, "GBP", 1 },
                    { 3, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3540), null, null, null, 0.93m, "EUR", 1 },
                    { 4, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3540), null, null, null, 0.71m, "JOD", 1 },
                    { 5, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3541), null, null, null, 155.53m, "JPY", 1 }
                });

            migrationBuilder.InsertData(
                table: "LookupLensType",
                columns: new[] { "LookupLensTypeId", "CreateDate", "CreateId", "EditDate", "EditId", "LookupLensTypeName", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3520), null, null, null, "classic", 1 },
                    { 2, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3522), null, null, null, "blue_light", 1 },
                    { 3, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3523), null, null, null, "transition", 1 }
                });

            migrationBuilder.InsertData(
                table: "LookupPrescriptionType",
                columns: new[] { "LookupPrescriptionTypeId", "CreateDate", "CreateId", "EditDate", "EditId", "LookupPrescriptionTypeName", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3420), null, null, null, "fashion", 1 },
                    { 2, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3432), null, null, null, "single_vision", 1 },
                    { 3, new DateTime(2024, 5, 9, 5, 59, 46, 775, DateTimeKind.Local).AddTicks(3433), null, null, null, "varifocal", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LookupLens_LookupLensTypeId",
                table: "LookupLens",
                column: "LookupLensTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupLens_LookupPrescriptionTypeId",
                table: "LookupLens",
                column: "LookupPrescriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCart_LookupCurrencyId",
                table: "TransactionCart",
                column: "LookupCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCart_LookupFrameId",
                table: "TransactionCart",
                column: "LookupFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCart_LookupLensId",
                table: "TransactionCart",
                column: "LookupLensId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TransactionCart");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LookupCurrency");

            migrationBuilder.DropTable(
                name: "LookupFrame");

            migrationBuilder.DropTable(
                name: "LookupLens");

            migrationBuilder.DropTable(
                name: "LookupLensType");

            migrationBuilder.DropTable(
                name: "LookupPrescriptionType");
        }
    }
}
