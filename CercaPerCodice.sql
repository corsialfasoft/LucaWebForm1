create procedure CercaPerCodice
	@idCod int
as
	select top 1 Id, descrizione, quantita
	from ProdottiSet
	where @idCod = Id
go

exec CercaPerCodice 1;

select * from ProdottiSet;
select * from RichiesteProdotti;
select * from RichiesteSet;