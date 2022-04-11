<%@ Page Title="Actor" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Actors.aspx.cs" Inherits="RopeyDVDs.Pages.Actors" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>

    <div class="container">
        <div class="formdiv">
            <div class="form-group row">
                <label for="surname" class="col-sm-2 col-form-label">ActorSurname</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="surnametxt" class="form-control" runat="server" placeholder="ActorSurname"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="firstname" class="col-sm-2 col-form-label">ActorFirstName</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="firstnametxt" class="form-control" runat="server" placeholder="ActorSurname"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </div>
        </div>


        <asp:GridView ID="actorview" class="table table-responsive table-striped" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Actions" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
