<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TooManyDvd.aspx.cs" Inherits="RopeyDVDs.Pages.TooManyDvd" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <h4>List of all members and the total number of DVDs they currently have on loan as well as displaying the message “Too 
many DVDs” for any member who has more DVDs on loan than they are allowed from their MembershipCategory.</h4>
        <asp:GridView ID="overloaneddvd" class="table table-responsive table-striped" runat="server">
        </asp:GridView>
    </div>
</asp:Content>


