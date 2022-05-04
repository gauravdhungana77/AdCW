<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Producer.aspx.cs" Inherits="RopeyDVDs.Pages.Producer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>

    <div class="container">
       <h4>Add new producer</h4>
        <div class="formdiv">
             <asp:TextBox ID="producernum"  runat="server" visible="false" ></asp:TextBox>
            <div class="form-group row mb-2">
                <label for="producername" class="col-sm-2 col-form-label">Producer Name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="producernametxt" class="form-control" runat="server" placeholder="Producer Name"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                 <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click" />
                 <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" OnClick="delete_Click" style="height: 36px"/>
            </div>
        </div>
        <h4>Available producer</h4>
        <asp:GridView ID="producerview" class="table table-responsive table-striped" OnRowCommand="producerviewNumber" runat="server">
            <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("ProducerNumber") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </div>
</asp:Content>
