$(document).ready(function(){
  $(".navbar-toggle").on("click", function(){
    $(".wrapper").toggleClass("sidebarInactive");
  });

   $(".dropdown-toggle").on("click", function(){
    $(".dropDown").toggleClass("open");
  });
   $(".form").hide();
   $("#toggle").on("click", function(){
   	$(".list").hide();
   	$(".form").show();
   });
   $("#cancel").on("click", function(){
   	$(".form").hide();
   	$(".list").show();
   });
});