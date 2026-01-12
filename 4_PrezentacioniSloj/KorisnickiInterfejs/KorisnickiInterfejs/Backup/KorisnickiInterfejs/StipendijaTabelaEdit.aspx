<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="StipendijaTabelaEdit.aspx.cs" Inherits="KorisnickiInterfejs.StipendijaTabelaEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
    .style1
    {
        width: 238px;
    }
    .style2
    {
        font-size: medium;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <strong>SPISAK STIPENDIJA ZA AZURIRANJE</strong></td>
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
            <asp:GridView ID="gvSpisakStipendijaEdit" runat="server" Font-Underline="False" 
                Height="277px" onselectedindexchanged="gvSpisakStipendijaEdit_SelectedIndexChanged" 
                Width="600px" AutoGenerateSelectButton="True" HorizontalAlign="Center">
            </asp:GridView>
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
</table>
</asp:Content>
