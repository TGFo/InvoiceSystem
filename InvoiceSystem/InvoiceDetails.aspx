<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceDetails.aspx.cs" Inherits="InvoiceSystem.InvoiceDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Invoice Details</h2>
    <asp:Label ID="lblInvoiceInfo" runat="server" Text=""></asp:Label>
    <br /><br />

    <div class="form-group">
        <label for="ddlCustomers">Customer:</label>
        <asp:DropDownList ID="ddlCustomers" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtInvoiceDate">Invoice Date:</label>
        <asp:TextBox ID="txtInvoiceDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtTotal">Total Amount:</label>
        <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Button ID="btnUpdate" runat="server" Text="Update Invoice" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete Invoice" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
    <br /><br />
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

    <hr />
    <h3>Invoice Items</h3>
    <asp:GridView ID="GridViewItems" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="InvoiceItemID" HeaderText="Item ID" />
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>
</asp:Content>
