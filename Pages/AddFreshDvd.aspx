<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddFreshDvd.aspx.cs" Inherits="RopeyDVDs.Pages.AddFreshDvd" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
       <h4>Add new Producer,Actor,Studio and DVD from here.</h4>
        <div class="formdiv">
            <asp:TextBox ID="actornumber" runat="server" Visible="false"></asp:TextBox>
            <h3>Actor Information</h3>
            <div class="form-group row mb-2">
                <label for="surname" class="col-sm-2 col-form-label">ActorSurname</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="surnametxt" class="form-control" runat="server" placeholder="ActorSurname"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row mb-2">
                <label for="firstname" class="col-sm-2 col-form-label">ActorFirstName</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="firstnametxt" class="form-control" runat="server" placeholder="ActorFirstname"></asp:TextBox>
                </div>
            </div>
            <hr />
            <h3>Producer Information</h3>
            <div class="form-group row ">
                <label for="producername" class="col-sm-2 col-form-label">Producer Name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="producernametxt" class="form-control" runat="server" placeholder="Producer Name"></asp:TextBox>
                </div>
            </div>
            <hr />
            <h3>Studio Information</h3>
            <div class="form-group row">
                <label for="studioname" class="col-sm-2 col-form-label">Studio Name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="studionametxt" class="form-control" runat="server" placeholder="Studio Name"></asp:TextBox>
                </div>
            </div>
            <hr />
             <h3>DVD Information</h3>
            
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
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"/>
                <%--<asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click" />
                <asp:Button class="btn btn-info button" ID="delete" runat="server" Text="Delete" />--%>
            </div>

        </div>

        <%--<div>
            <asp:GridView ID="actorview" OnRowCommand="actorviewCommand" class="table table-responsive table-striped" runat="server">
                <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("ActorNumber") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>            
        </div>--%>
    </div>
</asp:Content>

