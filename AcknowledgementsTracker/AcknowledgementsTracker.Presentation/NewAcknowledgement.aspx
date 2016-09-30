<%@ Page Title="" Language="C#" MasterPageFile="~/AcknowledgementsTracker.Master" AutoEventWireup="true" CodeBehind="NewAcknowledgement.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.NewAcknowledgement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-11">
                <h2>New Acknowledgement</h2>
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
                <legend>Give someone credit</legend>

                <%--Input--%>
                <div class="form-group">
                    <label for="inputBeneficiary" class="col-lg-2 control-label text-right">To</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="inputBeneficiary" placeholder="Firstname Lastname" required>
                    </div>
                </div>

                <div class="form-group">
                    <label for="contentText" class="col-lg-2 control-label text-right">Content</label>
                    <div class="col-lg-10">
                        <textarea class="form-control" rows="6" id="contentText" placeholder="Thank you for..." required></textarea>
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputTags" class="col-lg-2 control-label text-right">Tags</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="inputTags" placeholder="#tag" required>
                    </div>
                </div>

                <%--Buttons--%>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <button type="submit" class="btn btn-primary btn-lg"><i class="glyphicon glyphicon-ok"></i></button>
                        <button type="reset" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-repeat"></i></button>
                        <a href="Dashboard.aspx" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-remove"></i></a>
                    </div>
                </div>
            </fieldset>
        </main>

        <aside class="col-sm-3"></aside>
    </div>

</asp:Content>
