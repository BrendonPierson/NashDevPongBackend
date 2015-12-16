namespace PingPong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoublesMatches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        MatchDate = c.DateTime(nullable: false),
                        TeamOneScore = c.Int(nullable: false),
                        TeamTwoScore = c.Int(nullable: false),
                        TeamOneElo = c.Int(nullable: false),
                        TeamTwoElo = c.Int(nullable: false),
                        TeamOne_TeamId = c.Int(nullable: false),
                        TeamTwo_TeamId = c.Int(nullable: false),
                        DoublesTournament_TournamentId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.DoublesTeams", t => t.TeamOne_TeamId, cascadeDelete: true)
                .ForeignKey("dbo.DoublesTeams", t => t.TeamTwo_TeamId, cascadeDelete: true)
                .ForeignKey("dbo.DoublesTournaments", t => t.DoublesTournament_TournamentId)
                .Index(t => t.TeamOne_TeamId)
                .Index(t => t.TeamTwo_TeamId)
                .Index(t => t.DoublesTournament_TournamentId);
            
            CreateTable(
                "dbo.DoublesTeams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false, maxLength: 30),
                        EloRating = c.Int(nullable: false),
                        Player_PlayerId = c.Int(),
                        DoublesTournament_TournamentId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Players", t => t.Player_PlayerId)
                .ForeignKey("dbo.DoublesTournaments", t => t.DoublesTournament_TournamentId)
                .Index(t => t.Player_PlayerId)
                .Index(t => t.DoublesTournament_TournamentId);
            
            CreateTable(
                "dbo.SinglesMatches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        MatchDate = c.DateTime(nullable: false),
                        PlayerOneScore = c.Int(nullable: false),
                        PlayerTwoScore = c.Int(nullable: false),
                        PlayerOneElo = c.Int(nullable: false),
                        PlayerTwoElo = c.Int(nullable: false),
                        Player_PlayerId = c.Int(),
                        Player_PlayerId1 = c.Int(),
                        PlayerOne_PlayerId = c.Int(nullable: false),
                        PlayerTwo_PlayerId = c.Int(nullable: false),
                        DoublesTeam_TeamId = c.Int(),
                        SinglesTournament_TournamentId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Players", t => t.Player_PlayerId)
                .ForeignKey("dbo.Players", t => t.Player_PlayerId1)
                .ForeignKey("dbo.Players", t => t.PlayerOne_PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerTwo_PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.DoublesTeams", t => t.DoublesTeam_TeamId)
                .ForeignKey("dbo.SinglesTournaments", t => t.SinglesTournament_TournamentId)
                .Index(t => t.Player_PlayerId)
                .Index(t => t.Player_PlayerId1)
                .Index(t => t.PlayerOne_PlayerId)
                .Index(t => t.PlayerTwo_PlayerId)
                .Index(t => t.DoublesTeam_TeamId)
                .Index(t => t.SinglesTournament_TournamentId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 64),
                        LastName = c.String(maxLength: 64),
                        Handle = c.String(nullable: false, maxLength: 20),
                        EloRating = c.Int(nullable: false),
                        SinglesTournament_TournamentId = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.SinglesTournaments", t => t.SinglesTournament_TournamentId)
                .Index(t => t.SinglesTournament_TournamentId);
            
            CreateTable(
                "dbo.DoublesTournaments",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        TournamentName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TournamentId);
            
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
                "dbo.SinglesTournaments",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        TournamentName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TournamentId);
            
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
            DropForeignKey("dbo.SinglesMatches", "SinglesTournament_TournamentId", "dbo.SinglesTournaments");
            DropForeignKey("dbo.Players", "SinglesTournament_TournamentId", "dbo.SinglesTournaments");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DoublesTeams", "DoublesTournament_TournamentId", "dbo.DoublesTournaments");
            DropForeignKey("dbo.DoublesMatches", "DoublesTournament_TournamentId", "dbo.DoublesTournaments");
            DropForeignKey("dbo.DoublesMatches", "TeamTwo_TeamId", "dbo.DoublesTeams");
            DropForeignKey("dbo.DoublesMatches", "TeamOne_TeamId", "dbo.DoublesTeams");
            DropForeignKey("dbo.SinglesMatches", "DoublesTeam_TeamId", "dbo.DoublesTeams");
            DropForeignKey("dbo.SinglesMatches", "PlayerTwo_PlayerId", "dbo.Players");
            DropForeignKey("dbo.SinglesMatches", "PlayerOne_PlayerId", "dbo.Players");
            DropForeignKey("dbo.DoublesTeams", "Player_PlayerId", "dbo.Players");
            DropForeignKey("dbo.SinglesMatches", "Player_PlayerId1", "dbo.Players");
            DropForeignKey("dbo.SinglesMatches", "Player_PlayerId", "dbo.Players");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Players", new[] { "SinglesTournament_TournamentId" });
            DropIndex("dbo.SinglesMatches", new[] { "SinglesTournament_TournamentId" });
            DropIndex("dbo.SinglesMatches", new[] { "DoublesTeam_TeamId" });
            DropIndex("dbo.SinglesMatches", new[] { "PlayerTwo_PlayerId" });
            DropIndex("dbo.SinglesMatches", new[] { "PlayerOne_PlayerId" });
            DropIndex("dbo.SinglesMatches", new[] { "Player_PlayerId1" });
            DropIndex("dbo.SinglesMatches", new[] { "Player_PlayerId" });
            DropIndex("dbo.DoublesTeams", new[] { "DoublesTournament_TournamentId" });
            DropIndex("dbo.DoublesTeams", new[] { "Player_PlayerId" });
            DropIndex("dbo.DoublesMatches", new[] { "DoublesTournament_TournamentId" });
            DropIndex("dbo.DoublesMatches", new[] { "TeamTwo_TeamId" });
            DropIndex("dbo.DoublesMatches", new[] { "TeamOne_TeamId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SinglesTournaments");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.DoublesTournaments");
            DropTable("dbo.Players");
            DropTable("dbo.SinglesMatches");
            DropTable("dbo.DoublesTeams");
            DropTable("dbo.DoublesMatches");
        }
    }
}
