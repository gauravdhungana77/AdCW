<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RopeyDVDs.Pages.Login" %>
<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <div class="loginmain">
                <div class="loginformdiv">
                    <div class="form-group row mb-2">
                        <label for="username" class="col-sm-2 col-form-label">Username</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="usernametxt" class="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                        </div>
                    </div>

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

                    <div class="form-group row  mb-2">
                        <label for="password" class="col-sm-2 col-form-label">Password</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="passwordtxt" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <asp:Button class="btn btn-info button" ID="Button2" runat="server" Text="Login" OnClick="loginbtn_Click" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
    <link href="../Content/Css/Global.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="loginmain">
                <div class="loginformdiv">
                    <div class="form-group row mb-2">
                        <label for="username" class="col-sm-2 col-form-label">Username</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="usernametxt"  class="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                              <asp:RequiredFieldValidator  Style="color:red" ControlToValidate="usernametxt" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Username."></asp:RequiredFieldValidator>               
                        </div>
                    </div>

                    <div class="form-group row  mb-2">
                        <label for="roledrop" class="col-sm-2 col-form-label">Role</label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="roledrop" class="form-control" runat="server">                              
                                <asp:ListItem>Assistant</asp:ListItem>
                                <asp:ListItem>Manager</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator  Style="color:red" ControlToValidate="roledrop" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select your role."></asp:RequiredFieldValidator>    
                        </div>
                    </div>

                    <div class="form-group row  mb-2">
                        <label for="password" class="col-sm-2 col-form-label">Password</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="passwordtxt" TextMode="Password" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator  Style="color:red" ControlToValidate="passwordtxt" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Password."></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div>
                        <asp:Button class="btn btn-info button" ID="Butaton1" runat="server" Text="Login" OnClick="loginbtn_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="loginmain">


        <div class="formdiv">
            <div class="form-group row">
                <label for="username" class="col-sm-2 col-form-label">Username</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="usernametxt" class="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="roledrop" class="col-sm-2 col-form-label">Role</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="roledrop" runat="server" Height="25px" Width="186px">
                        <asp:ListItem>Normal</asp:ListItem>
                        <asp:ListItem>Assistant</asp:ListItem>
                        <asp:ListItem>Manager</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <label for="password" class="col-sm-2 col-form-label">Password</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="passwordtxt" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="loginbtn" runat="server" Text="Login" OnClick="loginbtn_Click" />
            </div>
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
</asp:Content>--%>
