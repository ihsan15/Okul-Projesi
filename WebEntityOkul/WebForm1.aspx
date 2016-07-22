<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebEntityOkul.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Öğrenciler</title>
    <style type="text/css">
        @import "okul.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:1000px;height:800px">
    <div class="icgovde">

        <asp:DropDownList ID="ddlSiniflar" runat="server" AutoPostBack="true" OnSelectedIndexChanged="itemselected" Height="21px" Width="218px" OnDataBound="ddlSiniflar_DataBound">
        </asp:DropDownList>
                
        <br />
        <br />
                
        <asp:GridView ID="gvOgrenciler" runat="server" Height="284px" Width="893px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvOgrenciler_SelectedIndexChanged" OnDataBound="gvOgrenciler_DataBound" DataKeyNames="Id">
        </asp:GridView>
    </div>

        <div class="icgovde">
            <asp:LinkButton ID="lbtnEkle" runat="server" OnClick="lbtnEkle_Click" >Yeni Öğrenci Ekle</asp:LinkButton>
            <asp:Panel ID="OgrencilerPaneli" runat="server" Height="300px" Width="893px" Visible="false">
            <table style="width:500px;margin-left:250px;margin-top:10px;">
                <tr style="height:30px;">
                    <td style="text-align:center;width:150px;">Adı</td>
                    <td><asp:TextBox ID="txtAdi" runat="server" Width="184px"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtId" runat="server" Width="57px" Visible="False"></asp:TextBox></td>
                </tr>
                <tr style="height:30px;">
                    <td style="text-align:center;width:150px;">Soyadı</td>
                    <td colspan="2"><asp:TextBox ID="txtSoyadi" runat="server" Width="184px"></asp:TextBox></td>
                </tr>
                <tr style="height:30px;">
                    <td style="text-align:center;width:150px;">Telefon</td>
                    <td colspan="2"><asp:TextBox ID="txtTelefon" runat="server" Width="184px"></asp:TextBox></td>
                </tr>
                <tr style="height:30px;">
                    <td style="text-align:center;width:150px;">Adres</td>
                    <td colspan="2"><asp:TextBox ID="txtAdres" runat="server" Width="184px"></asp:TextBox></td>
                </tr>
                <tr style="height:30px;">
                    <td style="text-align:center;width:150px;">TC</td>
                    <td colspan="2"><asp:TextBox ID="txtTC" runat="server" Width="184px"></asp:TextBox></td>
                </tr>
                <tr style="height:30px;">
                    <td style="text-align:center;width:150px;">Taksit Sayısı</td>
                    <td colspan="2"><asp:TextBox ID="txtTSayisi" runat="server" Width="184px"></asp:TextBox></td>
                </tr>
                <tr style="height:30px;">
                    <td style="text-align:center;width:150px;">Taksit Tutarı</td>
                    <td colspan="2" ><asp:TextBox ID="txtTTutari" runat="server" Width="184px"></asp:TextBox></td>
                </tr>
                <tr style="height:30px;">
                    <td><asp:Button ID="btnKaydet" runat="server" Text="Kaydet" Enabled="False" OnClick="btnKaydet_Click" /> </td>
                    
                    <td><asp:Button ID="btnDegistir" runat="server" Text="Değiştir" Enabled="False" OnClick="btnDegistir_Click" /></td>
                    <td style="width:140px"><asp:Button ID="btnSil" runat="server" Text="Sil" Enabled="False" OnClientClick="return confirm('Silmek İstiyor musunuz?')" OnClick="btnSil_Click" /></td>
                </tr>
                <tr style="height:30px;">
                    <td colspan="3"><asp:Label ID="lblMesaj" runat="server" Text=""></asp:Label> </td>
                </tr>
            </table>

        </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
