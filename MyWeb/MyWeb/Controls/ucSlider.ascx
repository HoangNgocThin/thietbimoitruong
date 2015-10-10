<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSlider.ascx.cs" Inherits="MyWeb.Controls.ucSlider" %>


<div class="slider-wrapper theme-default">
    <div id="slider_container_2">
        <div id="SliderName_2" class="SliderName_2">
            <asp:Literal ID="ltrslider" runat="server"></asp:Literal>
        </div>
        <div class="c"></div>
        <div id="SliderNameNavigation_2"></div>
        <div class="c"></div>

        <script type="text/javascript">
            effectsDemo2 = 'rain,stairs,fade';
            var demoSlider_2 = Sliderman.slider({
                container: 'SliderName_2', width: 770, height: 350, effects: effectsDemo2,
                display: {
                    autoplay: 3000,
                    loading: { background: '#000000', opacity: 0.5, image: 'img/loading.gif' },
                    buttons: { hide: true, opacity: 1, prev: { className: 'SliderNamePrev_2', label: '' }, next: { className: 'SliderNameNext_2', label: '' } },
                    description: { hide: true, background: '#000000', opacity: 0.4, height: 50, position: 'bottom' },
                    navigation: { container: 'SliderNameNavigation_2', label: '<img src="img/clear.gif" />' }
                }
            });
        </script>
        <div class="c"></div>
    </div>


</div>
