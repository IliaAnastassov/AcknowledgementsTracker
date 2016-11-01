<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="AcknowledgementsByTag.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.AcknowledgementsByTag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2>Acknowledgements</h2>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <aside class="col-sm-2"></aside>

            <main class="col-sm-8">

                <%--Acknowledgements By Tag--%>
                <fieldset>
                    <legend>Acknowledgements for
                        <asp:Literal ID="ltrTag" runat="server" />
                    </legend>

                    <asp:GridView CssClass="table table-bordered table-condensed table-hover table-striped"
                        AllowPaging="True" AutoGenerateColumns="False" ID="gvAcknowledgementsByTag" runat="server"
                        OnPageIndexChanging="gvAcknowledgementsByTag_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Tags">
                                <ItemTemplate>
                                    <asp:Repeater ID="rptrTags" runat="server" DataSource='<%# GetTags((IEnumerable<AcknowledgementsTracker.DTO.TagDTO>)(Eval("Tags"))) %>'>
                                        <ItemTemplate>
                                            <asp:HyperLink CssClass="label label-info" ID="lnkTag" runat="server" Text="<%# Container.DataItem %>"
                                                NavigateUrl='<%# string.Format("~/AcknowledgementsByTag.aspx?tag={0}", Uri.EscapeDataString(Container.DataItem.ToString())) %>' />
                                        </ItemTemplate>
                                    </asp:Repeater>
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

            <aside class="col-sm-2"></aside>
        </div>
    </div>

</asp:Content>
