using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParameterValuesToNumeric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9588), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9588) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9593), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9597), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9601), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9605), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9608), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9609) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9612), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9612) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9619), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9619) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9655), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9656), "1" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9660), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9660), "2" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9663), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9663), "3" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9666), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9666), "4" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9669), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9669), "5" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9673), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9673), "1" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9676), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9676), "2" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9681), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9682), "3" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9684), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9685), "4" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9688), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9688), "5" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9691), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9692), "1" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9694), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9695), "2" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9697), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9698), "3" });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "category_pr", "created_at", "subject_pr", "topic_pr", "updated_at" },
                values: new object[] { "1", new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9746), "1", "1", new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9746) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "category_pr", "created_at", "subject_pr", "topic_pr", "updated_at" },
                values: new object[] { "1", new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9750), "2", "2", new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9750) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "category_pr", "created_at", "subject_pr", "topic_pr", "updated_at" },
                values: new object[] { "1", new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9755), "3", "3", new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9756) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9456), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9457) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5907), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5908), "matematik" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5911), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5912), "fizik" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5915), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5915), "kimya" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5918), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5919), "biyoloji" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5922), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5922), "turkce" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5983), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5983), "temel_matematik" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5990), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5990), "cebir" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5993), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5993), "geometri" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5996), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(5997), "turev" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6000), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6000), "integral" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6003), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6003), "islem_onceligi" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6006), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6007), "ikinci_dereceden_denklemler" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at", "value" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6009), new DateTime(2025, 11, 28, 5, 35, 4, 975, DateTimeKind.Utc).AddTicks(6010), "alan_hesaplama" });

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
        }
    }
}
