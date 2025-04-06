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
                    { 1, 1, null, "3978", "Carretera de l'Aeroport", "68886-8887" },
                    { 2, 1, null, "6551", "Carrer de la Riera", "15482-6296" },
                    { 3, 2, null, "92367", "Cami de Ronda", "48958" },
                    { 4, 3, null, "1076", "Via Portugal", "85287" },
                    { 5, 4, (short)165, "3146", "Carrer de la Rosa", "87007" },
                    { 6, 5, (short)101, "740", "Carrer del Sol", "39212" },
                    { 7, 6, (short)125, "67275", "Carrer de la Ciutat", "66188" },
                    { 8, 7, (short)190, "286", "Carrer de la Lluna", "21532" },
                    { 9, 8, (short)9, "85051", "Carrer del Mar", "07414-9532" },
                    { 10, 9, (short)173, "426", "Carrer de la Mediterrània", "71416" },
                    { 11, 10, (short)41, "4997", "Carrer de la Palma", "50398-2264" },
                    { 12, 11, (short)13, "259", "Krakowskie Przedmieście", "18022" },
                    { 13, 12, (short)20, "542", "Strzelecka", "40768" },
                    { 14, 13, (short)49, "588", "Calle Gran Vía", "77083" },
                    { 15, 14, (short)151, "4630", "Passeig de Gràcia", "82184-6309" },
                    { 16, 15, (short)197, "96471", "Berliner Strasse", "67889-7479" },
                    { 17, 16, (short)24, "8776", "Maximilianstrasse", "39403" },
                    { 18, 17, (short)190, "905", "Rue Monge", "07709-6248" },
                    { 19, 18, (short)180, "604", "Rue Vauban", "81475" },
                    { 20, 19, (short)68, "0860", "Via Torino", "38069-2986" },
                    { 21, 20, (short)113, "58303", "Via Brera", "14771" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "ModelId", "PaintId", "RegistrationNr", "VIN" },
                values: new object[,]
                {
                    { 1, 1, 3, "IUT 485", "VFHLLGKJO7ZR35439" },
                    { 2, 1, 3, "TUG 382", "Z3DECGD4OXKM53555" },
                    { 3, 1, 7, "COS 106", "V8036NBWSLFO65723" },
                    { 4, 1, 5, "AIS 281", "USP0N1RFE2XF90571" },
                    { 5, 1, 4, "ACS 515", "J6CR72BGUQO013268" },
                    { 6, 1, 5, "OIS 693", "URLI3G2FHTJE97163" },
                    { 7, 1, 5, "TIT 711", "YA8YPCB3HMVU71252" },
                    { 8, 2, 2, "AUU 214", "6BQSWRSKZ1SK71033" },
                    { 9, 2, 1, "THE 473", "KBGY7A643MHT19800" },
                    { 10, 2, 1, "QQN 674", "GAI99GY0KDY751165" },
                    { 11, 2, 3, "IMD 400", "WTK4N72GIGFE84132" },
                    { 12, 2, 6, "VIE 200", "MXK1P0VZ8RMD13552" },
                    { 13, 2, 4, "NIE 263", "RKDDXI410ZEV38503" },
                    { 14, 2, 7, "TMA 546", "XPQQC1IIJEOG29573" },
                    { 15, 3, 3, "ANL 685", "BPXKO2SD92LE32682" },
                    { 16, 3, 7, "IUM 215", "JHDY15KWGRIU33218" },
                    { 17, 3, 6, "MEV 712", "80THY992EYJ821239" },
                    { 18, 3, 2, "USL 900", "DVXAYY9B3IQR44623" },
                    { 19, 3, 5, "AEO 663", "EAEUBNBYSLYN71443" },
                    { 20, 3, 4, "OAL 901", "KHO7U3BIEBLA74254" },
                    { 21, 3, 6, "QMD 364", "CZ77LMRX23V498887" },
                    { 22, 4, 2, "ELA 983", "T4HT2DOWREFV59184" },
                    { 23, 4, 7, "OEA 169", "ED9BD3K4ZSUB38819" },
                    { 24, 4, 2, "MTE 584", "N8AJIDABEDIT23938" },
                    { 25, 4, 5, "PMT 978", "6L60QV19A9S727908" },
                    { 26, 4, 1, "IFD 240", "7LN38N40WQMO88357" },
                    { 27, 4, 4, "SEV 535", "Z9E1Q7XH80TT39176" },
                    { 28, 4, 3, "ATM 891", "LBRDCY5S5RNF30187" },
                    { 29, 5, 1, "TAT 283", "XKW1UTQX4WC414604" },
                    { 30, 5, 2, "UDN 102", "T962V1SC0OHO50541" },
                    { 31, 5, 7, "SAU 304", "7Z704JZYP8EV26998" },
                    { 32, 5, 7, "NAI 367", "DV1BKWO3SVY167692" },
                    { 33, 5, 5, "QAM 981", "CPNCYRNWERKY30499" },
                    { 34, 5, 1, "DIT 374", "CDSXDTESTOHI12011" },
                    { 35, 5, 1, "QAO 970", "G6K0PC4D3ZTM43657" },
                    { 36, 6, 2, "LIA 239", "A2B71SKQYNEM63159" },
                    { 37, 6, 4, "ECT 125", "4ZFMZ8LCSRGJ39096" },
                    { 38, 6, 1, "IEP 618", "3B0KAVWOH0X830375" },
                    { 39, 6, 3, "SSS 811", "QHK824H7SMRJ35893" },
                    { 40, 6, 5, "AAE 256", "TBX5LXP8J3NJ16993" },
                    { 41, 6, 6, "EUA 288", "JGG0ATYUFKZN31896" },
                    { 42, 6, 2, "LST 895", "9NOFXMTGENPS68633" },
                    { 43, 7, 5, "UXU 243", "59X2LSBCZ6HJ32503" },
                    { 44, 7, 2, "NSS 492", "BK3L6Y7KJXHM42356" },
                    { 45, 7, 6, "AIA 868", "YKZWLL608HEV46925" },
                    { 46, 7, 3, "IOE 814", "LXIGJ3PJ5JWO82000" },
                    { 47, 7, 1, "ESL 969", "IY13Q3GJFTIN65914" },
                    { 48, 7, 1, "QUR 327", "AWG34V11WDTU69511" },
                    { 49, 7, 4, "OTM 159", "LEVDJDDDVHOX74661" },
                    { 50, 8, 2, "ILN 377", "5ACRHFNYEUNR69886" },
                    { 51, 8, 6, "OVC 534", "LGKVKAKXJVJS73244" },
                    { 52, 8, 4, "PTE 915", "RSP1L4K4CLAA17311" },
                    { 53, 8, 7, "TEE 953", "ET8A3VYP9NK111166" },
                    { 54, 8, 6, "IIN 159", "D4O8QQ5209N084674" },
                    { 55, 8, 1, "SIS 545", "9GAYDZQYE8YY34991" },
                    { 56, 8, 3, "ETT 871", "GU8WYP7VPFU215156" },
                    { 57, 9, 4, "LUI 422", "NT7KUZAQWFYN53426" },
                    { 58, 9, 2, "REI 560", "FLVO10Y9RPYI51196" },
                    { 59, 9, 4, "SNR 196", "9U2DCR2XJ4XU76376" },
                    { 60, 9, 6, "BTE 262", "3Z83L1H2RKVC99379" },
                    { 61, 9, 1, "EQN 398", "2J7TGFHSDCCN82594" },
                    { 62, 9, 6, "IRT 429", "2ZQM2YEFTCSC85016" },
                    { 63, 9, 6, "LAR 175", "HIW9ENU2LPBM24990" },
                    { 64, 10, 4, "NOE 397", "2NDZB32HZ3NB40448" },
                    { 65, 10, 2, "NEI 794", "ZHI0F5EPIEUT92291" },
                    { 66, 10, 5, "OUU 499", "PYP8R26091VN63428" },
                    { 67, 10, 7, "EME 588", "TOUTXLFEFGND14602" },
                    { 68, 10, 1, "IIA 843", "CUB2BTCV8EJQ86571" },
                    { 69, 10, 3, "IDC 821", "PRZ1PX662JPT66068" },
                    { 70, 10, 5, "LAT 198", "YBT8568Q54EO12910" },
                    { 71, 11, 3, "EAT 668", "CIRLZ1VCZIT179757" },
                    { 72, 11, 1, "DSE 893", "7MM649FMKMP825121" },
                    { 73, 11, 7, "UQU 669", "50F91682OCEC84906" },
                    { 74, 11, 6, "TSU 809", "JFAJEJ5J1QJQ54153" },
                    { 75, 11, 1, "LIX 421", "DTJIE9NTGARI92373" },
                    { 76, 11, 6, "EOE 936", "JPH05UOE7UZT42789" },
                    { 77, 11, 5, "IIQ 702", "KAJQEWHUKISX58902" },
                    { 78, 12, 1, "NRU 666", "HF4PHG1OWRNH41056" },
                    { 79, 12, 2, "UEE 208", "J5HIZTWKJ1FG93408" },
                    { 80, 12, 2, "UEU 956", "BL7WU1J8CMF629728" },
                    { 81, 12, 4, "QMO 245", "HYBN5ME9I4YM11493" },
                    { 82, 12, 4, "SNU 589", "PJASRQZGDTUH15150" },
                    { 83, 12, 3, "HTP 623", "HCENDO211AA889665" },
                    { 84, 12, 2, "UTS 985", "RT2Y3RX5T1EW48908" },
                    { 85, 13, 5, "LDS 739", "MVERY73LPND874709" },
                    { 86, 13, 6, "LET 375", "N38NRANBPADZ55739" },
                    { 87, 13, 7, "IUS 798", "X07Y9VF5PYME26515" },
                    { 88, 13, 3, "AOA 143", "6UUBM0CPM9TL45736" },
                    { 89, 13, 1, "IAI 454", "GCP3Y38FQ4X517904" },
                    { 90, 13, 2, "EPA 455", "SK3C2KX4IOHF75774" },
                    { 91, 13, 4, "EQA 771", "3172NTPX57QX28768" },
                    { 92, 14, 6, "TET 291", "DSGYVKIC8APT95880" },
                    { 93, 14, 5, "EIR 538", "SX65R60VK3IP59256" },
                    { 94, 14, 4, "SAO 861", "YGTHOG6W5FWR34971" },
                    { 95, 14, 6, "EGA 876", "AND62QFE90Y496450" },
                    { 96, 14, 4, "RPS 689", "RVZ6QSB7OVQ669328" },
                    { 97, 14, 5, "SER 848", "0NNQ6B2KOUA177781" },
                    { 98, 14, 3, "TQO 981", "MTOONK2OTHIU25094" },
                    { 99, 15, 5, "URQ 432", "9L8MVHPUITER38007" },
                    { 100, 15, 4, "CSE 160", "4NCRVPOR2PO052927" },
                    { 101, 15, 1, "RTD 485", "XRMX42GO6ROZ22222" },
                    { 102, 15, 1, "EUL 923", "Z7OO59AC84GT72754" },
                    { 103, 15, 4, "EHS 203", "T7BX9PSZXAVX34943" },
                    { 104, 15, 4, "TFM 736", "Z5QF36873EQJ35233" },
                    { 105, 15, 7, "NIU 769", "GUPR9LDL3ZEF20143" }
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
                    { 1, 0, 1, "37dfae4c-bb56-41e0-81a1-20a09eb89a65", new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "PSP5XIXASM", "admin@gmail.com", true, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEF4bTtKXvpaTR8fY/zJeRjhqZqhhVMDLJr+1QDptL8a91tZT5czZvsm0t1rrVzyVXg==", null, false, new DateTime(2025, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", false, "admin@gmail.com" },
                    { 2, 0, 12, " 9f0a42ad-8b69-4b33-b42e-87d16f84bfe5", new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8XGMA763KJ", "jan.kowalski@gmail.com", true, false, null, "Jan", "JAN.KOWALSKI@GMAIL.COM", "JAN.KOWALSKI@GMAIL.COM", "AQAAAAIAAYagAAAAELFzaRAygUpkvSbqjJBI5C01II2gm6RwAkbkajsbdOF6XRfkRw+honGPUcwMKLV62A==", null, false, new DateTime(2025, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), null, "Kowalski", false, "jan.kowalski@gmail.com" }
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
                    { 2, 2, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 4, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 5, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 6, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 7, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, 8, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 9, 9, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, 10, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, 11, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 12, 12, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, 13, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 14, 14, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, 15, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, 16, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 17, 17, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, 18, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, 19, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, 20, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 21, 21, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 22, 22, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 23, 23, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 24, 24, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 25, 25, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, 26, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 27, 27, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 28, 28, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 29, 29, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 30, 30, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 31, 31, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 32, 32, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 33, 33, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 34, 34, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 35, 35, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 36, 36, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 37, 37, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 38, 38, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 39, 39, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 40, 40, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 41, 41, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 42, 42, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 43, 43, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 44, 44, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 45, 45, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 46, 46, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 47, 47, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 48, 48, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 49, 49, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 50, 50, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 51, 51, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 52, 52, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 53, 53, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 54, 54, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 55, 55, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 56, 56, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 57, 57, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 58, 58, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 59, 59, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 60, 60, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 61, 61, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 62, 62, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 63, 63, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 64, 64, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 65, 65, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 66, 66, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 67, 67, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 68, 68, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 69, 69, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 70, 70, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 71, 71, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 72, 72, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 73, 73, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 74, 74, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 75, 75, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 76, 76, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 77, 77, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 78, 78, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 79, 79, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 80, 80, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 81, 81, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 82, 82, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 83, 83, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 84, 84, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 85, 85, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 86, 86, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 87, 87, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 88, 88, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 89, 89, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 90, 90, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 91, 91, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 92, 92, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 93, 93, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 94, 94, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 95, 95, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 96, 96, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 97, 97, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 98, 98, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 99, 99, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 100, 100, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 101, 101, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 102, 102, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 103, 103, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 104, 104, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
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
