<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DVDTitle.aspx.cs" Inherits="RopeyDVDs.Pages.DVDTitle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <div class="formdiv">
             <asp:TextBox ID="dvdnumber" runat="server" visible="false"></asp:TextBox>
             <div class="form-group row">
                <label for="actornumberdrop" class="col-sm-2 col-form-label">Actor Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="actornumberdrop" runat="server">                
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <label for="categorynumber" class="col-sm-2 col-form-label">Category Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="catnumdrop" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <label for="studionumber" class="col-sm-2 col-form-label">Studio Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="stdnumdrop" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <label for="producernumber" class="col-sm-2 col-form-label">Producer Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="prdcnumdrop" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="dvdtitle" class="col-sm-2 col-form-label">DVD Title</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="dvdtitletxt" class="form-control" runat="server" placeholder="DVD Title"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="datereleased" class="col-sm-2 col-form-label">Date Released</label>
                <div class="col-sm-10">
                    <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>
                   
                </div>
            </div>
            <div class="form-group row">
                <label for="standardcharge" class="col-sm-2 col-form-label">Standard Charge</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="stdchargetxt" class="form-control" runat="server" placeholder="Standard Charge"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="penaltycharge" class="col-sm-2 col-form-label">Penalty Charge</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="peneltychargetxt"  class="form-control" runat="server" placeholder="Penalty Charge"></asp:TextBox>
                </div>
            </div>

            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click"  />

            </div>
        </div>
        <asp:GridView ID="dvdtitleview" OnRowCommand="dvdtitleviewCommand" class="table table-responsive table-striped" runat="server">
            <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("DVDNumber") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
        <div>
           
        </div>
        

    </div>
</asp:Content>
