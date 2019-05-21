var _lenght = 0;
var _util, _laydate, _layer, _element;
function LoadMenu() {
    $.post("/Admin/AdminHome/LoadMenu", {}, function (result) {
        var menustr = ``;
        for (var i = 0, _lenght = result.length; i < _lenght; i++) {

            if (!result[i].ChildEntitis.length) {//没有子菜单
                menustr += `<li class="layui-nav-item"><a href="` + result[i].LinkAddress + `">` + result[i].ShowName + `</a></li>`;
            } else {
                var dl = ``;
                for (var j = 0; j < result[i].ChildEntitis.length; j++) {
                    dl += `<dl class="layui-nav-child">
                            <dd><a href="`+ result[i].ChildEntitis[j].LinkAddress + `">` + result[i].ChildEntitis[j].ShowName + `</a></dd>
                           </dl>`;
                }
                menustr += `<li class="layui-nav-item"><a href="javascript:;">` + result[i].ShowName + `</a>` + dl + `</li>`;
            }
        }
        $("#menu").html(menustr);
        layui.use(['element'], function () {
            _element = layui.element;

            _element.render('nav', 'menu');
        });
    });
}

$(function () {
    LoadMenu();
    GetUserInfo();
});

//加载用户信息
function GetUserInfo() {
    $.post("/Home/GetUserInfo").done(function (result) {
        $(".userinfo > a > img").attr("src", result.photo);
        $(".userinfo > a > span").text(result.userName);
    });
}