<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="InvoiceSystem.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Manage Customers</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    
    <!-- GridView to list customers -->
    <asp:GridView ID="GridViewCustomers" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" 
        OnRowCommand="GridViewCustomers_RowCommand" DataKeyNames="CustomerID">
        <Columns>
            <asp:BoundField DataField="CustomerID" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="ContactInfo" HeaderText="Contact Info" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="EditCustomer" 
                        CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="DeleteCustomer" 
                        CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="return confirm('Are you sure you want to delete this customer?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <hr />
    <h3>Add / Update Customer</h3>
    <!-- Hidden field to store the CustomerID when editing -->
    <asp:HiddenField ID="hfCustomerID" runat="server" />
    <div class="form-group">
        <label for="txtName">Name:</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtAddress">Address:</label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtContactInfo">Contact Info:</label>
        <asp:TextBox ID="txtContactInfo" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Button ID="btnAddUpdate" runat="server" Text="Add Customer" CssClass="btn btn-primary" OnClick="btnAddUpdate_Click" />
</asp:Content>