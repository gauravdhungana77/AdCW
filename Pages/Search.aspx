<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="RopeyDVDs.Pages.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<link href="../Content/Css/Global.css" rel="stylesheet" />--%>
   
    <%--    View dvd title with number of copies.--%>
    <div class="container">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label">View dvd title of actor who is cast memeber. </asp:Label>
            <div class="form-group row">
                <label for="search" class="col-sm-2 col-form-label">Actor Surname</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="searchbox" class="form-control" runat="server" placeholder="Actor Surname" AutoPostBack="false"></asp:TextBox>
                    <asp:Button ID="searchbtn" class="button btn btn-primary" runat="server" Text="Search" OnClick="searchbtn_Click" />
                </div>
            </div>
        </div>
            <asp:GridView ID="jointableview" class="table table-responsive table-striped mt-3" runat="server"></asp:GridView>
        <hr />

        <div>
            <asp:Label ID="Label2" runat="server" Text="Label">View dvd title with number of copies.</asp:Label>
            <div class="form-group row">
                <label for="search" class="col-sm-2 col-form-label">Actor Surname</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="searchbox2" class="form-control" runat="server" placeholder="Actor Surname" AutoPostBack="false"></asp:TextBox>
                    <asp:Button ID="searchbtn2" class="button btn btn-primary" runat="server" Text="Search" OnClick="searchbtn2_Click" />
                </div>
            </div>
        </div>
          <asp:GridView ID="dvdcopiescount" class="table table-responsive table-striped mt-3" runat="server"></asp:GridView>
        <%if (!role.Equals("Normal")){ %>
        <hr />

        <div>
            <asp:Label ID="Label3" runat="server" Text="Label">View dvd title  borrowed by member within 31 dayss</asp:Label>
            <div class="form-group row">
                <label for="search" class="col-sm-2 col-form-label">Member Lastname</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="searchbox3" class="form-control" runat="server" placeholder="Member lastname" AutoPostBack="false"></asp:TextBox>
                    <asp:Button ID="searchbtn3" class="button btn btn-primary" runat="server" Text="Search" OnClick="searchbtn3_Click" />
                </div>
            </div>
        </div>
         <asp:GridView ID="gridview3" class="table table-responsive table-striped mt-3" runat="server"></asp:GridView>
        <hr />

        <div>
            <asp:Label ID="Label4" runat="server" Text="Label">View latest copy of dvd loaned by the member</asp:Label>
            <div class="form-group row">
                <label for="search" class="col-sm-2 col-form-label">Copy number</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="searchbox4" class="form-control" runat="server" placeholder="Copy number" AutoPostBack="false"></asp:TextBox>
                    <asp:Button ID="searchbtn4" class="button btn btn-primary" runat="server" Text="Search" OnClick="searchbtn4_Click" />
                </div>
            </div>
        </div>
          <asp:GridView ID="gridview4" class="table table-responsive table-striped mt-3" runat="server"></asp:GridView>
        <%} %>
    </div>

 
</asp:Content>


