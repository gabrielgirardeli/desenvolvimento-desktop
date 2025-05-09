create database multapps_dev;

use  multapps_dev;

  CREATE TABLE IF NOT EXISTS  categoria(
  Id  int not null auto_increment primary key,
 nome  varchar(100) not null,
DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DataAlteracao TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 status enum ('ativo','inativo','excluido') not null
 );
 
 
 
   CREATE TABLE IF NOT EXISTS produto(
  Id int not null auto_increment primary key,
  categoria_id int not null,
 nome  varchar(100) not null,
 preco decimal not null,
 quantidade_estoque int not null,
DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
DataAlteracao TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 status enum ('ativo','inativo','excluido') not null,
 foreign key (categoria_id) references categoria (Id)
   

);


create table if not exists Usuarios (
Id int auto_increment primary key,
NomeCompleto varchar(255) not null,
CPF varchar(15) not null,
Email varchar(255) not null,
Senha varchar(255) not null,
DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
DataAlteracao TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
status int not null
);

   

