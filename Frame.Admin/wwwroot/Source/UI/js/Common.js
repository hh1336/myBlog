//监听滚动条
$(document).scroll(function () {
    var wWidth = $(document).width();
    if (~~wWidth > 768) {
        var scroH = $(document).scrollTop();
        $("nav").css("background", "rgba(255,255,255," + scroH / 48 + ")");
    }
});

$(document).on("click", ".menubtn", function (e) {
    $(".phonemenu ul").toggle();
})

$(function () {

});