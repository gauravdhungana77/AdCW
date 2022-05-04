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
        <%} %>
    </div>




    <%--    View dvd title of actor who is cast memeber.--%>
    <div class="modal  fade" id="myModal" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">

            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <asp:GridView ID="jointableview" class="table table-responsive table-striped" runat="server"></asp:GridView>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                </div>
            </div>

        </div>
    </div>


    <%--    View dvd title with number of copies.--%>
    <!-- Modal -->
    <div class="modal fade" id="copycount" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle2">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:GridView ID="dvdcopiescount" class="table table-responsive table-striped" runat="server"></asp:GridView>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>


    <%--    View dvd title  borrowed by member within 31 days--%>
    <!-- Modal -->
    <div class="modal fade" id="memberloan" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle3">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:GridView ID="gridview3" class="table table-responsive table-striped" runat="server"></asp:GridView>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
      <%--    View latest copy of dvd loaned by the member--%>
    <!-- Modal -->
    <div class="modal fade" id="latestcopyloan" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" style="width:fit-content!important" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle4">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:GridView ID="gridview4" class="table table-responsive table-striped" runat="server"></asp:GridView>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>


    <script type='text/javascript'>
        function OpenModal() {
            $('[id*=myModal]').modal('show');
        }
        function CopyCount() {
            $('[id*=copycount]').modal('show');
        }
        function MemberLoan() {
            $('[id*=memberloan]').modal('show');
        }
        function copyLoan() {
            $('[id*=latestcopyloan]').modal('show');
        }
    </script>

</asp:Content>


