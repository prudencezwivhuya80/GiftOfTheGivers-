BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261028164732_AddCertificateNumberToDonations'
)
BEGIN
    ALTER TABLE [Donations] ADD [CertificateNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261028164732_AddCertificateNumberToDonations'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20261028164732_AddCertificateNumberToDonations', N'8.0.30');
END;
GO

COMMIT;
GO

