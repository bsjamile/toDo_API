CREATE LOGIN todolistuser
WITH PASSWORD = '340$Uuxwp7Mcxo7Khy';
GO

CREATE DATABASE todolist;


USE todolist;
-- Cria um usuário para o banco.
CREATE USER todolistuser FOR LOGIN todolistuser;
GO

USE todolist;
GO
ALTER ROLE db_owner ADD MEMBER todolistuser;


update __EFMigrationsHistory
   set MigrationId = '20220623180912_TabelaTaskLists'
 where MigrationId = '20220707204502_TabelaTaskLists';

insert into __EFMigrationsHistory(MigrationId, ProductVersion) values ('20220627180812_TabelaTaskDetais', '5.0.0');

select * from tasklists

insert into colors(name) values ('vermelho'), ('branco');

select * from colors

INSERT INTO tasklists  (ListName, IdColor)
VALUES ( 'Lista 1', 1)

DELETE from tasklists where ListName = 'Lista 1';
select * from tasklists
