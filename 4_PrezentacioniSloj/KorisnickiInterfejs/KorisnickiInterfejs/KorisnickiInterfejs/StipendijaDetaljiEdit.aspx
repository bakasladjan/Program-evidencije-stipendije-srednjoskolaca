<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="StipendijaDetaljiEdit.aspx.cs" Inherits="KorisnickiInterfejs.StipendijaDetaljiEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
    .style1
    {
        width: 275px;
        text-align: right;
    }
    .style2
    {
        width: 400px;
    }
    .auto-style1 {
        width: 275px;
        text-align: right;
        height: 21px;
    }
    .auto-style2 {
        width: 400px;
        height: 21px;
    }
    .auto-style3 {
        height: 21px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
             STIPENDIJA - DETALJNI PRIKAZ ZA EDITOVANJE</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Sifra</td>
        <td class="style2">
            <asp:TextBox ID="txbSifra" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Naziv</td>
        <td class="style2">
            <asp:TextBox ID="txbNaziv" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
   
         <tr>
        <td class="style1">
            Iznos</td>
        <td class="style2">
            <asp:TextBox ID="txbIznos" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
         </tr>
    <tr>
        <td class="auto-style1">
            </td>
        <td class="auto-style2">
        </td>
        <td class="auto-style3">
            </td>
    </tr>
   
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Label ID="lblStatus" runat="server" Text="STATUS"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Button ID="btnObrisi" runat="server" Text="Obrisi" 
                onclick="btnObrisi_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Button ID="btnIzmeni" runat="server" Text="Omoguci izmenu" 
                onclick="btnIzmeni_Click" Width="133px" />
            <asp:Button ID="btnSnimiIzmenu" runat="server" onclick="btnSnimiIzmenu_Click" 
                Text="SNIMI IZMENU" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
