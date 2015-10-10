<%@ Page Title="" Language="C#" MasterPageFile="~/ThreeMaster.Master" AutoEventWireup="true" CodeBehind="lichbay.aspx.cs" Inherits="MyWeb.Modules.Search.lichbay" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table class="vandon">
  <tr>
    <th scope="row">Hãng vận chuyển: </th>
    <td><select name="select" id="cboCarriers" class="combo" runat="server">
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
    </select> <span id="lb1" class="hide_error">*</span></td>
  </tr>
  <tr>
    <th scope="row">Ngày </th>
    <td>
        <asp:TextBox ID="txtDate" CssClass="date" runat="server"></asp:TextBox><asp:MaskedEditExtender ID="meeDate" runat="server" Mask="99/99/9999" 
        MaskType="Date" OnFocusCssClass="MaskedEditFocus" 
        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate" 
        CultureName="vi" /> <asp:CalendarExtender ID="cdeDate" runat="server" 
        PopupButtonID="ibtDate" TargetControlID="txtDate" 
        TodaysDateFormat="dd/MM/yyyy" /> <asp:ImageButton ID="ibtDate" runat="server" CausesValidation="False" ImageUrl="/App_Themes/default/images/calendar.png" /> <asp:MaskedEditValidator ID="mevDate" runat="server" ControlExtender="meeDate" ControlToValidate="txtDate" Display="Dynamic" EmptyValueBlurredText="*" IsValidEmpty="true" InvalidValueBlurredMessage="*" SetFocusOnError="True"/><span id="lb2" class="hide_error">*</span>
        <br />
        <asp:radiobuttonlist id="radType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:listitem runat="server" value="IMP" Text="Đến" />
            <asp:listitem runat="server" value="EXP" Text="Đi" Selected="True" />
        </asp:radiobuttonlist>
      </td>
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
    <th>Số hiệu chuyến bay</th>
    <th>Loại máy bay</th>
    <th><asp:Literal ID="ltrHour" runat="server"></asp:Literal></th>
    <th><asp:Literal ID="ltrType" runat="server"></asp:Literal></th>
  </tr>
  <asp:Literal ID="ltrResult" runat="server"></asp:Literal>
</table>
<script type="text/javascript">
    $(function () {
        $("#<%= cboCarriers.ClientID %>").change(function () {
            showErrorLB();
        });
        $("#<%= txtDate.ClientID %>").change(function () {
            showErrorLB();
        });
        $('#btnVanDon').click(function () {
            showErrorLB();
            if ($("#<%= cboCarriers.ClientID %>").val() != "" && $("#<%= txtDate.ClientID %>").val() != "") {
                var url = "/search/lichbay/" + $("#<%= txtDate.ClientID %>").val().replace(/\//g, '-') + "/" + $("#<%= cboCarriers.ClientID %>").val() + "-" + $("input[@name='ctl00$MainContent$radType']:checked").val() + ".aspx";
                $(window.location).attr('href', url);
            }
        });
        function showErrorLB() {
            $("#lb1").addClass("hide_error");
            $("#lb2").addClass("hide_error");
            if ($("#<%= cboCarriers.ClientID %>").val() == "") {
                $("#lb1").removeClass("hide_error");
                $("#lb1").addClass("show_error");
            }
            if ($("#<%= txtDate.ClientID %>").val() == "") {
                $("#lb2").removeClass("hide_error");
                $("#lb2").addClass("show_error");
            }
        }
    });
</script>
</asp:Content>
