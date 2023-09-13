create database Viagem
go

use Viagem
go

create Table Aeroporto
(
    Id int not null identity primary key,
    Sigla varchar(3) not null,
    Descricao varchar(256) 
)
go

create table Rotas(
    Id int not null identity primary key, 
    IdRota uniqueidentifier not null,
    Origem varchar(3) not null foreign key references Aeroporto(Sigla),
    Destino varchar(3) not null foreign key references Aeroporto(Sigla),
    Valor money not null
)

