<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Search.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2 class="pageHeader">Search</h2>
            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="mainUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row">
                    <aside class="col-sm-4"></aside>

                    <main class="col-sm-4">
                        <fieldset>
                            <legend>Search for employees, acknowledgements or tags</legend>

                            <asp:Panel runat="server" DefaultButton="btnSearch">
                                <%--Input--%>
                                <div class="form-group">
                                    <label for="txtbSearch" class="col-lg-2 control-label text-right">Search</label>
                                    <div class="col-lg-10">
                                        <input type="text" class="form-control" placeholder="enter your query" required id="txtbSearch" runat="server" tabindex="100">
                                    </div>
                                </div>

                                <%--Buttons--%>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <asp:Button CssClass="btn btn-info mt-10" ID="btnSearch" runat="server" OnClick="btnSearch_Click" TabIndex="200" Text="Search" />
                                        <button type="reset" class="btn btn-default mt-10" id="btnReset" runat="server" onserverclick="btnReset_ServerClick" tabindex="300">Reset</button>
                                        <a href="Dashboard.aspx" class="btn btn-default mt-10" tabindex="400">Cancel</a>
                                    </div>
                                </div>
                            </asp:Panel>
                        </fieldset>

                        <%--Error label--%>
                        <div id="ErrorMsg">
                            <label class="alert-warning" id="ErrorLabel" runat="server"></label>
                        </div>
                    </main>
                </div>
            </div>

            <%--RESULTS--%>

            <%--Employees--%>
            <div class="container-fluid">
                <div class="row">
                    <aside class="col-sm-2"></aside>

                    <main class="col-sm-8">
                        <fieldset id="fldsEmployeesResults" runat="server" visible="false">
                            <legend>Employees</legend>

                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <%--Timer--%>
                                    <asp:Timer ID="tmrEmployeesResults" runat="server" OnTick="tmrEmployeesResults_Tick" Interval="100" />

                                    <%--Loading Grid--%>
                                    <asp:Panel ID="pnlEmployeesResults" runat="server">
                                        <table class="table table-bordered table-condensed table-hover table-striped mb-0 bb-none">
                                            <tr>
                                                <th scope="col">Name</th>
                                                <th scope="col">Email</th>
                                                <th scope="col">Team</th>
                                            </tr>
                                        </table>
                                        <asp:Panel CssClass="table table-bordered progress-parent" Height="350px" runat="server">
                                            <img src="Images/progress.gif" />
                                        </asp:Panel>
                                    </asp:Panel>

                                    <%--Bound Grid--%>
                                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                                        AllowPaging="true" AutoGenerateColumns="False" ID="gvEmployeesResults" runat="server"
                                        OnPageIndexChanging="gvEmployeesResults_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Literal Text="Name" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="lnkName" runat="server" Text='<%# Eval("Name") %>'
                                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}&mode=allTime", Convert.ToString(Eval("Username"))) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                            <asp:BoundField DataField="Team" HeaderText="Team" />
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </fieldset>

                        <%--Acknowledgements--%>
                        <fieldset id="fldsAcknowledgementsResults" runat="server" visible="false">
                            <legend>Acknowledgements</legend>

                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <%--Timer--%>
                                    <asp:Timer ID="tmrAcknowledgementsResults" runat="server" OnTick="tmrAcknowledgementsResults_Tick" Interval="100" />

                                    <%--Loading Grid--%>
                                    <asp:Panel ID="pnlAcknowledgementsResults" runat="server">
                                        <table class="table table-bordered table-condensed table-hover table-striped mb-0 bb-none">
                                            <tr>
                                                <th scope="col">Tags</th>
                                                <th scope="col">To</th>
                                                <th scope="col">Text</th>
                                                <th scope="col">From</th>
                                                <th scope="col">Date Created</th>
                                            </tr>
                                        </table>
                                        <asp:Panel CssClass="table table-bordered progress-parent" Height="350px" runat="server">
                                            <img src="Images/progress.gif" />
                                        </asp:Panel>
                                    </asp:Panel>

                                    <%--Bound Grid--%>
                                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                                        AllowPaging="true" AutoGenerateColumns="False" ID="gvAcknowledgementsResults" runat="server"
                                        OnPageIndexChanging="gvAcknowledgementsResults_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Tags">
                                                <ItemTemplate>
                                                    <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService(
                                                    (AcknowledgementsTracker.Business.Interfaces.ILdapServerConnection)Session[AcknowledgementsTracker.Presentation.Global.LdapConnection])
                                                    .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                                        <ItemTemplate>
                                                            <asp:HyperLink CssClass="label label-info label-margin" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
                                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}&mode=allTime",
                                                                Uri.EscapeDataString(Container.DataItem.ToString())) %>' />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Literal Text="To" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="lnkBeneficiaryName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService(
                                                    (AcknowledgementsTracker.Business.Interfaces.ILdapServerConnection)Session[AcknowledgementsTracker.Presentation.Global.LdapConnection])
                                                    .ReadUserFullName(Convert.ToString(Eval("BeneficiaryUsername"))) %>'
                                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}&mode=allTime", Convert.ToString(Eval("BeneficiaryUsername"))) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Literal Text="From" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="lnkAuthorName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService(
                                                    (AcknowledgementsTracker.Business.Interfaces.ILdapServerConnection)Session[AcknowledgementsTracker.Presentation.Global.LdapConnection])
                                                    .ReadUserFullName(Convert.ToString(Eval("AuthorUsername"))) %>'
                                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}&mode=allTime", Convert.ToString(Eval("AuthorUsername"))) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </fieldset>
                    </main>

                    <aside class="col-sm-2"></aside>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
