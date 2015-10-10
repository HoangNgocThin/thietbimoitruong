<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="lichbay_wuc.ascx.cs" Inherits="MyWeb.Modules.Search.lichbay_wuc" %>
<table class="lichbay-tb">
  <tr>
    <td>Hãng vận chuyển:<br/><select name="select" id="cboCarriers2" class="combo" runat="server">
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
    <td>Ngày<br/><asp:TextBox ID="txtDate2" CssClass="date" runat="server"></asp:TextBox><asp:MaskedEditExtender ID="meeDate" runat="server" Mask="99/99/9999" 
        MaskType="Date" OnFocusCssClass="MaskedEditFocus" 
        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate2" 
        CultureName="vi" /> <asp:CalendarExtender ID="cdeDate" runat="server" 
        PopupButtonID="ibtDate" TargetControlID="txtDate2" 
        TodaysDateFormat="dd/MM/yyyy" /> <asp:ImageButton ID="ibtDate" runat="server" CausesValidation="False" ImageUrl="/App_Themes/default/images/calendar.png" /> <asp:MaskedEditValidator ID="mevDate" runat="server" ControlExtender="meeDate" ControlToValidate="txtDate2" Display="Dynamic" EmptyValueBlurredText="*" IsValidEmpty="true" InvalidValueBlurredMessage="*" SetFocusOnError="True"/><span id="lb2" class="hide_error">*</span>
        <br />
        <asp:radiobuttonlist id="radType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:listitem runat="server" value="IMP" Text="Đến" />
            <asp:listitem runat="server" value="EXP" Text="Đi" Selected="True" /> </asp:radiobuttonlist> </td>
  </tr>
  <tr><td><input id="btnLichBay" type="button" value="" class="submit" /></td></tr>
</table>
<script type="text/javascript">
    $(function () {
        $("#<%= cboCarriers2.ClientID %>").change(function () {
            showErrorLB();
        });
        $("#<%= txtDate2.ClientID %>").change(function () {
            showErrorLB();
        });
        $('#btnLichBay').click(function () {
            showErrorLB();
            if ($("#<%= cboCarriers2.ClientID %>").val() != "" && $("#<%= txtDate2.ClientID %>").val() != "") {
                var url = "/search/lichbay/" + $("#<%= txtDate2.ClientID %>").val().replace(/\//g, '-') + "/" + $("#<%= cboCarriers2.ClientID %>").val() + "-" + $("input[@name='ctl00$MainContent$radType']:checked").val() + ".aspx";
                $(window.location).attr('href', url);
            }
        });
        function showErrorLB() {
            $("#lb1").addClass("hide_error");
            $("#lb2").addClass("hide_error");
            if ($("#<%= cboCarriers2.ClientID %>").val() == "") {
                $("#lb1").removeClass("hide_error");
                $("#lb1").addClass("show_error");
            }
            if ($("#<%= txtDate2.ClientID %>").val() == "") {
                $("#lb2").removeClass("hide_error");
                $("#lb2").addClass("show_error");
            }
        }
    });
</script>