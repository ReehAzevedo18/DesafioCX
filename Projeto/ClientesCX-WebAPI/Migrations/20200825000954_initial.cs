using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientesCX_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dt_registro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    Clienteid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contatos_Cliente_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "id", "dt_registro", "email", "nome", "telefone" },
                values: new object[,]
                {
                    { 1, "242424", "Rodrigues", "Renata", "renata@cx.com.br" },
                    { 2, "203030", "Tavares", "Roger", "rtavares@cx.com.br" },
                    { 3, "949493", "Lima", "Ricardo", "lima@cx.com.br" },
                    { 4, "202010", "Diego", "Rayssa", "rdiego@cx.com.br" }
                });

            migrationBuilder.InsertData(
                table: "Contatos",
                columns: new[] { "id", "Clienteid", "email", "idCliente", "nome", "telefone" },
                values: new object[,]
                {
                    { 1, null, "renata@cx.com.br", 1, "Paula", "242424" },
                    { 2, null, "rtavares@cx.com.br", 2, "Laura", "203030" },
                    { 3, null, "lima@cx.com.br", 3, "Lima", "949493" },
                    { 4, null, "teste@cx.com.br", 4, "Teste", "050504" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_Clienteid",
                table: "Contatos",
                column: "Clienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
