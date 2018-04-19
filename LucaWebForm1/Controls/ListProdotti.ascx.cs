using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LucaWebForm1 {
	public partial class ListProdotti : System.Web.UI.UserControl {
		public bool showQtaRichiesta { get; set; }
		public bool IsDetailEnabled { get; set; }
		public List<Prodotto> Products { get; set; }

		protected void Page_Load(object sender, EventArgs e) {
		}
		public void Update() {
			if (Products != null) {
				foreach (Prodotto p in Products) {
					TableRow tr = new TableRow();
					tr.Cells.Add(CreaCella(new Label() { Text = p.Id.ToString(), CssClass = "col-xs-2" }));
					tr.Cells.Add(CreaCella(new Label() { Text = p.Descrizione, CssClass = "col-xs-6" }));
					tr.Cells.Add(CreaCella(new Label() { Text = p.Qta.ToString(), CssClass = "col-xs-2" }));
					if (this.IsDetailEnabled) { tr.Cells.Add(CreaCella(new Button() { Text = "detail", PostBackUrl = $"/Detail.aspx?codice={p.Id}", CssClass = "col-xs-2" })); }
					if (this.showQtaRichiesta) { tr.Cells.Add(CreaCella(new Label() { Text = p.Magazzino.ToString(), CssClass = "col-xs-2" })); }
					TabellaProdotti.Rows.Add(tr);
				}
			}
		}

		private TableCell CreaCella(Control label) {
			TableCell cella = new TableCell();
			cella.Controls.Add(label);
			return cella;
		}
	}
}