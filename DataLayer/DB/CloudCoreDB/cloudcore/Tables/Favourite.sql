CREATE TABLE [cloudcore].[Favourite] (
    [UserId]             INT          NOT NULL,
    [FavouriteGuid] UNIQUEIDENTIFIER NOT NULL,
    [FavouriteTypeId]    SMALLINT     NOT NULL,
    [FavouriteType]      AS           (case [FavouriteTypeId] when (0) then 'Menu' when (1) then 'Dashboard' else 'Unknown' end),
    CONSTRAINT [PK_Favourite] PRIMARY KEY CLUSTERED ([UserId] ASC, [FavouriteGuid] ASC, [FavouriteTypeId] ASC),
    CONSTRAINT [FK_Favourite_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] ([UserId])
);

