using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LucaWebForm1 {
	public partial class _Ordina : Page {
		public List<Prodotto> listP = new List<Prodotto>();
		public string Messaggio{get;set;}
		public static string CercaPerId { get; set; }
		public static string CercaPerDescr { get; set; }

		protected void Page_Load(object sender, EventArgs e) {
			Messaggio = Request["Messaggio"] ?? null;
		}

		protected void Cerca_Click(object sender, EventArgs e) {			
			CercaPerId = CercaId.Text;
			CercaPerDescr = CercaDescr.Text;
			if (!String.IsNullOrEmpty(CercaId.Text)) {
				Response.Redirect($"~/Dettaglio.aspx?CercaId={CercaId.Text}");
			} else if (!String.IsNullOrEmpty(CercaDescr.Text)) {
				IDomainModel mock = new MockDomainModel();
				listP = mock.CercaProdottoByDescr(CercaDescr.Text) ?? null;
				foreach (Prodotto p in listP) {
					TableRow tr = new TableRow();
					TableCell tdCodice = new TableCell();
					tdCodice.Controls.Add(new Label() { Text = p.Id.ToString(), CssClass = "col-xs-2" });
					tr.Cells.Add(tdCodice);
					TableCell tdDescrizione = new TableCell();
					tdDescrizione.Controls.Add(new Label() { Text = p.Descrizione, CssClass = "col-xs-6" });
					tr.Cells.Add(tdDescrizione);
					TableCell tdGiacenza = new TableCell();
					tdGiacenza.Controls.Add(new Label() { Text = p.Qta.ToString(), CssClass = "col-xs-2" });
					tr.Cells.Add(tdGiacenza);
					TableCell tdButton = new TableCell();
					tdButton.Controls.Add(new Button() { Text = "detail", PostBackUrl = $"Detail?codice={p.Id}", CssClass = "col-xs-2" });
					tr.Cells.Add(tdButton);
					Tablettino.Rows.Add(tr);
				}
			}
		}

		//protected void Ordina_Click(object sender, EventArgs e) {
		//	CercaPerId = CercaId.Text;
		//	var url = String.Format("~/Descrizione.aspx?CercaPerId=CercaId.Text");
		//	Response.Redirect(url);
		//	//CercaPerDescr = CercaDescr.Text;
		//}
	}
}