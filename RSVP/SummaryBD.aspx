<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile ="~/Site.master" CodeBehind="SummaryBD.aspx.cs" Inherits="RSVP.SummaryBD" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <h2>Список участников</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email"></asp:BoundField>
                    <asp:BoundField DataField="Phone" HeaderText="Phone" ReadOnly="True" SortExpression="Phone"></asp:BoundField>
                    <asp:BoundField DataField="Rdata" HeaderText="Rdata" ReadOnly="True" SortExpression="Rdata"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="SampleContext" EntityTypeName="" Select="new (Name, Email, Phone, Rdata, Reports, WillAttend)" TableName="GuestResponses">
            </asp:LinqDataSource>
        </div>
</asp:Content>
