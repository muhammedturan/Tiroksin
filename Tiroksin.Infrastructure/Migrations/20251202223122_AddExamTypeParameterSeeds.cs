using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExamTypeParameterSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "parameter_definitions",
                columns: new[] { "id", "created_at", "created_by", "data_type", "default_value", "description", "is_required", "key", "name", "updated_at", "updated_by", "validation_rules" },
                values: new object[] { new Guid("00000009-9999-9999-9999-999999999999"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7156), null, "string", null, "Sorunun ait olduğu sınav tipi (LGS, TYT, AYT, KPSS vb.)", false, "EXAM_TYPE", "Sınav Tipi", new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7156), null, null });

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
                columns: new[] { "created_at", "password_hash", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(6946), "$2a$11$K7sXL9VF.W8eQ4Qm7ybZwuPxHjVnZq3KvLmRcDfTgNhYjMpUvXsBC", new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(6947) });

            migrationBuilder.InsertData(
                table: "parameter_values",
                columns: new[] { "id", "created_at", "created_by", "name", "order_no", "parameter_definition_id", "updated_at", "updated_by", "value" },
                values: new object[,]
                {
                    { new Guid("10000004-0001-0001-0001-000000000001"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7315), null, "LGS", 1, new Guid("00000009-9999-9999-9999-999999999999"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7315), null, "LGS" },
                    { new Guid("10000004-0001-0001-0001-000000000002"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7319), null, "TYT", 2, new Guid("00000009-9999-9999-9999-999999999999"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7319), null, "TYT" },
                    { new Guid("10000004-0001-0001-0001-000000000003"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7322), null, "AYT", 3, new Guid("00000009-9999-9999-9999-999999999999"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7323), null, "AYT" },
                    { new Guid("10000004-0001-0001-0001-000000000004"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7325), null, "KPSS", 4, new Guid("00000009-9999-9999-9999-999999999999"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7326), null, "KPSS" },
                    { new Guid("10000004-0001-0001-0001-000000000005"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7328), null, "ALES", 5, new Guid("00000009-9999-9999-9999-999999999999"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7329), null, "ALES" },
                    { new Guid("10000004-0001-0001-0001-000000000006"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7332), null, "DGS", 6, new Guid("00000009-9999-9999-9999-999999999999"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7332), null, "DGS" },
                    { new Guid("10000004-0001-0001-0001-000000000007"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7335), null, "YDS", 7, new Guid("00000009-9999-9999-9999-999999999999"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7335), null, "YDS" },
                    { new Guid("10000004-0001-0001-0001-000000000008"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7338), null, "Diğer", 99, new Guid("00000009-9999-9999-9999-999999999999"), new DateTime(2025, 12, 2, 22, 31, 20, 403, DateTimeKind.Utc).AddTicks(7338), null, "OTHER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000005"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000006"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000007"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000008"));

            migrationBuilder.DeleteData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"));

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8361), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8366), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8370), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8374), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8377), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8378) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8388), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8391), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8392) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8394), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8431), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8431) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8435), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8436) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8439), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8439) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8442), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8443) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8445), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8445) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8451), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8451) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8454), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8454) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8457), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8457) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8460), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8462), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8463) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8465), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8466) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8468), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8468) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8471), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8471) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8516), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8520), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8520) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8523), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8523) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "password_hash", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8239), "$2a$11$MKiZ20zeoqBTNPV5HxwRruNo8uK4KQmNcD9eK3ndrZQZCHyOoesAW", new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8240) });
        }
    }
}
