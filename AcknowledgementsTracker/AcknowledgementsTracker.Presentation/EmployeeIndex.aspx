<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="EmployeeIndex.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.EmployeeIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2 class="pageHeader">Employee Index</h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <aside class="col-sm-2"></aside>

            <main class="col-sm-8">
                <fieldset>
                    <legend>Proxiad Employees</legend>

                    <%--Data--%>
                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                        AllowPaging="True" AutoGenerateColumns="False" ID="gvEmployees" runat="server" OnPageIndexChanging="gvEmployees_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Literal Text="Name" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkName" runat="server" Text='<%# Eval("Name") %>'
                                        NavigateUrl='<%# string.Format("~/AcknowledgementsByUser.aspx?user={0}", Convert.ToString(Eval("Username"))) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:BoundField DataField="Team" HeaderText="Team" SortExpression="Team" />
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </main>

            <aside class="col-sm-2"></aside>
        </div>
    </div>

</asp:Content>
