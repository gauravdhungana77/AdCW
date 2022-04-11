<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producer.aspx.cs" Inherits="RopeyDVDs.Pages.Producer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>

    <div class="container">
        <div class="formdiv">
            <div class="form-group row">
                <label for="producername" class="col-sm-2 col-form-label">Producer Name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="producernametxt" class="form-control" runat="server" placeholder="Producer Name"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </div>
        </div>
        <asp:GridView ID="producerview" class="table table-responsive table-striped" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Actions" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
