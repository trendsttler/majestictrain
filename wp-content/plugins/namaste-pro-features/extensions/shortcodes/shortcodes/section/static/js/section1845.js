jQuery(document).ready(function(t){function i(){if(window.matchMedia("(min-width: 1170px)").matches){var i=t("#bodychild").width(),e=i/2;t(".namaste-fullwidth-section .section-image-left").css({width:e+"px"}),t(".namaste-fullwidth-section .section-image-right").css({width:e+"px"}),t(".namaste-fullwidth-section .section-content-left").css({width:e+"px"}),t(".namaste-fullwidth-section .section-content-right").css({width:e+"px"}),t(".namaste-fullwidth-section .section-layer-holder").css({width:i+"px"}),t(".namaste-fullwidth-section .section-dynamic-width").css({width:i+"px"})}}function e(){if(window.matchMedia("(max-width: 1169px)").matches){var i=t("#bodychild").width();t(".namaste-fullwidth-section .section-content-left").css({width:i+"px"}),t(".namaste-fullwidth-section .section-content-right").css({width:i+"px"}),t(".namaste-fullwidth-section .section-content").css({width:i+"px"}),t(".namaste-fullwidth-section .section-layer-holder").css({width:i+"px"}),t(".namaste-fullwidth-section .section-dynamic-width").css({width:i+"px"})}}t(document).ready(i),t(window).on("resize",i),t(document).ready(e),t(window).on("resize",e)});