<%@ Page Title="" Language="C#" MasterPageFile="~/AcknowledgementsTracker.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Search.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-11">
                <h2>Search</h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <aside class="col-sm-3"></aside>

        <main class="col-sm-6">
            <fieldset>
                <legend>Search for employees, acknowledgements or tags</legend>

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
                        <button type="submit" class="btn btn-info btn-lg" runat="server" id="SearchBtn" onserverclick="SearchBtn_ServerClick" tabindex="200"><i class="glyphicon glyphicon-search"></i></button>
                        <button type="reset" class="btn btn-default btn-lg" tabindex="300"><i class="glyphicon glyphicon-repeat"></i></button>
                        <a href="Dashboard.aspx" class="btn btn-default btn-lg" tabindex="400"><i class="glyphicon glyphicon-remove"></i></a>
                    </div>
                </div>
            </fieldset>

            <%--RESULTS--%>

            <%--Employees--%>
            <fieldset id="fldsEmployeesResults" runat="server" visible="false">
                <legend>Employees</legend>

                <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                    AllowPaging="true" AutoGenerateColumns="False" ID="EmployeesResultsGridView" runat="server"
                    OnPageIndexChanging="EmployeesResultsGridView_PageIndexChanging">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
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
                                <asp:Literal ID="ltrTags" runat="server" Text='<%#GetTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Literal Text="To" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="ltrBeneficiaryName" runat="server" Text='<%#GetUserFullName(Convert.ToString(Eval("BeneficiaryUsername")))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Literal Text="From" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="ltrAuthorName" runat="server" Text='<%#GetUserFullName(Convert.ToString(Eval("AuthorUsername")))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                    </Columns>
                </asp:GridView>
            </fieldset>
        </main>

        <aside class="col-sm-3"></aside>
    </div>

</asp:Content>
