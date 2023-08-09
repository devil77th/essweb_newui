<%@ Page Title="Family List" Language="C#" MasterPageFile="~/masterPage/Site2.Master" AutoEventWireup="true" CodeBehind="family_list.aspx.cs" Inherits="WebApplication1.page.family_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <uc1:pagecode_family_list id="uc1" runat="server"></uc1:pagecode_family_list>
</asp:Content>
