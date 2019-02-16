jQuery(document).ready(function($){

    $(document).on("click", ".main-menu:not(.active) .nav-sub > a", function() { 
            $(this).parent().siblings(".nav-sub").find("> a").removeClass("open");
            $(this).parent().siblings(".nav-sub").find(" > ul").slideUp(250);
            $(this).next("ul").slideToggle(250);
            $(this).toggleClass("open");
            return false
    });

    $(document).on("click",".siteLogo",function(){
        $(this).parent().toggleClass("active");
    })
});