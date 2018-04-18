<%@ Page Title="Dettaglio" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Dettaglio.aspx.cs" 
    Inherits="LucaWebForm1._Dettaglio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <div class="text">
        Id = <%=LucaWebForm1._Ordina.CercaPerId %>
    </div>
    <div class="text">
        Descrizione = <%  = LucaWebForm1._Ordina.CercaPerDescr %>
    </div>

     <div class="text">
        Magazzino = <%  = prodotto.Magazzino %>
    </div>

    <div>
    <asp:TextBox class="form-control" placeholder="Quantità" ID="Qnta" runat="server"></asp:TextBox>
        <asp:Button OnClick="Richista_Click" runat="server" /> Richiedi
        <a runat="server" href="~/Ordina">Indietro</a>
    </div>
</asp:Content>
