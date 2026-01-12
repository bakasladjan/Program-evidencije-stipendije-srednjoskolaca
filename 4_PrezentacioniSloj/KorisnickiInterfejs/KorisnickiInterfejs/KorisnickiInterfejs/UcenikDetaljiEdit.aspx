<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UcenikDetaljiEdit.aspx.cs" Inherits="KorisnickiInterfejs.UcenikDetaljiEdit" %>
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
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
             UČENIK - DETALJNI PRIKAZ ZA EDITOVANJE</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            JMBG učenika</td>
        <td class="style2">
            <asp:TextBox ID="txbJMBGUcenika" runat="server" MaxLength="13" MinLength="13" Enabled="False"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="JMBG mora imati 13 cifara!"
                  runat="server" ControlToValidate="txbJMBGUcenika" ForeColor="Red" ValidationExpression="[0-9]{13}"></asp:RegularExpressionValidator>

        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Ime i prezime učenika</td>
        <td class="style2">
            <asp:TextBox ID="txbImeIPrezimeUcenika" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
         <tr>
        <td class="style1">
            Razred</td>
        <td class="style2">
            <asp:TextBox ID="txbRazred" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
         </tr>
         <tr>
        <td class="style1">
            Škola</td>
        <td class="style2">
            <asp:TextBox ID="txbSkola" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
         </tr>
    <tr>
        <td class="style1">
             Datum rođenja</td>
        <td class="style2">
            <asp:TextBox ID="txbDatumRodjenja" runat="server"  Enabled="False"></asp:TextBox>


        </td>
        <td>
             &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
             Adresa učenika</td>
        <td class="style2">
            <asp:TextBox ID="txbAdresaUcenika" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
             &nbsp;</td>
    </tr>

          <tr>
        <td class="style1">
             Kontakt telefon</td>
        <td class="style2">
            <asp:TextBox ID="txbKontaktTelefon" runat="server" Enabled="False"></asp:TextBox>
             

        </td>
        <td>
             &nbsp;</td>
    </tr>

          <tr>
        <td class="style1">
             Naziv stipendije</td>
        <td class="style2">
             <asp:DropDownList ID="ddlStipendija" runat="server" Height="16px" Width="233px" Enabled="False">
            </asp:DropDownList>
        </td>
        <td>
             &nbsp;</td>
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
                onclick="btnIzmeni_Click" Width="110px" />
            <asp:Button ID="btnSnimiIzmenu" runat="server" onclick="btnSnimiIzmenu_Click" 
                Text="SNIMI IZMENU" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
