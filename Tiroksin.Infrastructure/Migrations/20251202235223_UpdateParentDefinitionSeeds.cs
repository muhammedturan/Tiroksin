using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParentDefinitionSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8170), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8179), new Guid("00000009-9999-9999-9999-999999999999"), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8179) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8184), new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8190), new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8191) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8195), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8195) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8199), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8199) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8219), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8224), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8224) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8269), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8273), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8273) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8277), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8277) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8281), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8285), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8286) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8289), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8290) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8296), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8300), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8300) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8304), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8304) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8307), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8308) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8311), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8316), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8321), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8324), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8331), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8334), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8338), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8346), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8346) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000007"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8349), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8350) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000008"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8353), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8622), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8623) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8631), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8631) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8635), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8635) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(7961), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(7962) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3423), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3424) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3429), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3429) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3433), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3434) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3437), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3437) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3441), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3441) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3445), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3445) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3457), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3458) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3462), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3462) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3502), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3502) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3506), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3506) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3509), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3513), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3513) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3516), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3520), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3526), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3526) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3529), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3533), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3533) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3536), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3537) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3615), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3616) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3619), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3623), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3623) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3626), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3626) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3632), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3632) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3635), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3636) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3639), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3639) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3642), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3643) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3646), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3646) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000007"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3650), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000008"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3653), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3653) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3717), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3723), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3724) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3728), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3728) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3289), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3290) });
        }
    }
}
