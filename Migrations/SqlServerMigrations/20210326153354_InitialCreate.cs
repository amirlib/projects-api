using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectsApi.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BugsCount = table.Column<int>(type: "int", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    MadeDadeline = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "BugsCount", "DurationInDays", "MadeDadeline", "Name" },
                values: new object[,]
                {
                    { "5fb9953bd98214b6df37174d", 74, 35, false, "Backend Project" },
                    { "5fb9953b9937c7bcd60c4bc5", 52, 55, false, "Design Project" },
                    { "5fb9953b899dd436c5604120", 34, 36, true, "Backend Project" },
                    { "5fb9953b97e765bfc40b0e64", 32, 51, true, "Frontend Project" },
                    { "5fb9953b9cbcef501edc3282", 42, 68, true, "Design Project" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "JoinedAt", "Name", "PasswordHash", "PasswordSalt", "Team" },
                values: new object[,]
                {
                    { "5fb9953bd98214b6df37174d", "amir.lib@gmail.com", new DateTime(2021, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amir Liberzon", new byte[] { 5, 44, 94, 230, 37, 236, 6, 242, 59, 125, 123, 9, 123, 255, 47, 225, 126, 52, 152, 245, 168, 78, 104, 71, 220, 66, 7, 249, 187, 217, 22, 246, 224, 66, 0, 75, 104, 186, 113, 164, 146, 210, 194, 74, 229, 54, 122, 0, 139, 44, 208, 158, 3, 161, 1, 147, 33, 56, 105, 150, 241, 224, 88, 117 }, new byte[] { 109, 207, 43, 249, 239, 127, 23, 15, 67, 232, 186, 1, 237, 132, 55, 201, 163, 78, 180, 219, 74, 211, 50, 196, 124, 45, 7, 126, 70, 67, 231, 151, 137, 138, 55, 167, 89, 172, 115, 210, 114, 104, 228, 62, 14, 231, 212, 88, 210, 88, 241, 159, 106, 115, 250, 70, 54, 22, 121, 118, 62, 164, 33, 51, 204, 52, 249, 96, 164, 40, 98, 243, 173, 4, 66, 227, 108, 34, 65, 56, 188, 252, 192, 161, 69, 169, 200, 98, 206, 88, 133, 96, 242, 249, 152, 83, 94, 215, 185, 1, 206, 100, 189, 214, 118, 218, 142, 211, 6, 232, 218, 155, 85, 134, 36, 25, 151, 28, 13, 42, 227, 44, 112, 149, 222, 53, 1, 230 }, "Developers" },
                    { "5fb9953b9937c7bcd60c4bc5", "inbal.bit@gmail.com", new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inbal Biton", new byte[] { 147, 99, 138, 221, 42, 112, 205, 246, 87, 143, 30, 23, 194, 163, 4, 44, 224, 60, 221, 229, 5, 107, 163, 211, 239, 123, 59, 185, 70, 27, 85, 78, 213, 6, 32, 53, 235, 142, 42, 221, 153, 133, 185, 179, 224, 16, 80, 249, 3, 204, 67, 130, 231, 234, 70, 150, 210, 242, 6, 202, 63, 169, 172, 96 }, new byte[] { 226, 37, 178, 184, 214, 165, 0, 77, 58, 182, 52, 16, 152, 99, 168, 175, 156, 206, 232, 63, 167, 125, 63, 83, 210, 253, 255, 213, 229, 29, 206, 25, 141, 100, 78, 156, 52, 150, 143, 40, 84, 110, 48, 92, 128, 220, 146, 243, 72, 76, 241, 208, 92, 241, 218, 101, 92, 6, 103, 32, 95, 14, 185, 23, 212, 135, 85, 142, 102, 64, 85, 186, 189, 11, 113, 85, 183, 121, 126, 51, 168, 26, 46, 167, 58, 59, 196, 79, 31, 85, 176, 51, 62, 86, 65, 78, 130, 233, 190, 185, 166, 54, 88, 78, 160, 173, 2, 154, 5, 30, 247, 36, 149, 62, 103, 4, 73, 59, 83, 71, 61, 20, 34, 2, 39, 250, 219, 67 }, "Developers" },
                    { "5fb9953b899dd436c5604120", "lior.pez@gmail.com", new DateTime(2021, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lior Pezman", new byte[] { 20, 140, 136, 245, 203, 85, 199, 83, 86, 73, 215, 14, 174, 3, 185, 230, 32, 62, 151, 120, 43, 101, 129, 202, 76, 147, 72, 248, 73, 64, 107, 166, 40, 18, 250, 7, 94, 166, 250, 172, 238, 49, 234, 169, 232, 193, 124, 192, 198, 227, 204, 49, 63, 215, 46, 39, 21, 73, 127, 191, 48, 40, 129, 43 }, new byte[] { 114, 175, 145, 169, 64, 254, 210, 89, 162, 94, 48, 242, 59, 84, 53, 106, 242, 236, 152, 19, 0, 118, 186, 231, 1, 106, 199, 110, 71, 102, 8, 253, 218, 237, 154, 32, 154, 128, 158, 252, 49, 5, 124, 195, 123, 238, 106, 48, 71, 47, 98, 152, 53, 210, 21, 231, 161, 134, 97, 236, 81, 117, 119, 174, 164, 28, 247, 229, 4, 49, 104, 235, 186, 80, 21, 53, 85, 105, 27, 5, 248, 80, 237, 124, 208, 127, 232, 94, 244, 161, 251, 117, 139, 193, 75, 169, 190, 232, 49, 156, 109, 183, 161, 231, 209, 139, 226, 221, 141, 86, 117, 43, 156, 64, 88, 21, 48, 254, 157, 112, 144, 217, 96, 31, 29, 244, 126, 204 }, "Marketing" },
                    { "5fb9953b97e765bfc40b0e64", "ido.gold@gmail.com", new DateTime(2021, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ido Goldshtain", new byte[] { 227, 154, 136, 22, 81, 202, 189, 21, 26, 212, 28, 1, 110, 212, 4, 211, 121, 192, 48, 158, 26, 109, 3, 222, 59, 96, 196, 215, 149, 150, 236, 124, 28, 200, 111, 81, 122, 203, 14, 105, 180, 137, 7, 2, 46, 236, 67, 99, 1, 10, 31, 61, 172, 217, 22, 108, 141, 194, 93, 241, 69, 55, 252, 121 }, new byte[] { 236, 55, 196, 156, 93, 28, 18, 249, 56, 51, 174, 145, 62, 218, 157, 248, 152, 169, 2, 180, 102, 158, 4, 171, 212, 37, 3, 64, 126, 79, 90, 79, 38, 213, 35, 78, 146, 177, 41, 108, 71, 185, 45, 89, 140, 136, 212, 1, 92, 127, 108, 251, 220, 89, 34, 79, 106, 90, 238, 239, 21, 204, 147, 188, 55, 14, 25, 234, 69, 98, 90, 107, 71, 233, 22, 136, 173, 76, 103, 163, 233, 9, 237, 86, 171, 102, 40, 224, 104, 36, 161, 81, 126, 193, 166, 132, 115, 234, 97, 147, 172, 29, 146, 2, 90, 237, 19, 199, 98, 65, 10, 16, 153, 127, 7, 188, 13, 97, 202, 7, 223, 92, 186, 223, 77, 66, 116, 196 }, "Marketing" },
                    { "5fb9953b9cbcef501edc3282", "itamar.dellus@gmail.com", new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Itamar Fellus", new byte[] { 125, 153, 135, 113, 185, 205, 128, 15, 38, 128, 126, 94, 252, 65, 204, 160, 92, 110, 199, 144, 205, 87, 138, 229, 204, 143, 115, 207, 127, 164, 242, 184, 210, 253, 248, 208, 240, 107, 115, 219, 138, 194, 51, 3, 248, 84, 155, 246, 210, 10, 103, 8, 123, 136, 112, 235, 138, 210, 151, 163, 110, 213, 85, 153 }, new byte[] { 15, 185, 185, 149, 251, 230, 127, 5, 112, 128, 209, 116, 218, 130, 253, 145, 245, 52, 11, 36, 128, 136, 21, 24, 18, 181, 61, 153, 76, 45, 158, 53, 164, 226, 181, 215, 7, 80, 35, 46, 130, 105, 95, 121, 61, 22, 226, 178, 149, 179, 227, 123, 6, 169, 232, 26, 173, 133, 218, 100, 206, 41, 105, 198, 130, 27, 24, 67, 114, 109, 127, 228, 43, 219, 178, 111, 79, 219, 143, 206, 23, 78, 119, 215, 80, 114, 79, 119, 35, 76, 235, 234, 117, 21, 92, 38, 132, 215, 157, 175, 120, 88, 125, 190, 43, 231, 208, 119, 145, 133, 98, 216, 49, 118, 235, 245, 81, 6, 8, 255, 105, 208, 250, 93, 192, 196, 16, 198 }, "QA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
