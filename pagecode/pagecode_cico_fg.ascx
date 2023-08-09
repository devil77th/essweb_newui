<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_cico_fg.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_cico_fg" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 
<table style="width:100%">
   
    <tr style="width:50%">
        <td>
            <asp:Label ID="lbl1" runat="server" Text="Date - Time Server : "></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblTimeServer" runat="server"></asp:Label>
        </td>
    </tr>
    <tr style="width:50%">
        <td>
            Last Activity :
        </td>
        <td>
             <asp:Label ID="lblLastActivity" runat="server"></asp:Label>
             <asp:HiddenField ID="hidLastActTime1" runat="server" />
             <asp:HiddenField ID="hidLastAct1" runat="server" />
        </td>
    </tr>
    <tr style="width:50%">
        <td colspan="2">
            <asp:Button ID="cmdRefreshTimeServer" runat="server" CssClass="btn btn-lg btn-primary btn-block"
                Text="Refresh" OnClick="cmdRefreshTimeServer_Click" Width="100%" UseSubmitBehavior="false"  />
        </td>
    </tr>
    <tr>
        <td colspan="2">

        </td>
    </tr>
     <tr style="width:50%">
        <td>
            Position :
        </td>
        <td>
            <asp:Button ID="cmdGetLocation" runat="server" OnClientClick="getLocation();return false;" 
                Text="Get Location" />
        &nbsp;</td>
    </tr>
    <tr style="width:50%">
        <td>
            &nbsp;</td>
        <td>
            <asp:HiddenField ID="hidlat1" runat="server" />
            <asp:HiddenField ID="hidlon1" runat="server" />
            <asp:Label ID="lblLocStatus" runat="server"></asp:Label> &nbsp;&nbsp;
        &nbsp;<p id="maploc"></p> </td>
    </tr>
</table>
<br />
<br />
<table style="width:100%;text-align:center">
    <tr>
        <td>
          <asp:Button ID="cmdClockIn" runat="server" CssClass="btn btn-lg btn-primary btn-block"
                Text="Clock In" OnClick="cmdClockIn_Click" Width="100%" />
        </td>
        
    </tr>
    <tr>
        <td>
            &nbsp;</td>     
    </tr>
    <tr>
        <td>
            &nbsp;</td>    
    </tr>
    <tr>
        <td>
            <asp:Button ID="cmdClockOut" runat="server" CssClass="btn btn-lg btn-primary btn-block"
                Text="Clock Out" OnClick="cmdClockOut_Click" Width="100%" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align:left">
            1. Absensi ini menggunakan lokasi device anda (HP/Laptop dll). Pastikan anda memberikan Permission untuk mendeteksi lokasi anda.<br />
            <br />
            2. Lokasi anda akan disimpan di database dan akan diperiksa oleh HR untuk memastikan bahwa anda sudah benar di lokasi kantor SERA.<br />
            <br />
            3. Apabila &quot;Last Activity&quot; anda adalah &quot;Clock In&quot; , maka anda hanya bisa melakukan &quot;Clock Out&quot;.<br />
            <br />
            4. Sebaliknya , apabila &quot;Last Activity&quot; anda adalah &quot;Clock Out&quot; , maka anda hanya bisa melakukan &quot;Clock In&quot;.<br />
            <br />
            5. Apabila anda belum melakukan &quot;Clock Out&quot; pada aktivitas sebelumnya dan anda mau melakukan &quot;Clock In&quot; , silahkan melakukan &quot;Clock Out&quot; terlebih dahulu (Request apabila sudah berbeda hari).<br />
&nbsp;</td>
    </tr>
</table>
 <script>
     function getLocation() {
         // Check whether browser supports Geolocation API or not
         if (navigator.geolocation) // Supported
         {
             var positionOptions = {
                 timeout: Infinity,
                 maximumAge: 0,
                 enableHighAccuracy: true
             };
             // Set the watchID
             watchID = navigator.geolocation.watchPosition(getPosition, catchError, positionOptions);
         }
         else // Not supported
         {
             alert("Oop! This browser does not support HTML5 Geolocation.");
         }
     }
     function stopWatch() {
         navigator.geolocation.clearWatch(watchID);
         watchID = null;
     }
     function getPosition(position) {
         var lat1 = document.getElementById('<%=hidlat1.ClientID %>');
         var lon1 = document.getElementById('<%=hidlon1.ClientID %>');
         var lblloc1 = document.getElementById('<%=lblLocStatus.ClientID %>');
         
         lat1.value = position.coords.latitude;
         lon1.value = position.coords.longitude;
         lblloc1.textContent = "Lokasi sudah didapatkan";
         document.getElementById("maploc").innerHTML = "<a href='https://www.openstreetmap.org/#map=19/" +
             position.coords.latitude + "/" + position.coords.longitude + "' target='_blank'>Lihat di peta</a>";
       
     }
     function catchError(error) {
         switch (error.code) {
             case error.TIMEOUT:
                 alert("The request to get user location has aborted as it has taken too long.");
                 break;
             case error.POSITION_UNAVAILABLE:
                 alert("Location information is not available.");
                 break;
             case error.PERMISSION_DENIED:
                 alert("Permission to share location information has been denied!");
                 break;
             default:
                 alert("An unknown error occurred.");
         }
     }
</script>
    
  