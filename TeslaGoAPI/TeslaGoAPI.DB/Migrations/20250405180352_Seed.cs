using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeslaGoAPI.DB.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, 1, null, "31950", "Carretera de l'Aeroport", "63930" },
                    { 2, 1, null, "9610", "Carrer de la Riera", "00197" },
                    { 3, 2, null, "32551", "Cami de Ronda", "84761" },
                    { 4, 3, null, "844", "Via Portugal", "83207-5238" },
                    { 5, 4, (short)137, "1708", "Carrer de la Rosa", "26569" },
                    { 6, 5, (short)187, "4938", "Carrer del Sol", "37770-3680" },
                    { 7, 6, (short)48, "349", "Carrer de la Ciutat", "47933" },
                    { 8, 7, (short)121, "07063", "Carrer de la Lluna", "99930" },
                    { 9, 8, (short)176, "5507", "Carrer del Mar", "91065" },
                    { 10, 9, (short)130, "3495", "Carrer de la Mediterrània", "21937" },
                    { 11, 10, (short)173, "0746", "Carrer de la Palma", "51716-1600" },
                    { 12, 11, (short)194, "20728", "Krakowskie Przedmieście", "62814" },
                    { 13, 12, (short)158, "59989", "Strzelecka", "81313" },
                    { 14, 13, (short)116, "341", "Calle Gran Vía", "89984-9147" },
                    { 15, 14, (short)159, "11672", "Passeig de Gràcia", "31265" },
                    { 16, 15, (short)36, "654", "Berliner Strasse", "46228" },
                    { 17, 16, (short)10, "7238", "Maximilianstrasse", "15330-2871" },
                    { 18, 17, (short)61, "02842", "Rue Monge", "06922" },
                    { 19, 18, (short)29, "0051", "Rue Vauban", "55272-5650" },
                    { 20, 19, (short)105, "990", "Via Torino", "31019" },
                    { 21, 20, (short)59, "70019", "Via Brera", "77965" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "ModelId", "PaintId", "RegistrationNr", "VIN" },
                values: new object[,]
                {
                    { 1, 1, 3, "ENT 638", "M02A7DYHPPKA22243" },
                    { 2, 1, 4, "SRX 392", "61A14DQH3XY580456" },
                    { 3, 1, 1, "AID 143", "IOS32XJQEIV617501" },
                    { 4, 1, 4, "VTT 485", "C13KG45Y9MUY99172" },
                    { 5, 1, 6, "UOT 734", "4CQMMS5V87DV12535" },
                    { 6, 1, 5, "NLL 934", "9YXCN24WPYPR32067" },
                    { 7, 1, 5, "ICA 771", "DWK27FAEMWMH34862" },
                    { 8, 2, 6, "VSA 689", "2BIXICWYDBYJ22323" },
                    { 9, 2, 6, "NOT 468", "P5DGH3NEV3U131351" },
                    { 10, 2, 2, "UEQ 570", "EBW63EBUPOBY74564" },
                    { 11, 2, 1, "DET 452", "15PG2U11DQV944979" },
                    { 12, 2, 5, "ITR 400", "ULB37JBZ7ZOY37175" },
                    { 13, 2, 5, "HNT 722", "K8IYG9P69ETQ35425" },
                    { 14, 2, 3, "DQU 354", "LOZ67DGMHVOW74542" },
                    { 15, 3, 3, "IDN 336", "5MZYJ1VQSUAL68590" },
                    { 16, 3, 4, "ITL 129", "IGWOK8DIABRX83650" },
                    { 17, 3, 4, "ATS 976", "E8S839QHRLYC96729" },
                    { 18, 3, 4, "LIT 781", "HMTAPAR1XSHM69096" },
                    { 19, 3, 5, "UMO 698", "7VZSA8JEHXXU67243" },
                    { 20, 3, 3, "SRX 790", "BHD75LIVIVGH37454" },
                    { 21, 3, 6, "ETA 982", "26S62JZNMBJZ18723" },
                    { 22, 4, 1, "TEN 505", "EVPSNV2CAXV855190" },
                    { 23, 4, 5, "TUB 424", "YDP3GRLTOWDL48105" },
                    { 24, 4, 5, "DEF 422", "OZNJ7KMUS8D359100" },
                    { 25, 4, 7, "ARS 413", "222ACSI518V529426" },
                    { 26, 4, 7, "TOT 479", "ARS04GH38DCH59647" },
                    { 27, 4, 3, "NTN 661", "S3XBKF4ASSRF77461" },
                    { 28, 4, 4, "TEE 374", "S0CIFZAHIKCP70603" },
                    { 29, 5, 2, "RUM 306", "A2W46IGZ3SR257313" },
                    { 30, 5, 2, "XAI 970", "TT74DZAMUCK418605" },
                    { 31, 5, 6, "PIT 177", "Q6VRW64DV6MS88259" },
                    { 32, 5, 7, "EEN 544", "ETHM6ZW3DDF622219" },
                    { 33, 5, 6, "AAN 651", "F6TVOBU7YSMA33492" },
                    { 34, 5, 6, "EMQ 448", "UWG2ZDDAUZTZ99822" },
                    { 35, 5, 4, "IET 750", "WVWS5RISBGYE60326" },
                    { 36, 6, 6, "TET 243", "ZKLQP188C0X357970" },
                    { 37, 6, 5, "QOM 748", "70693W3HL7RA68590" },
                    { 38, 6, 1, "TTE 874", "66BSHPUOAIFG34155" },
                    { 39, 6, 3, "IUE 423", "U3ZIOXPGJFWH66852" },
                    { 40, 6, 5, "QUU 754", "4XJGLOPKDTB720165" },
                    { 41, 6, 6, "QEE 697", "CLEYZU181UJS99850" },
                    { 42, 6, 3, "USR 372", "ZP1ILV8403NJ18344" },
                    { 43, 7, 1, "CDD 588", "ELOUAHPWZHID37202" },
                    { 44, 7, 3, "UQR 964", "BVAS6L48B3XP85585" },
                    { 45, 7, 7, "NEL 268", "VNSOAQFIKICW35026" },
                    { 46, 7, 5, "RQS 578", "LGP9K9MH4RXC51497" },
                    { 47, 7, 1, "HTT 190", "XJ8GRRF9WVAG12072" },
                    { 48, 7, 3, "EIM 666", "3SRLZ2D882YP25439" },
                    { 49, 7, 2, "MPO 476", "ZZNYHQ10EDGL95127" },
                    { 50, 8, 6, "MAO 275", "Q4HVF7CR09LZ90134" },
                    { 51, 8, 1, "MEA 912", "BD019NXF4BYC82243" },
                    { 52, 8, 1, "TCS 868", "2BQTJVJYZQJR58580" },
                    { 53, 8, 1, "ISE 937", "PCNW78MEP2AH54190" },
                    { 54, 8, 3, "QFU 363", "KI8MCBKZ4TDX23844" },
                    { 55, 8, 6, "TPA 602", "FNJ4M8EAPGWN60862" },
                    { 56, 8, 3, "QCL 223", "XU2TRKJ8H0SS16234" },
                    { 57, 9, 3, "LTM 404", "AO5KZ5ZOA4L533059" },
                    { 58, 9, 4, "EST 821", "MR2HCN9MGQQQ98824" },
                    { 59, 9, 6, "ART 728", "UJQX9GROHFRG35364" },
                    { 60, 9, 6, "GEM 410", "HOPWIWWAY7YE59803" },
                    { 61, 9, 2, "SFI 207", "ST757IO7LERF80248" },
                    { 62, 9, 3, "UAH 268", "YVZ2DJ70WZA723301" },
                    { 63, 9, 1, "TIU 849", "1HACPPPXTUY921047" },
                    { 64, 10, 5, "AEU 417", "0R5QEF3U88QN87766" },
                    { 65, 10, 5, "ICI 644", "G9GPNGDT8YD555572" },
                    { 66, 10, 6, "SUQ 414", "812V6MAMQPFX59217" },
                    { 67, 10, 3, "MVS 651", "YH6LRZNJV0RK34714" },
                    { 68, 10, 3, "TSU 266", "I97TQXM5LLO179741" },
                    { 69, 10, 2, "ANP 579", "TQMLOJUP69X231212" },
                    { 70, 10, 3, "TLQ 538", "V5ZZ2SO8JAXE77576" },
                    { 71, 11, 3, "ENR 980", "R79F7YMEWBYY38678" },
                    { 72, 11, 1, "RLA 653", "BVQMLB2O71XX42028" },
                    { 73, 11, 6, "UPV 485", "KZ1HJ5DAGEG542781" },
                    { 74, 11, 3, "OUA 994", "6MSD2TDJWND695619" },
                    { 75, 11, 2, "NAM 589", "RISLTKCURVYR30518" },
                    { 76, 11, 6, "IUP 129", "W3CKZX7UZ2F933679" },
                    { 77, 11, 5, "SUM 716", "DRXT5OEF3WIZ96287" },
                    { 78, 12, 6, "SLL 567", "ER5EU0VLH5R358687" },
                    { 79, 12, 4, "AEF 473", "FL1X7ZXU5XO331539" },
                    { 80, 12, 3, "TTS 680", "A7TOGFM5VKPE87901" },
                    { 81, 12, 7, "MPM 626", "Y4FCQ1QQZTOJ71072" },
                    { 82, 12, 7, "TAA 646", "QHE3SN045NZA10955" },
                    { 83, 12, 1, "IDS 395", "THJ3TP5WRWBN20175" },
                    { 84, 12, 7, "TTS 196", "XG8YWEH69LUH27243" },
                    { 85, 13, 5, "IEU 645", "AX5HT0A8LYUS24902" },
                    { 86, 13, 2, "TUE 146", "MTTSDJFJ09XW48805" },
                    { 87, 13, 2, "ILA 497", "GK19MECHJXRK95364" },
                    { 88, 13, 3, "SSO 102", "VZFCN4FDEFWV97827" },
                    { 89, 13, 6, "DTL 860", "LAP3WPY5L7QR95781" },
                    { 90, 13, 4, "OUC 217", "WWRYJJ43AOH295180" },
                    { 91, 13, 4, "NCA 583", "DBT1T3H38RGT73748" },
                    { 92, 14, 4, "MNM 765", "GKRQSR3RBMMA21020" },
                    { 93, 14, 2, "OSD 232", "3OE06P8854OF95838" },
                    { 94, 14, 6, "OUA 552", "LNW7ZJUC3EU872084" },
                    { 95, 14, 1, "NIO 701", "GVBU2BTLZLHC49106" },
                    { 96, 14, 7, "UEF 982", "QBIHACFS3BOE62070" },
                    { 97, 14, 5, "CIV 141", "C39YDJA210MR97714" },
                    { 98, 14, 2, "IMT 676", "3ASRA2E2VAHN24707" },
                    { 99, 15, 5, "IBA 404", "71A2RJVIQELO49102" },
                    { 100, 15, 7, "ISL 361", "8R08PVIVIDYA54494" },
                    { 101, 15, 2, "OEI 477", "7G3AZ5TUZJJD28471" },
                    { 102, 15, 1, "TQA 784", "4V3BBHXLM9FF72238" },
                    { 103, 15, 3, "LTC 227", "44OFYM1N8AAY96643" },
                    { 104, 15, 2, "MEU 890", "SJIHJVOY00LA43822" },
                    { 105, 15, 3, "ION 730", "AU7I1S1WC2L220124" }
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
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DateOfBirth", "DrivingLicenseNumber", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisteredDate", "RoleId", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, 1, "37dfae4c-bb56-41e0-81a1-20a09eb89a65", new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "RW651KRQY4", "admin@gmail.com", true, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEB/8KnjLpPvVAPm782QcWIQRtjnGlMe5kQfKASPhen/oLX6wlI2I3+I7wyL7mB8+JQ==", null, false, new DateTime(2025, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Admin", false, "admin@gmail.com" },
                    { 2, 0, 12, " 9f0a42ad-8b69-4b33-b42e-87d16f84bfe5", new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "32AQRB133W", "jan.kowalski@gmail.com", true, false, null, "Jan", "JAN.KOWALSKI@GMAIL.COM", "JAN.KOWALSKI@GMAIL.COM", "AQAAAAIAAYagAAAAENuLV/t8Ba+BuJlBLSQy5VPoPojLVfAoIDO+v+1fXBKpM37GUoxuMT4Qv7YEUzv7RA==", null, false, new DateTime(2025, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Kowalski", false, "jan.kowalski@gmail.com" }
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
                    { 1, 1, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, 2, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 4, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, 5, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 6, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 7, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, 8, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 9, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, 10, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 11, 11, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, 12, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 13, 13, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 14, 14, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, 15, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, 16, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, 17, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, 18, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, 19, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, 20, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, 21, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 22, 22, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 23, 23, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 24, 24, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 25, 25, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, 26, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 27, 27, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 28, 28, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 29, 29, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 30, 30, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 31, 31, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 32, 32, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 33, 33, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 34, 34, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 35, 35, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 36, 36, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 37, 37, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 38, 38, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 39, 39, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 40, 40, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 41, 41, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 42, 42, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 43, 43, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 44, 44, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 45, 45, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 46, 46, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 47, 47, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 48, 48, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 49, 49, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 50, 50, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 51, 51, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 52, 52, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 53, 53, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 54, 54, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 55, 55, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 56, 56, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 57, 57, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 58, 58, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 59, 59, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 60, 60, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 61, 61, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 62, 62, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 63, 63, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 64, 64, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 65, 65, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 66, 66, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 67, 67, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 68, 68, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 69, 69, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 70, 70, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 71, 71, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 72, 72, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 73, 73, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 74, 74, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 75, 75, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 76, 76, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 77, 77, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 78, 78, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 79, 79, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 80, 80, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 81, 81, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 82, 82, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 83, 83, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 84, 84, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 85, 85, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 86, 86, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 87, 87, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 88, 88, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 89, 89, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 90, 90, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 91, 91, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 92, 92, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 93, 93, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 94, 94, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 95, 95, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 96, 96, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 97, 97, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 98, 98, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 99, 99, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 100, 100, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 101, 101, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 102, 102, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 103, 103, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 104, 104, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 105, 105, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BodyType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarModelDetails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 10, 11 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 11, 9 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 12, 11 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 13, 9 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 14, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 14, 9 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 15, 4 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 15, 6 });

            migrationBuilder.DeleteData(
                table: "CarModel_Equipment",
                keyColumns: new[] { "CarModelId", "EquipmentId" },
                keyValues: new object[] { 15, 11 });

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Car_Location",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OptService",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OptService",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OptService",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OptService",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarModel",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Paint",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paint",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paint",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Paint",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Paint",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Paint",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Paint",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BodyType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BodyType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BodyType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DriveType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DriveType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GearBox",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ModelVersion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ModelVersion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ModelVersion",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ModelVersion",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ModelVersion",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
