<%@ Page Title="" Language="C#" MasterPageFile="~/AcknowledgementsTracker.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Search.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h2>Search</h2>
    <p>
        <asp:Label ID="TagsLabel" runat="server" Text="Tags:"></asp:Label>
        <asp:TextBox ID="TagsTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="TextLabel" runat="server" Text="Text:"></asp:Label>
        <asp:TextBox ID="TextTextBox" runat="server"></asp:TextBox>
    </p>
</asp:Content>
