using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeslaGoAPI.DB.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriveType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearBox",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NumberOfGears = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearBox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptService", x => x.Id);
                    table.CheckConstraint("CK_OptService_Price", "[Price] BETWEEN 0 AND 50000");
                });

            migrationBuilder.CreateTable(
                name: "Paint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColorHex = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paint", x => x.Id);
                    table.CheckConstraint("CK_Paint_ColorHex", "LEN([ColorHex]) BETWEEN 7 AND 7");
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeatCount = table.Column<byte>(type: "tinyint", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Range = table.Column<short>(type: "smallint", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoorCount = table.Column<byte>(type: "tinyint", nullable: true),
                    HorsePower = table.Column<short>(type: "smallint", nullable: true),
                    MaxSpeedInKmPerHour = table.Column<short>(type: "smallint", nullable: true),
                    TrunkCapacityLiters = table.Column<int>(type: "int", nullable: true),
                    TrunkCapacitySuitCases = table.Column<int>(type: "int", nullable: true),
                    AccelerationInSeconds = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    GearBoxId = table.Column<int>(type: "int", nullable: false),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    DriveTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CarModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.Id);
                    table.CheckConstraint("CK_CarModel_AccelerationInSeconds", "[AccelerationInSeconds] BETWEEN 0 AND 1000");
                    table.CheckConstraint("CK_CarModel_DoorCount", "[DoorCount] BETWEEN 1 AND 30");
                    table.CheckConstraint("CK_CarModel_HorsePower", "[HorsePower] BETWEEN 1 AND 10000");
                    table.CheckConstraint("CK_CarModel_MaxSpeedInKmPerHour", "[MaxSpeedInKmPerHour] BETWEEN 1 AND 1000");
                    table.CheckConstraint("CK_CarModel_PricePerDay", "[PricePerDay] BETWEEN 0 AND 50000");
                    table.CheckConstraint("CK_CarModel_Range", "[Range] BETWEEN 0 AND 10000");
                    table.CheckConstraint("CK_CarModel_SeatCount", "[SeatCount] BETWEEN 1 AND 255");
                    table.CheckConstraint("CK_CarModel_TrunkCapacityLiters", "[TrunkCapacityLiters] BETWEEN 0 AND 10000");
                    table.CheckConstraint("CK_CarModel_TrunkCapacitySuitCases", "[TrunkCapacitySuitCases] BETWEEN 0 AND 50");
                    table.ForeignKey(
                        name: "FK_CarModel_BodyType_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModel_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModel_CarModel_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarModel_DriveType_DriveTypeId",
                        column: x => x.DriveTypeId,
                        principalTable: "DriveType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModel_FuelType_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModel_GearBox_GearBoxId",
                        column: x => x.GearBoxId,
                        principalTable: "GearBox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModel_ModelVersion_ModelVersionId",
                        column: x => x.ModelVersionId,
                        principalTable: "ModelVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HouseNr = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    FlatNr = table.Column<short>(type: "smallint", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.CheckConstraint("CK_Address_FlatNr", "[FlatNr] BETWEEN 0 AND 10000");
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    RegistrationNr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    PaintId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.CheckConstraint("CK_Car_VIN", "LEN([VIN]) BETWEEN 17 AND 17");
                    table.ForeignKey(
                        name: "FK_Car_CarModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Paint_PaintId",
                        column: x => x.PaintId,
                        principalTable: "Paint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModel_Equipment",
                columns: table => new
                {
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel_Equipment", x => new { x.CarModelId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_CarModel_Equipment_CarModel_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModel_Equipment_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModelDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductionStartYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductionEndYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModelDetails_CarModel_Id",
                        column: x => x.Id,
                        principalTable: "CarModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DrivingLicenseNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car_Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Location_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Location_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    PickupLocationId = table.Column<int>(type: "int", nullable: false),
                    ReturnLocationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.CheckConstraint("CK_Reservation_TotalCost", "[TotalCost] BETWEEN 0 AND 1000000");
                    table.ForeignKey(
                        name: "FK_Reservation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_CarModel_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_Location_PickupLocationId",
                        column: x => x.PickupLocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_Location_ReturnLocationId",
                        column: x => x.ReturnLocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarAvailabilityIssue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDetectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAvailabilityIssue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarAvailabilityIssue_CarModel_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarAvailabilityIssue_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarAvailabilityIssue_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservation_OptService",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    OptServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation_OptService", x => new { x.OptServiceId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_Reservation_OptService_OptService_OptServiceId",
                        column: x => x.OptServiceId,
                        principalTable: "OptService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_OptService_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin role", "Admin", "ADMIN" },
                    { 2, null, "User role", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "BodyType",
                columns: new[] { "Id", "DeleteDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Sedan" },
                    { 2, null, false, "SUV" },
                    { 3, null, false, "Pickup" },
                    { 4, null, false, "Roadster" }
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "DeleteDate", "IsDeleted", "Name" },
                values: new object[] { 1, null, false, "Tesla" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "DeleteDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Spain" },
                    { 2, null, false, "Poland" },
                    { 3, null, false, "Germany" },
                    { 4, null, false, "France" },
                    { 5, null, false, "Italy" }
                });

            migrationBuilder.InsertData(
                table: "DriveType",
                columns: new[] { "Id", "DeleteDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, "Rear-Wheel Drive", false, "RWD" },
                    { 2, null, "All-Wheel Drive", false, "AWD" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Advanced driver assistance system with automatic lane-keeping, adaptive cruise control, and more.", "Autopilot" },
                    { 2, "Includes Autopilot features plus Navigate on Autopilot, Auto Park, Summon, and more.", "Full Self-Driving (FSD) Package" },
                    { 3, "Upgraded interior with premium audio, ambient lighting, and more luxurious finishes.", "Premium Interior" },
                    { 4, "Heated front and rear seats for added comfort during cold weather.", "Heated Seats" },
                    { 5, "Panoramic glass roof providing an open, airy feel and UV protection.", "Glass Roof" },
                    { 6, "Access to Tesla's Supercharger network for fast charging.", "Supercharging" },
                    { 7, "Access to premium features such as satellite maps, live traffic visualizations, and more.", "Premium Connectivity" },
                    { 8, "Includes a tow hitch and towing accessories for hauling trailers or other gear.", "Towing Package" },
                    { 9, "Basic 19-inch wheels", "19\" Wheels" },
                    { 10, "Larger 20-inch wheels for better performance and appearance.", "20\" Wheels" },
                    { 11, "Sportier 20-inch wheels for enhanced performance and aesthetics.", "20\" Sport Wheels" },
                    { 12, "Upgraded audio system with premium sound quality.", "Enhanced Audio System" },
                    { 13, "Ability to remotely summon your Tesla to you using the Tesla app.", "Smart Summon" }
                });

            migrationBuilder.InsertData(
                table: "FuelType",
                columns: new[] { "Id", "DeleteDate", "IsDeleted", "Name" },
                values: new object[] { 1, null, false, "Electric" });

            migrationBuilder.InsertData(
                table: "GearBox",
                columns: new[] { "Id", "DeleteDate", "IsDeleted", "Name", "NumberOfGears" },
                values: new object[] { 1, null, false, "Single-Speed", (byte)1 });

            migrationBuilder.InsertData(
                table: "ModelVersion",
                columns: new[] { "Id", "DeleteDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, "Standard range, standard performance", false, "Standard" },
                    { 2, null, "Longer range, standard performance", false, "Long Range" },
                    { 3, null, "High-performance version with quicker acceleration", false, "Performance" },
                    { 4, null, "Top performance with three motors and extreme acceleration", false, "Plaid" },
                    { 5, null, "Tri-motor performance with extreme acceleration and off-road prowess.", false, "Cyber-beast" }
                });

            migrationBuilder.InsertData(
                table: "OptService",
                columns: new[] { "Id", "DeleteDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, "Comprehensive insurance coverage including damage, theft, and third-party liability.", false, "Full Insurance", 250.00m },
                    { 3, null, "Safe and comfortable child car seat suitable for different age groups.", false, "Child Car Seat", 50.00m },
                    { 4, null, "24/7 roadside assistance in case of emergencies like breakdowns or accidents.", false, "Roadside Assistance", 199.00m },
                    { 5, null, "Add an additional driver to the rental for no extra charge for the duration of the rental period.", false, "Extra Driver", 25.00m }
                });

            migrationBuilder.InsertData(
                table: "Paint",
                columns: new[] { "Id", "ColorHex", "DeleteDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "#ffffff", null, false, "Pearl White" },
                    { 2, "#000000", null, false, "Solid Black" },
                    { 3, "#235598", null, false, "Deep Blue Metallic" },
                    { 4, "#212127", null, false, "Stealth Grey" },
                    { 5, "#87858e", null, false, "QuickSilver" },
                    { 6, "#b6151f", null, false, "Ultra Red" },
                    { 7, "#740415", null, false, "Midnight Cherry Red" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "DeleteDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Credit Card" },
                    { 2, null, false, "Bank Transfer" },
                    { 3, null, false, "PayPal" },
                    { 4, null, false, "Apple Pay" },
                    { 5, null, false, "Google Pay" },
                    { 6, null, false, "Cash on Delivery" }
                });

            migrationBuilder.InsertData(
                table: "CarModel",
                columns: new[] { "Id", "AccelerationInSeconds", "BodyTypeId", "BrandId", "CarModelId", "DeleteDate", "DoorCount", "DriveTypeId", "FuelTypeId", "GearBoxId", "HorsePower", "ImageName", "IsDeleted", "MaxSpeedInKmPerHour", "ModelVersionId", "Name", "PricePerDay", "Range", "SeatCount", "TrunkCapacityLiters", "TrunkCapacitySuitCases" },
                values: new object[,]
                {
                    { 1, 3.2m, 1, 1, null, null, (byte)4, 1, 1, 1, (short)670, "tesla_model_s.png", false, (short)250, 1, "Model S", 100m, (short)634, (byte)5, 793, 6 },
                    { 2, 2.1m, 1, 1, null, null, (byte)4, 1, 1, 1, (short)1020, "tesla_model_s.png", false, (short)322, 4, "Model S", 170m, (short)600, (byte)5, 793, 6 },
                    { 3, 6.1m, 1, 1, null, null, (byte)4, 1, 1, 1, (short)283, "tesla_model_3.png", false, (short)225, 1, "Model 3", 80m, (short)513, (byte)5, 682, 5 },
                    { 4, 5.2m, 1, 1, null, null, (byte)4, 1, 1, 1, (short)283, "tesla_model_3.png", false, (short)225, 2, "Model 3", 100m, (short)702, (byte)5, 682, 5 },
                    { 5, 4.4m, 1, 1, null, null, (byte)4, 2, 1, 1, (short)346, "tesla_model_3.png", false, (short)233, 2, "Model 3", 110m, (short)629, (byte)5, 682, 5 },
                    { 6, 3.1m, 1, 1, null, null, (byte)4, 2, 1, 1, (short)472, "tesla_model_3.png", false, (short)261, 3, "Model 3", 140m, (short)528, (byte)5, 682, 5 },
                    { 7, 6.9m, 2, 1, null, null, (byte)4, 1, 1, 1, (short)283, "tesla_model_y.png", false, (short)217, 1, "Model Y", 60m, (short)455, (byte)5, 2158, 12 },
                    { 8, 5.9m, 2, 1, null, null, (byte)4, 1, 1, 1, (short)283, "tesla_model_y.png", false, (short)217, 2, "Model Y", 75m, (short)600, (byte)5, 2158, 12 },
                    { 9, 5.0m, 2, 1, null, null, (byte)4, 2, 1, 1, (short)351, "tesla_model_y.png", false, (short)217, 2, "Model Y", 85m, (short)533, (byte)5, 2158, 12 },
                    { 10, 3.7m, 2, 1, null, null, (byte)4, 2, 1, 1, (short)456, "tesla_model_y.png", false, (short)250, 3, "Model Y", 115m, (short)514, (byte)5, 2158, 12 },
                    { 11, 3.9m, 2, 1, null, null, (byte)4, 2, 1, 1, (short)670, "tesla_model_x.png", false, (short)250, 1, "Model X", 105m, (short)576, (byte)5, 2614, 14 },
                    { 12, 2.6m, 2, 1, null, null, (byte)4, 2, 1, 1, (short)1020, "tesla_model_x.png", false, (short)262, 4, "Model X", 145m, (short)543, (byte)5, 2614, 14 },
                    { 13, 6.7m, 3, 1, null, null, (byte)4, 1, 1, 1, (short)315, "tesla_cybertruck.png", false, (short)180, 1, "Cybertruck", 140m, (short)402, (byte)5, 2830, 16 },
                    { 14, 4.3m, 3, 1, null, null, (byte)4, 2, 1, 1, (short)600, "tesla_cybertruck.png", false, (short)180, 1, "Cybertruck", 170m, (short)547, (byte)5, 2830, 16 },
                    { 15, 2.7m, 3, 1, null, null, (byte)4, 2, 1, 1, (short)845, "tesla_cybertruck.png", false, (short)209, 5, "Cybertruck", 210m, (short)515, (byte)5, 2830, 16 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "DeleteDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Palma" },
                    { 2, 1, null, false, "Alcudia" },
                    { 3, 1, null, false, "Manacor" },
                    { 4, 1, null, false, "Inca" },
                    { 5, 1, null, false, "Santanyí" },
                    { 6, 1, null, false, "Sóller" },
                    { 7, 1, null, false, "Magaluf" },
                    { 8, 1, null, false, "Porto Cristo" },
                    { 9, 1, null, false, "Campos" },
                    { 10, 1, null, false, "Marratxí" },
                    { 11, 2, null, false, "Warsaw" },
                    { 12, 2, null, false, "Kraków" },
                    { 13, 1, null, false, "Madrid" },
                    { 14, 1, null, false, "Barcelona" },
                    { 15, 3, null, false, "Berlin" },
                    { 16, 3, null, false, "Munich" },
                    { 17, 4, null, false, "Paris" },
                    { 18, 1, null, false, "Lyon" },
                    { 19, 5, null, false, "Rome" },
                    { 20, 5, null, false, "Milan" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "CityId", "DeleteDate", "FlatNr", "HouseNr", "IsDeleted", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, 1, null, null, "21845", false, "Carretera de l'Aeroport", "72586-0447" },
                    { 2, 1, null, null, "435", false, "Carrer de la Riera", "13081" },
                    { 3, 2, null, null, "736", false, "Cami de Ronda", "27575" },
                    { 4, 3, null, null, "4538", false, "Via Portugal", "67260" },
                    { 5, 4, null, (short)183, "78834", false, "Carrer de la Rosa", "51577-0662" },
                    { 6, 5, null, (short)59, "653", false, "Carrer del Sol", "78051" },
                    { 7, 6, null, (short)173, "079", false, "Carrer de la Ciutat", "72785-9146" },
                    { 8, 7, null, (short)33, "3631", false, "Carrer de la Lluna", "13228-6376" },
                    { 9, 8, null, (short)24, "6564", false, "Carrer del Mar", "48502" },
                    { 10, 9, null, (short)116, "8679", false, "Carrer de la Mediterrània", "63271-6608" },
                    { 11, 10, null, (short)20, "6343", false, "Carrer de la Palma", "64918" },
                    { 12, 11, null, (short)72, "52924", false, "Krakowskie Przedmieście", "69361" },
                    { 13, 12, null, (short)190, "771", false, "Strzelecka", "40935" },
                    { 14, 13, null, (short)9, "2369", false, "Calle Gran Vía", "35943-1987" },
                    { 15, 14, null, (short)168, "37171", false, "Passeig de Gràcia", "52170-3742" },
                    { 16, 15, null, (short)4, "7317", false, "Berliner Strasse", "67342-1120" },
                    { 17, 16, null, (short)121, "8778", false, "Maximilianstrasse", "19951-6389" },
                    { 18, 17, null, (short)94, "42056", false, "Rue Monge", "25748-4485" },
                    { 19, 18, null, (short)179, "65240", false, "Rue Vauban", "32567" },
                    { 20, 19, null, (short)180, "669", false, "Via Torino", "69283-0049" },
                    { 21, 20, null, (short)187, "960", false, "Via Brera", "54437-2000" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "DeleteDate", "IsDeleted", "ModelId", "PaintId", "RegistrationNr", "VIN" },
                values: new object[,]
                {
                    { 1, null, false, 1, 3, "TUM 340", "B2CCXT8PGBHC41563" },
                    { 2, null, false, 1, 5, "AMT 783", "Z8YQG6HMY7OD85894" },
                    { 3, null, false, 1, 2, "DTU 232", "TM5KMIEUIORD63287" },
                    { 4, null, false, 1, 2, "STI 817", "B443Q9TPNTPL28528" },
                    { 5, null, false, 1, 2, "QUT 737", "CJSMYJPY05S358000" },
                    { 6, null, false, 1, 3, "ICE 653", "M4ZILDJZDSIY79664" },
                    { 7, null, false, 1, 2, "AUM 577", "1BYC5WBZVYM030113" },
                    { 8, null, false, 2, 6, "HPN 574", "YCVOEQ84EGR676731" },
                    { 9, null, false, 2, 6, "PNN 429", "H169MG5GWELF50421" },
                    { 10, null, false, 2, 2, "AII 459", "6MN8D85Z3CVM84922" },
                    { 11, null, false, 2, 7, "ITU 741", "7YQ5OHGIU5L424242" },
                    { 12, null, false, 2, 6, "ASC 975", "QKQJ3QFNYQOQ90823" },
                    { 13, null, false, 2, 6, "TNS 421", "ZWDF97RWRNOZ73555" },
                    { 14, null, false, 2, 5, "NSE 751", "99NK17T41FGU65579" },
                    { 15, null, false, 3, 7, "QBE 220", "512EAK6ZA8OK88710" },
                    { 16, null, false, 3, 6, "UTI 799", "4DTQKBFNWGIY80834" },
                    { 17, null, false, 3, 5, "PEI 498", "3GN0GHUHWNZ337381" },
                    { 18, null, false, 3, 3, "FSA 790", "189NEP5B4NLY96891" },
                    { 19, null, false, 3, 4, "QED 853", "KREBIRYH01OY41195" },
                    { 20, null, false, 3, 5, "ECB 347", "MKYJBOI943O381906" },
                    { 21, null, false, 3, 5, "TEI 335", "LXYRII1I2LEO90849" },
                    { 22, null, false, 4, 4, "UUA 241", "AWTK4NYV27FA64573" },
                    { 23, null, false, 4, 3, "MET 200", "EZJ98WQCJGI245745" },
                    { 24, null, false, 4, 5, "EIO 955", "H6UFDHH0WXKL55320" },
                    { 25, null, false, 4, 1, "OAP 364", "DS7KVTVWHWUT43415" },
                    { 26, null, false, 4, 6, "MID 858", "3YESLQWGZXXV41096" },
                    { 27, null, false, 4, 3, "NET 488", "EDUICZ74ONKT97477" },
                    { 28, null, false, 4, 4, "IUU 508", "6S4M0X15E7NE96915" },
                    { 29, null, false, 5, 4, "OEI 704", "0E51T71YL8O848651" },
                    { 30, null, false, 5, 3, "VLD 999", "KF58MY4FL2XY19098" },
                    { 31, null, false, 5, 6, "TTT 287", "Z4PT2Y7L75GC57934" },
                    { 32, null, false, 5, 1, "MTE 852", "TE8HM53HGEBW20565" },
                    { 33, null, false, 5, 1, "SIT 864", "FRULLQAHKQO470257" },
                    { 34, null, false, 5, 4, "TUO 882", "KS7RKSHSQ5SL51576" },
                    { 35, null, false, 5, 6, "RSE 478", "OU7WJ5KS77DW14833" },
                    { 36, null, false, 6, 1, "DTR 260", "QW1H6E88E3TI80450" },
                    { 37, null, false, 6, 2, "EUQ 355", "12DTXNM0ZHGD38973" },
                    { 38, null, false, 6, 3, "AEN 869", "0BTTTV2O8RWT55321" },
                    { 39, null, false, 6, 7, "PDU 453", "Y9S1GQL3J6R762762" },
                    { 40, null, false, 6, 5, "ETO 898", "1EJRNXWA13R920396" },
                    { 41, null, false, 6, 5, "OTN 730", "51O78XLL25JI72229" },
                    { 42, null, false, 6, 2, "UPI 309", "NF9Y882W5URY49921" },
                    { 43, null, false, 7, 3, "PAE 644", "1YF2O3MF0EVG65295" },
                    { 44, null, false, 7, 6, "QTR 467", "E2NPKEU3YNOR84496" },
                    { 45, null, false, 7, 6, "OIA 464", "OPQ3UJ9TQKI894515" },
                    { 46, null, false, 7, 7, "EME 602", "R3XPX8O7X8YJ24124" },
                    { 47, null, false, 7, 1, "RTI 491", "GZZGNDYE4KKL35428" },
                    { 48, null, false, 7, 7, "TIE 820", "STCQQA45YRMV58656" },
                    { 49, null, false, 7, 4, "EIQ 938", "T8E1W1KQIPWE84290" },
                    { 50, null, false, 8, 5, "OAS 534", "GSRYV5YG0TN718399" },
                    { 51, null, false, 8, 7, "EIC 152", "3SSH2GP4HMDW25719" },
                    { 52, null, false, 8, 7, "NEI 381", "04J58BMLTPZV20024" },
                    { 53, null, false, 8, 5, "QNO 907", "8QQ6DHZQT9QF40087" },
                    { 54, null, false, 8, 1, "UNV 730", "GVFSKY9Y44ML64994" },
                    { 55, null, false, 8, 2, "VUU 267", "1H46V09OAKFB79747" },
                    { 56, null, false, 8, 1, "AIE 871", "A7C4A6ABC8XW39925" },
                    { 57, null, false, 9, 3, "IPE 789", "BEEV5O1390MN12191" },
                    { 58, null, false, 9, 2, "EPO 177", "OHSTMS4M9OFZ59500" },
                    { 59, null, false, 9, 4, "TPE 644", "PEPWLSQ6P5R548124" },
                    { 60, null, false, 9, 5, "SOP 419", "AN9FQOA4L2RO28119" },
                    { 61, null, false, 9, 3, "AEN 264", "OSJPN996EECY94765" },
                    { 62, null, false, 9, 1, "LAS 840", "IH6K66I1M6J929385" },
                    { 63, null, false, 9, 2, "MQE 183", "NTQ57WVWD4PQ37680" },
                    { 64, null, false, 10, 2, "QEA 759", "WAIMRA8747LE89081" },
                    { 65, null, false, 10, 2, "QCE 953", "QYUGTHYPN7MO50193" },
                    { 66, null, false, 10, 7, "IPU 187", "Q4ZR7475D5KL94725" },
                    { 67, null, false, 10, 7, "AER 934", "V0PMJVHNWTMI83816" },
                    { 68, null, false, 10, 6, "TCC 761", "9J3D483MAHQ419907" },
                    { 69, null, false, 10, 4, "LIQ 547", "AMKYJHKHKCSH23129" },
                    { 70, null, false, 10, 2, "OME 740", "JUKW3GAWHYKN31500" },
                    { 71, null, false, 11, 2, "QQR 561", "GMI3V46ZFJI340380" },
                    { 72, null, false, 11, 1, "SUS 368", "HBEVHIXWBCUT82445" },
                    { 73, null, false, 11, 4, "SON 927", "LE9OVQ18BCC856427" },
                    { 74, null, false, 11, 2, "EUL 570", "R6NVQQOLTRXF90567" },
                    { 75, null, false, 11, 1, "UCI 565", "OJH5X2R42TU954933" },
                    { 76, null, false, 11, 3, "QMU 950", "6GWFQ1BPIRU127945" },
                    { 77, null, false, 11, 7, "SIV 819", "QIWYECZK42M975891" },
                    { 78, null, false, 12, 5, "AAU 800", "WFNHBXPW8JMY97239" },
                    { 79, null, false, 12, 4, "TSV 997", "9UXWNFQ0N0MY88938" },
                    { 80, null, false, 12, 3, "IAI 117", "EK3DBA0LZFNE50516" },
                    { 81, null, false, 12, 4, "SAS 325", "515N6RS5MFCD32584" },
                    { 82, null, false, 12, 5, "QNQ 501", "DHWSLMLRW8DM24115" },
                    { 83, null, false, 12, 1, "IVQ 685", "PAUU2XL3M3V847695" },
                    { 84, null, false, 12, 1, "TIN 535", "WRHA2RWBQDLD51455" },
                    { 85, null, false, 13, 5, "HAH 186", "QDQV61YNIZBL99580" },
                    { 86, null, false, 13, 2, "SEI 524", "SI43DAUF5OCT54838" },
                    { 87, null, false, 13, 1, "NFL 760", "O2C650HV97V710149" },
                    { 88, null, false, 13, 5, "IQA 816", "1Q9H17L6ZHIQ92469" },
                    { 89, null, false, 13, 3, "OMT 215", "CDIH0PBWXJIH50602" },
                    { 90, null, false, 13, 3, "VUI 170", "SFUOYMEV8EDA75393" },
                    { 91, null, false, 13, 1, "UNM 758", "HNCNW0BC07CF57979" },
                    { 92, null, false, 14, 6, "LST 686", "VS6OLRQ1M2LA22005" },
                    { 93, null, false, 14, 5, "BPT 858", "8GZPPKA5SGGY98390" },
                    { 94, null, false, 14, 6, "QAE 367", "W0HJW9XVPAMT30502" },
                    { 95, null, false, 14, 5, "IEV 179", "W1UTIXE5SQAW79977" },
                    { 96, null, false, 14, 6, "EBE 722", "ZE674B21WOJD92891" },
                    { 97, null, false, 14, 7, "ELQ 101", "FHTZKP7LPKOE66167" },
                    { 98, null, false, 14, 3, "AIU 209", "1SIMJK9KGZKB79447" },
                    { 99, null, false, 15, 5, "MAT 560", "PIM3L6JJH3IE26931" },
                    { 100, null, false, 15, 6, "AET 632", "7VIJ056FY6AI58930" },
                    { 101, null, false, 15, 1, "OTA 584", "VZNY3IZUBUYW26053" },
                    { 102, null, false, 15, 4, "BQU 159", "KW4AAPD04BI755628" },
                    { 103, null, false, 15, 5, "TXS 327", "4AQ1Z1VVQ8H328953" },
                    { 104, null, false, 15, 1, "IIM 891", "4SSK4YAIAQBJ90202" },
                    { 105, null, false, 15, 1, "TTA 356", "BNLQOKL40DNC78016" }
                });

            migrationBuilder.InsertData(
                table: "CarModelDetails",
                columns: new[] { "Id", "Description", "ProductionEndYear", "ProductionStartYear" },
                values: new object[,]
                {
                    { 1, "Standard Tesla Model S is an all-electric luxury sedan with impressive range and performance.", null, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Tesla Model S Plaid is a high-performance electric sedan with 1,020 horsepower, offering incredible acceleration, a top speed of 322 km/h, and a range of up to 600 km. Perfect blend of speed, luxury, and technology.", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Tesla Model 3 is an all-electric sedan offering a perfect combination of performance, efficiency, and style. With 283 horsepower, it delivers smooth acceleration, a top speed of 225 km/h, and a range of up to 513 km. Ideal for those looking for a reliable and affordable electric vehicle.", null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Tesla Model 3 Long Range RWD is an all-electric sedan offering great efficiency, a range of up to 590 km, and smooth acceleration with 283 horsepower. Perfect for long trips with a top speed of 225 km/h.", null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Tesla Model 3 Long Range AWD is an all-electric sedan offering impressive performance and efficiency. With 346 horsepower, a top speed of 233 km/h, and a range of up to 580 km, it's perfect for those seeking power, range, and versatility.", null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Tesla Model 3 Performance is an all-electric sedan offering exhilarating performance and efficiency. With 472 horsepower, a top speed of 261 km/h, and a range of up to 530 km, it's perfect for those seeking speed, power, and precision.", null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Tesla Model Y is an all-electric SUV offering a blend of performance and efficiency. With 283 horsepower, a top speed of 217 km/h, and a range of up to 530 km, it’s perfect for those seeking space and sustainability.", null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Tesla Model Y Long Range RWD is an all-electric SUV offering excellent efficiency and performance. With 283 horsepower, a top speed of 217 km/h, and a range of up to 530 km, it’s perfect for long trips with ample space.", null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Tesla Model Y Long Range AWD is an all-electric SUV offering a perfect balance of power, efficiency, and space. With 351 horsepower, a top speed of 217 km/h, and a range of up to 505 km, it’s ideal for long trips and all-weather performance.", null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Tesla Model Y Performance is an all-electric SUV delivering exceptional speed and performance. With 456 horsepower, a top speed of 250 km/h, and a range of up to 480 km, it offers thrilling acceleration and dynamic handling.", null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Tesla Model X is an all-electric SUV combining top-tier performance, safety, and cutting-edge technology. With 670 horsepower, a top speed of 250 km/h, and a range of up to 560 km, it offers incredible acceleration, spaciousness, and versatility.", null, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Tesla Model X Plaid is a high-performance all-electric SUV that redefines speed and capability. With 1020 horsepower, a top speed of 262 km/h, and a range of up to 560 km, it delivers thrilling acceleration, cutting-edge technology, and unparalleled versatility for families and performance enthusiasts alike.", null, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Tesla Cybertruck is an all-electric pickup truck that offers exceptional durability, performance, and utility. With 1020 horsepower, a top speed of 180 km/h, and a range of up to 402 km, it’s built to handle any terrain with advanced technology and futuristic design.", null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Tesla Cybertruck is an all-electric pickup truck that offers exceptional durability, performance, and utility. With 1020 horsepower, a top speed of 180 km/h, and a range of up to 402 km, it’s built to handle any terrain with advanced technology and futuristic design.", null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Tesla Cybertruck Cyber-beast is an all-electric pickup with unmatched performance. Equipped with three motors, it delivers extreme acceleration, a top speed of 262 km/h, and a range of up to 502 km, designed for the toughest terrains and ultimate power.", null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CarModel_Equipment",
                columns: new[] { "CarModelId", "EquipmentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 9 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 6 },
                    { 2, 11 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 4 },
                    { 3, 9 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 4 },
                    { 4, 9 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 4 },
                    { 5, 9 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 4 },
                    { 6, 6 },
                    { 6, 11 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 4 },
                    { 7, 9 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 4 },
                    { 8, 9 },
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 4 },
                    { 9, 9 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 4 },
                    { 10, 6 },
                    { 10, 11 },
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 4 },
                    { 11, 9 },
                    { 12, 1 },
                    { 12, 2 },
                    { 12, 3 },
                    { 12, 4 },
                    { 12, 6 },
                    { 12, 11 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 4 },
                    { 13, 9 },
                    { 14, 1 },
                    { 14, 2 },
                    { 14, 4 },
                    { 14, 9 },
                    { 15, 1 },
                    { 15, 2 },
                    { 15, 3 },
                    { 15, 4 },
                    { 15, 6 },
                    { 15, 11 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DateOfBirth", "DrivingLicenseNumber", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisteredDate", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, 1, "37dfae4c-bb56-41e0-81a1-20a09eb89a65", new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "UU7OD8NAXC", "admin@gmail.com", true, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGEMYoNWV9ZPZbmvUC7bIR9ZoFmrtLksCK1C5/Zv5zeZKOQ5ZdGQIfIetYntVtwvsw==", null, false, new DateTime(2025, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", false, "admin@gmail.com" },
                    { 2, 0, 12, " 9f0a42ad-8b69-4b33-b42e-87d16f84bfe5", new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4WVG9U3XB2", "jan.kowalski@gmail.com", true, false, null, "Jan", "JAN.KOWALSKI@GMAIL.COM", "JAN.KOWALSKI@GMAIL.COM", "AQAAAAIAAYagAAAAEOxfEj/QgbFYuT8NjbpqyOCZquEHFa2tZWhTad2pbvEHpffKzMnJSUHOc6cjr9jh+g==", null, false, new DateTime(2025, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), null, "Kowalski", false, "jan.kowalski@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "AddressId", "DeleteDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Palma Airport" },
                    { 2, 2, null, false, "Palma City Center" },
                    { 3, 3, null, false, "Alcudia" },
                    { 4, 4, null, false, "Manacor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Car_Location",
                columns: new[] { "Id", "CarId", "FromDate", "LocationId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 2, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 3, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 4, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, 5, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 6, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 7, 7, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, 8, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, 9, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, 10, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, 11, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, 12, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, 13, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, 14, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 15, 15, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, 16, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 17, 17, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, 18, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, 19, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, 20, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, 21, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 22, 22, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 23, 23, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 24, 24, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 25, 25, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 26, 26, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 27, 27, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 28, 28, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 29, 29, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 30, 30, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 31, 31, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 32, 32, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 33, 33, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 34, 34, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 35, 35, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 36, 36, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 37, 37, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 38, 38, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 39, 39, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 40, 40, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 41, 41, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 42, 42, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 43, 43, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 44, 44, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 45, 45, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 46, 46, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 47, 47, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 48, 48, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 49, 49, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 50, 50, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 51, 51, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 52, 52, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 53, 53, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 54, 54, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 55, 55, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 56, 56, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 57, 57, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 58, 58, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 59, 59, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 60, 60, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 61, 61, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 62, 62, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 63, 63, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 64, 64, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 65, 65, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 66, 66, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 67, 67, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 68, 68, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 69, 69, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 70, 70, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 71, 71, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 72, 72, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 73, 73, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 74, 74, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 75, 75, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 76, 76, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 77, 77, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 78, 78, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 79, 79, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 80, 80, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 81, 81, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 82, 82, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 83, 83, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 84, 84, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 85, 85, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 86, 86, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 87, 87, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 88, 88, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 89, 89, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 90, 90, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 91, 91, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 92, 92, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 93, 93, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 94, 94, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 95, 95, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 96, 96, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 97, 97, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 98, 98, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 99, 99, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 100, 100, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 101, 101, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 102, 102, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 103, 103, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 104, 104, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 105, 105, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DrivingLicenseNumber",
                table: "AspNetUsers",
                column: "DrivingLicenseNumber",
                unique: true,
                filter: "[DrivingLicenseNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                table: "Car",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_PaintId",
                table: "Car",
                column: "PaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_RegistrationNr",
                table: "Car",
                column: "RegistrationNr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_VIN",
                table: "Car",
                column: "VIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_Location_CarId",
                table: "Car_Location",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_Location_LocationId",
                table: "Car_Location",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAvailabilityIssue_CarModelId",
                table: "CarAvailabilityIssue",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAvailabilityIssue_LocationId",
                table: "CarAvailabilityIssue",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAvailabilityIssue_ReservationId",
                table: "CarAvailabilityIssue",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_BodyTypeId",
                table: "CarModel",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_BrandId",
                table: "CarModel",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_CarModelId",
                table: "CarModel",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_DriveTypeId",
                table: "CarModel",
                column: "DriveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_FuelTypeId",
                table: "CarModel",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_GearBoxId",
                table: "CarModel",
                column: "GearBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_ModelVersionId",
                table: "CarModel",
                column: "ModelVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_Equipment_EquipmentId",
                table: "CarModel_Equipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_AddressId",
                table: "Location",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CarId",
                table: "Reservation",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CarModelId",
                table: "Reservation",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PaymentMethodId",
                table: "Reservation",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PickupLocationId",
                table: "Reservation",
                column: "PickupLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReturnLocationId",
                table: "Reservation",
                column: "ReturnLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_OptService_ReservationId",
                table: "Reservation_OptService",
                column: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Car_Location");

            migrationBuilder.DropTable(
                name: "CarAvailabilityIssue");

            migrationBuilder.DropTable(
                name: "CarModel_Equipment");

            migrationBuilder.DropTable(
                name: "CarModelDetails");

            migrationBuilder.DropTable(
                name: "Reservation_OptService");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "OptService");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "Paint");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BodyType");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "DriveType");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropTable(
                name: "GearBox");

            migrationBuilder.DropTable(
                name: "ModelVersion");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
