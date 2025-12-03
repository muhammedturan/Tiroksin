using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParentValueIdToParameterValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "parent_value_id",
                table: "parameter_values",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9721), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9722) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9784), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9785) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9791), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9791) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9807), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9808) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9813), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9813) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9819), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9819) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9824), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9824) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9828), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9877), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9878) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9882), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9883) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9886), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9887) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9894), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9895) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9899), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9899) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9903), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9904) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9908), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9908) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9912), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9912) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9916), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9917) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9921), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9921) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9925), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9925) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9932), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9932) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9936), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9937) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9940), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9941) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9945), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9949), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9949) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9953), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9953) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9957), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9957) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000006"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9961), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9962) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000007"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9968), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9969) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000008"),
                columns: new[] { "created_at", "parent_value_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9972), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9973) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 328, DateTimeKind.Utc).AddTicks(40), new DateTime(2025, 12, 3, 0, 13, 28, 328, DateTimeKind.Utc).AddTicks(41) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 328, DateTimeKind.Utc).AddTicks(130), new DateTime(2025, 12, 3, 0, 13, 28, 328, DateTimeKind.Utc).AddTicks(131) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 328, DateTimeKind.Utc).AddTicks(135), new DateTime(2025, 12, 3, 0, 13, 28, 328, DateTimeKind.Utc).AddTicks(136) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9569), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9570) });

            migrationBuilder.CreateIndex(
                name: "ix_parameter_values_parent_value_id",
                table: "parameter_values",
                column: "parent_value_id");

            migrationBuilder.AddForeignKey(
                name: "fk_parameter_values_parameter_values_parent_value_id",
                table: "parameter_values",
                column: "parent_value_id",
                principalTable: "parameter_values",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_parameter_values_parameter_values_parent_value_id",
                table: "parameter_values");

            migrationBuilder.DropIndex(
                name: "ix_parameter_values_parent_value_id",
                table: "parameter_values");

            migrationBuilder.DropColumn(
                name: "parent_value_id",
                table: "parameter_values");

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
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8179), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8179) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8184), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8190), new DateTime(2025, 12, 2, 23, 52, 22, 855, DateTimeKind.Utc).AddTicks(8191) });

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
    }
}
