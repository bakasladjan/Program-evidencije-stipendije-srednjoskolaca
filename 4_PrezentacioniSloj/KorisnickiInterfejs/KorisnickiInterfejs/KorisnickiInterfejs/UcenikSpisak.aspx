<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UcenikSpisak.aspx.cs" Inherits="KorisnickiInterfejs.UcenikSpisak" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
    .style1
    {
        width: 174px;
    }
    .style2
    {
        width: 100%;
    }
    .style3
    {
        width: 513px;
        font-size: large;
        font-family: Arial;
    }
          .auto-style2 {
               width: 100%;
               

          }
          .auto-style3 {
               width: 174px;
               height: 115px;
          }
          .auto-style4 {
               width: 513px;
               height: 115px;
          }
          .auto-style6 {
               width: 174px;
               height: 37px;
          }
          .auto-style7 {
               width: 513px;
               height: 37px;
          }
          .auto-style8 {
               width: 164px;
          }
          .auto-style9 {
               width: 164px;
               height: 37px;
          }
          .auto-style10 {
               width: 164px;
               height: 115px;
          }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table class="auto-style2">
    <tr>
        <td class="style1">
             &nbsp;</td>
        <td class="style3">
            <strong>SPISAK UCENIKA</strong></td>
        <td class="auto-style8">
             &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
             &nbsp;</td>
        <td class="style2">
             &nbsp;</td>
        <td class="auto-style8">
             &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">
            </td>
        <td class="auto-style7">
            JMBG<asp:TextBox ID="txbFilter" runat="server"></asp:TextBox>
            <asp:Button ID="btnFiltriraj" runat="server" Text="FILTRIRAJ" 
                onclick="btnFiltriraj_Click" />
            <asp:Button ID="btnSvi" runat="server" Text="SVI" Width="97px" 
                onclick="btnSvi_Click" />
        </td>
        <td class="auto-style9">
            </td>
    </tr>
    <tr>
        <td class="style1">
             &nbsp;</td>
        <td class="style2">
             &nbsp;</td>
        <td class="auto-style8">
             &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
             &nbsp;</td>
        <td class="style2">
            <asp:GridView ID="gvUcenici" runat="server" Height="199px" Width="100%">
            </asp:GridView>
        </td>
        <td class="auto-style8">
             &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
             &nbsp;</td>
        <td class="style2">
             &nbsp;</td>
        <td class="auto-style8">
             &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            </td>
        <td class="auto-style4">
            </td>
        <td class="auto-style10">
            </td>
    </tr>

        
</table>
</asp:Content>
