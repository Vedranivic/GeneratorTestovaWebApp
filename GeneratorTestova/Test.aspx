<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Generator_testova.WebForm2" %> 
<%@ PreviousPageType VirtualPath="~/Generiraj.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:UpdatePanel ID="Test" runat="server">--%>
        <%--<ContentTemplate>--%>
            <center>
    <div style="background-color:white; width:1076px;">
        <div style="text-align: center;">
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Width="600px"></asp:Label>
            <br />
            <br />

            </div>
        <asp:Panel style="word-wrap:normal; word-break:break-all; line-height:30px; text-align:left; font-family:Calibri; font-size:16px; margin-bottom:30px;margin-top:4px;" ID="Panel1" runat="server" Width="600px">
            <asp:Label ID="Label3" runat="server" Width="600px" ></asp:Label>
          
            <br />
          
        </asp:Panel>


        <asp:GridView ID="GridView1" runat="server" Visible="False">
        </asp:GridView>
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="number_of_answers" HeaderText="broj" />
                <asp:BoundField DataField="answer_list" HeaderText="odgovori" />
                <asp:BoundField DataField="IDQ" HeaderText="IDQ" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:GridView ID="GridView5" runat="server">
        </asp:GridView>
        <br />
        <input id="Button4" type="button" value="button" runat="server" onserverclick="Button_test" />
        <input id="Reset1" type="reset" value="reset" />
        <input id="Submit1" type="submit" value="submit" /><asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=GeneratorDBContext" DefaultContainerName="GeneratorDBContext" EnableFlattening="False" EntitySetName="Questions" OnSelecting="EntityDataSource1_Selecting" Include="Answers">
        </asp:EntityDataSource>
    </div>

        <asp:Button ID="Button3"  runat="server" Height="30px" Text="Generiraj s istim parametrima" Width="220px" OnClick="Button3_Click" PostBackUrl="~/Test.aspx" />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Zadaj nove parametre" PostbackUrl ="~/Generiraj.aspx" Height="30px" Width="220px" />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Spremi" Height="30px" Width="220px" />
        <br />

    </center>
       <%-- </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>

 <div style="z-index:-100; background-image:url('Images/back2.jpg'); background-repeat:repeat-x; position:fixed; top: 50px; left: 0px; width: 5500px; height: 1234px; margin-right: 0px; margin-bottom: 0px;box-shadow: -2px 0px 7px #888888 inset;">
 </div>      

</asp:Content>
