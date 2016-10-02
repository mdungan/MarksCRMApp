CREATE TABLE [dbo].[Notes] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Body]        NVARCHAR (MAX) NOT NULL,
    [CreatedBy]   NVARCHAR (100) NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [UpdatedDate] DATETIME       NOT NULL,
    [UpdatedBy]   NVARCHAR (256) NULL,
    [CustomerId]  BIGINT         NOT NULL,
    CONSTRAINT [PK_dbo.Notes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Notes_dbo.Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CustomerId]
    ON [dbo].[Notes]([CustomerId] ASC);

