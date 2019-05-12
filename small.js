 $(document).ready(function() {
    var $lightbox = $('#lightbox');
    
    $('[data-target="#lightbox"]').on('click', function(event) {
        var $img = $(this).find('img'), 
            src = $img.attr('src'),
            alt = $img.attr('alt'),
            css = {
                'maxWidth': $(window).width() - 100,
                'maxHeight': $(window).height() - 100
            };
    
        $lightbox.find('.close').addClass('hidden');
        $lightbox.find('img').attr('src', src);
        $lightbox.find('img').attr('alt', alt);
        $lightbox.find('img').css(css);
    });
    
    $lightbox.on('shown.bs.modal', function (e) {
        var $img = $lightbox.find('img');
            
        $lightbox.find('.modal-dialog').css({'width': $img.width()});
        $lightbox.find('.close').removeClass('hidden');
    });
});

/*<![CDATA[ */var give_global_vars={"ajaxurl":"http:\/\/namaste.webzakt.com\/wp-admin\/admin-ajax.php","checkout_nonce":"65988de76c","currency":"USD","currency_sign":"$","currency_pos":"before","thousands_separator":",","decimal_separator":".","no_gateway":"Please select a payment method.","bad_minimum":"The minimum custom donation amount for this form is","bad_maximum":"The maximum custom donation amount for this form is","general_loading":"Loading...","purchase_loading":"Please Wait...","number_decimals":"0","give_version":"2.1.3","magnific_options":{"main_class":"give-modal","close_on_bg_click":false},"form_translation":{"payment-mode":"Please select payment mode.","give_first":"Please enter your first name.","give_email":"Please enter a valid email address.","give_user_login":"Invalid username. Only lowercase letters (a-z) and numbers are allowed.","give_user_pass":"Enter a password.","give_user_pass_confirm":"Enter the password confirmation.","give_agree_to_terms":"You must agree to the terms and conditions."},"confirm_email_sent_message":"Please check your email and click on the link to access your complete donation history.","ajax_vars":{"ajaxurl":"http:\/\/namaste.webzakt.com\/wp-admin\/admin-ajax.php","ajaxNonce":"02e8cf3f3a","loading":"Loading","select_option":"Please select an option","default_gateway":"manual","permalinks":"1","number_decimals":0}};var giveApiSettings={"root":"http:\/\/namaste.webzakt.com\/wp-json\/give-api\/v2\/","rest_base":"give-api\/v2"};/*]]> */window._wpemojiSettings={"baseUrl":"https:\/\/s.w.org\/images\/core\/emoji\/2.4\/72x72\/","ext":".png","svgUrl":"https:\/\/s.w.org\/images\/core\/emoji\/2.4\/svg\/","svgExt":".svg","source":{"concatemoji":"http:\/\/namaste.webzakt.com\/wp-includes\/js\/wp-emoji-release.min.js?ver=4.9.6"}};!function(a,b,c){function d(a,b){var c=String.fromCharCode;l.clearRect(0,0,k.width,k.height),l.fillText(c.apply(this,a),0,0);var d=k.toDataURL();l.clearRect(0,0,k.width,k.height),l.fillText(c.apply(this,b),0,0);var e=k.toDataURL();return d===e}function e(a){var b;if(!l||!l.fillText)return!1;switch(l.textBaseline="top",l.font="600 32px Arial",a){case"flag":return!(b=d([55356,56826,55356,56819],[55356,56826,8203,55356,56819]))&&(b=d([55356,57332,56128,56423,56128,56418,56128,56421,56128,56430,56128,56423,56128,56447],[55356,57332,8203,56128,56423,8203,56128,56418,8203,56128,56421,8203,56128,56430,8203,56128,56423,8203,56128,56447]),!b);case"emoji":return b=d([55357,56692,8205,9792,65039],[55357,56692,8203,9792,65039]),!b}return!1}function f(a){var c=b.createElement("script");c.src=a,c.defer=c.type="text/javascript",b.getElementsByTagName("head")[0].appendChild(c)}var g,h,i,j,k=b.createElement("canvas"),l=k.getContext&&k.getContext("2d");for(j=Array("flag","emoji"),c.supports={everything:!0,everythingExceptFlag:!0},i=0;i<j.length;i++)c.supports[j[i]]=e(j[i]),c.supports.everything=c.supports.everything&&c.supports[j[i]],"flag"!==j[i]&&(c.supports.everythingExceptFlag=c.supports.everythingExceptFlag&&c.supports[j[i]]);c.supports.everythingExceptFlag=c.supports.everythingExceptFlag&&!c.supports.flag,c.DOMReady=!1,c.readyCallback=function(){c.DOMReady=!0},c.supports.everything||(h=function(){c.readyCallback()},b.addEventListener?(b.addEventListener("DOMContentLoaded",h,!1),a.addEventListener("load",h,!1)):(a.attachEvent("onload",h),b.attachEvent("onreadystatechange",function(){"complete"===b.readyState&&c.readyCallback()})),g=c.source||{},g.concatemoji?f(g.concatemoji):g.wpemoji&&g.twemoji&&(f(g.twemoji),f(g.wpemoji)))}(window,document,window._wpemojiSettings);