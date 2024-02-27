﻿// <auto-generated />
using System;
using Auth.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Auth.Infrastructure.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    partial class AuthDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Auth.Domain.Entities.Auth.Permissions.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_at");

                    b.HasKey("Id");

                    b.ToTable("ermission", "auth_full");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.RolePermissions.RolePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at");

                    b.Property<long>("PermissionId")
                        .HasColumnType("bigint")
                        .HasColumnName("permission_id");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_at");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("role_permission", "auth_full");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.Roles.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long?>("PermissionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_at");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("role", "auth_full");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.Tokens.UserRefreshToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at");

                    b.Property<DateTime>("ExpirationInMinutes")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("expiration_in_minutes");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tefresh_token");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_at");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.UserRoles.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_at");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_role", "auth_full");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at");

                    b.Property<DateTimeOffset>("DateOfBrith")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_brith");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean")
                        .HasColumnName("is_bloked");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_at");

                    b.HasKey("Id");

                    b.ToTable("user", "auth_full");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Products.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("integer")
                        .HasColumnName("product_status");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_at");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("product", "auth_full");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.RolePermissions.RolePermission", b =>
                {
                    b.HasOne("Auth.Domain.Entities.Auth.Permissions.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auth.Domain.Entities.Auth.Roles.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.Roles.Role", b =>
                {
                    b.HasOne("Auth.Domain.Entities.Auth.Permissions.Permission", null)
                        .WithMany("Roles")
                        .HasForeignKey("PermissionId");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.UserRoles.UserRole", b =>
                {
                    b.HasOne("Auth.Domain.Entities.Auth.Roles.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auth.Domain.Entities.Auth.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Products.Product", b =>
                {
                    b.HasOne("Auth.Domain.Entities.Auth.Users.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.Permissions.Permission", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.Roles.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Auth.Domain.Entities.Auth.Users.User", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
