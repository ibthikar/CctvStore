namespace CctvStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newserver : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoriesId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UrlImageAccessory = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessoriesId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        ProductName = c.String(),
                        Description = c.String(),
                        UrlProductImage = c.String(),
                        SubCategoryId = c.Int(),
                        CategoryId = c.Int(),
                        CatalogId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId)
                .ForeignKey("dbo.Catalogs", t => t.CatalogId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.SubCategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.CatalogId);
            
            CreateTable(
                "dbo.Catalogs",
                c => new
                    {
                        CatalogId = c.Int(nullable: false, identity: true),
                        CatalogName = c.String(),
                    })
                .PrimaryKey(t => t.CatalogId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CatalogId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Catalogs", t => t.CatalogId)
                .Index(t => t.CatalogId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductDownloads",
                c => new
                    {
                        ProductDownloadId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileUrl = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductDownloadId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Downloads",
                c => new
                    {
                        DownloadId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Version = c.String(),
                        Introduction = c.String(),
                        FeaturesfromSDK = c.String(),
                        DownloadUrl = c.String(),
                    })
                .PrimaryKey(t => t.DownloadId);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        FAQId = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FAQId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SpAudios",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        AudioCompression = c.String(),
                        TwoWayAudio = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.Specifications",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.SpCameras",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        ImageSensor = c.String(),
                        MinIllumination = c.String(),
                        DayNight = c.String(),
                        ShutterSpeed = c.String(),
                        AutoIris = c.String(),
                        WideDynamicRange = c.String(),
                        DigitalNoiseReduction = c.String(),
                        Lens = c.String(),
                        FOV = c.String(),
                        IRLED = c.String(),
                        IRRange = c.String(),
                        SN = c.String(),
                        SignalSystem = c.String(),
                        DetecterType = c.String(),
                        ArrayFormal = c.String(),
                        PixelPitch = c.String(),
                        Sensitivity = c.String(),
                        SpecteralRange = c.String(),
                        TemperatureDetection = c.String(),
                        Focus = c.String(),
                        DetectDistanceVehicle = c.String(),
                        DetectDistanceHumen = c.String(),
                        RecognizeDistance = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.SpGenerals",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        PowerSupply = c.String(),
                        PowerConsumption = c.String(),
                        OperatureTemperature = c.String(),
                        IngressProtection = c.String(),
                        Approvals = c.String(),
                        ProductDimensions = c.String(),
                        ProductWeight = c.String(),
                        Materials = c.String(),
                        Size = c.String(),
                        Chasis = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.SpHardDisks",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        SATAHDD = c.String(),
                        MountingMode = c.String(),
                        Cpacity = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.SpImages",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        EffectiveResolution = c.String(),
                        WhiteBalance = c.String(),
                        Gain = c.String(),
                        LightCompensation = c.String(),
                        DigitalZoom = c.String(),
                        MotionDetection = c.String(),
                        PrivateMask = c.String(),
                        OSDLanguage = c.String(),
                        Defog = c.String(),
                        DigitalImageStable = c.String(),
                        UTC = c.String(),
                        VideoCompression = c.String(),
                        BitRate = c.String(),
                        AudioCompression = c.String(),
                        MaxResolution = c.String(),
                        Stream = c.String(),
                        ImageSetting = c.String(),
                        DeWrapping = c.String(),
                        HLC = c.String(),
                        CorridorMode = c.String(),
                        ROI = c.String(),
                        EffectivePixel = c.String(),
                        DVEImageEnhance = c.String(),
                        ImageColorMode = c.String(),
                        NoiseReduce = c.String(),
                        ImageCorrection = c.String(),
                        ImageOverturn = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.SpInterfaces",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        Ethernet = c.String(),
                        AudioIO = c.String(),
                        AlarmIO = c.String(),
                        RS485 = c.String(),
                        BNCOutput = c.String(),
                        ResetButton = c.String(),
                        EdgeStorage = c.String(),
                        Output = c.String(),
                        PTZControl = c.String(),
                        Network = c.String(),
                        USB = c.String(),
                        HDMIVGA = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.SpNetworks",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        NetworkProtocols = c.String(),
                        AlarmTrigger = c.String(),
                        RTSPVideo = c.String(),
                        Security = c.String(),
                        WebLanguage = c.String(),
                        SystemCompatibility = c.String(),
                        NetworkInterface = c.String(),
                        POEInterface = c.String(),
                        POEMaxPower = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.SpRecordPlaybacks",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        HardDrive = c.String(),
                        Record = c.String(),
                        PlayBack = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.SpVideos",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        VideoCompression = c.String(),
                        EncodeAbility = c.String(),
                        DecodeAbility = c.String(),
                        VideoInput = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.SpVideoAudioInputs",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        VideoInput = c.String(),
                        IncomingBandwidth = c.String(),
                        OutgoingChannel = c.String(),
                        AudioInput = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.SpVideoAudioOutputs",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false),
                        RecordingResolution = c.String(),
                        FrameRate = c.String(),
                        LiveviewPlaybackResolution = c.String(),
                        LiveviewPlaybackCapacity = c.String(),
                        HDMIVGA = c.String(),
                        AudioOutput = c.String(),
                    })
                .PrimaryKey(t => t.SpecificationId)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.SuccessStories",
                c => new
                    {
                        SuccessStoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Stories = c.Int(nullable: false),
                        SuccessStoryUrl = c.String(),
                    })
                .PrimaryKey(t => t.SuccessStoryId);
            
            CreateTable(
                "dbo.Supports",
                c => new
                    {
                        DownloadId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FileType = c.Int(nullable: false),
                        Description = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                        DownloadUrl = c.String(),
                    })
                .PrimaryKey(t => t.DownloadId);
            
            CreateTable(
                "dbo.TroubleShootings",
                c => new
                    {
                        TroubleShootingId = c.Int(nullable: false, identity: true),
                        ErrorTitle = c.String(maxLength: 50),
                        ErrorDescription = c.String(),
                        ErrorUrl = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TroubleShootingId);
            
            CreateTable(
                "dbo.Uploads",
                c => new
                    {
                        UploadId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.UploadId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SpAudios", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.SpVideoAudioOutputs", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.SpVideoAudioInputs", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.SpVideos", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.SpRecordPlaybacks", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.SpNetworks", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.SpInterfaces", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.SpImages", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.SpHardDisks", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.SpGenerals", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.SpCameras", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.Specifications", "ProductId", "dbo.Products");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductDownloads", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "CatalogId", "dbo.Catalogs");
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "CatalogId", "dbo.Catalogs");
            DropForeignKey("dbo.Accessories", "ProductId", "dbo.Products");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SpVideoAudioOutputs", new[] { "SpecificationId" });
            DropIndex("dbo.SpVideoAudioInputs", new[] { "SpecificationId" });
            DropIndex("dbo.SpVideos", new[] { "SpecificationId" });
            DropIndex("dbo.SpRecordPlaybacks", new[] { "SpecificationId" });
            DropIndex("dbo.SpNetworks", new[] { "SpecificationId" });
            DropIndex("dbo.SpInterfaces", new[] { "SpecificationId" });
            DropIndex("dbo.SpImages", new[] { "SpecificationId" });
            DropIndex("dbo.SpHardDisks", new[] { "SpecificationId" });
            DropIndex("dbo.SpGenerals", new[] { "SpecificationId" });
            DropIndex("dbo.SpCameras", new[] { "SpecificationId" });
            DropIndex("dbo.Specifications", new[] { "ProductId" });
            DropIndex("dbo.SpAudios", new[] { "SpecificationId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductDownloads", new[] { "ProductId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "CatalogId" });
            DropIndex("dbo.Products", new[] { "CatalogId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.Accessories", new[] { "ProductId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Uploads");
            DropTable("dbo.TroubleShootings");
            DropTable("dbo.Supports");
            DropTable("dbo.SuccessStories");
            DropTable("dbo.SpVideoAudioOutputs");
            DropTable("dbo.SpVideoAudioInputs");
            DropTable("dbo.SpVideos");
            DropTable("dbo.SpRecordPlaybacks");
            DropTable("dbo.SpNetworks");
            DropTable("dbo.SpInterfaces");
            DropTable("dbo.SpImages");
            DropTable("dbo.SpHardDisks");
            DropTable("dbo.SpGenerals");
            DropTable("dbo.SpCameras");
            DropTable("dbo.Specifications");
            DropTable("dbo.SpAudios");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FAQs");
            DropTable("dbo.Downloads");
            DropTable("dbo.ProductDownloads");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Catalogs");
            DropTable("dbo.Products");
            DropTable("dbo.Accessories");
        }
    }
}
