<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DVDCopy.aspx.cs" Inherits="RopeyDVDs.Pages.DVDCopy" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <h4>Add new DVD Copy</h4>
        <div class="formdiv">
             <asp:TextBox ID="copynumber"  runat="server" Visible="false"></asp:TextBox> 
            <div class="form-group row mb-2">
                <label for="dvdnumber" class="col-sm-2 col-form-label">DVD Title</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="dvdnumberdrop" class="form-control" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
             <div class="form-group row mb-2">
                <label for="datepurchased" class="col-sm-2 col-form-label">Date Purchased</label>
                <div class="col-sm-10">
                    <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>                  
                </div>
            </div>

            <div>
                <asp:Button class="btn btn-info button" ID="add" runat="server" Text="Add" OnClick="add_Click"   />
                <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click"   />
                 <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click"    />
            </div>
        </div>
        <h4>Available dvd copy </h4>
        <asp:GridView ID="dvdcopyview" OnRowCommand="dvdcopyviewCommand" class="table table-responsive table-striped" runat="server">
             <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("CopyNumber") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
        <div>
           
        </div>
        

    </div>
</asp:Content>