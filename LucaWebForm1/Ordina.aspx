<%@ Page Title="Ordina" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Ordina.aspx.cs" 
    Inherits="LucaWebForm1._Ordina" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>

    <%if(Messaggio != null){%>
        <div class="text-warning">
       <%=Messaggio %>
    <%} %>
    
    </div>
    <%--<div class="form-group">
    <%if(CercaPerId != null && CercaPerId != ""){%>
        <div class="text-warning">
        Id = <%=CercaPerId %>
    <%} %>
        </div>
    </div>--%>

<%--    <div class="form-group">
    <%if(CercaPerDescr != null && CercaPerDescr !=""){%>
        <div class="text-warning">
        Descrizione = <%  = CercaPerDescr %>
    <%} %>
        </div>
     </div>--%>

   <%-- <div class="form-group">
    <%if(prodotto.Magazzino != null && CercaPerId != ""){%>
        <div class="text-warning">
        Id = <%=CercaPerId %>
    <%} %>
        </div>
    </div>--%>

     

    <div class="form-group">
        <asp:TextBox class="form-control" textmode ="Number" placeholder="Id..." ID="CercaId" runat="server" ></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox class="form-control" placeholder="Descrizione..." ID="CercaDescr" runat="server"></asp:TextBox>
    </div>
        <asp:Button Text ="Cerca" OnClick="Cerca_Click" runat="server" class="btn btn-primary" />
    <div class="table" style="margin-top:25px">
        <asp:Table ID="Tablettino" runat="server" width="100%"
            CellPadding="10"
            GridLines="None"
            HorizontalAlign="Center">
        </asp:Table>
    </div>
</asp:Content>
