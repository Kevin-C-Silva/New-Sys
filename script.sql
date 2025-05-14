-- Criando e usando o banco
create database dbNewSys;
use dbNewSys;

-- Criando as tabelas

create table Usuario(
Id int primary key auto_increment,
Nome varchar(200) not null,
Email varchar(200) not null,
Senha varchar(200) not null
);

create table Produto(
Id int primary key auto_increment,
Nome varchar(200) not null,
Descricao varchar(200) not null,
Preco decimal(10,2) not null,
Quantidade int not null
);