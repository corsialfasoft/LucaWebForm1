using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LucaWebForm1;


namespace LucaWebForm1 {
	public partial class _Dettaglio : Page {
		public Prodotto prodotto;
		public string Messaggio;
		private IDomainModel mock = new MockDomainModel();

		protected void Page_Load(object sender, EventArgs e) {
			prodotto = int.TryParse(Request["CercaId"], out int code) ? mock.CercaProdotto(code) : null;
			if (prodotto == null) {
				Response.Redirect($"~/Ordina.aspx?Messaggio='prodotto non trovato'");
			}
		}

		protected void Richista_Click(object sender, EventArgs e) {
			if (int.TryParse(Qnta.Text, out int qtaRichiesta)) {
				List<Prodotto> prodotti = (List<Prodotto>)Session["listaRichieste"] ?? new List<Prodotto>();
				var query = from prod in prodotti
							where prod.Id == prodotto.Id
							select prod;
				if (query.FirstOrDefault() != null) {
					query.FirstOrDefault().Qta = query.FirstOrDefault().Qta + qtaRichiesta;
				} else {
					prodotto.Qta = qtaRichiesta;
					prodotti.Add(prodotto);
				}
				Session["listaRichieste"] = prodotti;
				Response.Redirect("~/Ordina.aspx?Messaggio=Richiesta di ordine riuscita");
			} else {
				Messaggio = "La quantità deve essere un valore numerico";
			}
		}
	}

	public partial class Prodotto{
		public int Id {get; set;}
		public string Descrizione { get; set; }
		public int Qta { get; set; }
		public int Magazzino {get; set;}

		//public Prodotto p = new Prodotto();
		//public List<Prodotto> listP = new List<Prodotto>();
	}

	public partial interface IDomainModel{
		Prodotto CercaProdotto(int id);
		List<Prodotto> CercaProdottoByDescr(string descr);
		void AddProdotto(int idProd, int qta);
	}

	public partial class MockDomainModel : IDomainModel{
		public Prodotto CercaProdotto(int id){
			Prodotto p = new Prodotto();
			try {
				//SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
				//builder.DataSource = @"(localdb)\MSSQLLocalDB";
				//builder.InitialCatalog = "RICHIESTE";
				//SqlConnection conn = new SqlConnection(builder.ConnectionString);
				SqlConnection cnt = Connessione();
				cnt.Open();
				SqlCommand cmd = new SqlCommand("dbo.CercaPerCodice", cnt);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@idCod", System.Data.SqlDbType.Int).Value = id;
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()){
					p.Id = reader.GetInt32(0);
					p.Descrizione = reader.GetString(1);
					p.Qta = reader.GetInt32(2);
				}
				reader.Close();
				cmd.Dispose();
			}catch(Exception e){
				throw e;
			}finally{
				Connessione().Dispose();
			}
			return p;		
		//return new Prodotto(){Id=1, Descrizione ="Rondelle", Qta=7, Magazzino = 9876};
		}

		public List<Prodotto> CercaProdottoByDescr(string descr) {

			//return new List<Prodotto>(){
			//	new Prodotto(){Id=1, Descrizione="Rondelle", Qta=500, Magazzino=9876},
			//	new Prodotto(){Id=2, Descrizione="Bulloni", Qta=10250, Magazzino=2018},
			//	new Prodotto(){Id=3, Descrizione="Dadi", Qta=675, Magazzino=2020}
			//};

			List<Prodotto> listP = new List<Prodotto>();
			try {				
				SqlConnection cnt = Connessione();
				cnt.Open();
				SqlCommand cmd = new SqlCommand("dbo.CercaPerDescrizione", cnt);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@descr", System.Data.SqlDbType.NVarChar).Value = descr;
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read()) {
					Prodotto p = new Prodotto();
					p.Id = reader.GetInt32(0);
					p.Descrizione = reader.GetString(1);
					p.Qta = reader.GetInt32(2);
					listP.Add(p);
				}
				reader.Close();
				cmd.Dispose();
			} catch (Exception e) {
				throw e;
			} finally {
				Connessione().Dispose();
			}
			return listP;
		}

		public void AddProdotto(int idProd, int qta) {
		
		}

		public SqlConnection Connessione(){
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = @"(localdb)\MSSQLLocalDB";
			builder.InitialCatalog = "RICHIESTE";
			SqlConnection conn = new SqlConnection(builder.ConnectionString);
			return conn;
			//return new SqlConnection(builder.ConnectionString);
		}
	}
}