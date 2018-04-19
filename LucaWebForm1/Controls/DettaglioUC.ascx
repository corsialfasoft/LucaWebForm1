<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="DettaglioUC.ascx.cs" 
    Inherits="LucaWebForm1.DettaglioUC" %>

<div class="col-sm-4">
    <asp:Label runat="server">Codice Prodotto </asp:Label>
</div>
<div class="col-sm-8">
    <asp:Label runat="server"><%=p.Id %></asp:Label>
</div>

<div class="col-sm-4">
    <asp:Label runat="server">Descrizione Prodotto </asp:Label>
</div>
<div class="col-sm-8">
    <asp:Label runat="server"><%=p.Descrizione %></asp:Label>
</div>

<div class="col-sm-4">
    <asp:Label runat="server">Giacenza </asp:Label>
</div>
<div class="col-sm-8">
    <asp:Label runat="server"><%=p.Qta %></asp:Label>
</div>

