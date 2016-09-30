<%@ Page Title="" Language="C#" MasterPageFile="~/AcknowledgementsTracker.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Search.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-11">
                <h2>Search</h2>
            </div>
            <div class="col-sm-1">
                <a href="Login.aspx" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-off"></i></a>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <aside class="col-sm-3"></aside>

        <main class="col-sm-6">
            <fieldset runat="server">
                <legend>Search for people, content or tags</legend>

                <%--Input--%>
                <div class="form-group">
                    <label for="inputSearch" class="col-lg-2 control-label text-right">Search</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="inputSearch" placeholder="enter your query" required>
                    </div>
                </div>

                <%--Buttons--%>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <button type="submit" class="btn btn-info btn-lg"><i class="glyphicon glyphicon-search"></i></button>
                        <button type="reset" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-repeat"></i></button>
                        <a href="Dashboard.aspx" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-remove"></i></a>
                    </div>
                </div>
            </fieldset>
        </main>

        <aside class="col-sm-3"></aside>
    </div>

</asp:Content>
