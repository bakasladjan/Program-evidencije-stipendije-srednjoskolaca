<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="StipendijaUnos.aspx.cs" Inherits="KorisnickiInterfejs.StipendijaUnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style1
        {
            width: 214px;
            text-align: right;
        }
        .style2
        {
            width: 214px;
            text-align: right;
            font-weight: bold;
        }
          .auto-style1 {
               width: 237px;
               text-align: right;
               height: 29px;
          }
          .auto-style2 {
               height: 29px;
          }
          .auto-style5 {
               width: 237px;
               text-align: right;
               font-weight: bold;
          }
          .auto-style6 {
               width: 237px;
               text-align: right;
          }
         .auto-style7 {
             width: 237px;
             text-align: right;
             height: 26px;
         }
         .auto-style8 {
             height: 26px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:100%;">
        <tr>
            <td class="auto-style5">
                 &nbsp;</td>
            <td>
                <b>UNOS STIPENDIJE</b></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                Sifra</td>
            <td class="auto-style8">
                <asp:TextBox ID="txbSifra" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style8">
                </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Naziv</td>
            <td class="auto-style2">
                <asp:TextBox ID="txbNaziv" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2">
                </td>
        </tr>
        
         <tr>
            <td class="auto-style1">
                Iznos</td>
            <td class="auto-style2">
                <asp:TextBox ID="txbIznos" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2">
                </td>
         </tr>
        
        <tr>
            <td class="auto-style6">
                 &nbsp;</td>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="status"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                 &nbsp;</td>
            <td>
                <asp:Button ID="btnSnimi" runat="server" onclick="btnSnimi_Click" Text="SNIMI" 
                    Width="90px" />
                <asp:Button ID="btnOdustani" runat="server" onclick="btnOdustani_Click" 
                    Text="ODUSTANI" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                 &nbsp;</td>
            <td>
                 &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
