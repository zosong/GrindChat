using Microsoft.EntityFrameworkCore;
using GrindChat.Library.Models;

namespace GrindChat.API.Data
{
    //public class GrindChatDb : DbContext
    //{
    //    public GrindChatDb(DbContextOptions<GrindChatDb> options)
    //        : base(options)
    //    { }

    //    public DbSet<User> Users { get; set; }
    //    public DbSet<Team> Teams { get; set; }
    //    public DbSet<UserTeam> UsersTeam { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<UserTeam>()
    //            .HasOne(ut => ut.User)
    //            .WithMany(u => u.UserTeams) // Assuming User has a collection property UserTeams
    //            .HasForeignKey(ut => ut.UserId)
    //            .OnDelete(DeleteBehavior.NoAction); // Here we are altering the delete behavior

    //        modelBuilder.Entity<UserTeam>()
    //            .HasOne(ut => ut.Team)
    //            .WithMany(t => t.UserTeams) // Assuming Team has a collection property UserTeams
    //            .HasForeignKey(ut => ut.TeamId)
    //            .OnDelete(DeleteBehavior.NoAction); // Here we are altering the delete behavior

    //        modelBuilder.Entity<Team>()
    //            .HasOne(t => t.Admin) // Assuming Team has an Admin property of type User
    //            .WithMany()
    //            .HasForeignKey(t => t.AdminId)
    //            .OnDelete(DeleteBehavior.NoAction); // Altering delete behavior for AdminId foreign key
    //    }

    //}
}
