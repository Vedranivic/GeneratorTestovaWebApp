<%@ Page Title="O Aplikaciji" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Generator.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Aplikacija namjenjena generiranju testova.</h3>
    <p>Stiskom na gumb GENERIRAJ odlazi se na stranicu za generiranje testa. Unosom željenih parametara, na osnovu pitanja iz baze, generira se i sprema na računalo test. Odlaskom na PITANJA, korisnik dobiva uvid u bazu pitanja gdje ista može mijenjati ili brisati.</p>
    <p>Aplikacija je kreirana u svrhu realizacije završnog rada. Za sva pitanja, obratite se autoru (Kontakt).</p>
</asp:Content>
