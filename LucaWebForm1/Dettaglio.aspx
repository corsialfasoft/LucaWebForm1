﻿<%@ Page Title="Dettaglio" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Dettaglio.aspx.cs" 
    Inherits="LucaWebForm1._Dettaglio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <div class="text">
<%--    Id = <%=LucaWebForm1._Ordina.CercaPerId %>--%>
        Id = <%=prodotto.Id %>
    </div>
    <div class="text">
<%--        Descrizione = <%  = LucaWebForm1._Ordina.CercaPerDescr %>--%>
        Descrizione = <%  = prodotto.Descrizione %>
    </div>

     <div class="text">
        Magazzino = <%  = prodotto.Qta %>
    </div>

    <div>
    <asp:TextBox class="form-control" placeholder="Quantità" ID="Qnta" runat="server"></asp:TextBox>
        <asp:Button text="Richiedi" OnClick="Richista_Click" runat="server" /> 
        <asp:Button text="Indietro" PostBackUrl="~/Ordina.aspx" runat="server"/>
    </div>
</asp:Content>
