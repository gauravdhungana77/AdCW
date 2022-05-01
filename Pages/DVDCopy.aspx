<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DVDCopy.aspx.cs" Inherits="RopeyDVDs.Pages.DVDCopy" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <div class="formdiv">
             <asp:TextBox ID="copynumber"  runat="server" Visible="false"></asp:TextBox> 
            <div class="form-group row">
                <label for="dvdnumber" class="col-sm-2 col-form-label">DVD Title</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="dvdnumberdrop" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
             <div class="form-group row">
                <label for="datepurchased" class="col-sm-2 col-form-label">Date Purchased</label>
                <div class="col-sm-10">
                    <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>                  
                </div>
            </div>

            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"  />
                <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click"   />
            </div>
        </div>
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