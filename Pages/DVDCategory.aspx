<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DVDCategory.aspx.cs" Inherits="RopeyDVDs.Pages.DVDCategory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>

    <div class="container">
        <div class="formdiv">
            <div class="form-group row">
                <label for="catdesc" class="col-sm-2 col-form-label">Category Description</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="catdesctxt" class="form-control" runat="server" placeholder="Category Description"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="agerestr" class="col-sm-2 col-form-label">Age Restricted</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="ageresttxt" class="form-control" runat="server" placeholder="Age Restricted"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"  />
            </div>
        </div>
        <asp:GridView ID="dvdcategoryview" class="table table-responsive table-striped" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Actions" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

