<%@ Page Title="Carrello" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Carrello.aspx.cs" 
    Inherits="LucaWebForm1._Carrello" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr />
    <div class="text-warning">
        <%=Message %>
    </div>
    <%if(prodotti!=null){
      foreach(var p in prodotti){ %>        
        <div class="col-sm-4">
           Id:  <%=p.Id%>
        </div>
        <div class="col-sm-4">
           Descrizione: <%=p.Descrizione%>
        </div>
        <div class="col-sm-4">
           Magazzino: <%=p.Qta%>
        </div>
        <%--<div class="col-sm-4">
            <%=p.Magazzino%>
        </div>--%>
    <%}} %>
    <br><br>
    <asp:Button runat="server" OnClick="Richiedi_Click" class="btn btn-primary" Text="Richiedi" />
</asp:Content>
