using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParameterValueSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1754), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1754) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1808), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1809) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1813), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1814) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1817), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1817) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1833), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1833) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1837), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1837) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1842), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1845), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1846) });

            migrationBuilder.InsertData(
                table: "parameter_values",
                columns: new[] { "id", "created_at", "created_by", "entity_id", "entity_type", "parameter_definition_id", "updated_at", "updated_by", "value" },
                values: new object[,]
                {
                    { new Guid("10000001-0001-0001-0001-000000000001"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1993), null, new Guid("eeeeeeee-1111-1111-1111-111111111111"), "Question", new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1993), null, "Matematik" },
                    { new Guid("10000001-0001-0001-0001-000000000002"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1997), null, new Guid("eeeeeeee-1111-1111-1111-111111111111"), "Question", new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1997), null, "Temel Matematik" },
                    { new Guid("10000001-0001-0001-0001-000000000003"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2002), null, new Guid("eeeeeeee-1111-1111-1111-111111111111"), "Question", new Guid("00000004-4444-4444-4444-444444444444"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2002), null, "İşlem Önceliği" },
                    { new Guid("10000002-0002-0002-0002-000000000001"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2006), null, new Guid("eeeeeeee-2222-2222-2222-222222222222"), "Question", new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2006), null, "Matematik" },
                    { new Guid("10000002-0002-0002-0002-000000000002"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2010), null, new Guid("eeeeeeee-2222-2222-2222-222222222222"), "Question", new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2010), null, "Cebir" },
                    { new Guid("10000002-0002-0002-0002-000000000003"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2013), null, new Guid("eeeeeeee-2222-2222-2222-222222222222"), "Question", new Guid("00000004-4444-4444-4444-444444444444"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2013), null, "İkinci Dereceden Denklemler" },
                    { new Guid("10000003-0003-0003-0003-000000000001"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2016), null, new Guid("eeeeeeee-3333-3333-3333-333333333333"), "Question", new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2016), null, "Matematik" },
                    { new Guid("10000003-0003-0003-0003-000000000002"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2019), null, new Guid("eeeeeeee-3333-3333-3333-333333333333"), "Question", new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2019), null, "Geometri" },
                    { new Guid("10000003-0003-0003-0003-000000000003"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2023), null, new Guid("eeeeeeee-3333-3333-3333-333333333333"), "Question", new Guid("00000004-4444-4444-4444-444444444444"), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2023), null, "Alan Hesaplama" }
                });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1894), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1894) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1898), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1899) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1902), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1902) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1622), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1623) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0002-0002-0002-000000000001"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0002-0002-0002-000000000002"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0002-0002-0002-000000000003"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0003-0003-0003-000000000001"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0003-0003-0003-000000000002"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0003-0003-0003-000000000003"));

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3448), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3448) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3453), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3453) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3466), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3466) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3470), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3470) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3473), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3474) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3477), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3478) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3481), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3481) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3484), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3485) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3534), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3534) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3538), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3538) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3545), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3545) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3273), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3274) });
        }
    }
}
