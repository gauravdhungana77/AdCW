<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="RopeyDVDs.Pages.ChangePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <h4>Enter your new password</h4>
        <div class="formdiv">
            <asp:TextBox ID="usernumber" Visible="false" runat="server"></asp:TextBox>

            <div class="form-group row mb-2">
                <label for="currentpass" class="col-sm-2 col-form-label">Current Password</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="currentpasswtxt" class="form-control" runat="server" placeholder="Enter your current password"></asp:TextBox>
                </div>
            </div>   
            
            <div class="form-group row mb-2">
                <label for="newpass" class="col-sm-2 col-form-label">New Password</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="newpasswordtxt" class="form-control" runat="server" placeholder="New Password"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row mb-2">
                <label for="password" class="col-sm-2 col-form-label">Conform-Password</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="confpassword" class="form-control" runat="server" placeholder="Conform Password"></asp:TextBox>
                </div>
            </div>

            <div>
                <asp:Button class="btn btn-info button" ID="changepass" runat="server" Text="Change" OnClick="changepass_Click"  />
            </div>

        </div>


    </div>
</asp:Content>
