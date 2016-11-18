<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2 class="pageHeader">Dashboard</h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <aside class="col-sm-2">

                <%--Page Navigation--%>
                <nav class="navbar navbar-responsive navbar-left affix">
                    <ul class="nav nav-stacked">
                        <li class="nav-header">Acknowledgements</li>
                        <li><a href="#Mine">Mine</a></li>
                        <li><a href="#Last">Last</a></li>
                        <li><a href="#Todays">Today's</a></li>
                        <li><a href="#ThisWeeks">This Week's</a></li>
                        <li><a href="#ThisMonths">This Month's</a></li>
                        <li class="nav-header">Champions</li>
                        <li><a href="#AllTimeChampions">All Time</a></li>
                        <li><a href="#ThisMonthChampions">This Month</a></li>
                        <li class="nav-header">Frequent Tags</li>
                        <li><a href="#MostFrequentTagsAllTime">All Time</a></li>
                        <li><a href="#MostFrequentTagsThisMonth">This Month</a></li>
                    </ul>
                </nav>
            </aside>

            <main class="col-sm-8">

                <%--User Acknowledgements--%>
                <fieldset id="Mine">
                    <legend>My acknowledgements</legend>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrUserAcknowledgements" runat="server" OnTick="tmrUserAcknowledgements_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlUserAcknowledgementsLoader" runat="server">
                                <table class="table table-bordered table-condensed table-hover table-striped mb-0 bb-none">
                                    <tr>
                                        <th scope="col">Tags</th>
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
                                AllowPaging="True" AutoGenerateColumns="False" ID="gvUserAcknowledgements" runat="server"
                                OnPageIndexChanging="gvUserAcknowledgements_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Tags">
                                        <ItemTemplate>
                                            <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                                    .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                                <ItemTemplate>
                                                    <asp:HyperLink CssClass="label label-info label-margin" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
                                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}&mode=allTime",
                                                                Uri.EscapeDataString(Container.DataItem.ToString())) %>' />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Literal Text="From" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkAuthorName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
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

                <%--Last 10 acknowledgements grid view--%>
                <fieldset id="Last">
                    <legend>Last acknowledgements</legend>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrLastAcknowledgements" runat="server" OnTick="tmrLastAcknowledgements_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlLastAcknowledgements" runat="server">
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
                                AllowPaging="True" AutoGenerateColumns="False" ID="gvLastAcknowledgemets" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Tags">
                                        <ItemTemplate>
                                            <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                                <ItemTemplate>
                                                    <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
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
                                            <asp:HyperLink ID="lnkBeneficiaryName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
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
                                            <asp:HyperLink ID="lnkAuthorName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
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

                <%--Today's Acknowledgements--%>
                <fieldset id="Todays">
                    <legend>Today's acknowledgements</legend>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrTodaysAcknowledgements" runat="server" OnTick="tmrTodaysAcknowledgements_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlTodaysAcknowledgements" runat="server">
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
                                AllowPaging="True" AutoGenerateColumns="False" ID="gvTodaysAcknowledgements" runat="server"
                                OnPageIndexChanging="gvTodaysAcknowledgements_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Tags">
                                        <ItemTemplate>
                                            <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                                <ItemTemplate>
                                                    <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
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
                                            <asp:HyperLink ID="lnkBeneficiaryName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
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
                                            <asp:HyperLink ID="lnkAuthorName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
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

                <%--This Week's Acknowledgements--%>
                <fieldset id="ThisWeeks">
                    <legend>This week's acknowledgements</legend>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrThisWeeksAcnowledgements" runat="server" OnTick="tmrThisWeeksAcnowledgements_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlThisWeeksAcnowledgements" runat="server">
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
                                AllowPaging="True" AutoGenerateColumns="False" ID="gvThisWeeksAcknowledgements" runat="server"
                                OnPageIndexChanging="gvThisWeeksAcknowledgements_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Tags">
                                        <ItemTemplate>
                                            <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                                <ItemTemplate>
                                                    <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
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
                                            <asp:HyperLink ID="lnkBeneficiaryName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
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
                                            <asp:HyperLink ID="lnkAuthorName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
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

                <%--This Month's Acknowledgements--%>
                <fieldset id="ThisMonths">
                    <legend>This month's acknowledgements</legend>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrThisMonthAcknowledgements" runat="server" OnTick="tmrThisMonthAcknowledgements_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlThisMonthAcknowledgements" runat="server">
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
                            <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="True"
                                AutoGenerateColumns="False" ID="gvThisMonthsAcknowledgements" runat="server"
                                OnPageIndexChanging="ThisMonthsAcknowledgementsGridView_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Tags">
                                        <ItemTemplate>
                                            <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                                <ItemTemplate>
                                                    <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
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
                                            <asp:HyperLink ID="lnkBeneficiaryName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
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
                                            <asp:HyperLink ID="lnkAuthorName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
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

                <%--Top 10 Most Acknowledged persons all time--%>
                <fieldset id="AllTimeChampions">
                    <legend>Most acknowledged persons all time</legend>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrAllTimeTopTen" runat="server" OnTick="tmrAllTimeTopTen_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlAllTimeTopTen" runat="server">
                                <table class="table table-bordered table-condensed table-hover table-striped mb-0 bb-none">
                                    <tr>
                                        <th scope="col">Name</th>
                                        <th scope="col">Number of Acknowledgements</th>
                                    </tr>
                                </table>
                                <asp:Panel CssClass="table table-bordered progress-parent" Height="350px" runat="server">
                                    <img src="Images/progress.gif" />
                                </asp:Panel>
                            </asp:Panel>

                            <%--Bound Grid--%>
                            <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="true"
                                AutoGenerateColumns="false" ID="gvAllTimeTopTen" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Literal Text="Name" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadUserFullName(Convert.ToString(Eval("Key"))) %>'
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}&mode=allTime", Convert.ToString(Eval("Key"))) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Literal Text="Number of Acknowledgements" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkNumberOfAcknowledgements" runat="server" Text='<%# Eval("Value") %>'
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}&mode=allTime_Rec", Convert.ToString(Eval("Key"))) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>

                <%--Top 10 Most Acknowledged persons this month--%>
                <fieldset id="ThisMonthChampions">
                    <legend>Most acknowledged persons this month</legend>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrThisMonthTopTen" runat="server" OnTick="tmrThisMonthTopTen_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlThisMonthTopTen" runat="server">
                                <table class="table table-bordered table-condensed table-hover table-striped mb-0 bb-none">
                                    <tr>
                                        <th scope="col">Name</th>
                                        <th scope="col">Number of Acknowledgements</th>
                                    </tr>
                                </table>
                                <asp:Panel CssClass="table table-bordered progress-parent" Height="350px" runat="server">
                                    <img src="Images/progress.gif" />
                                </asp:Panel>
                            </asp:Panel>

                            <%--Bound Grid--%>
                            <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="true"
                                AutoGenerateColumns="false" ID="gvThisMonthTopTen" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Literal Text="Name" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadUserFullName(Convert.ToString(Eval("Key"))) %>'
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}&mode=allTime", Convert.ToString(Eval("Key"))) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Literal Text="Number of Acknowledgements" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkNumberOfAcknowledgements" runat="server" Text='<%#Eval("Value") %>'
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}&mode=thisMonth", Convert.ToString(Eval("Key"))) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>

                <%--Top 10 Most Frequent Tags All Time--%>
                <fieldset id="MostFrequentTagsAllTime">
                    <legend>Most frequently used tags all time</legend>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrMostFrequentTagsAllTime" runat="server" OnTick="tmrMostFrequentTagsAllTime_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlMostFrequentTagsAllTime" runat="server">
                                <table class="table table-bordered table-condensed table-hover table-striped mb-0 bb-none">
                                    <tr>
                                        <th scope="col">Tag</th>
                                        <th scope="col">Times mentioned</th>
                                    </tr>
                                </table>
                                <asp:Panel CssClass="table table-bordered progress-parent" Height="350px" runat="server">
                                    <img src="Images/progress.gif" />
                                </asp:Panel>
                            </asp:Panel>

                            <%--Bound Grid--%>
                            <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="true"
                                AutoGenerateColumns="false" ID="gvMostFrequentTagsAllTime" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Literal Text="Tag" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server"
                                                Text='<%# ((KeyValuePair<string, int>)Container.DataItem).Key %>'
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}&mode=allTime",
                                            Uri.EscapeDataString(((KeyValuePair<string, int>)Container.DataItem).Key)) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Literal Text="Times mentioned" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" Text='<%# ((KeyValuePair<string, int>)Container.DataItem).Value %>'
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}&mode=allTime",
                                            Uri.EscapeDataString(((KeyValuePair<string, int>)Container.DataItem).Key)) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>

                <%--Top 10 Most Frequent Tags This Month--%>
                <fieldset id="MostFrequentTagsThisMonth">
                    <legend>Most frequently used tags this month</legend>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrMostFrequentTagsThisMonth" runat="server" OnTick="tmrMostFrequentTagsThisMonth_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlMostFrequentTagsThisMonth" runat="server">
                                <table class="table table-bordered table-condensed table-hover table-striped mb-0 bb-none">
                                    <tr>
                                        <th scope="col">Tag</th>
                                        <th scope="col">Times mentioned</th>
                                    </tr>
                                </table>
                                <asp:Panel CssClass="table table-bordered progress-parent" Height="350px" runat="server">
                                    <img src="Images/progress.gif" />
                                </asp:Panel>
                            </asp:Panel>

                            <%--Bound Grid--%>
                            <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="true"
                                AutoGenerateColumns="false" ID="gvMostFrequentTagsThisMonth" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Literal Text="Tag" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server"
                                                Text='<%# ((KeyValuePair<string, int>)Container.DataItem).Key %>'
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}&mode=allTime",
                                            Uri.EscapeDataString(((KeyValuePair<string, int>)Container.DataItem).Key))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Literal Text="Times mentioned" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" Text='<%# ((KeyValuePair<string, int>)Container.DataItem).Value %>'
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}&mode=thisMonth",
                                            Uri.EscapeDataString(((KeyValuePair<string, int>)Container.DataItem).Key)) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
            </main>

            <aside class="col-sm-2"></aside>
        </div>
    </div>

</asp:Content>
