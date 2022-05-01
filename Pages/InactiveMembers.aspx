<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InactiveMembers.aspx.cs" Inherits="RopeyDVDs.Pages.InactiveMembers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <h2> Members who has not borrowed dvd copy in last 31 days.</h2>
        <asp:GridView ID="inactivememberview" class="table table-responsive table-striped" runat="server"></asp:GridView>
    </div>
</asp:Content>


