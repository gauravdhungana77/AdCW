<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Studio.aspx.cs" Inherits="RopeyDVDs.Pages.Studio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>

    <div class="container">
        <h4>Add new studio</h4>
        <div class="formdiv">
            <asp:TextBox ID="studionum"  runat="server" visible ="false"></asp:TextBox>
            <div class="form-group row mb-2">
                <label for="studioname" class="col-sm-2 col-form-label">Studio Name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="studionametxt" class="form-control" runat="server" placeholder="Studio Name"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="add" runat="server" Text="Add" OnClick="add_Click" />
                <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click"  />
                  <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click"/>
            </div>
        </div>
        <h4>Available studio</h4>
        <asp:GridView ID="studioview" class="table table-responsive table-striped" OnRowCommand="studioviewCommand" runat="server">
           <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("StudioNumber")%>' runat="server">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </div>
</asp:Content>
