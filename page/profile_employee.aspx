<%@ Page Title="Employee Profile" Language="C#" MasterPageFile="~/masterPage/Site2.Master" AutoEventWireup="true" CodeBehind="profile_employee.aspx.cs" Inherits="WebApplication1.page.profile_employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
     <uc1:pagecode_user_profile id="uc1" runat="server"></uc1:pagecode_user_profile>
</asp:Content>
