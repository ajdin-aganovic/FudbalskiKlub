use miniafk

alter table Termin
add Rezultat varchar(50)

create table Proizvod
(
	ProizvodId int primary key identity(1,1),
	Naziv varchar(50),
	Sifra varchar(50),
	Kategorija varchar(50),
	Cijena float,
	Kolicina int
)

create table Narudzba
(
	NarudzbaId int primary key identity(1,1),
	BrojNarudzba varchar(50),
	Datum DateTime,
	Status varchar(50)
)

create table NarudzbaStavke
(
	NarudzbaStavkeId int primary key identity(1,1),
	NarudzbaId int,
	ProizvodId int,
	Kolicina int
)

alter table NarudzbaStavke
add constraint FK_NarudzbaStavkeNarudzba foreign key (NarudzbaId) references Narudzba(NarudzbaId)


alter table NarudzbaStavke
add constraint FK_NarudzbaStavkeProizvod foreign key (ProizvodId) references Proizvod(ProizvodId)

alter table Clanarina
add Placena bit

alter table Clanarina
add DatumPlacanja DateTime


delete Proizvod

select*
from Narudzba

select*
from NarudzbaStavke

select*
from Proizvod








































