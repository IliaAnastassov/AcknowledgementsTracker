<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2>Dashboard</h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <aside class="col-sm-2"></aside>

            <main class="col-sm-8">

                <%--User Acknowledgements--%>
                <fieldset>
                    <legend>Your acknowledgements</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                        AllowPaging="True" AutoGenerateColumns="False" ID="UserAcknowledgementsGridView" runat="server"
                        OnPageIndexChanging="UserAcknowledgementsGridView_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Tags">
                                <ItemTemplate>
                                    <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                        <ItemTemplate>
                                            <asp:HyperLink CssClass="label label-info label-margin" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}",
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
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}", Convert.ToString(Eval("AuthorUsername"))) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                        </Columns>
                    </asp:GridView>
                </fieldset>

                <%--Last 10 acknowledgements grid view--%>
                <fieldset>
                    <legend>Last acknowledgements</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                        AllowPaging="True" AutoGenerateColumns="False" ID="LastAcknowledgemetsGridView" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="Tags">
                                <ItemTemplate>
                                    <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                        <ItemTemplate>
                                            <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}",
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
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}", Convert.ToString(Eval("BeneficiaryUsername"))) %>' />
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
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}", Convert.ToString(Eval("AuthorUsername"))) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                        </Columns>
                    </asp:GridView>
                </fieldset>

                <%--Today's Acknowledgements--%>
                <fieldset>
                    <legend>Today's acknowledgements</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                        AllowPaging="True" AutoGenerateColumns="False" ID="TodaysAcknowledgementsGridView" runat="server"
                        OnPageIndexChanging="TodaysAcknowledgementsGridView_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Tags">
                                <ItemTemplate>
                                    <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                        <ItemTemplate>
                                            <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}",
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
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}", Convert.ToString(Eval("BeneficiaryUsername"))) %>' />
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
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}", Convert.ToString(Eval("AuthorUsername"))) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                        </Columns>
                    </asp:GridView>
                </fieldset>

                <%--This Week's Acknowledgements--%>
                <fieldset>
                    <legend>This week's acknowledgements</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                        AllowPaging="True" AutoGenerateColumns="False" ID="ThisWeeksAcknowledgementsGridView" runat="server"
                        OnPageIndexChanging="ThisWeeksAcknowledgementsGridView_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Tags">
                                <ItemTemplate>
                                    <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                        <ItemTemplate>
                                            <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}",
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
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}", Convert.ToString(Eval("BeneficiaryUsername"))) %>' />
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
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}", Convert.ToString(Eval("AuthorUsername"))) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                        </Columns>
                    </asp:GridView>
                </fieldset>

                <%--This Month's Acknowledgements--%>
                <fieldset>
                    <legend>This month's acknowledgements</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="True"
                        AutoGenerateColumns="False" ID="ThisMonthsAcknowledgementsGridView" runat="server"
                        OnPageIndexChanging="ThisMonthsAcknowledgementsGridView_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Tags">
                                <ItemTemplate>
                                    <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                        <ItemTemplate>
                                            <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}",
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
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}", Convert.ToString(Eval("BeneficiaryUsername"))) %>' />
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
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}", Convert.ToString(Eval("AuthorUsername"))) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                        </Columns>
                    </asp:GridView>
                </fieldset>

                <%--Top Ten Most Acknowledged persons all time--%>
                <fieldset>
                    <legend>Most acknowledged persons all time</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="true"
                        AutoGenerateColumns="false" ID="AllTimeTopTenGridView" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Literal Text="Name" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Literal ID="ltrEmployeeName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadUserFullName(Convert.ToString(Eval("Key"))) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Value" HeaderText="Number of Acknowledgements" />
                        </Columns>
                    </asp:GridView>
                </fieldset>

                <%--Top Ten Most Acknowledged persons this month--%>
                <fieldset>
                    <legend>Most acknowledged persons this month</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="true"
                        AutoGenerateColumns="false" ID="ThisMonthTopTenGridView" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Literal Text="Name" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Literal ID="ltrEmployeeName" runat="server" Text='<%# new AcknowledgementsTracker.Presentation.UIHelperService()
                                            .ReadUserFullName(Convert.ToString(Eval("Key"))) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Value" HeaderText="Number of Acknowledgements" />
                        </Columns>
                    </asp:GridView>
                </fieldset>

                <%--Top Ten Most Frequent Tags All Time--%>
                <fieldset>
                    <legend>Most frequently used tags all time</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="true"
                        AutoGenerateColumns="false" ID="MostFrequentTagsAllTimeGV" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Literal Text="Tag" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server"
                                        Text='<%# ((KeyValuePair<string, int>)Container.DataItem).Key %>'
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}",
                                            Uri.EscapeDataString(((KeyValuePair<string, int>)Container.DataItem).Key)) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Value" HeaderText="Times mentioned" />
                        </Columns>
                    </asp:GridView>
                </fieldset>

                <%--Top Ten Most Frequent Tags This Month--%>
                <fieldset>
                    <legend>Most frequently used tags this month</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="true"
                        AutoGenerateColumns="false" ID="MostFrequentTagsThisMonthGV" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Literal Text="Tag" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server"
                                        Text='<%# ((KeyValuePair<string, int>)Container.DataItem).Key %>'
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}",
                                            Uri.EscapeDataString(((KeyValuePair<string, int>)Container.DataItem).Key))%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Value" HeaderText="Times mentioned" />
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </main>

            <aside class="col-sm-2"></aside>
        </div>
    </div>

</asp:Content>
