<%@ Page Title="" Language="VB" MasterPageFile="~/InfoScreen.master" AutoEventWireup="false" CodeFile="InfoScreen.aspx.vb" Inherits="InfoScreen" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Chart ID="chrtSunlight" runat="server" Palette="Fire">
                   <Series>
                       <asp:Series Name="Series1" ChartType="Spline"></asp:Series>
                   </Series>
                   <ChartAreas>
                       <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                   </ChartAreas>
                   <Titles>
                       <asp:Title Name="Title1">
                       </asp:Title>
                   </Titles>
               </asp:Chart>
    <%--<asp:Timer ID="aspTimer" runat="server" Interval="8000" ></asp:Timer>--%>
    <%--<asp:UpdatePanel ID="updPanel" runat="server">
           <ContentTemplate>
                              
               <div runat="server" id="divContentContainer">

               </div>               
           </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

