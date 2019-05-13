function LoadMenu() {
    $.post("/Admin/AdminHome/LoadMenu", {}, function (result) {
        console.log(reuslt);
    });
}

$(function () {
    layui.use('element', function () {
        var element = layui.element;

    });
    LoadMenu();
});