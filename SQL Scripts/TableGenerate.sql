-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

IF OBJECT_ID('dbo.MoveStances', 'U') IS NOT NULL 
	DROP TABLE [dbo].[MoveStances]; 
GO

IF OBJECT_ID('dbo.MoveProperties', 'U') IS NOT NULL 
	DROP TABLE [dbo].[MoveProperties]; 
GO

IF OBJECT_ID('dbo.Moves', 'U') IS NOT NULL 
	DROP TABLE [dbo].[Moves]; 
GO

IF OBJECT_ID('dbo.Stances', 'U') IS NOT NULL 
	DROP TABLE [dbo].[Stances]; 
GO

IF OBJECT_ID('dbo.Properties', 'U') IS NOT NULL 
	DROP TABLE [dbo].[Properties]; 
GO

IF OBJECT_ID('dbo.Characters', 'U') IS NOT NULL 
	DROP TABLE [dbo].[Characters]; 
GO

--Characters
CREATE TABLE Characters
(
  Id INT NOT NULL,
  CharacterName NVARCHAR(50) NULL,
  PRIMARY KEY (Id)
);

--Properties
CREATE TABLE Properties
(
  Id INT NOT NULL,
  PropertyName VARCHAR(50) NOT NULL,
  Abbreviation VARCHAR(50) NULL,
  PRIMARY KEY (Id)
);

--Stances
CREATE TABLE Stances
(
  Id INT NOT NULL,
  StanceName NVARCHAR(50) NOT NULL,
  Abbreviation NVARCHAR(50) NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE Moves
(
  Id INT NOT NULL,
  MoveInput VARCHAR(100) NULL,
  StartUpBegin INT NULL,
  StartUpEnd INT NULL,
  BlockFrameBegin INT NULL,
  BlockFrameEnd INT NULL,
  HitFramesBegin INT NULL,
  HitFramesEnd INT NULL,
  CounterHitFramesBegin INT NULL,
  CounterHitFramesEnd INT NULL,
  StanceSelfLeftIn INT NULL,
  StanceOppLeftIn INT NULL,
  CharacterId INT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (CharacterId) REFERENCES Characters(Id)
);

CREATE TABLE MoveProperties
(
  Id INT NOT NULL,
  BlockFrameBegin INT NULL,
  BlockFrameEnd INT NULL,
  HitFramesBegin INT NULL,
  HitFramesEnd INT NULL,
  CounterHitFramesBegin INT NULL,
  CounterHitFrameBegin INT NULL,
  PropertyId INT NOT NULL,
  MoveId INT NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (PropertyId) REFERENCES Properties(Id),
  FOREIGN KEY (MoveId) REFERENCES Moves(Id)
);

CREATE TABLE MoveStances
(
  Id INT NOT NULL,
  StanceId INT NOT NULL,
  MoveId INT NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (StanceId) REFERENCES Stances(Id),
  FOREIGN KEY (MoveId) REFERENCES Moves(Id)
);










