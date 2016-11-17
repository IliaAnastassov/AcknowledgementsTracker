<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="NewAcknowledgement.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.NewAcknowledgement" %>

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
                                <label for="txtbBeneficiary" class="col-lg-2 control-label text-right">To</label>
                                <div class="col-lg-10">
                                    <input type="text" class="form-control" placeholder="Firstname Lastname" required runat="server" id="txtbBeneficiary">
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtbContent" class="col-lg-2 control-label text-right">Content</label>
                                <div class="col-lg-10">
                                    <textarea class="form-control" rows="6" placeholder="Thank you for..." required runat="server" id="txtbContent"></textarea>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtbTags" class="col-lg-2 control-label text-right">Tags</label>
                                <div class="col-lg-10">
                                    <input type="text" class="form-control" placeholder="tag" required runat="server" id="txtbTags">
                                </div>
                            </div>

                            <%--Buttons--%>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button CssClass="btn btn-info mt-10" ID="btnCreateNewAcknowledgement" runat="server" OnClick="btnCreateNewAcknowledgement_Click" Text="Acknowledge" />
                                    <button type="reset" class="btn btn-default mt-10" id="btnReset" runat="server" onserverclick="btnReset_ServerClick">Reset</button>
                                    <a href="Dashboard.aspx" class="btn btn-default mt-10">Cancel</a>
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
