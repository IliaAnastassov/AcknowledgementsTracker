<%@ Page Title="" Language="C#" MasterPageFile="~/AcknowledgementsTracker.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-11">
                <h2>Dashboard</h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <aside class="col-sm-3"></aside>

        <main class="col-sm-6">

            <%--User Acknowledgements--%>
            <fieldset>
                <legend>Your acknowledgements</legend>

                <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="True"
                    AutoGenerateColumns="False" ID="UserAcknowledgementsGridView" runat="server" OnRowDataBound="AcknowledgementsGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Tags">
                            <ItemTemplate>
                                <asp:Literal ID="ltrTags" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AuthorUsername" HeaderText="From" SortExpression="AuthorUsername" />
                        <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                    </Columns>
                </asp:GridView>

                <%--Buttons--%>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <a href="NewAcknowledgement.aspx" class="btn btn-primary btn-lg"><i class="glyphicon glyphicon-plus"></i></a>
                        <a href="Search.aspx" class="btn btn-info btn-lg"><i class="glyphicon glyphicon-search"></i></a>
                        <a href="EmployeeIndex.aspx" class="btn btn-info btn-lg"><i class="glyphicon glyphicon-globe"></i></a>
                    </div>
                </div>
            </fieldset>

            <%--Last 10 acknowledgements grid view--%>
            <fieldset>
                <legend>Last acknowledgements</legend>

                <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="True"
                    AutoGenerateColumns="False" ID="LastAcknowledgemetsGridView" runat="server" OnRowDataBound="AcknowledgementsGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Tags">
                            <ItemTemplate>
                                <asp:Literal ID="ltrTags" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BeneficiaryUsername" HeaderText="To" SortExpression="BeneficiaryUsername" />
                        <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                        <asp:BoundField DataField="AuthorUsername" HeaderText="From" SortExpression="AuthorUsername" />
                        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                    </Columns>
                </asp:GridView>
            </fieldset>

            <%--Today's Acknowledgements--%>
            <fieldset>
                <legend>Today's acknowledgements</legend>

                <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="True"
                    AutoGenerateColumns="False" ID="TodaysAcknowledgementsGridView" runat="server" OnRowDataBound="AcknowledgementsGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Tags">
                            <ItemTemplate>
                                <asp:Literal ID="ltrTags" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BeneficiaryUsername" HeaderText="To" SortExpression="BeneficiaryUsername" />
                        <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                        <asp:BoundField DataField="AuthorUsername" HeaderText="From" SortExpression="AuthorUsername" />
                        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                    </Columns>
                </asp:GridView>
            </fieldset>

            <%--This Week's Acknowledgements--%>
            <fieldset>
                <legend>This week's acknowledgements</legend>

                <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="True"
                    AutoGenerateColumns="False" ID="ThisWeeksAcknowledgementsGridView" runat="server" OnRowDataBound="AcknowledgementsGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Tags">
                            <ItemTemplate>
                                <asp:Literal ID="ltrTags" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BeneficiaryUsername" HeaderText="To" SortExpression="BeneficiaryUsername" />
                        <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                        <asp:BoundField DataField="AuthorUsername" HeaderText="From" SortExpression="AuthorUsername" />
                        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                    </Columns>
                </asp:GridView>
            </fieldset>

            <%--This Month's Acknowledgements--%>
            <fieldset>
                <legend>This month's acknowledgements</legend>

                <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="True"
                    AutoGenerateColumns="False" ID="ThisMonthsAcknowledgementsGridView" runat="server" OnRowDataBound="AcknowledgementsGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Tags">
                            <ItemTemplate>
                                <asp:Literal ID="ltrTags" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BeneficiaryUsername" HeaderText="To" SortExpression="BeneficiaryUsername" />
                        <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                        <asp:BoundField DataField="AuthorUsername" HeaderText="From" SortExpression="AuthorUsername" />
                        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                    </Columns>
                </asp:GridView>
            </fieldset>

            <%--Most Acknowledged person all time--%>
            <fieldset>
                <legend>All Time Champion</legend>

                <asp:Literal ID="ltrAllTimeChampion" runat="server" />
            </fieldset>

            <%--Top Ten Most Acknowledged persons all time--%>
            <fieldset>
                <legend>Most acknowledged persons all time</legend>

                <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="true"
                    AutoGenerateColumns="false" ID="AllTimeTopTenGridView" runat="server">
                    <Columns>
                        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                        <asp:BoundField DataField="Count" HeaderText="Number of Acknowledgements" SortExpression="Count" />
                    </Columns>
                </asp:GridView>
            </fieldset>
        </main>

        <aside class="col-sm-3"></aside>
    </div>

</asp:Content>
