<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Loan.aspx.cs" Inherits="RopeyDVDs.Pages.Loan" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <div class="formdiv">
            <asp:TextBox ID="loansnumber" Visible="false" runat="server"></asp:TextBox>
            <div class="form-group row mb-2">
                <label for="loantypenum" class="col-sm-2 col-form-label">Loan Type Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="loantypenumdrop" class="form-control" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="copynumber" class="col-sm-2 col-form-label">Copy Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="copynumberdrop" class="form-control" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row mb-2">
                <label for="membernumber" class="col-sm-2 col-form-label">Member Number</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="membernumberdrop" class="form-control" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

          
            <div class="form-group row mb-2">
                <label for="dateout" class="col-sm-2 col-form-label">Date Out</label>
                <div class="col-sm-10">
                    <asp:Calendar ID="Dateout" runat="server"></asp:Calendar>
                   
                </div>
            </div>
             <div class="form-group row mb-2">
                <label for="datedue" class="col-sm-2 col-form-label">Date Due</label>
                <div class="col-sm-10">
                    <asp:Calendar ID="datedue" runat="server"></asp:Calendar>
                   
                </div>
            </div>
             <div class="form-group row mb-2">
                <label for="datereturned" class="col-sm-2 col-form-label">Date Returned</label>
                <div class="col-sm-10">
                    <asp:Calendar ID="datereturned" runat="server"></asp:Calendar>
                   
                </div>
            </div>
                     

            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                <asp:Button class="btn btn-info button" ID="Editbutton" runat="server" Text="Edit" OnClick="Editbutton_Click"/>
                <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click"/>
            </div>
        </div>
        <asp:GridView ID="loanview" OnRowCommand="loancommandview" class="table table-responsive table-striped" runat="server">
             <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("LoanNumber") %>' runat="server">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
        <div>
           
        </div>
        

    </div>
</asp:Content>

