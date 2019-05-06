//监听滚动条
$(document).scroll(function () {
    var wWidth = $(document).width();
    if (~~wWidth > 768) {
        var scroH = $(document).scrollTop();
        $("nav").css("background", "rgba(255,255,255," + scroH / 48 + ")");
        if (scroH >= 48) {
            $("#tooltip>ul>li:last").removeClass("hidden");
        } else {
            $("#tooltip>ul>li:last").addClass("hidden");
        }
    }
});

//手机菜单动画
$(document).on("click", ".menubtn", function (e) {
    $(".phonemenu ul").animate({ height: "toggle" });

});

//控制toopit
$(document).on("click", "#tooltip>ul>li:last", function (e) {
    $(document).scrollTop(0);
});
$(document).on("click", "#tooltip>ul>li:first", function (e) {
    $(this).children("ul").animate({ width: "toggle" }, 200);
});

$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});