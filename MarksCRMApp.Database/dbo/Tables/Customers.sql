CREATE TABLE [dbo].[Customers] (
    [Id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [CompanyName]  NVARCHAR (100) NOT NULL,
    [EmailAddress] NVARCHAR (100) NOT NULL,
    [Address]      NVARCHAR (200) NOT NULL,
    [PhoneNumber]  NVARCHAR (15)  NOT NULL,
    [StateId]      INT            NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [CreatedBy]    NVARCHAR (256) NULL,
    [UpdatedDate]  DATETIME       NOT NULL,
    [UpdatedBy]    NVARCHAR (256) NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Customers_dbo.States_StateId] FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_StateId]
    ON [dbo].[Customers]([StateId] ASC);

