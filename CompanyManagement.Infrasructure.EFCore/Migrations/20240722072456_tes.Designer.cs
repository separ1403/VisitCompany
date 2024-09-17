﻿// <auto-generated />
using System;
using CompanyManagement.Infrasructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20240722072456_tes")]
    partial class tes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccountChecklist", b =>
                {
                    b.Property<long>("AccountsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ChecklistsId")
                        .HasColumnType("bigint");

                    b.HasKey("AccountsId", "ChecklistsId");

                    b.HasIndex("ChecklistsId");

                    b.ToTable("AccountChecklist");
                });

            modelBuilder.Entity("AccountManagement.Domain.AccountAgg.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ChecklistId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("AccountManagement.Domain.RoleAgg.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("CompanyLicenceCategory", b =>
                {
                    b.Property<long>("CompaniesId")
                        .HasColumnType("bigint");

                    b.Property<long>("LicenceCategoriesId")
                        .HasColumnType("bigint");

                    b.HasKey("CompaniesId", "LicenceCategoriesId");

                    b.HasIndex("LicenceCategoriesId");

                    b.ToTable("CompanyLicenceCategory");
                });

            modelBuilder.Entity("CompanyManagement.Domain.ChecklistAgg.Checklist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AccessControlStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("AccessControlStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("AccessManagementStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("AccessManagementStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("AccountIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AntivirusStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("AntivirusStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("AuthenticationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("AuthenticationStatusScore")
                        .HasColumnType("bigint");

                    b.Property<double>("AverageGeneral")
                        .HasColumnType("float");

                    b.Property<string>("BackupStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("BackupStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("BusinessIdentificationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("BusinessIdentificationStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("CCTVStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CCTVStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("ClockSynchronizationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ClockSynchronizationStatusScore")
                        .HasColumnType("bigint");

                    b.Property<long?>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("ComplianceManagementStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ComplianceManagementStatusScore")
                        .HasColumnType("bigint");

                    b.Property<long?>("CountEmployees")
                        .HasColumnType("bigint");

                    b.Property<long?>("CountFolowers")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CyberAttackResponseStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CyberAttackResponseStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("DataDestructionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DataDestructionStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("DataSalesTradeStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DataSalesTradeStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DevelopmentTestOperationsControlStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DevelopmentTestOperationsControlStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("EmployeeTrainingStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("EmployeeTrainingStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("EntryExitManagementStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("EntryExitManagementStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("FinancialPaymentPlatformStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("FinancialPaymentPlatformStatusScore")
                        .HasColumnType("bigint");

                    b.Property<long?>("HPEDL380ID")
                        .HasColumnType("bigint");

                    b.Property<string>("HostingServiceStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("HostingServiceStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("IncidentResponseStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("IncidentResponseStatusScore")
                        .HasColumnType("bigint");

                    b.Property<long?>("JuniperHardeningID")
                        .HasColumnType("bigint");

                    b.Property<string>("LogManagementStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LogManagementStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("NamePeopleCo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetworkLogicalPhysicalMapStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("NetworkLogicalPhysicalMapStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("OrganizationalSecurityStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrganizationalSecurityStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("PasswordPolicyStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PasswordPolicyStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("PersonnelHiringStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PersonnelHiringStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("PhonePeopleCo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhysicalAssetsInventoryStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PhysicalAssetsInventoryStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("PrivacyPolicyStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PrivacyPolicyStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("PublicComplaintsStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PublicComplaintsStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("RemoteAdministrativeAccessStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RemoteAdministrativeAccessStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("RspponsePeopleCo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecureCodingConfigStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SecureCodingConfigStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("SecurityChangeApprovalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SecurityChangeApprovalStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("SecurityEvaluationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SecurityEvaluationStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("SecurityManagerStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SecurityManagerStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("SecurityPolicyStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SecurityPolicyStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("SessionExpirationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SessionExpirationStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("ThirdPartyServiceStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ThirdPartyServiceStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdateStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("UserDataCollectionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserDataCollectionStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("WirelessNetworkStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("WirelessNetworkStatusScore")
                        .HasColumnType("bigint");

                    b.Property<string>("ZoningStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ZoningStatusScore")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("HPEDL380ID")
                        .IsUnique()
                        .HasFilter("[HPEDL380ID] IS NOT NULL");

                    b.HasIndex("JuniperHardeningID")
                        .IsUnique()
                        .HasFilter("[JuniperHardeningID] IS NOT NULL");

                    b.ToTable("Checklists", (string)null);
                });

            modelBuilder.Entity("CompanyManagement.Domain.ChecklistAgg.HPEDL380", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("AreAppropriateGroupsCreated")
                        .HasColumnType("bit");

                    b.Property<string>("AreAppropriateGroupsCreateddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AreAppropriateUsernamesCreated")
                        .HasColumnType("bit");

                    b.Property<string>("AreAppropriateUsernamesCreateddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AreILOPortAndUSBPortConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("AreILOPortAndUSBPortConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AreInitialILOSettingsConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("AreInitialILOSettingsConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AreInitialSettingsForILOConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("AreInitialSettingsForILOConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AreNetworkSettingsForILOConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("AreNetworkSettingsForILOConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AreProvisioningSettingsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("AreProvisioningSettingsDeleteddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AreSSHKeysEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("AreSSHKeysEnableddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AreSystemCertificatesConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("AreSystemCertificatesConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AreUserCertificatesConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("AreUserCertificatesConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAccountServiceConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("IsAccountServiceConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDiskAndRaidConfigDeletionDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("IsDiskAndRaidConfigDeletionDisableddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEncryptionConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("IsEncryptionConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSecureBootConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("IsSecureBootConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsServerNameAndFQDNSet")
                        .HasColumnType("bit");

                    b.Property<string>("IsServerNameAndFQDNSetdescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTPMConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("IsTPMConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTPMEnabledAndRO")
                        .HasColumnType("bit");

                    b.Property<string>("IsTPMEnabledAndROdescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUEFISecurityConfigured")
                        .HasColumnType("bit");

                    b.Property<string>("IsUEFISecurityConfigureddescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HPEDL380s", (string)null);
                });

            modelBuilder.Entity("CompanyManagement.Domain.ChecklistAgg.JuniperHardening", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool?>("AreUnusedInterfacesDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("AreUnusedInterfacesDisableddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsAuxiliaryPortDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("IsAuxiliaryPortDisableddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsConfigFileEncrypted")
                        .HasColumnType("bit");

                    b.Property<string>("IsConfigFileEncrypteddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsConsolePortSecured")
                        .HasColumnType("bit");

                    b.Property<string>("IsConsolePortSecureddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsCraftInterfaceDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("IsCraftInterfaceDisableddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDiagnosticPortDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("IsDiagnosticPortDisableddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsLCDMenuDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("IsLCDMenuDisableddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsPasswordRecoveryDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("IsPasswordRecoveryDisableddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsResetButtonDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("IsResetButtonDisableddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsRootLoginAuxDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("IsRootLoginAuxDisableddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsRootLoginDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("IsRootLoginDisableddescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsUSBPortDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("IsUSBPortDisableddescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JuniperHardenings", (string)null);
                });

            modelBuilder.Entity("CompanyManagement.Domain.CompanyAgg.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("Average")
                        .HasColumnType("float");

                    b.Property<string>("Brand")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("ChecklistId")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("LicenceId")
                        .HasColumnType("bigint");

                    b.Property<string>("ManagerName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SecurityManagerName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("CompanyManagement.Domain.CompanyCategoryAgg.CompanyCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("CompanyCategories", (string)null);
                });

            modelBuilder.Entity("CompanyManagement.Domain.LicenceCategoryAgg.LicenceCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("LicenceCategories", (string)null);
                });

            modelBuilder.Entity("AccountChecklist", b =>
                {
                    b.HasOne("AccountManagement.Domain.AccountAgg.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyManagement.Domain.ChecklistAgg.Checklist", null)
                        .WithMany()
                        .HasForeignKey("ChecklistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccountManagement.Domain.AccountAgg.Account", b =>
                {
                    b.HasOne("AccountManagement.Domain.RoleAgg.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AccountManagement.Domain.RoleAgg.Role", b =>
                {
                    b.OwnsMany("AccountManagement.Domain.RoleAgg.Permission", "Permissions", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<int>("Code")
                                .HasColumnType("int");

                            b1.Property<long>("RoleId")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("RoleId");

                            b1.ToTable("RolePermissions", (string)null);

                            b1.WithOwner("Role")
                                .HasForeignKey("RoleId");

                            b1.Navigation("Role");
                        });

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("CompanyLicenceCategory", b =>
                {
                    b.HasOne("CompanyManagement.Domain.CompanyAgg.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyManagement.Domain.LicenceCategoryAgg.LicenceCategory", null)
                        .WithMany()
                        .HasForeignKey("LicenceCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyManagement.Domain.ChecklistAgg.Checklist", b =>
                {
                    b.HasOne("CompanyManagement.Domain.CompanyAgg.Company", "Company")
                        .WithMany("Checklists")
                        .HasForeignKey("CompanyId");

                    b.HasOne("CompanyManagement.Domain.ChecklistAgg.HPEDL380", "HPEDL380")
                        .WithOne("Checklist")
                        .HasForeignKey("CompanyManagement.Domain.ChecklistAgg.Checklist", "HPEDL380ID");

                    b.HasOne("CompanyManagement.Domain.ChecklistAgg.JuniperHardening", "JuniperHardening")
                        .WithOne("Checklist")
                        .HasForeignKey("CompanyManagement.Domain.ChecklistAgg.Checklist", "JuniperHardeningID");

                    b.Navigation("Company");

                    b.Navigation("HPEDL380");

                    b.Navigation("JuniperHardening");
                });

            modelBuilder.Entity("CompanyManagement.Domain.CompanyAgg.Company", b =>
                {
                    b.HasOne("CompanyManagement.Domain.CompanyCategoryAgg.CompanyCategory", "CompanyCategory")
                        .WithMany("Companies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyCategory");
                });

            modelBuilder.Entity("AccountManagement.Domain.RoleAgg.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("CompanyManagement.Domain.ChecklistAgg.HPEDL380", b =>
                {
                    b.Navigation("Checklist")
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyManagement.Domain.ChecklistAgg.JuniperHardening", b =>
                {
                    b.Navigation("Checklist")
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyManagement.Domain.CompanyAgg.Company", b =>
                {
                    b.Navigation("Checklists");
                });

            modelBuilder.Entity("CompanyManagement.Domain.CompanyCategoryAgg.CompanyCategory", b =>
                {
                    b.Navigation("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
