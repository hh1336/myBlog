class frame {

    //封装layer信息弹出层
    static alert(obj) {
        //传入标题时，视为需要弹出返回内容的弹出层
        if (obj.title !== undefined) {
            if (obj.yes === undefined) {
                obj.yes = function (index, layero) {
                    layer.close(index);
                    return 1;
                };
            }
            if (obj.end === undefined) {
                obj.end = function (index, layero) {
                    return 0;
                };
            }
            layer.open({
                title: obj.title,
                content: obj.msg,
                shadeClose: true,
                area: obj.width === undefined ? 'auto' : obj.width,
                closeBtn: "2",
                btn: ["确定", "取消"],
                btn1: obj.yes,
                btn2: obj.end
            });
        } else {
            layer.msg(obj.msg, { icon: obj.icon });
        }
    }


    //封装模态框
    static appModal(obj) {
        this.default = {
            title: "标题",
            width: "50%",
            height: "",
            content: "",
            ClickBackClose: false,
            yes: function (index, layero) {
                layer.close(index);
            },
            end: function (index, layero) {
                
            }
        };

        layer.open({
            title: obj.title === undefined ? this.default.title : obj.title,
            type: 1,
            btn: ['确定', '取消'],
            //anim: 5,//从上掉下的动画
            maxmin: true,//按钮最大化
            skin: 'layui-layer-rim', //加上边框
            btnAlign: 'c',//按钮居中
            //shade: [0.5, '#393D49'],//设置背部遮罩层
            shade:0,
            //shadeClose: obj.ClickBackClose === undefined ? this.default.ClickBackClose : obj.ClickBackClose,//点击背部遮罩层是否关闭
            area: [obj.width === undefined ? this.default.width : obj.width, obj.height === undefined ? this.default.height : obj.height], //宽高
            content: obj.content === undefined ? this.default.content : obj.content,
            yes: obj.yes === undefined ? this.default.yes : obj.yes,
            btn2: obj.end === undefined ? this.default.end : obj.end

        });
    }


}

/////editormd用法
//<div id='demo'>
//    <textarea># 张三</textarea>
//</div>
//var testEditor = editormd("demo", {
//    placeholder: '左边编写，右边预览',  //默认显示的文字
//    width: "90%",//宽
//    height: 640,
//    syncScrolling: "single",
//    path: "/lib/editormd/lib/",//资源路径
//    theme: "gray",//主题 gray dark
//    emoji: true,//emoji表情
//    /**上传图片相关配置如下*/
//    //imageUpload: true,
//    //imageFormats: ["jpg", "jpeg", "gif", "png", "bmp", "webp"],
//    //imageUploadURL: "/editorMDUpload",//注意你后端的上传图片服务地址
//    previewTheme: "gray",//预览主题
//    editorTheme: "pastel-on-gray",//编辑主题
//    toolbarIcons: function () {  //自定义工具栏
//        return editormd.toolbarModes['full']; // full, simple, mini
//    }
//});
//testEditor.getMarkdown();


///显示markdown
//var testEditormdView2 = editormd.markdownToHTML("demo", {
//    htmlDecode: "style,script,iframe",  // you can filter tags decode
//    emoji: true,
//    taskList: true,
//    tex: true,  // 默认不解析
//    flowChart: true,  // 默认不解析
//    sequenceDiagram: true,  // 默认不解析

//});