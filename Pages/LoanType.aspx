<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LoanType.aspx.cs" Inherits="RopeyDVDs.Pages.LoanType" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>

    <div class="container">
        <h4>Add new loan type</h4>
        <div class="formdiv">
              <asp:TextBox ID="loantypenumber" Visible="false"  runat="server" ></asp:TextBox>
            <div class="form-group row mb-2">
                <label for="ltype" class="col-sm-2 col-form-label">Loan Type</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="loantypetxt" class="form-control" runat="server" placeholder="Loan Type "></asp:TextBox>
                </div>
            </div>

            <div class="form-group row mb-2">
                <label for="loanDuration" class="col-sm-2 col-form-label">Loan Duration</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="loandurationtxt" class="form-control" runat="server" placeholder="Loan Duration"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click"/>
                 <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click" />
            </div>
        </div>

        <h4>Available loan type</h4>
        <asp:GridView ID="loantypeview" class="table table-responsive table-striped" OnRowCommand="LoantypeCommand" runat="server">
            <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("LoanTypeNumber") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>

    </div>
</asp:Content>