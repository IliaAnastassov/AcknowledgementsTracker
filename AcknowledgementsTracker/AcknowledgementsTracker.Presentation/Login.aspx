<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedOut.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2 class="pageHeader">Login</h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <aside class="col-sm-4"></aside>

            <main class="col-sm-4">
                <asp:UpdatePanel ID="updatePanel" runat="server">
                    <ContentTemplate>
                        <fieldset>
                            <legend>Use your Proxiad-LDAP credentials to log in</legend>

                            <%--Input--%>
                            <div class="form-group">
                                <label for="txtbUsername" class="col-lg-2 control-label text-right">Username</label>
                                <div class="col-lg-10">
                                    <input type="text" class="form-control" placeholder="LDAP username" required id="txtbUsername" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtbPassword" class="col-lg-2 control-label text-right">Password</label>
                                <div class="col-lg-10">
                                    <input type="password" class="form-control" placeholder="LDAP password" required id="txtbPassword" runat="server" />
                                </div>
                            </div>

                            <%--Progress--%>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10" DynamicLayout="true">
                                <ProgressTemplate>
                                    <img class="col-lg-1" src="Images/progress.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>

                            <%--Buttons--%>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button CssClass="btn btn-info mt-10" ID="btnLogin" runat="server" OnClick="btnLogin_Click" OnClientClick="HideInputDelegate()" Text="Login" />
                                    <button type="reset" class="btn btn-default mt-10" onserverclick="btnReset_ServerClick" id="btnReset" runat="server">Reset</button>
                                </div>
                            </div>
                        </fieldset>

                        <%--Error label--%>
                        <div>
                            <label class="alert-warning" id="lblError" runat="server" visible="false"></label>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </main>

            <aside class="col-sm-4"></aside>
        </div>
    </div>
    <script type="text/javascript">
        function HideInputDelegate() {
            ////var username = document.getElementById('txtbUsername').value;
            ////var password = document.getElementById('txtbPassword').value;

            ////if (username !== null && password !== null) {
            ////}
            loginFunctions.HideInput('<%= lblError.ClientID %>', '<%= txtbUsername.ClientID %>', '<%= txtbPassword.ClientID %>');
        }
    </script>
</asp:Content>
