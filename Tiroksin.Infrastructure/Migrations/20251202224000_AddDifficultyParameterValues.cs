using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDifficultyParameterValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9034), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9035) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9041), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9046), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9046) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9050), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9054), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9055) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9064), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9065) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9077), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9078) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9081), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9086), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9086) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9129), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9129) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9185) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9190), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9194), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9198), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9206), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9210), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9211) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9214), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9215) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9219), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9219) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9223), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9223) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9226), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9230), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9231) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9235), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9235) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9241), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9242) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9245), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9249), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9253), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9257), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9258) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9261), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9262) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000007"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9265), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9266) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000008"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9269), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.InsertData(
                table: "parameter_values",
                columns: new[] { "id", "created_at", "created_by", "name", "order_no", "parameter_definition_id", "updated_at", "updated_by", "value" },
                values: new object[,]
                {
                    { new Guid("10000005-0001-0001-0001-000000000001"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9276), null, "Kolay", 1, new Guid("00000005-5555-5555-5555-555555555555"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9276), null, "Easy" },
                    { new Guid("10000005-0001-0001-0001-000000000002"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9280), null, "Orta", 2, new Guid("00000005-5555-5555-5555-555555555555"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9281), null, "Medium" },
                    { new Guid("10000005-0001-0001-0001-000000000003"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9285), null, "Zor", 3, new Guid("00000005-5555-5555-5555-555555555555"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9285), null, "Hard" }
                });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9356), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9357) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9362), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9366), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9367) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(8821), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(8822) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000005-0001-0001-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000005-0001-0001-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000005-0001-0001-0001-000000000003"));

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7109), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7115), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7115) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7119), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7119) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7123), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7123) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7127), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7128) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7131), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7132) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7148), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7148) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7152), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7152) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7156), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7156) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7195), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7195) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7269), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7270) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7273), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7274) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7276), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7277) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7280), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7286), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7286) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7289), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7289) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7293), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7294) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7296), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7297) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7300), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7303), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7303) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7306), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7306) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7309), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7315), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7315) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7319), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7319) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7322), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7323) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7325), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7326) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7328), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7329) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7332), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7332) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000007"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7335), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7335) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000008"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7338), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7338) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7399), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7404), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7405) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7408), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7408) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(6946), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(6947) });
        }
    }
}
