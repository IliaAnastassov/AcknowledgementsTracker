<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="AcknowledgementsByUser.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.AcknowledgementsByUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2 class="pageHeader">
                    <asp:Literal ID="ltrUser" runat="server" />'s Acknowledgements
                </h2>
                <button type="submit" class="btn btn-primary btn-sm ml-10" onserverclick="btnCreateNew_ServerClick" id="btnCreateNew" runat="server"><i class="glyphicon glyphicon-plus"></i>&nbsp Acknowledge</button>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <aside class="col-sm-2"></aside>

            <main class="col-sm-8">

                <%--Acknowledgements By User--%>
                <fieldset>
                    <legend>Acknowledgements received</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                        AllowPaging="True" AutoGenerateColumns="False" ID="gvAcknowledgementsReceived" runat="server"
                        OnPageIndexChanging="gvAcknowledgementsReceived_PageIndexChanging">
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

                <fieldset>
                    <legend>Acknowledgements given</legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                        AllowPaging="True" AutoGenerateColumns="False" ID="gvAcknowledgementsGiven" runat="server"
                        OnPageIndexChanging="gvAcknowledgementsGiven_PageIndexChanging">
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
                            <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                        </Columns>
                    </asp:GridView>
                </fieldset>

            </main>

            <aside class="col-sm-2"></aside>
        </div>
    </div>

</asp:Content>
