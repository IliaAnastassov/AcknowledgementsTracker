<%@ Page Title="" Language="C#" MasterPageFile="~/AcknowledgementsTracker.Master" AutoEventWireup="true" CodeBehind="EmployeeIndex.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.EmployeeIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <asp:GridView ID="EmployeesGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="EmployeesODS">
        <Columns>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="EmployeesODS" runat="server" SelectMethod="GetAllUsersData" TypeName="AcknowledgementsTracker.Business.Logic.LdapAccountManager"></asp:ObjectDataSource>

</asp:Content>
