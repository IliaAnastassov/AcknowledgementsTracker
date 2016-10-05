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
            <fieldset>
                <legend>Use your Proxiad credentials to log in</legend>

                <%--Input--%>
                <div class="form-group">
                    <label for="UsernameTextBox" class="col-lg-2 control-label text-right">Username</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" placeholder="username" required id="UsernameTextBox" runat="server">
                    </div>
                </div>

                <div class="form-group">
                    <label for="PasswordTextBox" class="col-lg-2 control-label text-right">Password</label>
                    <div class="col-lg-10">
                        <input type="password" class="form-control" placeholder="password" required id="PasswordTextBox" runat="server">
                    </div>
                </div>

                <%--Buttons--%>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <button type="submit" class="btn btn-primary btn-lg" onserverclick="Login_Click" id="LoginBtn" runat="server"><i class="glyphicon glyphicon-ok"></i></button>
                        <button type="reset" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-repeat"></i></button>
                    </div>
                </div>
            </fieldset>

            <%--Error label--%>
            <div id="ErrorMsg">
                <label class="alert-warning" id="ErrorLabel" runat="server"></label>
            </div>
        </main>

        <aside class="col-sm-3"></aside>
    </div>

</asp:Content>
