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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrEmployees" runat="server" OnTick="tmrEmployees_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlEmployees" runat="server">
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
                                AllowPaging="True" AutoGenerateColumns="False" ID="gvEmployees" runat="server" OnPageIndexChanging="gvEmployees_PageIndexChanging">
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
                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                    <asp:BoundField DataField="Team" HeaderText="Team" SortExpression="Team" />
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
