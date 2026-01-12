<%@ Page Title="" Language="C#" MasterPageFile="~/StampaZaglavlje.Master" AutoEventWireup="true" CodeBehind="UcenikStampa.aspx.cs" Inherits="KorisnickiInterfejs.UcenikStampa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style6
        {
            width: 160px;
        }
        .style7
        {
            color: #0066FF;
        }
        .style8
        {
            font-size: large;
        }
         .auto-style1 {
              width: 160px;
              height: 25px;
         }
         .auto-style2 {
              color: #0066FF;
              height: 25px;
         }
         .auto-style3 {
              height: 25px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:100%;">
        <tr>
            <td class="style6">
                <span class="style8"></span>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                </td>
            <td class="auto-style2">
                <strong>
                <asp:Label ID="lblNaslov" runat="server" Text="SPISAK UČENIKA"></asp:Label>
                </strong>
            </td>
            <td class="auto-style3">
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gvSpisakUcenika" runat="server" Height="286px" Width="433px" HorizontalAlign="Center">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
