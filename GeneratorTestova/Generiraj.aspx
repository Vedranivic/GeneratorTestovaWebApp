<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Generiraj.aspx.cs" Inherits="Generator.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div style="background-color:white; width:1076px;">--%>


    <center style="height: 560px; width: 1076px; background-color:white;position:fixed center; margin-left:50px; ">
        <p style="text-align:center; padding-top:15px; color:crimson; margin-left:-50px;">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <div class="jumbotron" style="padding:5px;width:1126px; margin-left:-25px; box-shadow: 2px 2px 5px #888888">
        <h1 style="font-size:15px; font-weight:500;text-align:left; text-indent:20px; width: 1298px;">GENERATOR TESTOVA</h1>
        </div>
        <p style="text-indent:50px; font-weight:lighter; text-align:left;"><i>Unesite željene parametre testa</i></p>

        <div style="padding: 0px 10px;background-image:url(Images/back1.jpg); color:azure; border-style: none; border-radius:5px; border-width:1px; width: 690px; margin-top:20px;">
        <asp:Panel style="display:inline-block;  text-align:right; line-height:40px;margin-top:30px;" ID="Panel1" runat="server" Height="210px" Width="247px" BorderStyle="None">
            Naziv testa:<asp:TextBox ID="TextBox7" runat="server" Height="25px" OnTextChanged="TextBox7_TextChanged" Width="100px"></asp:TextBox>
            <br />
            Info:<asp:TextBox ID="TextBox8" runat="server" Height="25px" Width="100px"></asp:TextBox>
            <br />
            Vrsta testa:<asp:DropDownList ID="DropDownList1" runat="server" Height="25px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="100px">
                <asp:ListItem>Ispit</asp:ListItem>
                <asp:ListItem>Anketa</asp:ListItem>
                <asp:ListItem>Kviz</asp:ListItem>
                <asp:ListItem>Kontrolna zadaća</asp:ListItem>
                <asp:ListItem>Upitnik</asp:ListItem>
            </asp:DropDownList>
            <br />
            Predmet/tema testa:<asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="100px" Height="25px">
            </asp:DropDownList>
            <br />
            Ukupan broj pitanja:<asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="50px"></asp:TextBox>
            <br />
            Prikaži bodove uz pitanja&nbsp;
            <asp:CheckBox style="margin-top:30px;" ID="CheckBox1" runat="server" />
            
<%--            <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=GeneratorDBContext" DefaultContainerName="GeneratorDBContext" EnableFlattening="False" EntitySetName="Questions" Select="DISTINCT it.[topic]">
            </asp:EntityDataSource>--%>
            
        </asp:Panel>

        <span style="display:inline-block; width:20px; height:100px;"> </span>

        <asp:Panel style="display:inline-block;" ID="Panel2" runat="server" Height="225px" Width="322px" BorderStyle="None">
            <div style="height: 230px; width: 322px; text-align:right;line-height:40px;">
                Broj pitanja <b>dugog odgovora</b>:<asp:TextBox ID="TextBox2" runat="server" Height="25px" Width="50px"></asp:TextBox>
                <br />
                Broj pitanja s <b>nadopunom</b>:<asp:TextBox ID="TextBox3" runat="server" Height="25px" Width="50px"></asp:TextBox>
                <br />
                Broj pitanja s <b>višestrukim odabirom</b>:<asp:TextBox ID="TextBox4" runat="server" Height="25px" OnTextChanged="TextBox4_TextChanged" Width="50px"></asp:TextBox>
                <br />
                Broj pitanja sa <b>zaokruživanjem</b>:<asp:TextBox ID="TextBox5" runat="server" Height="25px" OnTextChanged="TextBox5_TextChanged" Width="50px"></asp:TextBox>
                <br />
                Broj pitanja <b>točno/netočno</b>:<asp:TextBox style="margin-right:4px;" ID="TextBox6" runat="server" Height="25px" Width="50px" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
            </div>
        </asp:Panel>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generiraj test" Height="30px" Width="220px" />
    </center>
<%--    </div>--%>



 <div style="z-index:-100; background-image:url('Images/back2.jpg'); background-repeat:repeat-x; position:fixed; top: 50px; left: 0px; width: 5500px; height: 1234px; margin-right: 0px; margin-bottom: 0px;box-shadow: -2px 0px 7px #888888 inset;">
 </div>      

</asp:Content>
