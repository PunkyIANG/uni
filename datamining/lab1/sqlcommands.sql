create database DepozitIndustrial;

create table Timp (
	Id int primary key,
	DayNumber int,
	MonthNumber int,
	YearNumber int
);

create table Locatie (
	Id int primary key,
	Nume Varchar(255)
);

create table TipMarfa (
	Id int primary key,
	Nume Varchar(255)
);

create table Tara (
	Id int primary key,
	Nume Varchar(255)
);

insert into Locatie values (0, 'Depozit angro');
insert into Locatie values (1, 'Depozit vanzari');
insert into Locatie values (2, 'Depozit livrare');

insert into TipMarfa values (0, 'Metalurgie');
insert into TipMarfa values (1, 'Medicina');
insert into TipMarfa values (2, 'Agricultura');
insert into TipMarfa values (3, 'Alimentara');

insert into Tara values (0, 'Franta');
insert into Tara values (1, 'Anglia');
insert into Tara values (2, 'Spania');
insert into Tara values (3, 'Germania');
insert into Tara values (4, 'Austria');


declare @month int = 1;
declare @day int = 1;

while @day < 32
begin
	insert into Timp values (20220000 + @month * 100 + @day, @day, @month, 2022);
	set @day = @day+1;
end
-- analog si restul lunilor

create table livrare_volum(
	Id int primary key,
	TimpId int foreign key references Timp(id),
	LocatieId int foreign key references Locatie(id),
	TipMarfaId int foreign key references TipMarfa(id),
	TaraId int foreign key references Tara(id),
	Volum int
);

create table livrare_cantitati(
	Id int primary key,
	TimpId int foreign key references Timp(id),
	LocatieId int foreign key references Locatie(id),
	TipMarfaId int foreign key references TipMarfa(id),
	TaraId int foreign key references Tara(id),
	Cantitati int
);

-- analog si restul tabelelor

declare @month int = 1;
declare @day int = 1;
declare @counter int = 1;

while @day < 29 and @month < 13
begin
	insert into livrare_volum values (
		@counter,
		20220000 + @month * 100 + @day, 
		ABS(CHECKSUM(NEWID()) % 3), 
		ABS(CHECKSUM(NEWID()) % 4), 
		ABS(CHECKSUM(NEWID()) % 5), 
		ABS(CHECKSUM(NEWID()) % 100)
		);
	set @day = @day+1;
	set @counter = @counter + 1;

	if @day >= 29 
	begin
		set @day = 1;
		set @month = @month + 1
	end
end

-- analog si restul tabelelor