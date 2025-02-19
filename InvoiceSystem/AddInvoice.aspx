<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddInvoice.aspx.cs" Inherits="InvoiceSystem.AddInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Add New Invoice</h2>
    <div class="form-group">
        <label for="ddlCustomers">Customer:</label>
        <asp:DropDownList ID="ddlCustomers" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtDate">Invoice Date:</label>
        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtTotal">Total Amount:</label>
        <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Button ID="btnSubmit" runat="server" Text="Add Invoice" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
</asp:Content>
