using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParameterValueStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_parameter_values_entity_type_entity_id_parameter_definition",
                table: "parameter_values");

            migrationBuilder.DropIndex(
                name: "ix_parameter_values_parameter_definition_id",
                table: "parameter_values");

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

            migrationBuilder.DropColumn(
                name: "entity_id",
                table: "parameter_values");

            migrationBuilder.DropColumn(
                name: "entity_type",
                table: "parameter_values");

            migrationBuilder.AddColumn<string>(
                name: "category_pr",
                table: "questions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "subject_pr",
                table: "questions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "topic_pr",
                table: "questions",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "parameter_values",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "parameter_values",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "order_no",
                table: "parameter_values",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5832), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5833) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5837), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5842), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5846), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5846) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5849), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5849) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5853), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5853) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5864), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5864) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5867), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5868) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "name", "order_no", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5907), "Matematik", 1, new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5908), "matematik" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "name", "order_no", "parameter_definition_id", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5911), "Fizik", 2, new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5912), "fizik" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "name", "order_no", "parameter_definition_id", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5915), "Kimya", 3, new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5915), "kimya" });

            migrationBuilder.InsertData(
                table: "parameter_values",
                columns: new[] { "id", "created_at", "created_by", "name", "order_no", "parameter_definition_id", "updated_at", "updated_by", "value" },
                values: new object[,]
                {
                    { new Guid("10000001-0001-0001-0001-000000000004"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5918), null, "Biyoloji", 4, new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5919), null, "biyoloji" },
                    { new Guid("10000001-0001-0001-0001-000000000005"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5922), null, "Türkçe", 5, new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5922), null, "turkce" },
                    { new Guid("10000002-0001-0001-0001-000000000001"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5983), null, "Temel Matematik", 1, new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5983), null, "temel_matematik" },
                    { new Guid("10000002-0001-0001-0001-000000000002"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5990), null, "Cebir", 2, new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5990), null, "cebir" },
                    { new Guid("10000002-0001-0001-0001-000000000003"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5993), null, "Geometri", 3, new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5993), null, "geometri" },
                    { new Guid("10000002-0001-0001-0001-000000000004"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5996), null, "Türev", 4, new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5997), null, "turev" },
                    { new Guid("10000002-0001-0001-0001-000000000005"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6000), null, "İntegral", 5, new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6000), null, "integral" },
                    { new Guid("10000003-0001-0001-0001-000000000001"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6003), null, "İşlem Önceliği", 1, new Guid("00000004-4444-4444-4444-444444444444"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6003), null, "islem_onceligi" },
                    { new Guid("10000003-0001-0001-0001-000000000002"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6006), null, "İkinci Dereceden Denklemler", 2, new Guid("00000004-4444-4444-4444-444444444444"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6007), null, "ikinci_dereceden_denklemler" },
                    { new Guid("10000003-0001-0001-0001-000000000003"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6009), null, "Alan Hesaplama", 3, new Guid("00000004-4444-4444-4444-444444444444"), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6010), null, "alan_hesaplama" }
                });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "category_pr", "created_at", "subject_pr", "topic_pr", "updated_at" },
                values: new object[] { "matematik", new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6062), "temel_matematik", "islem_onceligi", new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6062) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "category_pr", "created_at", "subject_pr", "topic_pr", "updated_at" },
                values: new object[] { "matematik", new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6069), "cebir", "ikinci_dereceden_denklemler", new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6069) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "category_pr", "created_at", "subject_pr", "topic_pr", "updated_at" },
                values: new object[] { "matematik", new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6073), "geometri", "alan_hesaplama", new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6074) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5705), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5707) });

            migrationBuilder.CreateIndex(
                name: "ix_parameter_values_parameter_definition_id_value",
                table: "parameter_values",
                columns: new[] { "parameter_definition_id", "value" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_parameter_values_parameter_definition_id_value",
                table: "parameter_values");

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"));

            migrationBuilder.DropColumn(
                name: "category_pr",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "subject_pr",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "topic_pr",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "name",
                table: "parameter_values");

            migrationBuilder.DropColumn(
                name: "order_no",
                table: "parameter_values");

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "parameter_values",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<Guid>(
                name: "entity_id",
                table: "parameter_values",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "entity_type",
                table: "parameter_values",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6904), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6904) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6909), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6913), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6913) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6916), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6917) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6920), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6921) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6931), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6932) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6941), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6941) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6944), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6944) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "entity_id", "entity_type", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7138), new Guid("eeeeeeee-1111-1111-1111-111111111111"), "Question", new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7139), "Matematik" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "entity_id", "entity_type", "parameter_definition_id", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7143), new Guid("eeeeeeee-1111-1111-1111-111111111111"), "Question", new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7143), "Temel Matematik" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "entity_id", "entity_type", "parameter_definition_id", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7146), new Guid("eeeeeeee-1111-1111-1111-111111111111"), "Question", new Guid("00000004-4444-4444-4444-444444444444"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7146), "İşlem Önceliği" });

            migrationBuilder.InsertData(
                table: "parameter_values",
                columns: new[] { "id", "created_at", "created_by", "entity_id", "entity_type", "parameter_definition_id", "updated_at", "updated_by", "value" },
                values: new object[,]
                {
                    { new Guid("10000002-0002-0002-0002-000000000001"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7152), null, new Guid("eeeeeeee-2222-2222-2222-222222222222"), "Question", new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7153), null, "Matematik" },
                    { new Guid("10000002-0002-0002-0002-000000000002"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7156), null, new Guid("eeeeeeee-2222-2222-2222-222222222222"), "Question", new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7156), null, "Cebir" },
                    { new Guid("10000002-0002-0002-0002-000000000003"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7159), null, new Guid("eeeeeeee-2222-2222-2222-222222222222"), "Question", new Guid("00000004-4444-4444-4444-444444444444"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7160), null, "İkinci Dereceden Denklemler" },
                    { new Guid("10000003-0003-0003-0003-000000000001"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7163), null, new Guid("eeeeeeee-3333-3333-3333-333333333333"), "Question", new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7163), null, "Matematik" },
                    { new Guid("10000003-0003-0003-0003-000000000002"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7166), null, new Guid("eeeeeeee-3333-3333-3333-333333333333"), "Question", new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7166), null, "Geometri" },
                    { new Guid("10000003-0003-0003-0003-000000000003"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7169), null, new Guid("eeeeeeee-3333-3333-3333-333333333333"), "Question", new Guid("00000004-4444-4444-4444-444444444444"), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7169), null, "Alan Hesaplama" }
                });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6984), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6985) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6988), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6989) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6992), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6992) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6773), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6774) });

            migrationBuilder.CreateIndex(
                name: "ix_parameter_values_entity_type_entity_id_parameter_definition",
                table: "parameter_values",
                columns: new[] { "entity_type", "entity_id", "parameter_definition_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_parameter_values_parameter_definition_id",
                table: "parameter_values",
                column: "parameter_definition_id");
        }
    }
}
