using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Numero = table.Column<string>(type: "CHAR(5)", nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    UF = table.Column<string>(type: "CHAR(2)", nullable: false),
                    Cep = table.Column<string>(type: "CHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    IdPermissao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePermissao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.IdPermissao);
                });

            migrationBuilder.CreateTable(
                name: "StatusMotoristas",
                columns: table => new
                {
                    IdStatusMotorista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DscStatusMotorista = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMotoristas", x => x.IdStatusMotorista);
                });

            migrationBuilder.CreateTable(
                name: "StatusUsuarios",
                columns: table => new
                {
                    IdStatusUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DscStatusUsuario = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusUsuarios", x => x.IdStatusUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    IdMotorista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Sexo = table.Column<string>(type: "CHAR(1)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusMotoristaId = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.IdMotorista);
                    table.ForeignKey(
                        name: "FK_Motoristas_Enderecos",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motoristas_StatusMotoristas",
                        column: x => x.StatusMotoristaId,
                        principalTable: "StatusMotoristas",
                        principalColumn: "IdStatusMotorista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(12)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    PrimeiroAcesso = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    PermissaoId = table.Column<int>(type: "int", nullable: false),
                    StatusUsuarioId = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Permissoe",
                        column: x => x.PermissaoId,
                        principalTable: "Permissoes",
                        principalColumn: "IdPermissao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_StatusUsuarios",
                        column: x => x.StatusUsuarioId,
                        principalTable: "StatusUsuarios",
                        principalColumn: "IdStatusUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_Nome_Motorista",
                table: "Motoristas",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_EnderecoId",
                table: "Motoristas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_StatusMotoristaId",
                table: "Motoristas",
                column: "StatusMotoristaId");

            migrationBuilder.CreateIndex(
                name: "UQ_CPF_Motoristas",
                table: "Motoristas",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PermissaoId",
                table: "Usuarios",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_StatusUsuarioId",
                table: "Usuarios",
                column: "StatusUsuarioId");

            migrationBuilder.CreateIndex(
                name: "UQ_CPF_Usuarios",
                table: "Usuarios",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Email_Usuarios",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "StatusMotoristas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "StatusUsuarios");
        }
    }
}
