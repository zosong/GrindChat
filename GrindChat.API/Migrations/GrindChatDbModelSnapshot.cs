﻿using GrindChat.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrindChat.API.Migrations
{
//    [DbContext(typeof(GrindChatDb))]
//    partial class GrindChatDbModelSnapshot : ModelSnapshot
//    {
//        protected override void BuildModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder
//                .HasAnnotation("ProductVersion", "7.0.12")
//                .HasAnnotation("Relational:MaxIdentifierLength", 128);

//            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

//            modelBuilder.Entity("GrindChat.Library.Models.Team", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int");

//                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

//                    b.Property<int>("AdminId")
//                        .HasColumnType("int");

//                    b.Property<string>("TeamName")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.HasIndex("AdminId");

//                    b.ToTable("Teams");
//                });

//            modelBuilder.Entity("GrindChat.Library.Models.User", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int");

//                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

//                    b.Property<string>("EmailAddress")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Password")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.ToTable("Users");
//                });

//            modelBuilder.Entity("GrindChat.Library.Models.UserTeam", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int");

//                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

//                    b.Property<int>("TeamId")
//                        .HasColumnType("int");

//                    b.Property<int>("UserId")
//                        .HasColumnType("int");

//                    b.HasKey("Id");

//                    b.HasIndex("TeamId");

//                    b.HasIndex("UserId");

//                    b.ToTable("UsersTeam");
//                });

//            modelBuilder.Entity("GrindChat.Library.Models.Team", b =>
//                {
//                    b.HasOne("GrindChat.Library.Models.User", "Admin")
//                        .WithMany()
//                        .HasForeignKey("AdminId")
//                        .OnDelete(DeleteBehavior.NoAction)
//                        .IsRequired();

//                    b.Navigation("Admin");
//                });

//            modelBuilder.Entity("GrindChat.Library.Models.UserTeam", b =>
//                {
//                    b.HasOne("GrindChat.Library.Models.Team", "Team")
//                        .WithMany("UserTeams")
//                        .HasForeignKey("TeamId")
//                        .OnDelete(DeleteBehavior.NoAction)
//                        .IsRequired();

//                    b.HasOne("GrindChat.Library.Models.User", "User")
//                        .WithMany("UserTeams")
//                        .HasForeignKey("UserId")
//                        .OnDelete(DeleteBehavior.NoAction)
//                        .IsRequired();

//                    b.Navigation("Team");

//                    b.Navigation("User");
//                });

//            modelBuilder.Entity("GrindChat.Library.Models.Team", b =>
//                {
//                    b.Navigation("UserTeams");
//                });

//            modelBuilder.Entity("GrindChat.Library.Models.User", b =>
//                {
//                    b.Navigation("UserTeams");
//                });
//#pragma warning restore 612, 618
//        }
//    }
}
