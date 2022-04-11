<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Studio.aspx.cs" Inherits="RopeyDVDs.Pages.Studio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>

    <div class="container">
        <div class="formdiv">
            <div class="form-group row">
                <label for="studioname" class="col-sm-2 col-form-label">Studio Name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="studionametxt" class="form-control" runat="server" placeholder="Studio Name"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </div>
        </div>
        <asp:GridView ID="studioview" class="table table-responsive table-striped" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Actions" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
