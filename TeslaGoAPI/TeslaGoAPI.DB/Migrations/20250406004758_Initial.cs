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
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
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
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
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
                    NumberOfGears = table.Column<byte>(type: "tinyint", nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
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
                    ColorHex = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
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
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    GearBoxId = table.Column<int>(type: "int", nullable: false),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    DriveTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.Id);
                    table.CheckConstraint("CK_CarModel_PricePerDay", "[PricePerDay] BETWEEN 0 AND 50000");
                    table.CheckConstraint("CK_CarModel_Range", "[Range] BETWEEN 0 AND 10000");
                    table.CheckConstraint("CK_CarModel_SeatCount", "[SeatCount] BETWEEN 1 AND 255");
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
                    Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HouseNr = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FlatNr = table.Column<short>(type: "smallint", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.CheckConstraint("CK_Address_FlatNr", "[FlatNr] BETWEEN 0 AND 10000");
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    PaintId = table.Column<int>(type: "int", nullable: false)
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
                    DoorCount = table.Column<byte>(type: "tinyint", nullable: true),
                    HorsePower = table.Column<short>(type: "smallint", nullable: true),
                    ProductionStartYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductionEndYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AccelerationInSeconds = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    MaxSpeedInKmPerHour = table.Column<short>(type: "smallint", nullable: true),
                    TrunkCapacityLiters = table.Column<int>(type: "int", nullable: true),
                    TrunkCapacitySuitCases = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelDetails", x => x.Id);
                    table.CheckConstraint("CK_CarModelDetails_AccelerationInSeconds", "[AccelerationInSeconds] BETWEEN 0 AND 1000");
                    table.CheckConstraint("CK_CarModelDetails_DoorCount", "[DoorCount] BETWEEN 1 AND 30");
                    table.CheckConstraint("CK_CarModelDetails_HorsePower", "[HorsePower] BETWEEN 1 AND 10000");
                    table.CheckConstraint("CK_CarModelDetails_MaxSpeedInKmPerHour", "[MaxSpeedInKmPerHour] BETWEEN 1 AND 1000");
                    table.CheckConstraint("CK_CarModelDetails_TrunkCapacityLiters", "[TrunkCapacityLiters] BETWEEN 0 AND 10000");
                    table.CheckConstraint("CK_CarModelDetails_TrunkCapacitySuitCases", "[TrunkCapacitySuitCases] BETWEEN 0 AND 50");
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
                    AddressId = table.Column<int>(type: "int", nullable: false)
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
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
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
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "SUV" },
                    { 3, "Pickup" },
                    { 4, "Roadster" }
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tesla" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Spain" },
                    { 2, "Poland" },
                    { 3, "Germany" },
                    { 4, "France" },
                    { 5, "Italy" }
                });

            migrationBuilder.InsertData(
                table: "DriveType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Rear-Wheel Drive", "RWD" },
                    { 2, "All-Wheel Drive", "AWD" }
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
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Electric" });

            migrationBuilder.InsertData(
                table: "GearBox",
                columns: new[] { "Id", "Name", "NumberOfGears" },
                values: new object[] { 1, "Single-Speed", (byte)1 });

            migrationBuilder.InsertData(
                table: "ModelVersion",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Standard range, standard performance", "Standard" },
                    { 2, "Longer range, standard performance", "Long Range" },
                    { 3, "High-performance version with quicker acceleration", "Performance" },
                    { 4, "Top performance with three motors and extreme acceleration", "Plaid" },
                    { 5, "Tri-motor performance with extreme acceleration and off-road prowess.", "Cyber-beast" }
                });

            migrationBuilder.InsertData(
                table: "OptService",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Comprehensive insurance coverage including damage, theft, and third-party liability.", "Full Insurance", 250.00m },
                    { 3, "Safe and comfortable child car seat suitable for different age groups.", "Child Car Seat", 50.00m },
                    { 4, "24/7 roadside assistance in case of emergencies like breakdowns or accidents.", "Roadside Assistance", 199.00m },
                    { 5, "Add an additional driver to the rental for no extra charge for the duration of the rental period.", "Extra Driver", 25.00m }
                });

            migrationBuilder.InsertData(
                table: "Paint",
                columns: new[] { "Id", "ColorHex", "Name" },
                values: new object[,]
                {
                    { 1, "#ffffff", "Pearl White" },
                    { 2, "#000000", "Solid Black" },
                    { 3, "#235598", "Deep Blue Metallic" },
                    { 4, "#212127", "Stealth Grey" },
                    { 5, "#87858e", "QuickSilver" },
                    { 6, "#b6151f", "Ultra Red" },
                    { 7, "#740415", "Midnight Cherry Red" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Credit Card" },
                    { 2, "Bank Transfer" },
                    { 3, "PayPal" },
                    { 4, "Apple Pay" },
                    { 5, "Google Pay" },
                    { 6, "Cash on Delivery" }
                });

            migrationBuilder.InsertData(
                table: "CarModel",
                columns: new[] { "Id", "BodyTypeId", "BrandId", "DriveTypeId", "FuelTypeId", "GearBoxId", "ModelVersionId", "Name", "PricePerDay", "Range", "SeatCount" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, 1, 1, "Model S", 100m, (short)634, (byte)5 },
                    { 2, 1, 1, 1, 1, 1, 4, "Model S", 170m, (short)600, (byte)5 },
                    { 3, 1, 1, 1, 1, 1, 1, "Model 3", 80m, (short)513, (byte)5 },
                    { 4, 1, 1, 1, 1, 1, 2, "Model 3", 100m, (short)702, (byte)5 },
                    { 5, 1, 1, 2, 1, 1, 2, "Model 3", 110m, (short)629, (byte)5 },
                    { 6, 1, 1, 2, 1, 1, 3, "Model 3", 140m, (short)528, (byte)5 },
                    { 7, 2, 1, 1, 1, 1, 1, "Model Y", 60m, (short)455, (byte)5 },
                    { 8, 2, 1, 1, 1, 1, 2, "Model Y", 75m, (short)600, (byte)5 },
                    { 9, 2, 1, 2, 1, 1, 2, "Model Y", 85m, (short)533, (byte)5 },
                    { 10, 2, 1, 2, 1, 1, 3, "Model Y", 115m, (short)514, (byte)5 },
                    { 11, 2, 1, 2, 1, 1, 1, "Model X", 105m, (short)576, (byte)5 },
                    { 12, 2, 1, 2, 1, 1, 4, "Model X", 145m, (short)543, (byte)5 },
                    { 13, 3, 1, 1, 1, 1, 1, "Cybertruck", 140m, (short)402, (byte)5 },
                    { 14, 3, 1, 2, 1, 1, 1, "Cybertruck", 170m, (short)547, (byte)5 },
                    { 15, 3, 1, 2, 1, 1, 5, "Cybertruck", 210m, (short)515, (byte)5 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Palma" },
                    { 2, 1, "Alcudia" },
                    { 3, 1, "Manacor" },
                    { 4, 1, "Inca" },
                    { 5, 1, "Santanyí" },
                    { 6, 1, "Sóller" },
                    { 7, 1, "Magaluf" },
                    { 8, 1, "Porto Cristo" },
                    { 9, 1, "Campos" },
                    { 10, 1, "Marratxí" },
                    { 11, 2, "Warsaw" },
                    { 12, 2, "Kraków" },
                    { 13, 1, "Madrid" },
                    { 14, 1, "Barcelona" },
                    { 15, 3, "Berlin" },
                    { 16, 3, "Munich" },
                    { 17, 4, "Paris" },
                    { 18, 1, "Lyon" },
                    { 19, 5, "Rome" },
                    { 20, 5, "Milan" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "CityId", "FlatNr", "HouseNr", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, 1, null, "767", "Carretera de l'Aeroport", "85966-2348" },
                    { 2, 1, null, "22277", "Carrer de la Riera", "18943" },
                    { 3, 2, null, "28806", "Cami de Ronda", "84182" },
                    { 4, 3, null, "34424", "Via Portugal", "54867-2508" },
                    { 5, 4, (short)88, "9229", "Carrer de la Rosa", "87883" },
                    { 6, 5, (short)5, "39697", "Carrer del Sol", "57686" },
                    { 7, 6, (short)15, "6048", "Carrer de la Ciutat", "40424" },
                    { 8, 7, (short)174, "1636", "Carrer de la Lluna", "19951-0671" },
                    { 9, 8, (short)58, "5994", "Carrer del Mar", "93006" },
                    { 10, 9, (short)152, "57017", "Carrer de la Mediterrània", "06464-0437" },
                    { 11, 10, (short)51, "50343", "Carrer de la Palma", "85574" },
                    { 12, 11, (short)107, "54891", "Krakowskie Przedmieście", "01751" },
                    { 13, 12, (short)32, "2062", "Strzelecka", "66276" },
                    { 14, 13, (short)72, "025", "Calle Gran Vía", "01964" },
                    { 15, 14, (short)115, "33429", "Passeig de Gràcia", "99975-9885" },
                    { 16, 15, (short)37, "9853", "Berliner Strasse", "42242" },
                    { 17, 16, (short)98, "404", "Maximilianstrasse", "77489" },
                    { 18, 17, (short)192, "9076", "Rue Monge", "81227" },
                    { 19, 18, (short)165, "2378", "Rue Vauban", "30286-7831" },
                    { 20, 19, (short)62, "50645", "Via Torino", "42260-7986" },
                    { 21, 20, (short)62, "5967", "Via Brera", "53863" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "ModelId", "PaintId", "RegistrationNr", "VIN" },
                values: new object[,]
                {
                    { 1, 1, 1, "IQB 260", "NXMKEWHBTDX640374" },
                    { 2, 1, 3, "IXI 966", "1JKAP1BLR3C152291" },
                    { 3, 1, 3, "VUD 369", "JU2QETBTP6JN42761" },
                    { 4, 1, 5, "PIT 490", "JNH7Y6LQYIQ518157" },
                    { 5, 1, 4, "SAQ 441", "AK5G1XYMUMZ393348" },
                    { 6, 1, 4, "OUT 119", "M1G0ZEXUXDLL44920" },
                    { 7, 1, 5, "AME 684", "EFVBL3XHX8RB90327" },
                    { 8, 2, 4, "SSL 586", "R2KGSZ34NWE163505" },
                    { 9, 2, 1, "SIR 875", "MVGC7439JSBK41588" },
                    { 10, 2, 6, "GEE 334", "YUS7P2WFUHYL79402" },
                    { 11, 2, 3, "IEU 439", "OGILA4WFJBLB84898" },
                    { 12, 2, 4, "EUA 520", "B56KKT58FMWC98703" },
                    { 13, 2, 5, "STN 684", "LYG2TWKTWTWF92855" },
                    { 14, 2, 2, "TTI 370", "X4BAMHLO24DR54319" },
                    { 15, 3, 7, "NRQ 981", "F473332B8PVU56614" },
                    { 16, 3, 2, "EUQ 798", "CJRWJX43HGKG39239" },
                    { 17, 3, 2, "IUR 733", "L63NX58WWPNJ75261" },
                    { 18, 3, 3, "SOG 766", "PK3QKM9XDEE053307" },
                    { 19, 3, 5, "TTQ 290", "OV1VV25IQZGL98057" },
                    { 20, 3, 4, "IQC 629", "NQ9TZS0MVJTI46144" },
                    { 21, 3, 4, "EIO 975", "IV1T3O4A0ROT75651" },
                    { 22, 4, 7, "MTI 623", "JUKTXN5CHMDA43777" },
                    { 23, 4, 5, "OTE 385", "XTK53CCN9IFU53309" },
                    { 24, 4, 5, "LEU 380", "88IJTXENKRVZ78622" },
                    { 25, 4, 4, "ISG 706", "JBDMP8KMCTSI95546" },
                    { 26, 4, 5, "IMD 439", "P2G9PJZWEHZU10420" },
                    { 27, 4, 3, "TAT 179", "41HKV9MZFDPN22950" },
                    { 28, 4, 7, "SIT 156", "4UM9JV882BUF92251" },
                    { 29, 5, 7, "SES 596", "X0BPN0IIR1V111883" },
                    { 30, 5, 5, "ILM 957", "PLW1R5U0AIZI59485" },
                    { 31, 5, 2, "ESI 757", "3LQ3A0TG9MYS51151" },
                    { 32, 5, 4, "TAQ 667", "XF2TRIC3QRPY76878" },
                    { 33, 5, 3, "RAM 513", "GABHZI8I7OR558512" },
                    { 34, 5, 3, "IAU 625", "7NQDBZPU56HK51122" },
                    { 35, 5, 1, "MVL 592", "SC9O52YCL0AD35624" },
                    { 36, 6, 2, "TIA 618", "5CK9LJ258UCM83767" },
                    { 37, 6, 4, "API 475", "9O80INSZYYK635630" },
                    { 38, 6, 5, "AOR 981", "DI2VSELT73KK88002" },
                    { 39, 6, 5, "EUT 328", "BTLP9G9NBAH791587" },
                    { 40, 6, 5, "RTT 470", "EKGDV6KULHDJ12103" },
                    { 41, 6, 2, "OMP 874", "UUVDH9717WV925800" },
                    { 42, 6, 3, "ATI 850", "IOSMO1J38TPW32039" },
                    { 43, 7, 6, "IIU 922", "QVUCAMTDNLD734223" },
                    { 44, 7, 3, "TDA 295", "GILIBQ1JDXSE45811" },
                    { 45, 7, 4, "EOI 292", "8KE3G7ZY37Q444780" },
                    { 46, 7, 4, "IEU 753", "86D97MYVRSQQ27714" },
                    { 47, 7, 5, "NCT 330", "GPFD73RWW0R056894" },
                    { 48, 7, 4, "SUA 548", "QQYOUFGM31CT47946" },
                    { 49, 7, 3, "NAS 355", "M29Y540TL3WU79854" },
                    { 50, 8, 5, "ASU 155", "SBVV3N2ZGIUK29815" },
                    { 51, 8, 4, "GQC 103", "9CQTU27077KN68785" },
                    { 52, 8, 5, "MEQ 184", "AGRZ3A9O5YKD37766" },
                    { 53, 8, 6, "ILT 131", "Q7AJ65VM9AYA25672" },
                    { 54, 8, 5, "ADN 520", "RH61FNGI6VR281096" },
                    { 55, 8, 6, "MNE 957", "DKT6LHPO68K637592" },
                    { 56, 8, 6, "UQU 925", "8A12D956W1Y755107" },
                    { 57, 9, 2, "AOP 321", "7G99EA4FENB591708" },
                    { 58, 9, 7, "SUN 300", "MBOWPR9IJWBZ16167" },
                    { 59, 9, 6, "TAB 940", "IEI6QEEMVKUT78464" },
                    { 60, 9, 1, "ACE 941", "5JWCVDF7BLZ846635" },
                    { 61, 9, 2, "UON 791", "1D5YXAXL5JRP49038" },
                    { 62, 9, 6, "AMI 687", "2FW8664RL5BB90090" },
                    { 63, 9, 4, "LSS 836", "UA3MTQ6NANXB58374" },
                    { 64, 10, 4, "TAE 178", "A2OG00COIZHM96585" },
                    { 65, 10, 5, "ART 692", "ZHJ5E8BC6GDC89962" },
                    { 66, 10, 2, "REU 720", "1CGFUOVFZ0M722538" },
                    { 67, 10, 1, "UMI 285", "OVA6MB5MQGPC94359" },
                    { 68, 10, 5, "TIT 602", "1FE3PAT2T8KW78733" },
                    { 69, 10, 4, "AEE 703", "H9WMD20X0KN893811" },
                    { 70, 10, 1, "MET 529", "GDA2R9QU3YXY90993" },
                    { 71, 11, 4, "TIX 274", "L5OB4JW8FHUV79411" },
                    { 72, 11, 5, "IMO 497", "Y4K4GIMAUTS986998" },
                    { 73, 11, 7, "TAE 666", "MQ2UFGY77QQE84602" },
                    { 74, 11, 2, "OAE 534", "VU7QB6LWWMOJ37686" },
                    { 75, 11, 5, "QIR 351", "LUF7HM3H3KKE64001" },
                    { 76, 11, 7, "IED 917", "5XEJVZSI77XA17555" },
                    { 77, 11, 1, "PIC 569", "EYNL63ZO03KU34004" },
                    { 78, 12, 4, "UME 129", "1YN0D23FA3QB57367" },
                    { 79, 12, 6, "MVR 844", "RBCO4O2OS1N734859" },
                    { 80, 12, 3, "URT 282", "65AZP3OQ1LQY38254" },
                    { 81, 12, 1, "OST 540", "0GVG7LBNQ1N929820" },
                    { 82, 12, 5, "NEH 544", "UCNU4BCMC8O899933" },
                    { 83, 12, 4, "BLR 888", "WB267U3C4UWE64302" },
                    { 84, 12, 1, "GOE 262", "IS4M6HDPQGAH77859" },
                    { 85, 13, 7, "QXD 685", "98YJ3RCMWGUL57396" },
                    { 86, 13, 2, "IIS 863", "F0MMZ9MJG3MM41432" },
                    { 87, 13, 7, "TRE 107", "WAW1EU3H30IX71277" },
                    { 88, 13, 5, "UDM 342", "WNWQZZ5JMUM115671" },
                    { 89, 13, 1, "XOM 335", "FTV5TUWKP5RM70289" },
                    { 90, 13, 7, "CSU 752", "AJDPAGWTTASN78716" },
                    { 91, 13, 4, "UGC 399", "2RNERJN3VSHJ37105" },
                    { 92, 14, 7, "HMU 935", "6F43V1EM7UXN24307" },
                    { 93, 14, 2, "QPQ 987", "XJY7LCCAIZMO84286" },
                    { 94, 14, 1, "ARS 254", "SRV7SRMF6ZH335548" },
                    { 95, 14, 5, "ETV 232", "QG86H5TU4BZU80224" },
                    { 96, 14, 7, "EMI 399", "QCQSSN508LWI49756" },
                    { 97, 14, 6, "EOU 513", "OEQRECKS8REZ54186" },
                    { 98, 14, 7, "NPM 340", "SPZTCZWEPTZ843120" },
                    { 99, 15, 7, "STP 413", "ECFOO44P4LQV41469" },
                    { 100, 15, 6, "DUT 107", "Q2SKKUGSXOAH73721" },
                    { 101, 15, 3, "NUE 566", "DFWLMQI165Z792655" },
                    { 102, 15, 6, "SLI 627", "3GZEOXPS5TZT28161" },
                    { 103, 15, 2, "IMA 849", "DOJRJKJT5WJG85159" },
                    { 104, 15, 3, "MVE 723", "NCL8R7V9A7U556780" },
                    { 105, 15, 7, "MNU 169", "PEJPLASGL7GS55553" }
                });

            migrationBuilder.InsertData(
                table: "CarModelDetails",
                columns: new[] { "Id", "AccelerationInSeconds", "Description", "DoorCount", "HorsePower", "MaxSpeedInKmPerHour", "ProductionEndYear", "ProductionStartYear", "TrunkCapacityLiters", "TrunkCapacitySuitCases" },
                values: new object[,]
                {
                    { 1, 3.2m, "Standard Tesla Model S is an all-electric luxury sedan with impressive range and performance.", (byte)4, (short)670, (short)250, null, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 793, 6 },
                    { 2, 2.1m, "Tesla Model S Plaid is a high-performance electric sedan with 1,020 horsepower, offering incredible acceleration, a top speed of 322 km/h, and a range of up to 600 km. Perfect blend of speed, luxury, and technology.", (byte)4, (short)1020, (short)322, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 793, 6 },
                    { 3, 6.1m, "Tesla Model 3 is an all-electric sedan offering a perfect combination of performance, efficiency, and style. With 283 horsepower, it delivers smooth acceleration, a top speed of 225 km/h, and a range of up to 513 km. Ideal for those looking for a reliable and affordable electric vehicle.", (byte)4, (short)283, (short)225, null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 682, 5 },
                    { 4, 5.2m, "Tesla Model 3 Long Range RWD is an all-electric sedan offering great efficiency, a range of up to 590 km, and smooth acceleration with 283 horsepower. Perfect for long trips with a top speed of 225 km/h.", (byte)4, (short)283, (short)225, null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 682, 5 },
                    { 5, 4.4m, "Tesla Model 3 Long Range AWD is an all-electric sedan offering impressive performance and efficiency. With 346 horsepower, a top speed of 233 km/h, and a range of up to 580 km, it's perfect for those seeking power, range, and versatility.", (byte)4, (short)346, (short)233, null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 682, 5 },
                    { 6, 3.1m, "Tesla Model 3 Performance is an all-electric sedan offering exhilarating performance and efficiency. With 472 horsepower, a top speed of 261 km/h, and a range of up to 530 km, it's perfect for those seeking speed, power, and precision.", (byte)4, (short)472, (short)261, null, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 682, 5 },
                    { 7, 6.9m, "Tesla Model Y is an all-electric SUV offering a blend of performance and efficiency. With 283 horsepower, a top speed of 217 km/h, and a range of up to 530 km, it’s perfect for those seeking space and sustainability.", (byte)4, (short)283, (short)217, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2158, 12 },
                    { 8, 5.9m, "Tesla Model Y Long Range RWD is an all-electric SUV offering excellent efficiency and performance. With 283 horsepower, a top speed of 217 km/h, and a range of up to 530 km, it’s perfect for long trips with ample space.", (byte)4, (short)283, (short)217, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2158, 12 },
                    { 9, 5.0m, "Tesla Model Y Long Range AWD is an all-electric SUV offering a perfect balance of power, efficiency, and space. With 351 horsepower, a top speed of 217 km/h, and a range of up to 505 km, it’s ideal for long trips and all-weather performance.", (byte)4, (short)351, (short)217, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2158, 12 },
                    { 10, 3.7m, "Tesla Model Y Performance is an all-electric SUV delivering exceptional speed and performance. With 456 horsepower, a top speed of 250 km/h, and a range of up to 480 km, it offers thrilling acceleration and dynamic handling.", (byte)4, (short)456, (short)250, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2158, 12 },
                    { 11, 3.9m, "Tesla Model X is an all-electric SUV combining top-tier performance, safety, and cutting-edge technology. With 670 horsepower, a top speed of 250 km/h, and a range of up to 560 km, it offers incredible acceleration, spaciousness, and versatility.", (byte)4, (short)670, (short)250, null, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2614, 14 },
                    { 12, 2.6m, "Tesla Model X Plaid is a high-performance all-electric SUV that redefines speed and capability. With 1020 horsepower, a top speed of 262 km/h, and a range of up to 560 km, it delivers thrilling acceleration, cutting-edge technology, and unparalleled versatility for families and performance enthusiasts alike.", (byte)4, (short)1020, (short)262, null, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2614, 14 },
                    { 13, 6.7m, "Tesla Cybertruck is an all-electric pickup truck that offers exceptional durability, performance, and utility. With 1020 horsepower, a top speed of 180 km/h, and a range of up to 402 km, it’s built to handle any terrain with advanced technology and futuristic design.", (byte)4, (short)315, (short)180, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2830, 16 },
                    { 14, 4.3m, "Tesla Cybertruck is an all-electric pickup truck that offers exceptional durability, performance, and utility. With 1020 horsepower, a top speed of 180 km/h, and a range of up to 402 km, it’s built to handle any terrain with advanced technology and futuristic design.", (byte)4, (short)600, (short)180, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2830, 16 },
                    { 15, 2.7m, "Tesla Cybertruck Cyber-beast is an all-electric pickup with unmatched performance. Equipped with three motors, it delivers extreme acceleration, a top speed of 262 km/h, and a range of up to 502 km, designed for the toughest terrains and ultimate power.", (byte)4, (short)845, (short)209, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2830, 16 }
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
                    { 1, 0, 1, "37dfae4c-bb56-41e0-81a1-20a09eb89a65", new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "HITPOLLPN5", "admin@gmail.com", true, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEDh4YkHMrqHv+MtQoT6PSCwIRrjD48jVkDYSzQI4JVNXtUWSgq6xkjdAI80Rp1gGvw==", null, false, new DateTime(2025, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", false, "admin@gmail.com" },
                    { 2, 0, 12, " 9f0a42ad-8b69-4b33-b42e-87d16f84bfe5", new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KCBAGQ3O9Q", "jan.kowalski@gmail.com", true, false, null, "Jan", "JAN.KOWALSKI@GMAIL.COM", "JAN.KOWALSKI@GMAIL.COM", "AQAAAAIAAYagAAAAECWADmTfcidMdrFUrDTPGRklfy+vw+cgaJP2BMqHppEhRncElDwYYRyCJ1dDsHEYzg==", null, false, new DateTime(2025, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), null, "Kowalski", false, "jan.kowalski@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Palma Airport" },
                    { 2, 2, "Palma City Center" },
                    { 3, 3, "Alcudia" },
                    { 4, 4, "Manacor" }
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
                    { 1, 1, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, 3, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 4, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, 5, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 6, 6, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 7, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, 8, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 9, 9, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 10, 10, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, 11, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, 12, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, 13, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, 14, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, 15, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, 16, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 17, 17, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, 18, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, 19, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, 20, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 21, 21, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, 22, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 23, 23, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 24, 24, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 25, 25, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 26, 26, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 27, 27, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 28, 28, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 29, 29, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 30, 30, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 31, 31, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 32, 32, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 33, 33, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 34, 34, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 35, 35, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 36, 36, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 37, 37, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 38, 38, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 39, 39, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 40, 40, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 41, 41, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 42, 42, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 43, 43, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 44, 44, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 45, 45, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 46, 46, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 47, 47, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 48, 48, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 49, 49, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 50, 50, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 51, 51, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 52, 52, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 53, 53, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 54, 54, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 55, 55, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 56, 56, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 57, 57, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 58, 58, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 59, 59, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 60, 60, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 61, 61, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 62, 62, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 63, 63, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 64, 64, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 65, 65, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 66, 66, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 67, 67, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 68, 68, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 69, 69, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 70, 70, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 71, 71, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 72, 72, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 73, 73, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 74, 74, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 75, 75, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 76, 76, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 77, 77, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 78, 78, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 79, 79, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 80, 80, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 81, 81, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 82, 82, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 83, 83, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 84, 84, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 85, 85, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 86, 86, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 87, 87, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 88, 88, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 89, 89, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 90, 90, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 91, 91, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 92, 92, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 93, 93, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 94, 94, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 95, 95, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 96, 96, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 97, 97, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 98, 98, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 99, 99, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 100, 100, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 101, 101, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 102, 102, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 103, 103, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 104, 104, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 105, 105, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 }
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
                column: "AddressId");

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
                name: "IX_CarModel_BodyTypeId",
                table: "CarModel",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_BrandId",
                table: "CarModel",
                column: "BrandId");

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
                column: "AddressId");

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

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
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
                name: "CarModel_Equipment");

            migrationBuilder.DropTable(
                name: "CarModelDetails");

            migrationBuilder.DropTable(
                name: "Reservation_OptService");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "OptService");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
