<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="StipendijaTabelarni.aspx.cs" Inherits="KorisnickiInterfejs.StipendijaTabelarni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style1
        {
            width: 237px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                 TABELARNI PRIKAZ STIPENDIJA</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Filter (naziv):</td>
            <td>
                <asp:TextBox ID="txbFilter" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltriraj" runat="server" onclick="btnFiltriraj_Click" 
                    Text="FILTRIRAJ" />
                <asp:Button ID="btnSvi" runat="server" onclick="btnSvi_Click" Text="SVI" 
                    Width="68px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gvSpisakStipendija" runat="server" Height="211px" Width="500px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                     <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                     <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                     <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F7F7F7" />
                     <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                     <SortedDescendingCellStyle BackColor="#E5E5E5" />
                     <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
