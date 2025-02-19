<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InvoiceSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All Invoices</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="InvoiceID" HeaderText="Invoice ID" />
            <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" />
            <asp:BoundField DataField="InvoiceDate" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" DataFormatString="{0:C}" />
            <asp:HyperLinkField DataNavigateUrlFields="InvoiceID" DataNavigateUrlFormatString="InvoiceItems.aspx?InvoiceID={0}" Text="View Details" />
        </Columns>
    </asp:GridView>
</asp:Content>
