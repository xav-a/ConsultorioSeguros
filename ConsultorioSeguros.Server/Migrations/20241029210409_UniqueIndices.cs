using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioSeguros.Server.Migrations
{
    /// <inheritdoc />
    public partial class UniqueIndices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InsurancePlans_Code",
                table: "InsurancePlans");

            migrationBuilder.DropIndex(
                name: "IX_Clients_IdentificationNumber",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePlans_Code",
                table: "InsurancePlans",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdentificationNumber",
                table: "Clients",
                column: "IdentificationNumber",
                unique: true,
                filter: "[IdentificationNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InsurancePlans_Code",
                table: "InsurancePlans");

            migrationBuilder.DropIndex(
                name: "IX_Clients_IdentificationNumber",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePlans_Code",
                table: "InsurancePlans",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdentificationNumber",
                table: "Clients",
                column: "IdentificationNumber");
        }
    }
}
