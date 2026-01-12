<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UcenikUnos.aspx.cs" Inherits="KorisnickiInterfejs.UcenikUnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
    .style1
    {
        width: 423px;
    }
    .style2
    {
        width: 342px;
        text-align: right;
    }
    .style3
    {
        width: 423px;
        font-size: large;
    }
    .style4
    {
        font-size: large;
    }
    .style5
    {
        width: 342px;
        font-size: large;
        text-align: right;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:100%;">
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style3">
            <strong>UNOS UCENIKA</strong></td>
        <td class="style4">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label1" runat="server" Text="JMBG"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbJMBG" runat="server" MaxLength="13" MinLength="13"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="JMBG mora imati 13 cifara!"
                  runat="server" ControlToValidate="txbJMBG" ForeColor="Red" ValidationExpression="[0-9]{13}"></asp:RegularExpressionValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label2" runat="server" Text="Ime i prezime učenika"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbImeIPrezimeUcenika" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    
         <tr>
        <td class="style2">
            Razred</td>
        <td class="style1">
            <asp:TextBox ID="txbRazred" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
         </tr>
         <tr>
        <td class="style2">
            Škola</td>
        <td class="style1">
            <asp:TextBox ID="txbSkola" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
         </tr>
    
    <tr>
        <td class="style2">
             <asp:Label ID ="Label3" runat="server" Text="Datum rođenja"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbDatumRodjenja" runat="server" placeholder="dd.mm.yyyy"></asp:TextBox>
        </td>
        <td>
             &nbsp;</td>
    </tr>

          <tr>
        <td class="style2">
            <asp:Label ID="Label4" runat="server" Text="Adresa učenika"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbAdresaUcenika" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>

          <tr>
        <td class="style2">
            Kontakt telefon</td>
        <td class="style1">
            <asp:TextBox ID="txbKontaktTelefon" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>


    
    <tr>
        <td class="style2">
            Stipendija</td>
        <td class="style1">
            <asp:DropDownList ID="ddlStipendija" runat="server" Height="16px" Width="233px">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            <asp:Label ID="lblStatus" runat="server" Text="STATUS"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            <asp:Button ID="btnSnimi" runat="server" Text="SNIMI" Width="69px" 
                onclick="btnSnimi_Click" />
            <asp:Button ID="btnPonisti" runat="server" Text="PONISTI" 
                onclick="btnPonisti_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
