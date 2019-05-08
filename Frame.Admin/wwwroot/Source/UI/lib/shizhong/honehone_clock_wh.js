/******************************************************************************
	èâä˙ê›íË
******************************************************************************/
var swfUrl = "http://chabudai.sakura.ne.jp/blogparts/honehoneclock/honehone_clock_tr.swf";

var swfTitle = "honehoneclock";

// é¿çs
LoadBlogParts();

/******************************************************************************
	ì¸óÕ		Ç»Çµ
	èoóÕ		document.writeÇ…ÇÊÇÈHTMLèoóÕ
******************************************************************************/
function LoadBlogParts(){
	var sUrl = swfUrl;
	
	var sHtml = "";
    sHtml += '<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0" width="100%" height="100%" id="' + swfTitle + '" align="middle">';
	sHtml += '<param name="allowScriptAccess" value="always" />';
	sHtml += '<param name="movie" value="' + sUrl + '" />';
	sHtml += '<param name="quality" value="" />';
	sHtml += '<param name="bgcolor" value="rgba(0,0,0,0)" />';
	sHtml += '<param name="wmode" value="transparent" />';
    sHtml += '<embed wmode="transparent" src="' + sUrl + '" quality="high" bgcolor="rgba(0,0,0,0)" width="100%" height="100%" name="' + swfTitle + '" align="middle" allowScriptAccess="always" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />';
	sHtml += '</object>';
	
	document.write(sHtml);
}
