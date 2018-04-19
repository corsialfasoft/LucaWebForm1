<%@ Page Title="Dettaglio" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Dettaglio.aspx.cs" 
    Inherits="LucaWebForm1._Dettaglio" %>

<%@ Register TagPrefix="MineUC" TagName="Dettaglio" Src="~/Controls/DettaglioUC.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
<%--    <h3>Your contact page.</h3>--%>
<%--    <div class="text">--%>
<%--    Id = <%=LucaWebForm1._Ordina.CercaPerId %>--%>
        <%--Id = <%=prodotto.Id %>
    </div>
    <div class="text">--%>
<%--        Descrizione = <%  = LucaWebForm1._Ordina.CercaPerDescr %>--%>
        <%--Descrizione = <%  = prodotto.Descrizione %>
    </div>--%>

     <%--<div class="text">
        Magazzino = <%  = prodotto.Qta %>
    </div>--%>

     <%if(Messaggio != null){%>
        <div class="text-warning">
       <%=Messaggio %>
    <%} %>
        </div>

    <MineUC:Dettaglio  ID="detail" runat="server" />

    <div class="col-sm-4">
        <asp:Label runat="server">Quantita da richiedere</asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:Label runat="server"></asp:Label>
        <asp:TextBox TextMode="Number" ID="Qnta" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator
            ID="ReqFieldValCodice"
            ControlToValidate="Qnta"
            Display="Static"
            CssClass="text-danger"
            ErrorMessage=" quantita obbligatoria"
            runat="server" />
        <asp:RangeValidator
            ID="RangeValCodice"
            runat="server"
            ControlToValidate="Qnta"
            Display="Static"
            ErrorMessage=" Range non valido (si possono scegliere solo i primi 100 prodotti)"
            CssClass="text-danger"
            Type="Integer"
            MinimumValue="1"
            MaximumValue="999" />
        <asp:CustomValidator
            ID="CustomValidator1"
            ControlToValidate="Qnta"
            Display="Static"
            ErrorMessage="Solo i 46, 58 o 59 sono numeri MAGICI!"
            OnServerValidate="QtaValidator"
            runat="server"></asp:CustomValidator>

    </div>

    <div>
    <%--<asp:TextBox class="form-control" placeholder="Quantità" ID="Qnta" runat="server"></asp:TextBox>--%>
        <asp:Button text="Richiedi" OnClick="Richista_Click" runat="server" /> 
        <asp:Button text="Indietro" PostBackUrl="~/Ordina.aspx" runat="server"/>
    </div>
</asp:Content>
