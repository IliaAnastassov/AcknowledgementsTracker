<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="AcknowledgementsByTag.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.AcknowledgementsByTag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2 class="pageHeader">Acknowledgements for
                    <asp:Label CssClass="text-primary" ID="ltrTag" runat="server" />
                    <asp:Literal ID="ltrMonth" runat="server" />
                </h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <aside class="col-sm-2"></aside>

            <main class="col-sm-8">

                <%--Acknowledgements By Tag--%>
                <fieldset>
                    <legend>Acknowledgements</legend>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Timer--%>
                            <asp:Timer ID="tmrAcknowledgementsByTag" runat="server" OnTick="tmrAcknowledgementsByTag_Tick" Interval="100" />

                            <%--Loading Grid--%>
                            <asp:Panel ID="pnlAcknowledgementsByTag" runat="server">
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
                                AllowPaging="True" AutoGenerateColumns="False" ID="gvAcknowledgementsByTag" runat="server"
                                OnPageIndexChanging="gvAcknowledgementsByTag_PageIndexChanging">
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

</asp:Content>
