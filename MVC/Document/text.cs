正则表达式：
类型转参数变量
\w* \w* (\w*) { get; set; }
var P_$1=Request.QueryString["$1"]??Request.Form["$1"];
参数变量转非空验证
var (\w*) = [\w\.\[\"\]\?\s]*;
if(string.IsNullOrEmpty($1)) throw new Exception("$1不能为空");