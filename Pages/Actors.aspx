<%@ Page Title="Actor" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Actors.aspx.cs" Inherits="RopeyDVDs.Pages.Actors" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <div class="formdiv">
            <asp:TextBox ID="actornumber" runat="server" Visible="false"></asp:TextBox>

            <div class="form-group row">
                <label for="surname" class="col-sm-2 col-form-label">ActorSurname</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="surnametxt" class="form-control" runat="server" placeholder="ActorSurname"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator  Style="color:red" ControlToValidate="surnametxt" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Actor surname is required."></asp:RequiredFieldValidator> --%>              
                </div>
            </div>

            <div class="form-group row">
                <label for="firstname" class="col-sm-2 col-form-label">ActorFirstName</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="firstnametxt" class="form-control" runat="server" placeholder="ActorFirstname"></asp:TextBox>
                   <%--  <asp:RequiredFieldValidator  Style="color:red" ControlToValidate="firstnametxt" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Actor firstname is required."></asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click" />
                <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click" />

            </div>
        </div>

        <div>
            <asp:GridView ID="actorview" OnRowCommand="actorviewCommand" class="table table-responsive table-striped" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("ActorNumber") %>' runat="server">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>

    </div>
</asp:Content>
