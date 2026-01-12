<%@ Page Title="" Language="C#" MasterPageFile="~/Korisnik.Master" AutoEventWireup="true" CodeBehind="WelcomeKorisnik.aspx.cs" Inherits="KorisnickiInterfejs.WelcomeKorisnik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        DOBRODOSLI, KORISNIČE
        <asp:Label ID="lblImePrezimeKorisnika" runat="server" Text="Ime i prezime korisnika"></asp:Label>
&nbsp;!</p>
</asp:Content>
