<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="RopeyDVDs.Pages.User" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <h4>Register new user</h4>
        <div class="formdiv">
            <asp:TextBox ID="usernumber" Visible="false" runat="server"></asp:TextBox>
            <div class="form-group row mb-2">
                <label for="username" class="col-sm-2 col-form-label">Username</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="usernametxt" class="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                </div>
            </div>

            <%--     <div class="form-group row">
                <label for="usertype" class="col-sm-2 col-form-label">ActorFirstName</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="usertypetxt" class="form-control" runat="server" placeholder="User Type"></asp:TextBox>
                </div>
            </div>--%>
            <div class="form-group row  mb-2">
                <label for="roledrop" class="col-sm-2 col-form-label">Role</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="roledrop" class="form-control" runat="server">
                        <asp:ListItem>Normal</asp:ListItem>
                        <asp:ListItem>Assistant</asp:ListItem>
                        <asp:ListItem>Manager</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="password" class="col-sm-2 col-form-label">Password</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="passwordtxt" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="password" class="col-sm-2 col-form-label">Conform-Password</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="confpassword" class="form-control" runat="server" placeholder="Confform Password"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
                 <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click" />
                  <asp:Button class="btn btn-danger button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click" />
            </div>
        </div>


         <asp:GridView ID="userview" class="table table-responsive table-striped" OnRowCommand="userviewCommand" runat="server">
             <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("UserNumber") %>' runat="server">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </div>
</asp:Content>
