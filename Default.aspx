<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RopeyDVDs._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Css/Default.css" rel="stylesheet" />
    <div class="background_main">
        <div class="caption_main">
            <div class="captionn_heading">
                <h3>Ropey DVD</h3>
            </div>
            <div class="caption">
                <p>If you buy a dvd you have a copy. If you want a backup copy you buy another one.</p>
            </div>
        </div>

    </div>

    <div class="jumbotron">
        <h1>Our Collections</h1>        
    </div>
    <div class="row">
        <div class="column">
            <img src="Content/Images/dvd-cd-display-in-store.jpg"  class="image"/>
            <img src="Content/Images/p_avengersendgame_19751_e14a0104.jpeg" class="image"/>
            <img src="Content/Images/Captain_America_The_First_Avenger_poster.jpg" />
            <img src="Content/Images/ironman.jpg" />
        </div>
         <div class="column">
             <img src="Content/Images/man-of-steel-man-of-steel-34785819-1024-1492.png" />
             <img src="Content/Images/1054161_6756230.jpg" />
             <img src="Content/Images/5bff2157-7614-4183-a4a7-b9d14d3f9c9c.jpg" />
             <img src="Content/Images/X-Men_-_Apocalypse.jpg" />

        </div>
         <div class="column">
             <img src="Content/Images/mirzapur-2-twitter-review.jpg" />
             <img src="Content/Images/Deadpool_2_poster.jpg" />
             <img src="Content/Images/allu_arjun_pushpa_box_office_d_1200x768_0-sixteen_nine.jpeg" />
             <img src="Content/Images/rrr-review.jpg" />
        </div>
             <div class="column">
                 <img src="Content/Images/Krish-3-2013.jpg" />
                 <img src="Content/Images/KGF-Interview.jpg" />
                 <img src="Content/Images/Bahubali-The-beginning.jpg" />
                 <img src="Content/Images/peaky-blinders.jpg" />
             </div>
    </div>

    <div class="row m-0 p-0">      
            <div class="action_movie1">
               
            </div>
     </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
