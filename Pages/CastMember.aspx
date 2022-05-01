<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CastMember.aspx.cs" Inherits="RopeyDVDs.Pages.CastMember" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />

    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <div class="formdiv">
            <div class="form-group row">
                <label for="dvdnumber" class="col-sm-2 col-form-label">DVD Title</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="dvdnumberdrop" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="actornumber" class="col-sm-2 col-form-label">Actor Name</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="actornumberdrop" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
            </div>
        </div>

        <%--<asp:GridView ID="castmemberview" class="table table-responsive table-striped" runat="server"></asp:GridView>--%>

        <asp:GridView ID="jointableview" class="table table-responsive table-striped" runat="server"></asp:GridView>
    </div>
</asp:Content>


