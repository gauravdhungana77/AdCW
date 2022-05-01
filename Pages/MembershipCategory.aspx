﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MembershipCategory.aspx.cs" Inherits="RopeyDVDs.Pages.MembershipCategory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Css/Global.css" rel="stylesheet" />
    <%-- <h2><%: Title %></h2>--%>
    <div class="container">
        <div class="formdiv">
             <asp:TextBox ID="membershipcatnum"  runat="server" visible="false" ></asp:TextBox>
            <div class="form-group row">
                <label for="categorydescription" class="col-sm-2 col-form-label">Membership Category Description</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="categorydesctxt" class="form-control" runat="server" placeholder="Category description"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="membershiploan" class="col-sm-2 col-form-label">Membership Category Total Loan</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="membershiploantxt" class="form-control" runat="server" placeholder="Total loan"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button class="btn btn-info button" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"  />
                <asp:Button class="btn btn-info button" ID="edit" runat="server" Text="Edit" OnClick="edit_Click"  />
            </div>
        </div>

        <asp:GridView ID="membershipcategoryview" class="table table-responsive table-striped" OnRowCommand="membershipcategoryCommand" runat="server">
            <Columns>                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("MembershipCategoryNumber") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </div>
</asp:Content>