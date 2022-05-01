<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DVDInfo.aspx.cs" Inherits="RopeyDVDs.Pages.DVDInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <h2> DVD title with its producer, Studio and cast members</h2>
        <asp:GridView ID="Dvdinfoview" class="table table-responsive table-striped" runat="server"></asp:GridView>
    </div>
</asp:Content>

