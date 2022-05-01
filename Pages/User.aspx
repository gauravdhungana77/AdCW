<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="RopeyDVDs.Pages.User" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <div class="formdiv">
            <div class="form-group row">
                <label for="username" class="col-sm-2 col-form-label">Username</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="usernametxt" class="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="usertype" class="col-sm-2 col-form-label">ActorFirstName</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="usertypetxt" class="form-control" runat="server" placeholder="User Type"></asp:TextBox>
                </div>
            </div>
             <div class="form-group row">
                <label for="password" class="col-sm-2 col-form-label">Password</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="passwordtxt" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </div>
        </div>


        <asp:GridView ID="userview" class="table table-responsive table-striped" OnRowCommand="userviewCommand" runat="server">
             <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("UserNumber") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </div>
</asp:Content>