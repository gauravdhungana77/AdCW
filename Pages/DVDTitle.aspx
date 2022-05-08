<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DVDTitle.aspx.cs" Inherits="RopeyDVDs.Pages.DVDTitle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
       
         <h3>Inorder to add new dvdtitle with new producer, studio,actor <a runat="server" href="~/Pages/AddFreshDvd">Click Here</a> </h3>
         <h4>Add new DVD title</h4>
        <div class="formdiv">
             <asp:TextBox ID="dvdnumber" runat="server" visible="false"></asp:TextBox>
             <div class="form-group row mb-2">
                <label for="actornumberdrop" class="col-sm-2 col-form-label">Actor Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="actornumberdrop" class="form-control" runat="server">                
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="categorynumber" class="col-sm-2 col-form-label">Category Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="catnumdrop" class="form-control" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="studionumber" class="col-sm-2 col-form-label">Studio Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="stdnumdrop" class="form-control" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="producernumber" class="col-sm-2 col-form-label">Producer Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="prdcnumdrop" class="form-control" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group row mb-2">
                <label for="dvdtitle" class="col-sm-2 col-form-label">DVD Title</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="dvdtitletxt" class="form-control" runat="server" placeholder="DVD Title"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="datereleased" class="col-sm-2 col-form-label">Date Released</label>
                <div class="col-sm-10">
                    <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>
                   
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="standardcharge" class="col-sm-2 col-form-label">Standard Charge</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="stdchargetxt" class="form-control" runat="server" placeholder="Standard Charge"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="penaltycharge" class="col-sm-2 col-form-label">Penalty Charge</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="peneltychargetxt"  class="form-control" runat="server" placeholder="Penalty Charge"></asp:TextBox>
                </div>
            </div>

            <div>
                <asp:Button class="btn btn-info button" ID="add" runat="server" Text="Add" OnClick="add_Click" />
                <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click"  />
                <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click"/>

            </div>
        </div>
        <h4>Available dvd title</h4>
        <asp:GridView ID="dvdtitleview" OnRowCommand="dvdtitleviewCommand" class="table table-responsive table-striped" runat="server">
            <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("DVDNumber") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>

    </div>
</asp:Content>
