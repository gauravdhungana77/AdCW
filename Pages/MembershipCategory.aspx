<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MembershipCategory.aspx.cs" Inherits="RopeyDVDs.Pages.MembershipCategory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <h4>Add new membership category</h4>
        <div class="formdiv">
             <asp:TextBox ID="membershipcatnum"  runat="server" visible="false" ></asp:TextBox>
            <div class="form-group row mb-2">
                <label for="categorydescription" class="col-sm-2 col-form-label">Membership Category Description</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="categorydesctxt" class="form-control" runat="server" placeholder="Category description"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row mb-2">
                <label for="membershiploan" class="col-sm-2 col-form-label">Membership Category Total Loan</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="membershiploantxt" class="form-control" runat="server" placeholder="Total loan"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="add" runat="server" Text="Add" OnClick="add_Click"   />
                <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click"  />
                 <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click"/>
            </div>
        </div>
        <h4>Available membership category</h4>
        <asp:GridView ID="membershipcategoryview" class="table table-responsive table-striped" OnRowCommand="membershipcategoryCommand" runat="server">
            <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("MembershipCategoryNumber") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </div>
</asp:Content>