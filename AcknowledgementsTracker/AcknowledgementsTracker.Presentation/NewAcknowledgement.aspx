﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="NewAcknowledgement.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.NewAcknowledgement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2 class="pageHeader">New Acknowledgement</h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <aside class="col-sm-3"></aside>
            <main class="col-sm-6">

                <asp:UpdatePanel ID="updatePanel" runat="server">
                    <ContentTemplate>

                        <fieldset>
                            <legend>Give someone credit</legend>
                            <asp:UpdateProgress ID="progress1" runat="server" DisplayAfter="300" DynamicLayout="true">
                                <ProgressTemplate>
                                    <img src="Images/progress.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>

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
                                    <input type="text" class="form-control" placeholder="tag" required runat="server" id="TagsTextBox">
                                </div>
                            </div>

                            <%--Buttons--%>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <button class="btn btn-info mt-10" id="CreateNewAcknowledgementBtn" runat="server" onserverclick="CreateNewAcknowledgementBtn_Click"><i class="glyphicon glyphicon-ok"></i></button>
                                    <button type="reset" class="btn btn-default mt-10" id="ResetBtn" runat="server" onserverclick="ResetBtn_ServerClick"><i class="glyphicon glyphicon-repeat"></i></button>
                                    <a href="Dashboard.aspx" class="btn btn-default mt-10"><i class="glyphicon glyphicon-remove"></i></a>
                                </div>
                            </div>
                        </fieldset>

                        <%--Error label--%>
                        <div>
                            <label class="alert-warning" id="lblError" runat="server" visible="false">Please fill all the boxes</label>
                        </div>

                        <%--Success label--%>
                        <div>
                            <label class="alert-success" id="lblSuccess" runat="server" visible="false">New acknowledgement created</label>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </main>

            <aside class="col-sm-3"></aside>
        </div>
    </div>

</asp:Content>
