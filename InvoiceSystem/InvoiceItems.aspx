<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceItems.aspx.cs" Inherits="InvoiceSystem.InvoiceItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Manage Invoice Items</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    
    <asp:GridView ID="GridViewInvoiceItems" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" 
        OnRowCommand="GridViewInvoiceItems_RowCommand" DataKeyNames="InvoiceItemID,ItemID">
        <Columns>
            <asp:BoundField DataField="InvoiceItemID" HeaderText="ID" />
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="EditItem" 
                        CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="DeleteItem" 
                        CommandArgument='<%# Container.DataItemIndex %>' 
                        OnClientClick="return confirm('Are you sure you want to delete this invoice item?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <hr />
    <h3>Add / Update Invoice Item</h3>
    <!-- Hidden field to store the InvoiceItemID when editing -->
    <asp:HiddenField ID="hfInvoiceItemID" runat="server" />
    <div class="form-group">
        <label for="ddlItems">Item:</label>
        <asp:DropDownList ID="ddlItems" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtQuantity">Quantity:</label>
        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Button ID="btnAddUpdate" runat="server" Text="Add Invoice Item" CssClass="btn btn-primary" OnClick="btnAddUpdate_Click" />
</asp:Content>
