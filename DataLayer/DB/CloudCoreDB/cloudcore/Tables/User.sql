CREATE TABLE [cloudcore].[User] (
    [UserId]           INT              IDENTITY (1, 5) NOT NULL,
    [UserKey]          UNIQUEIDENTIFIER NOT NULL constraint [DF_User_UserKey] DEFAULT newid(),
    [Login]            VARCHAR (320)    NOT NULL,
    [Initials]         VARCHAR (15)     NOT NULL,
    [Firstnames]       VARCHAR (100)    NOT NULL,
    [Surname]          VARCHAR (30)     NOT NULL,
    [PasswordHash]     VARCHAR (200)     CONSTRAINT [DF_User_PasswordHash] DEFAULT ('') NOT NULL,
    [PasswordChanged]  DATETIME         CONSTRAINT [DF_User_PasswordChanged] DEFAULT (getdate()) NOT NULL,
    [ReferenceGuid]    UNIQUEIDENTIFIER NULL,
    [Email]            VARCHAR (255)     CONSTRAINT [DF_User_Email] DEFAULT ('') NOT NULL,
    [CellNo]           VARCHAR (15)     NULL,
    [Active]           AS               cast (CASE WHEN [IntAccess] = 1 or [ExtAccess] = 1 then 1 else 0 end as bit),
    [IntAccess]        BIT              NOT NULL default 0,
    [ExtAccess]        BIT              NOT NULL default 0,
	[IsAdministrator]  BIT              NOT NULL constraint [DF_User_IsAdministrator] default 0,
    [IsNamedUser]      BIT              NOT NULL default 1,
    [Created]          DATETIME         CONSTRAINT [DF_User_Created] DEFAULT (getdate()) NOT NULL,
    [LastLogin]        DateTime         NOT NULL CONSTRAINT [DF_User_LastLogin] default(getdate()),
    [ThumbImage]       IMAGE            NULL,
    [MainImage]        IMAGE            NULL,
    [Fullname]         AS               RTRIM(([Firstnames]+' ')+[Surname]),
    [NFullname]        AS               RTRIM(([Initials]+' ')+[Surname]),
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [UNQ_User_Login] UNIQUE NONCLUSTERED ([Login] ASC)
);


GO
