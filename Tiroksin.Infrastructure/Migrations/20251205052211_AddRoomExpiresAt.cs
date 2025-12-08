using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomExpiresAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "expires_at",
                table: "rooms",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6100), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6101) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6108), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6109) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6114), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6114) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6196), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6196) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6202), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6202) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6208), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6208) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6211), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6212) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6218), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6219) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6279), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6279) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6282), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6283) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6286), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6286) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000104"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6296), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6296) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000105"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6299), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6299) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000106"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6302), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6303) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6305), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6306) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6309), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6309) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6312), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6312) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6315), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6316) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000205"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6319), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000206"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6324), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6325) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000207"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6328), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6329) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6331), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6332) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6335), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6335) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6338), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6338) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6341), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6341) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6346), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6346) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6349), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6350) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6355), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6355) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6359), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6359) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6363), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6364) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6367), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6372) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6376), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6376) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6379), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6262), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6262) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6266), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6267) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6270), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6271) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6275), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6275) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6479), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6479) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6483), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6484) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6489), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(5965), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(5966) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expires_at",
                table: "rooms");

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(221), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(222) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(229), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(235), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(235) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(318), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(319) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(329), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(349), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(350) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(354), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(355) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(359), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(359) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(436), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(444), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(444) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(448), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(449) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000104"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(454), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(454) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000105"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(458), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(458) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000106"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(462), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(463) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(467), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(467) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(471), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(472) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(476), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(477) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(485), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(486) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000205"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(490), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(490) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000206"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(495), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(496) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000207"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(499), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(504), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(504) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(508), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(508) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(512), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(516), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(517) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(524), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(524) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(528), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(528) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(532), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(532) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(537), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(537) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(542), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(542) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(546), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(550), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(551) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(555), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(555) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(414), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(415) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(419), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(419) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(423), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(424) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(431), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(431) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(691), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(692) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(698), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(698) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(702), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(703) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(58), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(59) });
        }
    }
}
