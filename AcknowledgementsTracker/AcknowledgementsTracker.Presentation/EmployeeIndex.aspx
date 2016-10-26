<%@ Page Title="" Language="C#" MasterPageFile="~/AcknowledgementsTracker.Master" AutoEventWireup="true" CodeBehind="EmployeeIndex.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.EmployeeIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-11">
                <h2>Employee Index</h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <aside class="col-sm-3"></aside>

        <main class="col-sm-6">
            <fieldset>
                <legend>Proxiad Employees and their acknowledgements</legend>

                <%--Data--%>
                <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                    AllowPaging="True" AutoGenerateColumns="False" DataSourceID="EmployeesODS" ID="EmployeesGridView" runat="server">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="EmployeesODS" runat="server" SelectMethod="ReadAllUsersData" TypeName="AcknowledgementsTracker.Business.Logic.LdapAccountService"></asp:ObjectDataSource>

                <%--Buttons--%>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <a href="Dashboard.aspx" class="btn btn-primary btn-lg"><i class="glyphicon glyphicon-dashboard"></i></a>
                    </div>
                </div>

            </fieldset>
        </main>

        <aside class="col-sm-3"></aside>
    </div>

</asp:Content>
