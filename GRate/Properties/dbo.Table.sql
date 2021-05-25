CREATE TABLE [dbo].[Table] (
    [GameId]          INT      NOT NULL,
    [GameName]        TEXT     NULL,
    [GameCompanyName] TEXT     NULL,
    [GameGenre]       TEXT     NULL,
    [GameReleaseTime] DATE NULL,
    PRIMARY KEY CLUSTERED ([GameId] ASC)
);

