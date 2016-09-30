<%@ Page Title="" Language="C#" MasterPageFile="~/AcknowledgementsTracker.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2>Login</h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <aside class="col-sm-3"></aside>

        <main class="col-sm-6">
            <fieldset runat="server">
                <legend>Use your Proxiad credentials</legend>

                <%--Input--%>
                <div class="form-group">
                    <label for="inputEmail" class="col-lg-2 control-label text-right">Email</label>
                    <div class="col-lg-10">
                        <input type="email" class="form-control" id="inputEmail" placeholder="username@proxiad.com" required>
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputPassword" class="col-lg-2 control-label text-right">Password</label>
                    <div class="col-lg-10">
                        <input type="password" class="form-control" id="inputPassword" placeholder="password" required>
                    </div>
                </div>

                <%--Buttons--%>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <button type="submit" class="btn btn-primary btn-lg"><i class="glyphicon glyphicon-ok"></i></button>
                        <button type="reset" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-repeat"></i></button>
                    </div>
                </div>
            </fieldset>
        </main>

        <aside class="col-sm-3"></aside>
    </div>

</asp:Content>
