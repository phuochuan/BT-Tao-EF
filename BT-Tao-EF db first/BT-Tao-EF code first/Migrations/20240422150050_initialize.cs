using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BT_Tao_EF_code_first.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Company__3213E83FA892E438", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    staffCount = table.Column<int>(type: "int", nullable: true),
                    companyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__3213E83F41D3CB4F", x => x.id);
                    table.ForeignKey(
                        name: "FK__Departmen__compa__267ABA7A",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    dateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    departmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3213E83F5308DE42", x => x.id);
                    table.ForeignKey(
                        name: "FK__Employee__depart__29572725",
                        column: x => x.departmentId,
                        principalTable: "Department",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_companyId",
                table: "Department",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_departmentId",
                table: "Employee",
                column: "departmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
