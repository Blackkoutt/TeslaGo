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
                    { 1, 1, null, null, "56115", false, "Carretera de l'Aeroport", "91149" },
                    { 2, 1, null, null, "4464", false, "Carrer de la Riera", "60851" },
                    { 3, 2, null, null, "530", false, "Cami de Ronda", "80137" },
                    { 4, 3, null, null, "883", false, "Via Portugal", "64769-3615" },
                    { 5, 4, null, (short)160, "5469", false, "Carrer de la Rosa", "98649" },
                    { 6, 5, null, (short)179, "7439", false, "Carrer del Sol", "60257" },
                    { 7, 6, null, (short)90, "26491", false, "Carrer de la Ciutat", "87886" },
                    { 8, 7, null, (short)56, "5098", false, "Carrer de la Lluna", "39423" },
                    { 9, 8, null, (short)161, "2511", false, "Carrer del Mar", "70956" },
                    { 10, 9, null, (short)64, "8919", false, "Carrer de la Mediterrània", "36512" },
                    { 11, 10, null, (short)195, "70120", false, "Carrer de la Palma", "25673" },
                    { 12, 11, null, (short)118, "59877", false, "Krakowskie Przedmieście", "74352" },
                    { 13, 12, null, (short)113, "2088", false, "Strzelecka", "03035" },
                    { 14, 13, null, (short)132, "14665", false, "Calle Gran Vía", "57399-7360" },
                    { 15, 14, null, (short)152, "320", false, "Passeig de Gràcia", "23576" },
                    { 16, 15, null, (short)3, "313", false, "Berliner Strasse", "71042-2714" },
                    { 17, 16, null, (short)54, "9939", false, "Maximilianstrasse", "82913" },
                    { 18, 17, null, (short)135, "09717", false, "Rue Monge", "29766-6155" },
                    { 19, 18, null, (short)196, "97913", false, "Rue Vauban", "72811" },
                    { 20, 19, null, (short)59, "6633", false, "Via Torino", "86530-6197" },
                    { 21, 20, null, (short)112, "8464", false, "Via Brera", "93663" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "DeleteDate", "IsDeleted", "ModelId", "PaintId", "RegistrationNr", "VIN" },
                values: new object[,]
                {
                    { 1, null, false, 1, 7, "UMA 627", "WX5UMWDMLNL875013" },
                    { 2, null, false, 1, 5, "RAS 483", "HIEDZP4F9LM094928" },
                    { 3, null, false, 1, 6, "ULV 599", "MHI6P1V6WAII14621" },
                    { 4, null, false, 1, 5, "ALI 256", "IXJ55WMEE9H691655" },
                    { 5, null, false, 1, 3, "MEQ 694", "0QPKQQB759VG28732" },
                    { 6, null, false, 1, 3, "ULE 870", "JYWNYC47T8JQ70081" },
                    { 7, null, false, 1, 6, "ETG 741", "WDKNXU2FM4P533906" },
                    { 8, null, false, 2, 4, "ATN 549", "XIM2S1ZG9EU851789" },
                    { 9, null, false, 2, 3, "EEO 547", "U1THKUO2NQIG66367" },
                    { 10, null, false, 2, 3, "OIM 720", "C5MXIBDF2OR649886" },
                    { 11, null, false, 2, 7, "TMT 289", "KF8QFGYNCTIV93645" },
                    { 12, null, false, 2, 5, "RQM 309", "F5956AHM8ACU31721" },
                    { 13, null, false, 2, 4, "LUI 141", "S94QPAIXH5B673190" },
                    { 14, null, false, 2, 7, "ROB 312", "ZQOIBLQPNJNP82557" },
                    { 15, null, false, 3, 6, "EDI 952", "AZUWWO6VYMR890550" },
                    { 16, null, false, 3, 2, "EUT 196", "FJ8Z1PP0ZIQX31958" },
                    { 17, null, false, 3, 7, "OHM 528", "T4BVTBRKCKWO80952" },
                    { 18, null, false, 3, 1, "OPI 517", "5I4S848JAWQ657232" },
                    { 19, null, false, 3, 5, "AAE 650", "ZHXK8WRM2QLF95385" },
                    { 20, null, false, 3, 4, "AUU 734", "I7VXIE3WNEOR35764" },
                    { 21, null, false, 3, 1, "AEI 569", "EYO00HA3I1LV12627" },
                    { 22, null, false, 4, 5, "OTO 174", "JBYZKDIVMWC373648" },
                    { 23, null, false, 4, 2, "UAE 936", "7IW8X8B5ITFD28348" },
                    { 24, null, false, 4, 3, "ERT 660", "B2697N6AG8C760067" },
                    { 25, null, false, 4, 6, "SDU 339", "BA37SILCJEYB64707" },
                    { 26, null, false, 4, 5, "NEU 606", "OQCDESNYN1HL52658" },
                    { 27, null, false, 4, 3, "UTE 441", "5CDT2T0OOIPX38519" },
                    { 28, null, false, 4, 4, "ALI 841", "MB4CNZGW8AO362624" },
                    { 29, null, false, 5, 3, "LRP 255", "4AIU5KPSG7GH25476" },
                    { 30, null, false, 5, 6, "AUA 623", "DCC4J1INJYET61973" },
                    { 31, null, false, 5, 6, "UML 780", "BV1P487Q5UXQ14776" },
                    { 32, null, false, 5, 6, "IDD 345", "X6BY1F6IL1F478934" },
                    { 33, null, false, 5, 5, "MAL 446", "N4U8D6NBMPPO22738" },
                    { 34, null, false, 5, 5, "IIA 792", "RPS8PA12RSDI51283" },
                    { 35, null, false, 5, 2, "DQN 774", "7RHOBY20SDJQ55188" },
                    { 36, null, false, 6, 7, "EEO 146", "M08U99M27UX222955" },
                    { 37, null, false, 6, 3, "QTF 998", "698GIEKQMPRC94061" },
                    { 38, null, false, 6, 7, "ULA 944", "XCE67ZL7O0ZO24541" },
                    { 39, null, false, 6, 4, "STT 565", "4KLA3UN2B1CZ28245" },
                    { 40, null, false, 6, 3, "DIL 955", "R3XMQ0XLISB663555" },
                    { 41, null, false, 6, 2, "ASA 432", "5HPPI9G1S7D679853" },
                    { 42, null, false, 6, 2, "TEX 457", "BK6R0OS0K2FX46372" },
                    { 43, null, false, 7, 5, "ILQ 233", "899A175BM2WK63375" },
                    { 44, null, false, 7, 1, "TDA 514", "LRQ710D01ZFL28465" },
                    { 45, null, false, 7, 7, "TNT 340", "UPJMDKS2ZKOF50241" },
                    { 46, null, false, 7, 2, "MBQ 427", "H62GZ7FS9YNB57764" },
                    { 47, null, false, 7, 1, "UUA 473", "S3F4O7BT71DJ85133" },
                    { 48, null, false, 7, 1, "EHC 795", "4IWX9T9RVRH620832" },
                    { 49, null, false, 7, 6, "EIO 533", "QF4EYI73BYXV47595" },
                    { 50, null, false, 8, 1, "TSD 452", "0C7QEZ3SXHC151027" },
                    { 51, null, false, 8, 6, "ETI 991", "DIT6WHGXGMPP20446" },
                    { 52, null, false, 8, 7, "LTE 276", "KLCJKD8S5FYR69717" },
                    { 53, null, false, 8, 4, "AQT 411", "0I7EACQH59XS38390" },
                    { 54, null, false, 8, 3, "SSA 193", "R90WXBAOKPT537490" },
                    { 55, null, false, 8, 2, "EEI 967", "S2EOEELORDFP53747" },
                    { 56, null, false, 8, 3, "UDS 526", "SJ76NJ3W8PFV87165" },
                    { 57, null, false, 9, 5, "EUQ 212", "N8G89EKTJLIW13813" },
                    { 58, null, false, 9, 5, "SAI 785", "3ZPJLTQ56CT471452" },
                    { 59, null, false, 9, 5, "HFA 290", "LDYAMZHZ3XL196071" },
                    { 60, null, false, 9, 1, "OAI 809", "EKQUPTRPOXW368939" },
                    { 61, null, false, 9, 1, "IFI 295", "83O3US63F5IW25287" },
                    { 62, null, false, 9, 2, "CTU 944", "C03AZXV3XOY779811" },
                    { 63, null, false, 9, 2, "LNN 117", "HPD0SR9NBZBP12626" },
                    { 64, null, false, 10, 1, "MTA 285", "APJKU92FJ5II39494" },
                    { 65, null, false, 10, 1, "OSS 928", "R5GZWKX1UWZO82360" },
                    { 66, null, false, 10, 3, "QAA 339", "QOBEIW2F8AGX55888" },
                    { 67, null, false, 10, 2, "QOU 331", "VRJSQGDYR5ZF35583" },
                    { 68, null, false, 10, 5, "OEL 369", "8686PKNW0GW992776" },
                    { 69, null, false, 10, 2, "LAT 705", "DSJF3BV22MLD82461" },
                    { 70, null, false, 10, 6, "UTQ 439", "4ZXD7BBWPPP913071" },
                    { 71, null, false, 11, 6, "UAE 984", "COA73UW4YCBS15375" },
                    { 72, null, false, 11, 4, "QIM 326", "LKMDKJ9WSRTN77798" },
                    { 73, null, false, 11, 2, "MSH 564", "ELZJAJB9WDUU16600" },
                    { 74, null, false, 11, 2, "ANT 514", "4ZN8FJ65DXVE60733" },
                    { 75, null, false, 11, 5, "AIE 610", "RZXIYL3CSSQY64359" },
                    { 76, null, false, 11, 6, "RNS 287", "NW5KIEL9H3IL11517" },
                    { 77, null, false, 11, 2, "SUA 433", "JNPKSSJ36DZ259199" },
                    { 78, null, false, 12, 2, "UOP 991", "3V681L4LOJS370606" },
                    { 79, null, false, 12, 2, "OIU 286", "4A5FOUWIBIBB11346" },
                    { 80, null, false, 12, 7, "TUN 586", "W5PST1VNGKGT45626" },
                    { 81, null, false, 12, 4, "EUE 704", "IBLD3X240BJR44213" },
                    { 82, null, false, 12, 4, "RSA 554", "SWDUGA3724I353254" },
                    { 83, null, false, 12, 4, "SRS 566", "J90VLOIDJKVF57263" },
                    { 84, null, false, 12, 2, "GII 946", "432VOB71ORYP57410" },
                    { 85, null, false, 13, 1, "EAA 893", "3UIBZ9MAKCTM42553" },
                    { 86, null, false, 13, 7, "FMR 230", "P8SVT78O5TDP99225" },
                    { 87, null, false, 13, 5, "ATI 833", "1GM1MEYN4UAH55935" },
                    { 88, null, false, 13, 7, "REE 162", "WK4ZPMYDMXPT89503" },
                    { 89, null, false, 13, 3, "TME 227", "QEO9BKBWDWOT23775" },
                    { 90, null, false, 13, 6, "VPC 977", "X0RGYJ0EKNJR95694" },
                    { 91, null, false, 13, 6, "TEL 818", "6SGFKKEJ0OVT33981" },
                    { 92, null, false, 14, 6, "DNO 572", "BBL6H1OJTUZM94214" },
                    { 93, null, false, 14, 1, "VXT 235", "8NHOQI99PRCW58782" },
                    { 94, null, false, 14, 5, "SPS 219", "089UMXL06XZS37644" },
                    { 95, null, false, 14, 7, "MLM 301", "K2GB5T6B1URN52326" },
                    { 96, null, false, 14, 1, "UTE 206", "8BBZGBYEZ8BY72738" },
                    { 97, null, false, 14, 2, "LSL 268", "UGPHJ4DI8FJB49588" },
                    { 98, null, false, 14, 5, "EEE 760", "1OIFZK0I3EHQ91172" },
                    { 99, null, false, 15, 6, "SCD 899", "33ZS7ND01FHL16336" },
                    { 100, null, false, 15, 7, "RCA 740", "5MA9FBGC81U332023" },
                    { 101, null, false, 15, 4, "OMT 701", "4AXAC05W3PS356425" },
                    { 102, null, false, 15, 1, "RNN 457", "VUZD5F1SGPM018887" },
                    { 103, null, false, 15, 2, "SIP 588", "G8V6DMMWG8F773343" },
                    { 104, null, false, 15, 2, "UMU 896", "6L420RR5E1FZ37921" },
                    { 105, null, false, 15, 4, "ETU 172", "MLK03IRG20S292568" }
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
                    { 1, 0, 1, "37dfae4c-bb56-41e0-81a1-20a09eb89a65", new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "X32I4KYO4U", "admin@gmail.com", true, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMGxuhAVzfomRZU9ymMBzuTxWRRf0JDNO5vl8IQEQLPCkLGnGjRKSeZrXNM/GKjhIQ==", null, false, new DateTime(2025, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", false, "admin@gmail.com" },
                    { 2, 0, 12, " 9f0a42ad-8b69-4b33-b42e-87d16f84bfe5", new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YL3CZX95TJ", "jan.kowalski@gmail.com", true, false, null, "Jan", "JAN.KOWALSKI@GMAIL.COM", "JAN.KOWALSKI@GMAIL.COM", "AQAAAAIAAYagAAAAEBNwzUahGhDpXXSDopVvZwveO1CDIu+vy9NPbezcW36Z8caSW2yZci/z2pWmTa1EyQ==", null, false, new DateTime(2025, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), null, "Kowalski", false, "jan.kowalski@gmail.com" }
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
                    { 2, 2, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 3, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 4, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 5, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 6, 6, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 7, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, 8, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, 9, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 10, 10, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 11, 11, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, 12, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, 13, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, 14, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 15, 15, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, 16, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, 17, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 18, 18, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 19, 19, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, 20, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, 21, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, 22, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 23, 23, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 24, 24, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 25, 25, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 26, 26, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 27, 27, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 28, 28, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 29, 29, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 30, 30, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 31, 31, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 32, 32, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 33, 33, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 34, 34, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 35, 35, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 36, 36, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 37, 37, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 38, 38, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 39, 39, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 40, 40, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 41, 41, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 42, 42, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 43, 43, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 44, 44, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 45, 45, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 46, 46, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 47, 47, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 48, 48, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 49, 49, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 50, 50, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 51, 51, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 52, 52, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 53, 53, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 54, 54, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 55, 55, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 56, 56, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 57, 57, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 58, 58, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 59, 59, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 60, 60, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 61, 61, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 62, 62, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 63, 63, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 64, 64, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 65, 65, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 66, 66, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 67, 67, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 68, 68, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 69, 69, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 70, 70, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 71, 71, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 72, 72, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 73, 73, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 74, 74, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 75, 75, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 76, 76, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 77, 77, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 78, 78, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 79, 79, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 80, 80, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 81, 81, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 82, 82, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 83, 83, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 84, 84, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 85, 85, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 86, 86, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 87, 87, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 88, 88, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 89, 89, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 90, 90, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 91, 91, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 92, 92, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 93, 93, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 94, 94, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 95, 95, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 96, 96, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 97, 97, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 98, 98, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 99, 99, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 100, 100, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 101, 101, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 102, 102, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 103, 103, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 104, 104, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 105, 105, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 }
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
