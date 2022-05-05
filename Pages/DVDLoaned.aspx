<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DVDLoaned.aspx.cs" Inherits="RopeyDVDs.Pages.DVDLoaned" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <h4>List of all DVD copies currently on loan, in date order of date out with the loans of a particular day ordered by the title. </h4>
        <asp:GridView ID="loaneddvdview" class="table table-responsive table-striped" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
