DROP TABLE IF EXISTS Moves;

CREATE TABLE IF NOT EXISTS "Moves" (
	"MoveId"	INTEGER NOT NULL UNIQUE,
	"CharacterId"	INTEGER,
	"Command"	TEXT,
	"HitLevel"	TEXT,
	"Damage"	TEXT,
	"StartUpFrame"	TEXT,
	"BlockFrame"	TEXT,
	"HitFrame"	TEXT,
	"CounterHitFrame"	TEXT,
	"Notes"	TEXT,
	PRIMARY KEY("MoveId")
	FOREIGN KEY (CharacterId) REFERENCES Characters (Id)
);