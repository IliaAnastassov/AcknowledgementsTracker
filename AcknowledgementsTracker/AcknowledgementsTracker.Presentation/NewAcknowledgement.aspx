<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="NewAcknowledgement.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.NewAcknowledgement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <h2>New Acknowledgement</h2>

    <div class="container-fluid">
        <div class="row">
            <aside class="col-sm-3"></aside>

            <main class="col-sm-6">
                <fieldset>
                    <legend>Give someone credit</legend>

                    <%--Input--%>
                    <div class="form-group">
                        <label for="BeneficiaryTextBox" class="col-lg-2 control-label text-right">To</label>
                        <div class="col-lg-10">
                            <input type="text" class="form-control" placeholder="Firstname Lastname" required runat="server" id="BeneficiaryTextBox">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="ContentTextBox" class="col-lg-2 control-label text-right">Content</label>
                        <div class="col-lg-10">
                            <textarea class="form-control" rows="6" placeholder="Thank you for..." required runat="server" id="ContentTextBox"></textarea>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="TagsTextBox" class="col-lg-2 control-label text-right">Tags</label>
                        <div class="col-lg-10">
                            <input type="text" class="form-control" placeholder="#tag" required runat="server" id="TagsTextBox">
                        </div>
                    </div>

                    <%--Buttons--%>
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <button class="btn btn-info" id="CreateNewAcknowledgementBtn" runat="server" onserverclick="CreateNewAcknowledgementBtn_Click"><i class="glyphicon glyphicon-ok"></i></button>
                            <button type="reset" class="btn btn-default" id="ResetBtn" runat="server" onserverclick="ResetBtn_ServerClick"><i class="glyphicon glyphicon-repeat"></i></button>
                            <a href="Dashboard.aspx" class="btn btn-default"><i class="glyphicon glyphicon-remove"></i></a>
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
    </div>

</asp:Content>
