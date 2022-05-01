<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExpiredDvdCopies.aspx.cs" Inherits="RopeyDVDs.Pages.ExpiredDvdCpoies" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <h2> DVD Copies older than 1 years.</h2>
        <asp:GridView ID="expireddvdcopies" OnRowCommand="dvdcopyview" class="table table-responsive table-striped" runat="server">
             <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("CopyNumber") %>' runat="server">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </div>
</asp:Content>

