<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="RopeyDVDs.Pages.Member" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <div class="formdiv">
             <asp:TextBox ID="membernumber"  runat="server" visible="false" ></asp:TextBox>
            <div class="form-group row mb-2">
                <label for="membershipcategorynumber" class="col-sm-2 col-form-label">Membership Category Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="membershipcategorynumberdrop" class="form-control" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group row mb-2">
                <label for="lastname" class="col-sm-2 col-form-label">Member last Name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="lastnametxt" class="form-control" runat="server" placeholder="Memeber last name"></asp:TextBox>

                </div>
            </div>

            <div class="form-group row mb-2">
                <label for="firstname" class="col-sm-2 col-form-label">Member First Name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="firstnametxt" class="form-control" runat="server" placeholder="Memeber first name"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row mb-2">
                <label for="membersddress" class="col-sm-2 col-form-label">Member Address</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="memberaddresstxt" class="form-control" runat="server" placeholder="Memeber address"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="memberdob" class="col-sm-2 col-form-label">Member DOB</label>
                <div class="col-sm-10">
                    <asp:Calendar ID="dobcalander" runat="server"></asp:Calendar>
                </div>
            </div>

            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" style="height: 36px"/>
                 <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit"  style="height: 36px" OnClick="edit_Click"/>
                <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click"  />
            </div>
        </div>
        <asp:GridView ID="memberview" OnRowCommand="MemberviewCommand" class="table table-responsive table-striped" runat="server">
            <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("MemberNumber") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
        <div>
        </div>


    </div>
</asp:Content>
