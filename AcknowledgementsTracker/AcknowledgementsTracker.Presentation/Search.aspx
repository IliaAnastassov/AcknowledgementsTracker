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

    <div class="container-fluid">
        <div class="row">
            <aside class="col-sm-4"></aside>

            <main class="col-sm-4">
                <fieldset>
                    <legend>Search for employees, acknowledgements or tags</legend>

                    <asp:Panel ID="SearchPanel" runat="server" DefaultButton="btnSearch">
                        <%--Input--%>
                        <div class="form-group">
                            <label for="SearchTextBox" class="col-lg-2 control-label text-right">Search</label>
                            <div class="col-lg-10">
                                <input type="text" class="form-control" placeholder="enter your query" required id="SearchTextBox" runat="server" tabindex="100">
                            </div>
                        </div>

                        <%--Buttons--%>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:LinkButton CssClass="btn btn-info mt-10" ID="btnSearch" runat="server" OnClick="btnSearch_Click" TabIndex="200"><span aria-hidden="true" class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                <button type="reset" class="btn btn-default mt-10" id="ResetBtn" runat="server" onserverclick="ResetBtn_ServerClick" tabindex="300"><i class="glyphicon glyphicon-repeat"></i></button>
                                <a href="Dashboard.aspx" class="btn btn-default mt-10" tabindex="400"><i class="glyphicon glyphicon-remove"></i></a>
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

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                        AllowPaging="true" AutoGenerateColumns="False" ID="EmployeesResultsGridView" runat="server"
                        OnPageIndexChanging="EmployeesResultsGridView_PageIndexChanging">
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
                </fieldset>

                <%--Acknowledgements--%>
                <fieldset id="fldsAcknowledgementsResults" runat="server" visible="false">
                    <legend>Acknowledgements</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                        AllowPaging="true" AutoGenerateColumns="False" ID="AcknowledgementsResultsGridView" runat="server"
                        OnPageIndexChanging="AcknowledgementsResultsGridView_PageIndexChanging">
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
                </fieldset>
            </main>

            <aside class="col-sm-2"></aside>
        </div>
    </div>

</asp:Content>
