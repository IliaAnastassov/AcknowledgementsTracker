<%@ Page Title="" Language="C#" MasterPageFile="~/AcknowledgementsTracker.Master" AutoEventWireup="true" CodeBehind="NewAcknowledgement.aspx.cs" Inherits="AcknowledgementsTracker.Presentation.NewAcknowledgement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/NewAcknowledgement.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h2>New Acknowledgement</h2>
    <p>
        <asp:Label ID="BeneficiaryLabel" runat="server" Text="To:"></asp:Label>
        <asp:TextBox ID="BeneficiaryTextBox" runat="server" TabIndex="100" Width="500px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="TextLabel" runat="server" Text="Text:"></asp:Label>
        <asp:TextBox ID="ContentTextBox" runat="server" Rows="10" TabIndex="200" TextMode="MultiLine" Width="500px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="TagsLabel" runat="server" Text="Tags:"></asp:Label>
        <asp:TextBox ID="TagsTextBox" runat="server" TabIndex="300" Width="500px"></asp:TextBox>
    </p>
</asp:Content>
