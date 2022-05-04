<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="InactiveDvdCopies.aspx.cs" Inherits="RopeyDVDs.Pages.InactiveDvdCopies" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <h2>List of dvd titles whose copy has not been loaned in the last 31 days </h2>
        <asp:GridView ID="inactivcopiesview" class="table table-responsive table-striped" runat="server"></asp:GridView>
    </div>
</asp:Content>

