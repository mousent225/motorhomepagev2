﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotorHomepage.Data.EF;

namespace MotorHomepage.Data.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190530041213_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Avatar");

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("FileSize");

                    b.Property<string>("FileType");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MasterId");

                    b.Property<int>("ModuleId");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserCreated");

                    b.Property<Guid?>("UserDeleted");

                    b.Property<Guid?>("UserModified");

                    b.HasKey("Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Heading")
                        .HasMaxLength(255);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("PublishStatus");

                    b.Property<int>("Status");

                    b.Property<string>("SubHeading")
                        .HasMaxLength(255);

                    b.Property<Guid>("UserCreated");

                    b.Property<Guid?>("UserDeleted");

                    b.Property<Guid?>("UserModified");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.BannerKo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Heading")
                        .HasMaxLength(255);

                    b.Property<int>("MasterId");

                    b.Property<string>("SubHeading")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("BannerKos");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.BannerVi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Heading")
                        .HasMaxLength(255);

                    b.Property<int>("MasterId");

                    b.Property<string>("SubHeading")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("BannerVis");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Image")
                        .HasMaxLength(255);

                    b.Property<string>("ImageCaption")
                        .HasMaxLength(250);

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("PublishStatus");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<int>("Status");

                    b.Property<string>("Thumbnail")
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<Guid>("UserCreated");

                    b.Property<Guid?>("UserDeleted");

                    b.Property<Guid?>("UserModified");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.PostKo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("ImageCaption")
                        .HasMaxLength(250);

                    b.Property<int>("MasterId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("PostKos");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.PostVi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("ImageCaption")
                        .HasMaxLength(250);

                    b.Property<int>("MasterId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("PostVis");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.SysCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Remark")
                        .HasMaxLength(1000);

                    b.Property<int>("Status");

                    b.Property<Guid>("UserCreated");

                    b.Property<Guid?>("UserDeleted");

                    b.Property<Guid?>("UserModified");

                    b.HasKey("Id");

                    b.ToTable("SysCategories");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.SysCategoryValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int?>("DictionaryId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int?>("ParentId");

                    b.Property<int>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserCreated");

                    b.Property<Guid?>("UserDeleted");

                    b.Property<Guid?>("UserModified");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DictionaryId");

                    b.ToTable("SysCategoryValues");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.SysDictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Language1")
                        .HasMaxLength(1000);

                    b.Property<string>("Language2")
                        .HasMaxLength(1000);

                    b.Property<string>("Language3")
                        .HasMaxLength(1000);

                    b.Property<string>("Language4")
                        .HasMaxLength(1000);

                    b.Property<string>("Language5")
                        .HasMaxLength(1000);

                    b.Property<int>("MasterId");

                    b.Property<int>("ModuleId");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserCreated");

                    b.Property<Guid?>("UserDeleted");

                    b.Property<Guid?>("UserModified");

                    b.HasKey("Id");

                    b.ToTable("SysDictionnary");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.SysMenu", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("IconCss");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ParentId")
                        .HasMaxLength(128);

                    b.Property<int>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<Guid>("UserCreated");

                    b.Property<Guid?>("UserDeleted");

                    b.Property<Guid?>("UserModified");

                    b.HasKey("Id");

                    b.ToTable("SysMenus");
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.BannerKo", b =>
                {
                    b.HasOne("MotorHomepage.Data.Entities.Banner", "Banner")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.BannerVi", b =>
                {
                    b.HasOne("MotorHomepage.Data.Entities.Banner", "Banner")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.Post", b =>
                {
                    b.HasOne("MotorHomepage.Data.Entities.SysCategory", "SysCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.PostKo", b =>
                {
                    b.HasOne("MotorHomepage.Data.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.PostVi", b =>
                {
                    b.HasOne("MotorHomepage.Data.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MotorHomepage.Data.Entities.SysCategoryValue", b =>
                {
                    b.HasOne("MotorHomepage.Data.Entities.SysCategory", "SysCategory")
                        .WithMany("SysCategoryValues")
                        .HasForeignKey("CategoryId");

                    b.HasOne("MotorHomepage.Data.Entities.SysDictionary", "SysDictionary")
                        .WithMany()
                        .HasForeignKey("DictionaryId");
                });
#pragma warning restore 612, 618
        }
    }
}
