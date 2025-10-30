using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    RUC = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    RAZON_SOCIAL = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    TELEFONO_CONTACTO = table.Column<long>(type: "NUMBER(18,0)", precision: 18, scale: 0, nullable: false),
                    CORREO_CONTACTO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    DIRECCION = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.RUC);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
