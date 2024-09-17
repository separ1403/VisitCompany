using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class win2019 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Win2019ID",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreviousLogin",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Win2019s",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPasswordHistoryEnabled = table.Column<bool>(type: "bit", nullable: true),
                    IsPasswordHistoryEnabledDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMaxPasswordAgeConfigured = table.Column<bool>(type: "bit", nullable: true),
                    IsMaxPasswordAgeConfiguredDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMinPasswordAgeConfigured = table.Column<bool>(type: "bit", nullable: true),
                    IsMinPasswordAgeConfiguredDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMinPasswordLengthConfigured = table.Column<bool>(type: "bit", nullable: true),
                    IsMinPasswordLengthConfiguredDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsComplexPasswordRequired = table.Column<bool>(type: "bit", nullable: true),
                    IsComplexPasswordRequiredDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPlainTextPasswordStorageDisabled = table.Column<bool>(type: "bit", nullable: true),
                    IsPlainTextPasswordStorageDisabledDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccountLockoutDurationConfigured = table.Column<bool>(type: "bit", nullable: true),
                    IsAccountLockoutDurationConfiguredDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFailedLogonAttemptsLimited = table.Column<bool>(type: "bit", nullable: true),
                    IsFailedLogonAttemptsLimitedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdminLockoutConfigured = table.Column<bool>(type: "bit", nullable: true),
                    IsAdminLockoutConfiguredDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPasswordResetErrorCountConfigured = table.Column<bool>(type: "bit", nullable: true),
                    IsPasswordResetErrorCountConfiguredDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUserAccountManagementRestricted = table.Column<bool>(type: "bit", nullable: true),
                    IsUserAccountManagementRestrictedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoteAccessManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsRemoteAccessManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOSAccountAccessLimited = table.Column<bool>(type: "bit", nullable: true),
                    IsOSAccountAccessLimitedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDomainJoinRestricted = table.Column<bool>(type: "bit", nullable: true),
                    IsDomainJoinRestrictedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMemoryManagementPermissionGranted = table.Column<bool>(type: "bit", nullable: true),
                    IsMemoryManagementPermissionGrantedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLocalConsoleLogonRestricted = table.Column<bool>(type: "bit", nullable: true),
                    IsLocalConsoleLogonRestrictedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoteLogonGroupManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsRemoteLogonGroupManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBackupAccessManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsBackupAccessManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSystemTimeChangeManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsSystemTimeChangeManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccessTokenCreationLimited = table.Column<bool>(type: "bit", nullable: true),
                    IsAccessTokenCreationLimitedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoteLogonRestrictedForGuests = table.Column<bool>(type: "bit", nullable: true),
                    IsRemoteLogonRestrictedForGuestsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsScheduledTasksPermissionManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsScheduledTasksPermissionManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLogonAsServicePermissionManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsLogonAsServicePermissionManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGuestLogonManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsGuestLogonManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLocalAccountLogonManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsLocalAccountLogonManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLogonAsServiceSettingsApplied = table.Column<bool>(type: "bit", nullable: true),
                    IsLogonAsServiceSettingsAppliedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoteShutdownPermissionManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsRemoteShutdownPermissionManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdministratorUsernameChanged = table.Column<bool>(type: "bit", nullable: true),
                    IsAdministratorUsernameChangedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCachedUsernameCountManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsCachedUsernameCountManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPasswordExpirationWarningManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsPasswordExpirationWarningManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnonymousSIDRequestManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsAnonymousSIDRequestManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNTFSMediaAccessManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsNTFSMediaAccessManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSharedPrinterDriverInstallationManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsSharedPrinterDriverInstallationManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrinterSpoolerServiceManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsPrinterSpoolerServiceManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOnlineTipManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsOnlineTipManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsKeepAliveTimeManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsKeepAliveTimeManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIRDPOptionDisabled = table.Column<bool>(type: "bit", nullable: true),
                    IsIRDPOptionDisabledDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDataRetransmissionManaged = table.Column<bool>(type: "bit", nullable: true),
                    IsDataRetransmissionManagedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Win2019s", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_Win2019ID",
                table: "Checklists",
                column: "Win2019ID",
                unique: true,
                filter: "[Win2019ID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_Win2019s_Win2019ID",
                table: "Checklists",
                column: "Win2019ID",
                principalTable: "Win2019s",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_Win2019s_Win2019ID",
                table: "Checklists");

            migrationBuilder.DropTable(
                name: "Win2019s");

            migrationBuilder.DropIndex(
                name: "IX_Checklists_Win2019ID",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Win2019ID",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PreviousLogin",
                table: "Accounts");
        }
    }
}
