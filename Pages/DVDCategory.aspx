<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DVDCategory.aspx.cs" Inherits="RopeyDVDs.Pages.DVDCategory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>

    <div class="container">
        <h4>Add new DVD Category</h4>
        <div class="formdiv">
            <asp:TextBox ID="categorynumber" runat="server" Visible="false"></asp:TextBox>
            <div class="form-group row mb-2">
                <label for="catdesc" class="col-sm-2 col-form-label">Category Description</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="catdesctxt" class="form-control" runat="server" placeholder="Category Description"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="agerestr" class="col-sm-2 col-form-label">Age Restricted</label>
                <div class="col-sm-10">
                    
                        <asp:DropDownList ID="ageresttxtdrop" class="form-control" runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click"/>
                <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click" />
            </div>
        </div>
        <h4>Available DVD Category</h4>
        <asp:GridView ID="dvdcategoryview" class="table table-responsive table-striped" OnRowCommand="dvdcategoryviewCommand" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("CategoryNumber") %>' runat="server">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

