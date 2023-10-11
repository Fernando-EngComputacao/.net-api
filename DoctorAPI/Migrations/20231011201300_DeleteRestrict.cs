using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAPI.Migrations
{
    public partial class DeleteRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Address_addressId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Address_addressId",
                table: "Patients");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Address_addressId",
                table: "Doctors",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Address_addressId",
                table: "Patients",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Address_addressId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Address_addressId",
                table: "Patients");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Address_addressId",
                table: "Doctors",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Address_addressId",
                table: "Patients",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
