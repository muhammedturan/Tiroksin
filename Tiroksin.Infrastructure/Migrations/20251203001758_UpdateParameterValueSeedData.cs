using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParameterValueSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "parameter_values",
                columns: new[] { "id", "created_at", "created_by", "name", "order_no", "parameter_definition_id", "parent_value_id", "updated_at", "updated_by", "value" },
                values: new object[,]
                {
                    { new Guid("10000001-0001-0001-0001-000000000101"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(436), null, "Matematik", 1, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000001"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(436), null, "lgs_matematik" },
                    { new Guid("10000001-0001-0001-0001-000000000102"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(444), null, "Fen Bilimleri", 2, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000001"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(444), null, "lgs_fen" },
                    { new Guid("10000001-0001-0001-0001-000000000103"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(448), null, "Türkçe", 3, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000001"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(449), null, "lgs_turkce" },
                    { new Guid("10000001-0001-0001-0001-000000000104"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(454), null, "Sosyal Bilgiler", 4, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000001"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(454), null, "lgs_sosyal" },
                    { new Guid("10000001-0001-0001-0001-000000000105"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(458), null, "İngilizce", 5, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000001"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(458), null, "lgs_ingilizce" },
                    { new Guid("10000001-0001-0001-0001-000000000106"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(462), null, "Din Kültürü", 6, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000001"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(463), null, "lgs_din" },
                    { new Guid("10000001-0001-0001-0001-000000000201"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(467), null, "Temel Matematik", 1, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000002"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(467), null, "tyt_matematik" },
                    { new Guid("10000001-0001-0001-0001-000000000202"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(471), null, "Fizik", 2, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000002"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(472), null, "tyt_fizik" },
                    { new Guid("10000001-0001-0001-0001-000000000203"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(476), null, "Kimya", 3, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000002"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(477), null, "tyt_kimya" },
                    { new Guid("10000001-0001-0001-0001-000000000204"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(485), null, "Biyoloji", 4, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000002"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(486), null, "tyt_biyoloji" },
                    { new Guid("10000001-0001-0001-0001-000000000205"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(490), null, "Türkçe", 5, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000002"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(490), null, "tyt_turkce" },
                    { new Guid("10000001-0001-0001-0001-000000000206"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(495), null, "Coğrafya", 6, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000002"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(496), null, "tyt_cografya" },
                    { new Guid("10000001-0001-0001-0001-000000000207"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(499), null, "Tarih", 7, new Guid("00000002-2222-2222-2222-222222222222"), new Guid("10000004-0001-0001-0001-000000000002"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(500), null, "tyt_tarih" }
                });

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

            migrationBuilder.InsertData(
                table: "parameter_values",
                columns: new[] { "id", "created_at", "created_by", "name", "order_no", "parameter_definition_id", "parent_value_id", "updated_at", "updated_by", "value" },
                values: new object[,]
                {
                    { new Guid("10000002-0001-0001-0001-000000000101"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(504), null, "Sayılar ve İşlemler", 1, new Guid("00000003-3333-3333-3333-333333333333"), new Guid("10000001-0001-0001-0001-000000000101"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(504), null, "lgs_mat_sayilar" },
                    { new Guid("10000002-0001-0001-0001-000000000102"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(508), null, "Cebir", 2, new Guid("00000003-3333-3333-3333-333333333333"), new Guid("10000001-0001-0001-0001-000000000101"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(508), null, "lgs_mat_cebir" },
                    { new Guid("10000002-0001-0001-0001-000000000103"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(512), null, "Geometri", 3, new Guid("00000003-3333-3333-3333-333333333333"), new Guid("10000001-0001-0001-0001-000000000101"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(513), null, "lgs_mat_geometri" },
                    { new Guid("10000002-0001-0001-0001-000000000201"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(516), null, "Temel Kavramlar", 1, new Guid("00000003-3333-3333-3333-333333333333"), new Guid("10000001-0001-0001-0001-000000000201"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(517), null, "tyt_mat_temel" },
                    { new Guid("10000002-0001-0001-0001-000000000202"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(524), null, "Cebir", 2, new Guid("00000003-3333-3333-3333-333333333333"), new Guid("10000001-0001-0001-0001-000000000201"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(524), null, "tyt_mat_cebir" },
                    { new Guid("10000002-0001-0001-0001-000000000203"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(528), null, "Geometri", 3, new Guid("00000003-3333-3333-3333-333333333333"), new Guid("10000001-0001-0001-0001-000000000201"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(528), null, "tyt_mat_geometri" },
                    { new Guid("10000002-0001-0001-0001-000000000204"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(532), null, "Olasılık ve İstatistik", 4, new Guid("00000003-3333-3333-3333-333333333333"), new Guid("10000001-0001-0001-0001-000000000201"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(532), null, "tyt_mat_olasilik" },
                    { new Guid("10000003-0001-0001-0001-000000000101"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(537), null, "Doğal Sayılar", 1, new Guid("00000004-4444-4444-4444-444444444444"), new Guid("10000002-0001-0001-0001-000000000101"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(537), null, "lgs_mat_sayilar_dogal" },
                    { new Guid("10000003-0001-0001-0001-000000000102"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(542), null, "Kesirler", 2, new Guid("00000004-4444-4444-4444-444444444444"), new Guid("10000002-0001-0001-0001-000000000101"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(542), null, "lgs_mat_sayilar_kesir" },
                    { new Guid("10000003-0001-0001-0001-000000000201"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(546), null, "Sayı Basamakları", 1, new Guid("00000004-4444-4444-4444-444444444444"), new Guid("10000002-0001-0001-0001-000000000201"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(546), null, "tyt_mat_temel_sayi" },
                    { new Guid("10000003-0001-0001-0001-000000000202"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(550), null, "Bölünebilme Kuralları", 2, new Guid("00000004-4444-4444-4444-444444444444"), new Guid("10000002-0001-0001-0001-000000000201"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(551), null, "tyt_mat_temel_bolunebilme" },
                    { new Guid("10000003-0001-0001-0001-000000000203"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(555), null, "EBOB-EKOK", 3, new Guid("00000004-4444-4444-4444-444444444444"), new Guid("10000002-0001-0001-0001-000000000201"), new DateTime(2025, 12, 3, 0, 17, 57, 533, DateTimeKind.Utc).AddTicks(555), null, "tyt_mat_temel_ebob_ekok" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000102"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000103"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000104"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000105"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000106"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000202"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000203"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000204"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000205"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000206"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000207"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000102"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000103"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000202"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000203"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000204"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000101"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000102"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000201"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000202"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000203"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000101"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000201"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000101"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000201"));

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
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9940), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9941) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9945), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9949), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9949) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9953), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9953) });

            migrationBuilder.InsertData(
                table: "parameter_values",
                columns: new[] { "id", "created_at", "created_by", "name", "order_no", "parameter_definition_id", "parent_value_id", "updated_at", "updated_by", "value" },
                values: new object[,]
                {
                    { new Guid("10000001-0001-0001-0001-000000000001"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9877), null, "Matematik", 1, new Guid("00000002-2222-2222-2222-222222222222"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9878), null, "1" },
                    { new Guid("10000001-0001-0001-0001-000000000002"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9882), null, "Fizik", 2, new Guid("00000002-2222-2222-2222-222222222222"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9883), null, "2" },
                    { new Guid("10000001-0001-0001-0001-000000000003"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9886), null, "Kimya", 3, new Guid("00000002-2222-2222-2222-222222222222"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9887), null, "3" },
                    { new Guid("10000001-0001-0001-0001-000000000004"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9894), null, "Biyoloji", 4, new Guid("00000002-2222-2222-2222-222222222222"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9895), null, "4" },
                    { new Guid("10000001-0001-0001-0001-000000000005"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9899), null, "Türkçe", 5, new Guid("00000002-2222-2222-2222-222222222222"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9899), null, "5" },
                    { new Guid("10000002-0001-0001-0001-000000000001"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9903), null, "Temel Matematik", 1, new Guid("00000003-3333-3333-3333-333333333333"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9904), null, "1" },
                    { new Guid("10000002-0001-0001-0001-000000000002"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9908), null, "Cebir", 2, new Guid("00000003-3333-3333-3333-333333333333"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9908), null, "2" },
                    { new Guid("10000002-0001-0001-0001-000000000003"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9912), null, "Geometri", 3, new Guid("00000003-3333-3333-3333-333333333333"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9912), null, "3" },
                    { new Guid("10000002-0001-0001-0001-000000000004"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9916), null, "Türev", 4, new Guid("00000003-3333-3333-3333-333333333333"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9917), null, "4" },
                    { new Guid("10000002-0001-0001-0001-000000000005"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9921), null, "İntegral", 5, new Guid("00000003-3333-3333-3333-333333333333"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9921), null, "5" },
                    { new Guid("10000003-0001-0001-0001-000000000001"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9925), null, "İşlem Önceliği", 1, new Guid("00000004-4444-4444-4444-444444444444"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9925), null, "1" },
                    { new Guid("10000003-0001-0001-0001-000000000002"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9932), null, "İkinci Dereceden Denklemler", 2, new Guid("00000004-4444-4444-4444-444444444444"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9932), null, "2" },
                    { new Guid("10000003-0001-0001-0001-000000000003"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9936), null, "Alan Hesaplama", 3, new Guid("00000004-4444-4444-4444-444444444444"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9937), null, "3" },
                    { new Guid("10000004-0001-0001-0001-000000000005"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9957), null, "ALES", 5, new Guid("00000009-9999-9999-9999-999999999999"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9957), null, "ALES" },
                    { new Guid("10000004-0001-0001-0001-000000000006"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9961), null, "DGS", 6, new Guid("00000009-9999-9999-9999-999999999999"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9962), null, "DGS" },
                    { new Guid("10000004-0001-0001-0001-000000000007"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9968), null, "YDS", 7, new Guid("00000009-9999-9999-9999-999999999999"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9969), null, "YDS" },
                    { new Guid("10000004-0001-0001-0001-000000000008"), new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9972), null, "Diğer", 99, new Guid("00000009-9999-9999-9999-999999999999"), null, new DateTime(2025, 12, 3, 0, 13, 28, 327, DateTimeKind.Utc).AddTicks(9973), null, "OTHER" }
                });

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
        }
    }
}
