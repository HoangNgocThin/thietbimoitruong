<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="MyWeb.Modules.News.NewsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div style="padding: 10px 0px 10px 0px"><asp:Literal runat="server" ID="ltrNavigate" /></div>
    <div class="newsDetail">
         <table style="margin:10px 0px 0px 0px;">
        <tr>
            <td>
                <asp:Literal ID="ltrLike" runat="server"></asp:Literal>  
            </td>
            <td style="padding-left: 5px;">
                <asp:Literal ID="ltrShare" runat="server"></asp:Literal></td>
            <td  style="padding-left: 5px;">
                <asp:Literal ID="ltrGoogle" runat="server"></asp:Literal></td>

        </tr>
    </table>
        <div class="newsDetail_head">
            <div class="newsDetail_head_left">
                <asp:Literal ID="ltrNewsImage" runat="server"></asp:Literal>
            </div>
            <div class="newsDetail_head_right">
                <p style="font-weight:bold ; padding:0px 0px 10px 10px"><asp:Literal ID="ltrTitle" runat="server"></asp:Literal></p>
                <p style="color:#777788; font-size:12px; padding:0px 0px 10px 10px"><asp:Literal ID="ltrPostedDate" runat="server"></asp:Literal></p>
                <div style="padding:0px 0px 10px 10px"><asp:Literal ID="ltrDescription" runat="server"></asp:Literal></div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="newsDetail_main">
            <asp:Literal ID="ltrDetail" runat="server"></asp:Literal>
        </div>
        <div class="comment">
            <asp:Literal runat="server" ID="ltrComment" />
        </div>
    </div>
    <div class="news_refer">
         <div class="news_refer_head">
             <span>Các tin cùng chuyên mục</span>
         </div>
         <div class="news_refer_main">
             <ul>
                 <asp:Literal ID="ltrNewsRefer" runat="server"></asp:Literal>
             </ul>
         </div>
    </div>
</asp:Content>
