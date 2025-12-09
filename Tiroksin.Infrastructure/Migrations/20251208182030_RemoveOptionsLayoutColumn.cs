using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOptionsLayoutColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "options_layout",
                table: "questions");

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9417), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9418) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9425), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9425) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9429), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9433), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9437), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9437) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9448), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9449) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9488), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9489) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9492), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9493) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9553), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9553) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9559), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9562), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9563) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000104"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9566), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9566) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000105"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9569), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000106"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9572), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9573) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9576), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9579), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9582), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9582) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9587), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9588) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000205"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9590), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9591) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000206"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9594), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9595) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000207"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9598), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9601), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9601) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9604), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9607), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9608) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9611), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9616), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9616) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9619), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9622), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9623) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9627), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9627) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9630), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9634), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9634) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9637), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9637) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9641), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9641) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9537), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9537) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9541), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9541) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9544), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9544) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9549), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9549) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9756), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9756) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9760), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9761) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9766), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9767) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9275), new DateTime(2025, 12, 8, 18, 20, 29, 399, DateTimeKind.Utc).AddTicks(9276) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "options_layout",
                table: "questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9864), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9865) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9873), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9873) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9877), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9878) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9894), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9894) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9898), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9898) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9901), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9901) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9904), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9905) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9908), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9908) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9966), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9966) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9970), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9970) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9973), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9973) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000104"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9976), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000105"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9980), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9980) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000106"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9983), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9983) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9986), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9987) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9992), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9992) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9995), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9995) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9999), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000205"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(2), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(3) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000206"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(6), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(6) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000207"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(9), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(9) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(12), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(12) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(15), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(16) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(21), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(21) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(25), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(25) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(66), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(70), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(70) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(73), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(73) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(78), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(78) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(81), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(82) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(86), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(86) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(92), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(92) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(96), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(96) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9944), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9948), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9948) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9951), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9952) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9958), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9958) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "options_layout", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(154), 0, new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(155) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "options_layout", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(159), 0, new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(159) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "options_layout", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(163), 0, new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(163) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9753), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9754) });
        }
    }
}
