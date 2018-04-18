create procedure CercaPerDescrizione
	@descr nvarchar (20)
as
	select Id, descrizione, quantita
	from ProdottiSet
	where descrizione like '%'+ @descr or
			descrizione = @descr or
		descrizione like '%' + @descr  +'%' or
		descrizione like @descr + '%'
go

exec CercaPerDescrizione 'u';

select * from ProdottiSet;
select * from RichiesteProdotti;
select * from RichiesteSet;