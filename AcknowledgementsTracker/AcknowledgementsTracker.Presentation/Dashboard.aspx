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
            <fieldset>
                <legend>Your acknowledgements</legend>

                <%--Data--%>
                <%--              <table class="table table-striped table-hover" visible="True" id="AcknowledgementsTable" runat="server">
                    <tr>
                        <th>From</th>
                        <th>Content</th>
                        <th>Tags</th>
                        <th>Date</th>
                    </tr>
                </table>--%>
                <asp:HiddenField runat="server" ID="hfUsername" />
                <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped" AllowPaging="True" AutoGenerateColumns="False" ID="AcknowledgementsGridView" runat="server" DataSourceID="AcknowledgementsODS">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="AuthorUsername" HeaderText="From" SortExpression="AuthorUsername" />
                        <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                    </Columns>
                </asp:GridView>

                <asp:ObjectDataSource ID="AcknowledgementsODS" runat="server" SelectMethod="Read" TypeName="AcknowledgementsTracker.Business.Logic.AcknowledgementDtoService">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfUsername" Name="username" PropertyName="Value" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <%--Buttons--%>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <a href="NewAcknowledgement.aspx" class="btn btn-primary btn-lg"><i class="glyphicon glyphicon-plus"></i></a>
                        <a href="Search.aspx" class="btn btn-info btn-lg"><i class="glyphicon glyphicon-search"></i></a>
                        <a href="EmployeeIndex.aspx" class="btn btn-info btn-lg"><i class="glyphicon glyphicon-globe"></i></a>
                    </div>
                </div>

            </fieldset>
        </main>

        <aside class="col-sm-3"></aside>
    </div>

</asp:Content>
