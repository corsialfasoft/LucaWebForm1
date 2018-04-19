using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LucaWebForm1 {
	public partial class _Carrello : Page {
		public string Message { get; set; }
		public List<Prodotto> prodotti { get; set; }

		protected void Page_Load(object sender, EventArgs e) {
			prodotti = (List<Prodotto>)Session["listaRichieste"] ?? null;
			Message = prodotti == null ? "Nessun prodotto tra le richieste di ordine" : null;
		}

		protected void Richiedi_Click(object sender, EventArgs e) {
			IDomainModel mock = new MockDomainModel();
			foreach (Prodotto p in prodotti) {
				mock.AddProdotto(p.Id, p.Qta);
				Session["CercaPerId"] = p.Id;
				Session["CercaPerDescr"] = p.Descrizione;
			}
			Session["listaRichieste"] = null;

			Response.Redirect("~/Ordina.aspx?Messaggio=Richiesta di ordine ANDATA IN PORTO");
			
		}
	}
}

		//protected void Ordina_Click(object sender, EventArgs e) {
		//	CercaPerId = CercaId.Text;
		//	var url = String.Format("~/Descrizione.aspx?CercaPerId=CercaId.Text");
		//	Response.Redirect(url);
		//	//CercaPerDescr = CercaDescr.Text;
		//}
//	}
//}