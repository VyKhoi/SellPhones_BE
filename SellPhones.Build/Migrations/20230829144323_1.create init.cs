using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SellPhones.Build.Migrations
{
    public partial class _1createinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    EstablishmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "color",
                columns: table => new
                {
                    names = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_color_names", x => x.names);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    IsMobile = table.Column<bool>(type: "boolean", nullable: false),
                    IsWeb = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActivated = table.Column<bool>(type: "boolean", nullable: false),
                    IsShowed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manufacture",
                columns: table => new
                {
                    names = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacture_names", x => x.names);
                });

            migrationBuilder.CreateTable(
                name: "promotion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    timeStart = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false),
                    timeEnd = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false),
                    Active = table.Column<short>(type: "smallint", nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promotion_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleBlock = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Gender = table.Column<short>(type: "smallint", nullable: true),
                    Hometown = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PassWord = table.Column<string>(type: "text", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    nameManufacture_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_Id", x => x.Id);
                    table.ForeignKey(
                        name: "product$product_nameManufacture_id_473540a7_fk_cellphone",
                        column: x => x.nameManufacture_id,
                        principalTable: "manufacture",
                        principalColumn: "names");
                });

            migrationBuilder.CreateTable(
                name: "GroupRoles",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRoles", x => new { x.GroupId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_GroupRoles_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderDate = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false),
                    deliveryAddress = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    deliveryPhone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    idUser_id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_Id", x => x.Id);
                    table.ForeignKey(
                        name: "order$order_idUser_id_bb73099a_fk_user_Id",
                        column: x => x.idUser_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: true),
                    ProviderKey = table.Column<string>(type: "text", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessTokenHash = table.Column<string>(type: "text", nullable: true),
                    AccessTokenExpiresDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RefreshTokenIdHash = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenIdHashSource = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiresDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    LoginProvider = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    contentComment = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    idProduct_id = table.Column<int>(type: "integer", nullable: false),
                    idUser_id = table.Column<Guid>(type: "uuid", nullable: false),
                    idReply = table.Column<int>(type: "integer", nullable: true),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_Id", x => x.Id);
                    table.ForeignKey(
                        name: "comment$comment_idProduct_id_886d85ab_fk_cellphone",
                        column: x => x.idProduct_id,
                        principalTable: "product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "comment$comment_idUser_id_d2fff2a5_fk_user_Id",
                        column: x => x.idUser_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comment_comment",
                        column: x => x.idReply,
                        principalTable: "comment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "earphone",
                columns: table => new
                {
                    product_ptr_id = table.Column<int>(type: "integer", nullable: false),
                    connectionType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Design = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Frequency_Response = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_earphone_product_ptr_id", x => x.product_ptr_id);
                    table.ForeignKey(
                        name: "earphone$earphon_product_ptr_id_af17d76e_fk_cellphone",
                        column: x => x.product_ptr_id,
                        principalTable: "product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "imageproduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    linkImg = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    idProduct_id = table.Column<int>(type: "integer", nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageproduct_Id", x => x.Id);
                    table.ForeignKey(
                        name: "imageproduct$imagepr_idProduct_id_4de16385_fk_cellphone",
                        column: x => x.idProduct_id,
                        principalTable: "product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "laptop",
                columns: table => new
                {
                    product_ptr_id = table.Column<int>(type: "integer", nullable: false),
                    CPU = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RAM = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ROM = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Graphic_Card = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Battery = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    operatorSystem = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Others = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laptop_product_ptr_id", x => x.product_ptr_id);
                    table.ForeignKey(
                        name: "laptop$laptop_product_ptr_id_137bfb4d_fk_cellphone",
                        column: x => x.product_ptr_id,
                        principalTable: "product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "product_color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    idProduct_id = table.Column<int>(type: "integer", nullable: false),
                    nameColor_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_color_Id", x => x.Id);
                    table.ForeignKey(
                        name: "product_color$product_idProduct_id_057d2aaf_fk_cellphone",
                        column: x => x.idProduct_id,
                        principalTable: "product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "product_color$product_nameColor_id_0ea8764a_fk_cellphone",
                        column: x => x.nameColor_id,
                        principalTable: "color",
                        principalColumn: "names");
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    idProduct_id = table.Column<int>(type: "integer", nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review_Id", x => x.Id);
                    table.ForeignKey(
                        name: "review$review_idProduct_id_4ede3625_fk_cellphone",
                        column: x => x.idProduct_id,
                        principalTable: "product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "smartphone",
                columns: table => new
                {
                    product_ptr_id = table.Column<int>(type: "integer", nullable: false),
                    Operator_System = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CPU = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RAM = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ROM = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Battery = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Others = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_smartphone_product_ptr_id", x => x.product_ptr_id);
                    table.ForeignKey(
                        name: "smartphone$smartph_product_ptr_id_a0e68210_fk_cellphone",
                        column: x => x.product_ptr_id,
                        principalTable: "product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "branch_product_color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Branch_id = table.Column<int>(type: "integer", nullable: false),
                    ProductColor_id = table.Column<int>(type: "integer", nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch_product_color_Id", x => x.Id);
                    table.ForeignKey(
                        name: "branch_product_color$branch__idBranch_id_edb533ab_fk_cellphone",
                        column: x => x.Branch_id,
                        principalTable: "branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "branch_product_color$branch__idProductColor_id_fbdccc0b_fk_cellphone",
                        column: x => x.ProductColor_id,
                        principalTable: "product_color",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "branch_promotion_product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    discountRate = table.Column<double>(type: "double precision", nullable: false),
                    idBrandProductColor_id = table.Column<int>(type: "integer", nullable: false),
                    idPromotion_id = table.Column<int>(type: "integer", nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch_promotion_product_Id", x => x.Id);
                    table.ForeignKey(
                        name: "branch_promotion_product$branch__idBrandProductColor__95f82815_fk_cellphone",
                        column: x => x.idBrandProductColor_id,
                        principalTable: "branch_product_color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "branch_promotion_product$branch__idPromotion_id_3456dae1_fk_cellphone",
                        column: x => x.idPromotion_id,
                        principalTable: "promotion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "orderdetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    idBrandProductColor_id = table.Column<int>(type: "integer", nullable: false),
                    idOder_id = table.Column<int>(type: "integer", nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    AddedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangedTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetail_Id", x => x.Id);
                    table.ForeignKey(
                        name: "orderdetail$orderde_idBrandProductColor__980f79ef_fk_cellphone",
                        column: x => x.idBrandProductColor_id,
                        principalTable: "branch_product_color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "orderdetail$orderde_idOder_id_6730d0c3_fk_cellphone",
                        column: x => x.idOder_id,
                        principalTable: "order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_branch_product_color_Branch_id",
                table: "branch_product_color",
                column: "Branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_product_color_ProductColor_id",
                table: "branch_product_color",
                column: "ProductColor_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_promotion_product_idBrandProductColor_id",
                table: "branch_promotion_product",
                column: "idBrandProductColor_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_promotion_product_idPromotion_id",
                table: "branch_promotion_product",
                column: "idPromotion_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_idProduct_id",
                table: "comment",
                column: "idProduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_idReply",
                table: "comment",
                column: "idReply");

            migrationBuilder.CreateIndex(
                name: "IX_comment_idUser_id",
                table: "comment",
                column: "idUser_id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoles_RoleId",
                table: "GroupRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_imageproduct_idProduct_id",
                table: "imageproduct",
                column: "idProduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_idUser_id",
                table: "order",
                column: "idUser_id");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_idBrandProductColor_id",
                table: "orderdetail",
                column: "idBrandProductColor_id");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_idOder_id",
                table: "orderdetail",
                column: "idOder_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_nameManufacture_id",
                table: "product",
                column: "nameManufacture_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_color_idProduct_id",
                table: "product_color",
                column: "idProduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_color_nameColor_id",
                table: "product_color",
                column: "nameColor_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_idProduct_id",
                table: "review",
                column: "idProduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserId",
                table: "UserGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId1",
                table: "UserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId1",
                table: "UserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId1",
                table: "UserTokens",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "branch_promotion_product");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "earphone");

            migrationBuilder.DropTable(
                name: "GroupRoles");

            migrationBuilder.DropTable(
                name: "imageproduct");

            migrationBuilder.DropTable(
                name: "laptop");

            migrationBuilder.DropTable(
                name: "orderdetail");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "smartphone");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "promotion");

            migrationBuilder.DropTable(
                name: "branch_product_color");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "branch");

            migrationBuilder.DropTable(
                name: "product_color");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "color");

            migrationBuilder.DropTable(
                name: "manufacture");
        }
    }
}
