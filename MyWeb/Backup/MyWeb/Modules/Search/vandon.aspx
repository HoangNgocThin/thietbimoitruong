<%@ Page Title="" Language="C#" MasterPageFile="~/ThreeMaster.Master" AutoEventWireup="true" CodeBehind="vandon.aspx.cs" Inherits="MyWeb.Modules.Search.vandon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table class="vandon">
  <tr>
    <th scope="row">Hãng vận chuyển: </th>
    <td><select name="select" id="cboCarriers"  class="combo" runat="server">
      <option value="507">Aeroflot Cargo</option>
      <option value="555">Aeroflot Russia Airlines</option>
      <option value="807">Air Asia Berhard</option>
      <option value="057">Air France</option>
      <option value="988">Asiana Airlines</option>
      <option value="160">Cathay Pacific</option>
      <option value="203">Cebu Airlines</option>
      <option value="297">China Airlines</option>
      <option value="784">China Southern Airlines</option>
      <option value="043">Dragon Air</option>
      <option value="176">Emirates</option>
      <option value="695">Eva Airways</option>
      <option value="851">Hongkong Airlines</option>
      <option value="131">Japan Airlines</option>
      <option value="180">Korean Airlines</option>
      <option value="229">Kuwait Airways</option>
      <option value="627">Lao Airlines</option>
      <option value="266">LTU Internation Airways</option>
      <option value="020">Lufthansa Cargo</option>
      <option value="232">Malaysia Airlines</option>
      <option value="550">Pacific airlines</option>
      <option value="672">Royal Brunei Airlines</option>
      <option value="618">Singapore Airlines</option>
      <option value="603">Srilankan Airlines</option>
      <option value="900">Thai Air Asia</option>
      <option value="217">Thai Airways</option>
      <option value="525">Uni Airways</option>
      <option value="250">Uzbekistan Airways</option>
      <option value="738">Vietnam Airlines</option>
      <option value="277">Vladivostok Air</option>
      <option value="" selected="selected">--None--</option>
    </select> <span id="vd1" class="hide_error">*</span></td>
  </tr>
  <tr>
    <th scope="row">Số vận đơn </th>
    <td>
        <asp:TextBox ID="txtCode" runat="server" CssClass="code" MaxLength="3" 
            ReadOnly="True"></asp:TextBox> &nbsp; 
        <asp:TextBox ID="txtAwbId" runat="server" CssClass="code2" MaxLength="8"></asp:TextBox> <span id="vd2" class="hide_error">*</span></td>
  </tr>
  <tr>
    <th scope="row">&nbsp;</th>
    <td><input id="btnVanDon" type="button" value="Tra cứu" class="submit" /></td>
  </tr>
</table>
<div class="message"><asp:Literal ID="ltrMessage" runat="server"></asp:Literal></div>
<br />
<table class="vandon-view" border="1">
  <tr>
    <th>Chuyến bay</th>
    <th>Nơi đi</th>
    <th>Nơi đến</th>
    <th>Số kiện</th>
    <th>Trọng lượng (Kg)</th>
    <th>Tên hàng</th>
    <th>Ghi chú</th>
    <th>Trạng thái</th>
  </tr>
  <asp:Literal ID="ltrResult" runat="server"></asp:Literal>
</table>
<script type="text/javascript">
    $(function () {
        $("#<%= cboCarriers.ClientID %>").change(function () {
            $("#<%= txtCode.ClientID %>").val(this.value);
            showErrorVD();
        });
        $("#<%= txtAwbId.ClientID %>").keypress(function () {
            showErrorVD();
        });
        $('#btnVanDon').click(function () {
            showErrorVD();
            if ($("#<%= txtCode.ClientID %>").val() != "" && $("#<%= txtAwbId.ClientID %>").val() != "") {
                var url = "/search/vandon/" + $("#<%= txtCode.ClientID %>").val() + "-" + $("#<%= txtAwbId.ClientID %>").val() + ".aspx";
                $(window.location).attr('href', url);
            }
        });
        function showErrorVD() {
            $("#vd1").addClass("hide_error");
            $("#vd2").addClass("hide_error");
            if ($("#<%= txtCode.ClientID %>").val() == "") {
                $("#vd1").removeClass("hide_error");
                $("#vd1").addClass("show_error");
            }
            if ($("#<%= txtAwbId.ClientID %>").val() == "") {
                $("#vd2").removeClass("hide_error");
                $("#vd2").addClass("show_error");
            }
        }
    });
</script>
</asp:Content>
