<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Unos_pitanja.aspx.cs" Inherits="Generator_testova.Unos_pitanja" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Unos pitanja</h2>
    <asp:EntityDataSource ID="UnosPitanjaSource" runat="server"
        ContextTypeName="GeneratorDBContext" EnableFlattening="False"
        EnableInsert="True" EntitySetName="Questions" ConnectionString="name=GeneratorDBContext" DefaultContainerName="GeneratorDBContext">
    </asp:EntityDataSource>
    <asp:DetailsView ID="QuestionsDetailsView" runat="server" 
        DataSourceID="UnosPitanjaSource" AutoGenerateRows="False"
        DefaultMode="Insert">
        <Fields>
            <asp:BoundField DataField="qtype" HeaderText="Tip pitanja" 
                SortExpression="qtype" />
            <asp:BoundField DataField="txt" HeaderText="Tekst" 
                SortExpression="txt" />
            <asp:BoundField DataField="points" HeaderText="Bodovi" 
                SortExpression="points" />
            <asp:BoundField DataField="topic" HeaderText="Predmet/tema" 
                SortExpression="topic" />
            <asp:BoundField DataField="frequency" HeaderText="Učestalost" 
                SortExpression="frequency" />
            <asp:BoundField DataField="last_used" HeaderText="Zadnji put upotrijebljeno" 
                SortExpression="last_used" />

             <asp:CommandField ShowInsertButton="True" />
       </Fields>
    </asp:DetailsView>
</asp:Content>
