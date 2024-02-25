using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP_Clients_Web_API.Migrations
{
    public partial class _22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c090a43d-bc2c-4b1d-9ab5-b05d959d8158"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ClientsISP",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ClientsISP",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ClientsISP",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("01a3cb71-c906-4c43-af63-982f15d621cc"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-17T00:00:00", "Address7", "Email7@gmail.com", "2024-02-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("01a87355-d00b-4fe7-acbc-832a104eeaca"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-18T00:00:00", "Address20", "Email20@gmail.com", "2024-02-10T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("03c53189-0d97-4bf5-9ebc-e74ea4a1da89"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-04-20T00:00:00", "Address19", "Email19@gmail.com", "2022-05-20T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0428860f-5ae4-4a67-b974-aad1eeb9cce4"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-03T00:00:00", "Address11", "Email11@gmail.com", "2024-01-04T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("04639589-b328-44a8-bcc3-b5a8220914e8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-10-17T00:00:00", "Address20", "Email20@gmail.com", "2024-10-15T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("05a7de35-8830-485a-bb9c-ea09c56649b0"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-02T00:00:00", "Address3", "Email3@gmail.com", "2024-07-15T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("06a9d0fc-807c-4775-8a96-6fd81d63bddf"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-07-16T00:00:00", "Address25", "Email25@gmail.com", "2024-01-15T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("06d817d1-3344-4e39-88a7-bbff789331ee"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-05T00:00:00", "Address18", "Email18@gmail.com", "2025-01-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0762a4b4-93bf-4bd0-a13a-ef03382fb3a8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-23T00:00:00", "Address17", "Email17@gmail.com", "2024-03-03T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("07cf23fa-e682-4f7e-9660-d9fa9717547f"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-02-04T00:00:00", "Address1", "Email1@gmail.com", "2024-03-04T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0b137860-be4b-4b05-8a8e-f90a1e99896b"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-10-29T00:00:00", "Address25", "Email25@gmail.com", "2021-11-14T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0fbda64c-6c69-4252-9646-824f304286f3"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-18T00:00:00", "Address5", "Email5@gmail.com", "2024-04-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0fc0a0eb-224f-4a34-9d5c-9c722753bd1b"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-17T00:00:00", "Address18", "Email18@gmail.com", "2024-02-06T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0ff58be4-45d7-4e0e-be24-cb7ac3137ec4"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-04T00:00:00", "Address0", "Email0@gmail.com", "2024-02-01T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1031f6f8-075e-4569-a775-3fb3b6c90023"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-07-15T00:00:00", "Address19", "Email19@gmail.com", "2022-08-16T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("11d31291-afc6-443d-be73-1806269d4f51"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2016-07-06T00:00:00", "Address24", "Email24@gmail.com", "0001-01-01T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("120a29ef-560d-4b0e-beb3-139a395ce5a5"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-01T00:00:00", "Address16", "Email16@gmail.com", "2024-02-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("12417d46-1d80-4696-90ab-aa8fdf1f9cc3"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-08-31T00:00:00", "Address10", "Email10@gmail.com", "2024-03-01T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("127ddde6-bd24-40d5-9822-6145975fee98"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-14T00:00:00", "Address16", "Email16@gmail.com", "2024-01-15T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("198395ef-0ad6-4750-9962-653e6f76b1a3"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-31T00:00:00", "Address20", "Email20@gmail.com", "2024-02-02T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1a3ccca6-d943-4031-b9da-b3526f599d21"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-01T00:00:00", "Address10", "Email10@gmail.com", "2024-08-02T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1d315603-14bc-4f70-a832-ddcafdd4df21"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-02-02T00:00:00", "Address7", "Email7@gmail.com", "2024-03-02T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1db031af-93f6-434b-8da8-1ef757ae616a"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-11T00:00:00", "Address12", "Email12@gmail.com", "2024-03-11T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1e3af7e3-7ef7-41b8-ad11-4fd5f418bd38"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-01T00:00:00", "Address22", "Email22@gmail.com", "2024-02-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1edbb03b-ce81-45c2-bc73-6a1f2efd50ac"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-04T00:00:00", "Address0", "Email0@gmail.com", "2024-04-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1f5ebe82-2041-42c0-b069-4f5ce9a004b8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-03T00:00:00", "Address0", "Email0@gmail.com", "2024-07-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2138ec16-720d-46d9-9d1a-d731cb305f30"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-02T00:00:00", "Address21", "Email21@gmail.com", "2024-02-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("23afd964-1626-4bb5-bdc5-94716fa99183"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-18T00:00:00", "Address15", "Email15@gmail.com", "2024-02-10T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("240300b1-a2cb-4f62-b0e4-1ac4988bf37c"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-02T00:00:00", "Address6", "Email6@gmail.com", "2024-02-01T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("246ee72a-e1c7-49cc-aadc-b24749aeea9f"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-11-05T00:00:00", "Address10", "Email10@gmail.com", "2022-12-05T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2489b508-f9fb-473e-8519-00532689563e"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-29T00:00:00", "Address12", "Email12@gmail.com", "2024-02-04T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2621be29-f8b2-4fa9-94b3-fe2e598e0c07"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-02T00:00:00", "Address9", "Email9@gmail.com", "2024-02-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-02-04T00:00:00", "Address15", "Email15@gmail.com", "2024-03-04T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("274ec2c5-ec55-42d5-aae7-619004eb964d"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-02-06T00:00:00", "Address10", "Email10@gmail.com", "2024-03-06T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("289a93f4-10ee-452f-ac7e-927b7733a146"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-31T00:00:00", "Address25", "Email25@gmail.com", "2024-02-01T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("29ae74fd-42ea-4105-be15-08f5d9897182"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-02-23T00:00:00", "Address22", "Email22@gmail.com", "2024-02-20T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2a9bd1c8-4bfd-4874-912e-a7fa09113f44"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-10-18T00:00:00", "Address10", "Email10@gmail.com", "2022-11-10T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2aafe212-2efd-435e-83f6-95bbe58d7158"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-22T00:00:00", "Address11", "Email11@gmail.com", "2024-02-08T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2c6a0d5b-da21-41d3-ab48-ec29a2e4b290"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-09-13T00:00:00", "Address24", "Email24@gmail.com", "2024-03-10T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2eea61fe-f0b2-4ba3-a408-5c443a65c6ad"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-31T00:00:00", "Address8", "Email8@gmail.com", "2024-02-01T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2f713e9c-8dc6-4a7a-b1fb-f94d50fff257"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-09-10T00:00:00", "Address11", "Email11@gmail.com", "2023-10-21T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("310cf4ed-40c4-4aa2-af14-6784f3100fd1"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-26T00:00:00", "Address15", "Email15@gmail.com", "2024-12-01T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("31968ee3-b21a-4835-8722-87a7a7324ed3"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-01-07T00:00:00", "Address3", "Email3@gmail.com", "2023-02-10T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("336a697e-b31c-4685-86ee-07eb191c1e89"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-22T00:00:00", "Address23", "Email23@gmail.com", "2024-02-10T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("33a7ded1-5e53-41a2-9ce3-37a9b9f0ee92"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-21T00:00:00", "Address18", "Email18@gmail.com", "2024-01-20T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("33b60808-5f5a-4cd2-9605-6748dafa9835"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-07-31T00:00:00", "Address11", "Email11@gmail.com", "2021-09-01T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("33fd7020-cc4d-4ee5-aa3c-3f4fc7eda960"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-21T00:00:00", "Address19", "Email19@gmail.com", "2024-02-01T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("340a076d-0c53-4e24-899d-d7aa73094abb"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-23T00:00:00", "Address8", "Email8@gmail.com", "2024-03-03T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("3797ff2b-53f3-4dbe-bf97-5bbc7a8ed1ed"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-09T00:00:00", "Address12", "Email12@gmail.com", "2024-03-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("38e79480-ff3f-4d90-8791-aa2a67d5d510"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-14T00:00:00", "Address17", "Email17@gmail.com", "2024-02-14T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("399713a9-624c-432e-8c19-8102310367c5"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-10-14T00:00:00", "Address15", "Email15@gmail.com", "2023-12-15T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("3abebc77-e824-439d-9a67-062e8dc84ee7"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-30T00:00:00", "Address16", "Email16@gmail.com", "2024-06-08T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("3cfc5fda-1fd2-45d9-ba02-04ca10f0b500"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-12-31T00:00:00", "Address15", "Email15@gmail.com", "2025-01-01T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("3e5bfb2a-9271-4920-864b-df62f5a3f41c"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-03T00:00:00", "Address13", "Email13@gmail.com", "2024-02-01T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("3f2cef07-b243-40ad-b3bd-7e928bd1d26b"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-07T00:00:00", "Address13", "Email13@gmail.com", "2024-02-25T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("408c2e53-a963-4ba8-ba67-a06a5e9d64e9"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-01-02T00:00:00", "Address18", "Email18@gmail.com", "2031-01-08T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("40c316d9-c4ca-4d2d-9352-cee627b46e20"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2020-08-03T00:00:00", "Address8", "Email8@gmail.com", "2020-09-15T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("43b49bb1-946c-4cab-a080-c16749d00b3e"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-10-27T00:00:00", "Address14", "Email14@gmail.com", "2024-11-01T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4409de67-2267-4899-b24a-c449b583adb8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-08-03T00:00:00", "Address15", "Email15@gmail.com", "2023-09-01T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("44274dc7-82e8-4274-a2bc-51488ee2100a"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-20T00:00:00", "Address24", "Email24@gmail.com", "2024-01-20T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4477f657-9f3f-4651-90c2-c1a1665b9f85"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-10-07T00:00:00", "Address6", "Email6@gmail.com", "2024-10-01T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("44eae22f-b163-44fc-ad27-aa933702bcfa"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2020-04-17T00:00:00", "Address19", "Email19@gmail.com", "2020-05-17T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4532be7f-fada-4ad6-b91a-0ca2ea2992fc"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-25T00:00:00", "Address1", "Email1@gmail.com", "2024-01-25T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4547e8ec-b5f0-4d87-a423-f612e39e83ad"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-02-04T00:00:00", "Address6", "Email6@gmail.com", "2024-03-04T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4588e482-af5f-4315-a614-ff8aadfb3d3b"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-25T00:00:00", "Address13", "Email13@gmail.com", "2024-01-31T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("45fe189b-b787-47ba-bc50-672f8a798b2a"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-29T00:00:00", "Address0", "Email0@gmail.com", "2024-02-01T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("474717e1-b5aa-4063-b73e-faa25f77aa58"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-03T00:00:00", "Address1", "Email1@gmail.com", "2024-01-22T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("47ab3c52-ab56-4ac9-acbb-91ea35921899"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-23T00:00:00", "Address15", "Email15@gmail.com", "2024-02-01T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("47e17c1f-6f6e-4845-a87a-59eb6dbb9a35"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-01T00:00:00", "Address21", "Email21@gmail.com", "2024-08-02T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("49c3731e-a782-432a-94a9-7d6814768eef"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-04T00:00:00", "Address9", "Email9@gmail.com", "2024-02-01T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4c08b9a0-a07a-40e5-8d07-8efcd3135398"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-10-24T00:00:00", "Address7", "Email7@gmail.com", "2024-09-01T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4c8bd5f5-6cc2-4d11-8589-9f89265a5e27"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-22T00:00:00", "Address21", "Email21@gmail.com", "2024-01-31T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4d865598-ce44-4f71-aac3-70a9ae6602f6"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-06T00:00:00", "Address11", "Email11@gmail.com", "2024-06-01T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4e563aeb-1b21-43ff-aa05-d888d7207393"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-08-27T00:00:00", "Address0", "Email0@gmail.com", "2022-08-25T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4e6e5645-1772-4f10-a770-883587b55847"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-07-31T00:00:00", "Address0", "Email0@gmail.com", "2024-02-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4feecb5d-a239-4899-9f00-0d0a9564434e"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-06-11T00:00:00", "Address2", "Email2@gmail.com", "2023-10-10T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("501b678f-3ac0-4fa9-b6ae-1eec3d421e44"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-29T00:00:00", "Address18", "Email18@gmail.com", "2024-02-01T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("50a30523-01cf-4b9a-923d-44d93f8691a4"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-23T00:00:00", "Address9", "Email9@gmail.com", "2024-03-03T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("50fe9d97-1b9f-4bf2-941c-f69ebf7f50e5"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-09-28T00:00:00", "Address13", "Email13@gmail.com", "2024-04-01T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("52b86300-8d82-4cb6-a38a-c8cc84cd2dd4"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-02T00:00:00", "Address6", "Email6@gmail.com", "2024-02-01T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5556b57e-64f0-4185-8e5f-3e3e8b7f3753"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-02-02T00:00:00", "Address9", "Email9@gmail.com", "2024-03-01T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("568600a9-b595-4f98-8bf6-23f9780f0ee1"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-12T00:00:00", "Address3", "Email3@gmail.com", "2024-02-07T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5742eb85-838c-4716-9d15-4cd8a9199644"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-23T00:00:00", "Address12", "Email12@gmail.com", "2024-02-09T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("591903ee-ce91-4073-9d95-ec8204e6aa20"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-03T00:00:00", "Address9", "Email9@gmail.com", "2024-02-01T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("59c44048-fb76-4538-9b95-17544410b4cd"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2020-05-26T00:00:00", "Address12", "Email12@gmail.com", "2020-06-09T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5ae6dabd-d0f5-4623-8939-33cff2210b3a"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-30T00:00:00", "Address13", "Email13@gmail.com", "2024-02-01T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5aec6ea5-18ed-42fe-81cb-c2e0583b1533"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-06T00:00:00", "Address23", "Email23@gmail.com", "2024-02-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5caf612a-7ab6-4807-81a2-b1e3d0982976"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-12T00:00:00", "Address8", "Email8@gmail.com", "2023-12-01T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5cdbe722-1566-4684-8b19-eccbd22ea851"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-07-27T00:00:00", "Address20", "Email20@gmail.com", "2024-01-23T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5d58feaf-6405-4e95-a2a5-c239a1bdc9ea"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-02-03T00:00:00", "Address4", "Email4@gmail.com", "2024-03-03T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5db550c1-50d9-4d47-ab9d-6e0856141241"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-18T00:00:00", "Address8", "Email8@gmail.com", "2024-01-17T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5dde3937-7de5-46cd-9340-5e6a686d6bb0"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-09T00:00:00", "Address18", "Email18@gmail.com", "2024-07-01T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5e59df8c-f2e4-4739-9ab6-6d947327f276"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-19T00:00:00", "Address8", "Email8@gmail.com", "2024-12-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5ee5548e-1a41-406e-9397-cf06fd01dca9"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-02-04T00:00:00", "Address23", "Email23@gmail.com", "2024-03-04T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("645c9e41-b7c8-44d2-bb58-5e5fe02ba27f"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-01-28T00:00:00", "Address2", "Email2@gmail.com", "2023-02-24T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("65fa09eb-4b0e-461c-a5c2-b291f0099b61"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-06-30T00:00:00", "Address3", "Email3@gmail.com", "2022-08-01T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("663b6397-1730-427f-abe6-dbb90ad1dad8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-10-30T00:00:00", "Address17", "Email17@gmail.com", "2024-12-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("68790c54-7d3b-42f3-8625-b44685fd789f"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-13T00:00:00", "Address3", "Email3@gmail.com", "2024-02-10T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("6e306dd6-0b0b-4ace-8025-221179784c0d"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2020-08-29T00:00:00", "Address14", "Email14@gmail.com", "2020-09-10T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("6e32981f-44a9-4ad9-b8a3-2e5b7abd7c00"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-07-31T00:00:00", "Address10", "Email10@gmail.com", "2023-09-01T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("6e425ed5-df18-4edb-b358-fd9644f716a0"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-17T00:00:00", "Address20", "Email20@gmail.com", "2024-02-02T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("6f9ba823-ad52-44bd-ba98-8bc895b2b3d6"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-30T00:00:00", "Address20", "Email20@gmail.com", "2025-01-01T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("70207bf0-a3e7-48a2-889e-fcadd23e1908"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-03-21T00:00:00", "Address22", "Email22@gmail.com", "2024-04-01T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("710a82cf-b6ca-4b76-9d37-52dd843af6af"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-04-08T00:00:00", "Address2", "Email2@gmail.com", "2024-05-15T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("71d49a70-1721-41e6-bd4f-e0812ffebce5"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-02T00:00:00", "Address9", "Email9@gmail.com", "2024-01-02T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("72abc9f9-8a67-4abc-8d17-ea3670f77adb"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-08T00:00:00", "Address2", "Email2@gmail.com", "2024-02-10T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("746f63b7-8e32-44e0-9f84-398aa8949853"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-08-13T00:00:00", "Address4", "Email4@gmail.com", "2023-09-08T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("755a0d47-c385-4092-a286-41b0bdbd9cd8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-11-28T00:00:00", "Address13", "Email13@gmail.com", "0001-01-01T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("767abf7e-b2f5-4ef2-960a-3b686ec1a4b7"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-07T00:00:00", "Address14", "Email14@gmail.com", "2024-03-01T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("76ff08ab-9960-4801-b76a-10d127b3ec83"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-16T00:00:00", "Address12", "Email12@gmail.com", "2024-01-15T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("772aed74-3f23-4f70-ad97-93f595a76102"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-09-08T00:00:00", "Address14", "Email14@gmail.com", "2023-10-07T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("77fff8cb-09f3-4349-8d00-5669e5727262"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-25T00:00:00", "Address11", "Email11@gmail.com", "2024-01-01T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("7958a937-42e8-4aae-943b-daafe8f053c5"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-05-21T00:00:00", "Address12", "Email12@gmail.com", "2023-08-30T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("7cc40ce9-beb8-49c5-9f85-ab5a566c32b8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-08-13T00:00:00", "Address1", "Email1@gmail.com", "2021-09-07T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("7d7f5602-9944-4a2c-a54a-d5878541862a"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-13T00:00:00", "Address5", "Email5@gmail.com", "2024-03-12T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("82a4ab9f-ec53-4158-83a9-a8eb505bd1a0"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-22T00:00:00", "Address7", "Email7@gmail.com", "2024-02-10T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("836052a4-55af-4b43-892e-86557b822595"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-02-24T00:00:00", "Address4", "Email4@gmail.com", "2021-03-19T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("87cc7388-262f-46ab-a6e5-caba8896b912"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-04-30T00:00:00", "Address2", "Email2@gmail.com", "2023-06-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("87f667bd-989b-4063-8e4c-936c9664e5e8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-01T00:00:00", "Address21", "Email21@gmail.com", "2024-02-12T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8986f06b-5a9e-498f-a6e7-42f4c65b6e79"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-19T00:00:00", "Address10", "Email10@gmail.com", "2024-06-01T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("89fe366d-5d89-424e-9418-bc9d608d81f8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-21T00:00:00", "Address16", "Email16@gmail.com", "2024-02-20T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8a1b925d-c891-4d8f-8b01-6f1ca837dd45"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-12T00:00:00", "Address1", "Email1@gmail.com", "2024-06-15T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8bbc9183-bf4f-4608-8452-399b4114f1b1"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-06-02T00:00:00", "Address5", "Email5@gmail.com", "2026-07-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8d30ed64-3b90-4689-96d4-2a447e254036"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-22T00:00:00", "Address20", "Email20@gmail.com", "2024-02-10T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8d874715-2d6d-4cf2-a4d8-4394056fb73a"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-04-09T00:00:00", "Address12", "Email12@gmail.com", "2027-10-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8e30fc6d-5152-4bef-8770-9ae8c2b2d296"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-02T00:00:00", "Address1", "Email1@gmail.com", "2024-02-16T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8ef9c694-b2a7-45ed-9ca3-31cd5fea9c15"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-01T00:00:00", "Address23", "Email23@gmail.com", "2024-02-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("910e57e7-7bea-4a9c-b1b8-477fdf7e5289"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-23T00:00:00", "Address5", "Email5@gmail.com", "2024-03-03T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("912dbaa6-2f41-4f9f-ab49-ba2c857d9dfa"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-10-05T00:00:00", "Address4", "Email4@gmail.com", "2024-11-01T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9140f836-0c67-4f66-88c4-7b4127c0e722"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-17T00:00:00", "Address11", "Email11@gmail.com", "2024-02-08T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("93c1868b-0026-43e9-a320-48e21fcf13e6"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-08-09T00:00:00", "Address12", "Email12@gmail.com", "2022-08-30T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9593c99e-3568-4d43-a406-94d65016dc27"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-04T00:00:00", "Address1", "Email1@gmail.com", "2024-02-05T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9648e4c4-36f8-440b-b085-6810f1113e7e"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-27T00:00:00", "Address16", "Email16@gmail.com", "2024-03-29T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("97aa5c1a-0241-4c24-80a8-3a5c87ac6021"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-03T00:00:00", "Address14", "Email14@gmail.com", "2024-02-02T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9d13236e-28ed-45bf-9c6e-71bec5192e62"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-08-11T00:00:00", "Address18", "Email18@gmail.com", "2024-02-01T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9d1bedf6-bac0-4245-843e-d072fa814bc8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-08T00:00:00", "Address5", "Email5@gmail.com", "2024-02-07T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9d2b4d9a-96eb-47fa-950e-eb92bd1cc353"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-21T00:00:00", "Address20", "Email20@gmail.com", "2024-07-01T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9e28b1ec-6d7e-4720-99c2-9c933922e37c"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-10T00:00:00", "Address4", "Email4@gmail.com", "2024-03-10T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9eda691c-f335-4ccb-b719-b41378420976"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-17T00:00:00", "Address13", "Email13@gmail.com", "2024-02-08T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9f4193e9-7207-46fb-8cda-e782e469ff63"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-18T00:00:00", "Address12", "Email12@gmail.com", "2024-02-02T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9f9412b2-951e-482c-a08f-ce80058e07b8"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-27T00:00:00", "Address0", "Email0@gmail.com", "2024-01-31T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("a0006dd7-7c4e-4f01-b4d6-4f4692d1f6ea"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-14T00:00:00", "Address1", "Email1@gmail.com", "2025-02-20T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("a784f680-6010-404a-a15a-d86e8da0fa04"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-03T00:00:00", "Address13", "Email13@gmail.com", "2024-02-01T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("a8849296-dd2d-4fd3-aacd-1ca2c6ec6e80"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-03T00:00:00", "Address17", "Email17@gmail.com", "2024-03-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("a88854f5-ec4b-477a-b5b4-c5d3aeef3f75"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-17T00:00:00", "Address25", "Email25@gmail.com", "2024-02-04T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ab0650b2-e025-4550-8e2e-195ad5ae645f"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-08-06T00:00:00", "Address21", "Email21@gmail.com", "2021-09-05T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("aba300f8-dc42-4ca6-adb0-0cc894e29ac6"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-09-01T00:00:00", "Address15", "Email15@gmail.com", "2021-10-01T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("acc4c8a4-6805-498e-9c80-4c578e90ccf4"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-07-08T00:00:00", "Address11", "Email11@gmail.com", "2024-01-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ae548204-8276-479e-a798-f5b000d59552"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2019-02-26T00:00:00", "Address13", "Email13@gmail.com", "2023-08-01T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ae75f74a-3824-4ac5-ada4-d793f77a41b0"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-02T00:00:00", "Address5", "Email5@gmail.com", "2024-02-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("aeacb899-8a07-43b5-98e0-dd228d41530c"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-06T00:00:00", "Address23", "Email23@gmail.com", "2024-01-24T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("af164350-0d87-48fe-be19-d886995c6438"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-12T00:00:00", "Address15", "Email15@gmail.com", "2024-02-10T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("b2813627-43c7-4eda-9e77-fd9dfd983eb0"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-18T00:00:00", "Address9", "Email9@gmail.com", "2024-01-17T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("b43d7cd1-971b-4287-aa07-11d5328def5c"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-21T00:00:00", "Address0", "Email0@gmail.com", "2024-02-01T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("bb0f760a-0a06-4ba8-bdbf-af2b8be9b21b"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-10T00:00:00", "Address8", "Email8@gmail.com", "2024-07-07T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("bbd4def6-c941-4e41-b0d9-0b0d09cd62c2"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-15T00:00:00", "Address7", "Email7@gmail.com", "2024-02-16T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("bc90190b-7cd1-4bc1-a764-d20a3767b1cc"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-23T00:00:00", "Address8", "Email8@gmail.com", "2024-02-07T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("bd50773e-aec0-4875-b09a-9bb925a3c40c"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-18T00:00:00", "Address24", "Email24@gmail.com", "2024-02-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("bef9a084-84c9-41bf-a3c6-e3d284b3e770"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2020-09-28T00:00:00", "Address18", "Email18@gmail.com", "2020-10-02T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c00957c7-cf21-4879-b4cb-b85af004af78"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-09-06T00:00:00", "Address17", "Email17@gmail.com", "2024-09-01T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c10be855-5e1b-4b7e-91e2-312f6341518f"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-02T00:00:00", "Address25", "Email25@gmail.com", "2024-01-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c1c1a1e3-07b9-4c07-89dd-567b67b69bdc"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-08T00:00:00", "Address2", "Email2@gmail.com", "2024-02-08T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c3450834-5b88-4098-9f32-f21aa5824495"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-12T00:00:00", "Address4", "Email4@gmail.com", "2024-05-11T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c68218d7-0b49-43a6-82cc-329ebaa70e1d"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-06T00:00:00", "Address0", "Email0@gmail.com", "2024-02-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c6bef67d-b55e-4a41-acba-4690beb7d2a2"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-11T00:00:00", "Address11", "Email11@gmail.com", "2025-01-15T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c793214b-0b83-4eaf-a3a9-0ea288083d02"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2020-02-25T00:00:00", "Address6", "Email6@gmail.com", "2020-04-11T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("cd07196a-f288-4e72-9b29-8cd1ba673f87"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-19T00:00:00", "Address15", "Email15@gmail.com", "2024-01-20T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("cd61f564-fde5-4d82-ac62-bd2574aa9619"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-05T00:00:00", "Address23", "Email23@gmail.com", "2024-02-04T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("cda93907-078a-4959-8bc1-07b4f493926b"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-26T00:00:00", "Address23", "Email23@gmail.com", "2024-01-23T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ce7cc9df-36c6-410f-ba1c-1a4ca0b36623"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-22T00:00:00", "Address15", "Email15@gmail.com", "2024-07-01T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d0cc1ba8-0fcb-4cfa-94a4-ff1222794da6"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-05T00:00:00", "Address19", "Email19@gmail.com", "2024-02-01T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d11111e7-0b15-4065-af56-ad3b5efdc936"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-27T00:00:00", "Address3", "Email3@gmail.com", "2024-02-17T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d132c6ee-0c21-430f-956d-26e297f6eb3a"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-22T00:00:00", "Address25", "Email25@gmail.com", "2024-02-10T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d16485e7-0b15-4065-af56-ad3b5efdc936"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-10-04T00:00:00", "Address24", "Email24@gmail.com", "2024-04-01T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d1c1f2cb-4e7b-44e7-846d-176f5923e1c4"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-15T00:00:00", "Address0", "Email0@gmail.com", "2024-02-15T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d23bbd77-fe5c-4a8a-92cb-22cebed75f8b"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-30T00:00:00", "Address16", "Email16@gmail.com", "2024-02-01T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d35178e6-81d7-4ad1-b7f9-5d8eb033901d"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-08-04T00:00:00", "Address5", "Email5@gmail.com", "2024-08-03T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d39e026f-0c6a-4973-a9b5-fc7d47a01f25"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2019-08-09T00:00:00", "Address14", "Email14@gmail.com", "2019-09-10T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d7f14a32-2522-4fde-b315-0034e81afd6e"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-01T00:00:00", "Address17", "Email17@gmail.com", "2024-02-01T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d812eb16-26ff-4025-adab-5dba21d3144a"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-03T00:00:00", "Address5", "Email5@gmail.com", "2024-03-04T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d849f168-235b-44d1-8336-5d1e22cfa098"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-04T00:00:00", "Address2", "Email2@gmail.com", "2024-02-04T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d8985f55-410a-40e5-bed0-a55f9f82f945"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-03-25T00:00:00", "Address4", "Email4@gmail.com", "2024-04-01T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d8b76fab-069d-4112-9285-1ab2334b44dc"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-08-20T00:00:00", "Address0", "Email0@gmail.com", "2024-09-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d8fa44fd-53aa-405d-810b-73d7d9881a96"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2020-09-28T00:00:00", "Address23", "Email23@gmail.com", "2020-10-24T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("da02b14a-e0f0-4197-a283-7a6d9b46f50b"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-07-18T00:00:00", "Address21", "Email21@gmail.com", "2023-08-15T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("db448b88-aaef-44ce-a120-3f4a54ca2d92"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-08T00:00:00", "Address22", "Email22@gmail.com", "2024-02-15T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dbf08eb1-cd35-48de-a9d3-0384382233a0"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2020-05-22T00:00:00", "Address13", "Email13@gmail.com", "2020-06-22T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dc1243a8-4594-4fd0-8856-cd7935334989"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-10-02T00:00:00", "Address10", "Email10@gmail.com", "2024-04-20T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dc49eda1-ff3b-4f0a-8892-70878a5747b2"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-17T00:00:00", "Address10", "Email10@gmail.com", "2024-02-07T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dc92dab4-1233-49de-b8d6-e2783eefa11f"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-05T00:00:00", "Address21", "Email21@gmail.com", "2024-05-10T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dd20e3d6-5667-405c-af6c-13ad6c163163"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-23T00:00:00", "Address25", "Email25@gmail.com", "2024-02-10T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dd214b54-80ee-4e75-abab-e3d198d23577"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-08T00:00:00", "Address14", "Email14@gmail.com", "2024-02-15T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("df5db1f8-d511-42b7-860a-a704dd0f24fb"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-06T00:00:00", "Address7", "Email7@gmail.com", "2024-02-15T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("df9e71d7-9c63-42fc-93f9-ac3246383a2a"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-31T00:00:00", "Address11", "Email11@gmail.com", "2024-02-01T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e17dab90-642a-4e03-8cc0-4067d1c443e7"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-06T00:00:00", "Address11", "Email11@gmail.com", "2024-07-01T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e2dde72f-34cb-43cc-a8d0-d261cf7b9af1"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-03T00:00:00", "Address21", "Email21@gmail.com", "2023-12-01T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e4667dd4-8a63-4f77-876e-2a3e9e011bae"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-06-16T00:00:00", "Address21", "Email21@gmail.com", "2023-06-16T00:00:00", "Phone7" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e55cd416-7ff7-424a-a56e-499b112d37ad"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-02-04T00:00:00", "Address20", "Email20@gmail.com", "2024-03-04T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e5ff1958-60aa-4a00-87a7-fa43b40ab3d5"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2017-07-25T00:00:00", "Address4", "Email4@gmail.com", "2017-09-17T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e6c2181c-5b2a-4681-bc3b-afc32d6450c9"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-19T00:00:00", "Address4", "Email4@gmail.com", "2024-01-21T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e81aa252-196c-42ed-9950-c386ccdd879e"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-11-08T00:00:00", "Address18", "Email18@gmail.com", "2023-12-01T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("eaf62615-2f83-43f4-8131-b6d5c00cac13"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-01T00:00:00", "Address20", "Email20@gmail.com", "2024-02-01T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ed6515a1-c814-457b-b1bd-8afaa8844ea6"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-08T00:00:00", "Address9", "Email9@gmail.com", "2024-02-07T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ed78f817-bd02-4cc6-8d47-cfaa1634a3c2"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-10-26T00:00:00", "Address1", "Email1@gmail.com", "2021-11-26T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f404c653-453b-472a-8264-bb05eb62adea"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-15T00:00:00", "Address1", "Email1@gmail.com", "2024-06-20T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f40a8ad1-3c88-40de-947b-1c23e9f6255e"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "0001-01-01T00:00:00", "Address24", "Email24@gmail.com", "2024-01-01T00:00:00", "Phone0" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f4ebab30-1e43-4787-a0ad-95961976f48b"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-31T00:00:00", "Address22", "Email22@gmail.com", "2024-02-01T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f4f73ef4-f65e-4587-9dda-3d5fad2a99d2"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2021-07-19T00:00:00", "Address20", "Email20@gmail.com", "2021-08-19T00:00:00", "Phone3" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f53d96e3-a514-49fc-81ef-5a927e22bcf2"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-03T00:00:00", "Address0", "Email0@gmail.com", "2024-02-01T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f73f2e64-c824-4c77-bca1-9dfaaad21c2f"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2022-11-18T00:00:00", "Address22", "Email22@gmail.com", "2022-12-18T00:00:00", "Phone5" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f79c9dcc-69d6-487d-95fd-8140e4361391"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-17T00:00:00", "Address12", "Email12@gmail.com", "2024-01-17T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f96acb79-4b1c-49a5-b28c-8fd1d0dea944"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-07-08T00:00:00", "Address4", "Email4@gmail.com", "2023-09-04T00:00:00", "Phone4" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("fa300434-f3a9-41ec-922c-749d1c01a377"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-13T00:00:00", "Address20", "Email20@gmail.com", "2024-02-16T00:00:00", "Phone8" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("fab55430-7a44-4a1d-a1cd-601801514e67"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-12-29T00:00:00", "Address7", "Email7@gmail.com", "2024-07-01T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("fbe54285-2504-4762-96ca-94f56eac9141"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2020-12-29T00:00:00", "Address1", "Email1@gmail.com", "2021-01-29T00:00:00", "Phone2" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("fcbb140c-6698-4e72-84a3-11e8eb4d222c"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-05T00:00:00", "Address23", "Email23@gmail.com", "2025-01-01T00:00:00", "Phone1" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("fd63f34b-0b3e-4e9c-b1fa-7911c85d89da"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2023-10-04T00:00:00", "Address21", "Email21@gmail.com", "2024-04-01T00:00:00", "Phone6" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("feaf5560-6113-403b-8c56-0d5c33832b40"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-22T00:00:00", "Address13", "Email13@gmail.com", "2024-02-13T00:00:00", "Phone9" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ff2cf652-03ba-4521-a6dd-166b7b73bb2c"),
                columns: new[] { "ActivationDate", "Address", "Email", "ExpiredDate", "Phone" },
                values: new object[] { "2024-01-06T00:00:00", "Address24", "Email24@gmail.com", "2024-07-06T00:00:00", "Phone3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ClientsISP");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ClientsISP");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ClientsISP");

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("01a3cb71-c906-4c43-af63-982f15d621cc"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-17", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("01a87355-d00b-4fe7-acbc-832a104eeaca"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-18", "2024-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("03c53189-0d97-4bf5-9ebc-e74ea4a1da89"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-04-20", "2022-05-20" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0428860f-5ae4-4a67-b974-aad1eeb9cce4"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-03", "2024-01-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("04639589-b328-44a8-bcc3-b5a8220914e8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-10-17", "2024-10-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("05a7de35-8830-485a-bb9c-ea09c56649b0"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-02", "2024-07-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("06a9d0fc-807c-4775-8a96-6fd81d63bddf"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-07-16", "2024-01-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("06d817d1-3344-4e39-88a7-bbff789331ee"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-05", "2025-01-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0762a4b4-93bf-4bd0-a13a-ef03382fb3a8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-23", "2024-03-03" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("07cf23fa-e682-4f7e-9660-d9fa9717547f"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-02-04", "2024-03-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0b137860-be4b-4b05-8a8e-f90a1e99896b"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-10-29", "2021-11-14" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0fbda64c-6c69-4252-9646-824f304286f3"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-18", "2024-04-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0fc0a0eb-224f-4a34-9d5c-9c722753bd1b"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-17", "2024-02-06" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("0ff58be4-45d7-4e0e-be24-cb7ac3137ec4"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-04", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1031f6f8-075e-4569-a775-3fb3b6c90023"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-07-15", "2022-08-16" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("11d31291-afc6-443d-be73-1806269d4f51"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2016-07-06", "0001-01-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("120a29ef-560d-4b0e-beb3-139a395ce5a5"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-01", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("12417d46-1d80-4696-90ab-aa8fdf1f9cc3"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-08-31", "2024-03-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("127ddde6-bd24-40d5-9822-6145975fee98"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-14", "2024-01-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("198395ef-0ad6-4750-9962-653e6f76b1a3"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-31", "2024-02-02" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1a3ccca6-d943-4031-b9da-b3526f599d21"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-01", "2024-08-02" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1d315603-14bc-4f70-a832-ddcafdd4df21"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-02-02", "2024-03-02" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1db031af-93f6-434b-8da8-1ef757ae616a"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-11", "2024-03-11" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1e3af7e3-7ef7-41b8-ad11-4fd5f418bd38"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-01", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1edbb03b-ce81-45c2-bc73-6a1f2efd50ac"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-04", "2024-04-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("1f5ebe82-2041-42c0-b069-4f5ce9a004b8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-03", "2024-07-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2138ec16-720d-46d9-9d1a-d731cb305f30"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-02", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("23afd964-1626-4bb5-bdc5-94716fa99183"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-18", "2024-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("240300b1-a2cb-4f62-b0e4-1ac4988bf37c"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-02", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("246ee72a-e1c7-49cc-aadc-b24749aeea9f"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-11-05", "2022-12-05" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2489b508-f9fb-473e-8519-00532689563e"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-29", "2024-02-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2621be29-f8b2-4fa9-94b3-fe2e598e0c07"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-02", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-02-04", "2024-03-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("274ec2c5-ec55-42d5-aae7-619004eb964d"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-02-06", "2024-03-06" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("289a93f4-10ee-452f-ac7e-927b7733a146"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-31", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("29ae74fd-42ea-4105-be15-08f5d9897182"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-02-23", "2024-02-20" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2a9bd1c8-4bfd-4874-912e-a7fa09113f44"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-10-18", "2022-11-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2aafe212-2efd-435e-83f6-95bbe58d7158"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-22", "2024-02-08" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2c6a0d5b-da21-41d3-ab48-ec29a2e4b290"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-09-13", "2024-03-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2eea61fe-f0b2-4ba3-a408-5c443a65c6ad"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-31", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("2f713e9c-8dc6-4a7a-b1fb-f94d50fff257"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-09-10", "2023-10-21" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("310cf4ed-40c4-4aa2-af14-6784f3100fd1"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-26", "2024-12-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("31968ee3-b21a-4835-8722-87a7a7324ed3"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-01-07", "2023-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("336a697e-b31c-4685-86ee-07eb191c1e89"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-22", "2024-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("33a7ded1-5e53-41a2-9ce3-37a9b9f0ee92"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-21", "2024-01-20" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("33b60808-5f5a-4cd2-9605-6748dafa9835"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-07-31", "2021-09-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("33fd7020-cc4d-4ee5-aa3c-3f4fc7eda960"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-21", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("340a076d-0c53-4e24-899d-d7aa73094abb"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-23", "2024-03-03" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("3797ff2b-53f3-4dbe-bf97-5bbc7a8ed1ed"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-09", "2024-03-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("38e79480-ff3f-4d90-8791-aa2a67d5d510"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-14", "2024-02-14" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("399713a9-624c-432e-8c19-8102310367c5"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-10-14", "2023-12-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("3abebc77-e824-439d-9a67-062e8dc84ee7"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-30", "2024-06-08" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("3cfc5fda-1fd2-45d9-ba02-04ca10f0b500"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-12-31", "2025-01-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("3e5bfb2a-9271-4920-864b-df62f5a3f41c"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-03", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("3f2cef07-b243-40ad-b3bd-7e928bd1d26b"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-07", "2024-02-25" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("408c2e53-a963-4ba8-ba67-a06a5e9d64e9"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-01-02", "2031-01-08" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("40c316d9-c4ca-4d2d-9352-cee627b46e20"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2020-08-03", "2020-09-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("43b49bb1-946c-4cab-a080-c16749d00b3e"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-10-27", "2024-11-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4409de67-2267-4899-b24a-c449b583adb8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-08-03", "2023-09-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("44274dc7-82e8-4274-a2bc-51488ee2100a"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-20", "2024-01-20" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4477f657-9f3f-4651-90c2-c1a1665b9f85"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-10-07", "2024-10-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("44eae22f-b163-44fc-ad27-aa933702bcfa"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2020-04-17", "2020-05-17" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4532be7f-fada-4ad6-b91a-0ca2ea2992fc"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-25", "2024-01-25" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4547e8ec-b5f0-4d87-a423-f612e39e83ad"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-02-04", "2024-03-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4588e482-af5f-4315-a614-ff8aadfb3d3b"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-25", "2024-01-31" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("45fe189b-b787-47ba-bc50-672f8a798b2a"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-29", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("474717e1-b5aa-4063-b73e-faa25f77aa58"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-03", "2024-01-22" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("47ab3c52-ab56-4ac9-acbb-91ea35921899"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-23", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("47e17c1f-6f6e-4845-a87a-59eb6dbb9a35"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-01", "2024-08-02" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("49c3731e-a782-432a-94a9-7d6814768eef"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-04", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4c08b9a0-a07a-40e5-8d07-8efcd3135398"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-10-24", "2024-09-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4c8bd5f5-6cc2-4d11-8589-9f89265a5e27"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-22", "2024-01-31" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4d865598-ce44-4f71-aac3-70a9ae6602f6"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-06", "2024-06-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4e563aeb-1b21-43ff-aa05-d888d7207393"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-08-27", "2022-08-25" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4e6e5645-1772-4f10-a770-883587b55847"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-07-31", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("4feecb5d-a239-4899-9f00-0d0a9564434e"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-06-11", "2023-10-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("501b678f-3ac0-4fa9-b6ae-1eec3d421e44"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-29", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("50a30523-01cf-4b9a-923d-44d93f8691a4"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-23", "2024-03-03" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("50fe9d97-1b9f-4bf2-941c-f69ebf7f50e5"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-09-28", "2024-04-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("52b86300-8d82-4cb6-a38a-c8cc84cd2dd4"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-02", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5556b57e-64f0-4185-8e5f-3e3e8b7f3753"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-02-02", "2024-03-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("568600a9-b595-4f98-8bf6-23f9780f0ee1"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-12", "2024-02-07" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5742eb85-838c-4716-9d15-4cd8a9199644"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-23", "2024-02-09" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("591903ee-ce91-4073-9d95-ec8204e6aa20"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-03", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("59c44048-fb76-4538-9b95-17544410b4cd"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2020-05-26", "2020-06-09" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5ae6dabd-d0f5-4623-8939-33cff2210b3a"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-30", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5aec6ea5-18ed-42fe-81cb-c2e0583b1533"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-06", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5caf612a-7ab6-4807-81a2-b1e3d0982976"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-12", "2023-12-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5cdbe722-1566-4684-8b19-eccbd22ea851"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-07-27", "2024-01-23" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5d58feaf-6405-4e95-a2a5-c239a1bdc9ea"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-02-03", "2024-03-03" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5db550c1-50d9-4d47-ab9d-6e0856141241"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-18", "2024-01-17" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5dde3937-7de5-46cd-9340-5e6a686d6bb0"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-09", "2024-07-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5e59df8c-f2e4-4739-9ab6-6d947327f276"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-19", "2024-12-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("5ee5548e-1a41-406e-9397-cf06fd01dca9"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-02-04", "2024-03-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("645c9e41-b7c8-44d2-bb58-5e5fe02ba27f"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-01-28", "2023-02-24" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("65fa09eb-4b0e-461c-a5c2-b291f0099b61"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-06-30", "2022-08-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("663b6397-1730-427f-abe6-dbb90ad1dad8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-10-30", "2024-12-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("68790c54-7d3b-42f3-8625-b44685fd789f"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-13", "2024-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("6e306dd6-0b0b-4ace-8025-221179784c0d"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2020-08-29", "2020-09-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("6e32981f-44a9-4ad9-b8a3-2e5b7abd7c00"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-07-31", "2023-09-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("6e425ed5-df18-4edb-b358-fd9644f716a0"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-17", "2024-02-02" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("6f9ba823-ad52-44bd-ba98-8bc895b2b3d6"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-30", "2025-01-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("70207bf0-a3e7-48a2-889e-fcadd23e1908"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-03-21", "2024-04-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("710a82cf-b6ca-4b76-9d37-52dd843af6af"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-04-08", "2024-05-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("71d49a70-1721-41e6-bd4f-e0812ffebce5"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-02", "2024-01-02" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("72abc9f9-8a67-4abc-8d17-ea3670f77adb"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-08", "2024-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("746f63b7-8e32-44e0-9f84-398aa8949853"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-08-13", "2023-09-08" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("755a0d47-c385-4092-a286-41b0bdbd9cd8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-11-28", "0001-01-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("767abf7e-b2f5-4ef2-960a-3b686ec1a4b7"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-07", "2024-03-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("76ff08ab-9960-4801-b76a-10d127b3ec83"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-16", "2024-01-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("772aed74-3f23-4f70-ad97-93f595a76102"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-09-08", "2023-10-07" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("77fff8cb-09f3-4349-8d00-5669e5727262"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-25", "2024-01-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("7958a937-42e8-4aae-943b-daafe8f053c5"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-05-21", "2023-08-30" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("7cc40ce9-beb8-49c5-9f85-ab5a566c32b8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-08-13", "2021-09-07" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("7d7f5602-9944-4a2c-a54a-d5878541862a"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-13", "2024-03-12" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("82a4ab9f-ec53-4158-83a9-a8eb505bd1a0"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-22", "2024-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("836052a4-55af-4b43-892e-86557b822595"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-02-24", "2021-03-19" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("87cc7388-262f-46ab-a6e5-caba8896b912"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-04-30", "2023-06-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("87f667bd-989b-4063-8e4c-936c9664e5e8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-01", "2024-02-12" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8986f06b-5a9e-498f-a6e7-42f4c65b6e79"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-19", "2024-06-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("89fe366d-5d89-424e-9418-bc9d608d81f8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-21", "2024-02-20" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8a1b925d-c891-4d8f-8b01-6f1ca837dd45"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-12", "2024-06-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8bbc9183-bf4f-4608-8452-399b4114f1b1"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-06-02", "2026-07-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8d30ed64-3b90-4689-96d4-2a447e254036"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-22", "2024-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8d874715-2d6d-4cf2-a4d8-4394056fb73a"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-04-09", "2027-10-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8e30fc6d-5152-4bef-8770-9ae8c2b2d296"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-02", "2024-02-16" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("8ef9c694-b2a7-45ed-9ca3-31cd5fea9c15"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-01", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("910e57e7-7bea-4a9c-b1b8-477fdf7e5289"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-23", "2024-03-03" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("912dbaa6-2f41-4f9f-ab49-ba2c857d9dfa"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-10-05", "2024-11-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9140f836-0c67-4f66-88c4-7b4127c0e722"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-17", "2024-02-08" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("93c1868b-0026-43e9-a320-48e21fcf13e6"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-08-09", "2022-08-30" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9593c99e-3568-4d43-a406-94d65016dc27"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-04", "2024-02-05" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9648e4c4-36f8-440b-b085-6810f1113e7e"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-27", "2024-03-29" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("97aa5c1a-0241-4c24-80a8-3a5c87ac6021"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-03", "2024-02-02" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9d13236e-28ed-45bf-9c6e-71bec5192e62"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-08-11", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9d1bedf6-bac0-4245-843e-d072fa814bc8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-08", "2024-02-07" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9d2b4d9a-96eb-47fa-950e-eb92bd1cc353"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-21", "2024-07-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9e28b1ec-6d7e-4720-99c2-9c933922e37c"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-10", "2024-03-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9eda691c-f335-4ccb-b719-b41378420976"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-17", "2024-02-08" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9f4193e9-7207-46fb-8cda-e782e469ff63"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-18", "2024-02-02" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("9f9412b2-951e-482c-a08f-ce80058e07b8"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-27", "2024-01-31" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("a0006dd7-7c4e-4f01-b4d6-4f4692d1f6ea"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-14", "2025-02-20" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("a784f680-6010-404a-a15a-d86e8da0fa04"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-03", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("a8849296-dd2d-4fd3-aacd-1ca2c6ec6e80"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-03", "2024-03-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("a88854f5-ec4b-477a-b5b4-c5d3aeef3f75"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-17", "2024-02-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ab0650b2-e025-4550-8e2e-195ad5ae645f"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-08-06", "2021-09-05" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("aba300f8-dc42-4ca6-adb0-0cc894e29ac6"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-09-01", "2021-10-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("acc4c8a4-6805-498e-9c80-4c578e90ccf4"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-07-08", "2024-01-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ae548204-8276-479e-a798-f5b000d59552"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2019-02-26", "2023-08-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ae75f74a-3824-4ac5-ada4-d793f77a41b0"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-02", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("aeacb899-8a07-43b5-98e0-dd228d41530c"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-06", "2024-01-24" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("af164350-0d87-48fe-be19-d886995c6438"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-12", "2024-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("b2813627-43c7-4eda-9e77-fd9dfd983eb0"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-18", "2024-01-17" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("b43d7cd1-971b-4287-aa07-11d5328def5c"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-21", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("bb0f760a-0a06-4ba8-bdbf-af2b8be9b21b"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-10", "2024-07-07" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("bbd4def6-c941-4e41-b0d9-0b0d09cd62c2"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-15", "2024-02-16" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("bc90190b-7cd1-4bc1-a764-d20a3767b1cc"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-23", "2024-02-07" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("bd50773e-aec0-4875-b09a-9bb925a3c40c"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-18", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("bef9a084-84c9-41bf-a3c6-e3d284b3e770"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2020-09-28", "2020-10-02" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c00957c7-cf21-4879-b4cb-b85af004af78"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-09-06", "2024-09-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c10be855-5e1b-4b7e-91e2-312f6341518f"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-02", "2024-01-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c1c1a1e3-07b9-4c07-89dd-567b67b69bdc"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-08", "2024-02-08" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c3450834-5b88-4098-9f32-f21aa5824495"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-12", "2024-05-11" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c68218d7-0b49-43a6-82cc-329ebaa70e1d"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-06", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c6bef67d-b55e-4a41-acba-4690beb7d2a2"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-11", "2025-01-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("c793214b-0b83-4eaf-a3a9-0ea288083d02"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2020-02-25", "2020-04-11" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("cd07196a-f288-4e72-9b29-8cd1ba673f87"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-19", "2024-01-20" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("cd61f564-fde5-4d82-ac62-bd2574aa9619"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-05", "2024-02-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("cda93907-078a-4959-8bc1-07b4f493926b"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-26", "2024-01-23" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ce7cc9df-36c6-410f-ba1c-1a4ca0b36623"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-22", "2024-07-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d0cc1ba8-0fcb-4cfa-94a4-ff1222794da6"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-05", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d11111e7-0b15-4065-af56-ad3b5efdc936"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-27", "2024-02-17" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d132c6ee-0c21-430f-956d-26e297f6eb3a"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-22", "2024-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d16485e7-0b15-4065-af56-ad3b5efdc936"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-10-04", "2024-04-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d1c1f2cb-4e7b-44e7-846d-176f5923e1c4"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-15", "2024-02-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d23bbd77-fe5c-4a8a-92cb-22cebed75f8b"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-30", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d35178e6-81d7-4ad1-b7f9-5d8eb033901d"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-08-04", "2024-08-03" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d39e026f-0c6a-4973-a9b5-fc7d47a01f25"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2019-08-09", "2019-09-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d7f14a32-2522-4fde-b315-0034e81afd6e"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-01", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d812eb16-26ff-4025-adab-5dba21d3144a"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-03", "2024-03-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d849f168-235b-44d1-8336-5d1e22cfa098"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-04", "2024-02-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d8985f55-410a-40e5-bed0-a55f9f82f945"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-03-25", "2024-04-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d8b76fab-069d-4112-9285-1ab2334b44dc"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-08-20", "2024-09-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("d8fa44fd-53aa-405d-810b-73d7d9881a96"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2020-09-28", "2020-10-24" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("da02b14a-e0f0-4197-a283-7a6d9b46f50b"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-07-18", "2023-08-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("db448b88-aaef-44ce-a120-3f4a54ca2d92"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-08", "2024-02-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dbf08eb1-cd35-48de-a9d3-0384382233a0"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2020-05-22", "2020-06-22" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dc1243a8-4594-4fd0-8856-cd7935334989"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-10-02", "2024-04-20" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dc49eda1-ff3b-4f0a-8892-70878a5747b2"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-17", "2024-02-07" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dc92dab4-1233-49de-b8d6-e2783eefa11f"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-05", "2024-05-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dd20e3d6-5667-405c-af6c-13ad6c163163"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-23", "2024-02-10" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("dd214b54-80ee-4e75-abab-e3d198d23577"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-08", "2024-02-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("df5db1f8-d511-42b7-860a-a704dd0f24fb"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-06", "2024-02-15" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("df9e71d7-9c63-42fc-93f9-ac3246383a2a"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-31", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e17dab90-642a-4e03-8cc0-4067d1c443e7"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-06", "2024-07-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e2dde72f-34cb-43cc-a8d0-d261cf7b9af1"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-03", "2023-12-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e4667dd4-8a63-4f77-876e-2a3e9e011bae"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-06-16", "2023-06-16" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e55cd416-7ff7-424a-a56e-499b112d37ad"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-02-04", "2024-03-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e5ff1958-60aa-4a00-87a7-fa43b40ab3d5"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2017-07-25", "2017-09-17" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e6c2181c-5b2a-4681-bc3b-afc32d6450c9"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-19", "2024-01-21" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("e81aa252-196c-42ed-9950-c386ccdd879e"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-11-08", "2023-12-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("eaf62615-2f83-43f4-8131-b6d5c00cac13"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-01", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ed6515a1-c814-457b-b1bd-8afaa8844ea6"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-08", "2024-02-07" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ed78f817-bd02-4cc6-8d47-cfaa1634a3c2"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-10-26", "2021-11-26" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f404c653-453b-472a-8264-bb05eb62adea"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-15", "2024-06-20" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f40a8ad1-3c88-40de-947b-1c23e9f6255e"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "0001-01-01", "2024-01-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f4ebab30-1e43-4787-a0ad-95961976f48b"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-31", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f4f73ef4-f65e-4587-9dda-3d5fad2a99d2"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2021-07-19", "2021-08-19" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f53d96e3-a514-49fc-81ef-5a927e22bcf2"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-03", "2024-02-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f73f2e64-c824-4c77-bca1-9dfaaad21c2f"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2022-11-18", "2022-12-18" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f79c9dcc-69d6-487d-95fd-8140e4361391"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-17", "2024-01-17" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("f96acb79-4b1c-49a5-b28c-8fd1d0dea944"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-07-08", "2023-09-04" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("fa300434-f3a9-41ec-922c-749d1c01a377"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-13", "2024-02-16" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("fab55430-7a44-4a1d-a1cd-601801514e67"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-12-29", "2024-07-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("fbe54285-2504-4762-96ca-94f56eac9141"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2020-12-29", "2021-01-29" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("fcbb140c-6698-4e72-84a3-11e8eb4d222c"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-05", "2025-01-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("fd63f34b-0b3e-4e9c-b1fa-7911c85d89da"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2023-10-04", "2024-04-01" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("feaf5560-6113-403b-8c56-0d5c33832b40"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-22", "2024-02-13" });

            migrationBuilder.UpdateData(
                table: "ClientsISP",
                keyColumn: "Id",
                keyValue: new Guid("ff2cf652-03ba-4521-a6dd-166b7b73bb2c"),
                columns: new[] { "ActivationDate", "ExpiredDate" },
                values: new object[] { "2024-01-06", "2024-07-06" });

            migrationBuilder.InsertData(
                table: "ClientsISP",
                columns: new[] { "Id", "ActivationDate", "ExpiredDate", "FullName" },
                values: new object[] { new Guid("c090a43d-bc2c-4b1d-9ab5-b05d959d8158"), "2024-01-30", "2024-02-01", "Англичани" });
        }
    }
}
