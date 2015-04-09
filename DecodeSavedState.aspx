<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DecodeSavedState.aspx.cs" Inherits="DecodeSavedState" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Decode Saved State</title>
    <link href="../Styles/Admin.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form method="post" runat="server">
        <div>
            State ID: 
            <input type="text" id="txtStateID" runat="server" />
            <br /><br />
            <input type="submit" value="Decode" id="cmdDecode" runat="server" onserverclick="Decode_Click" />
            <br /><br />
        </div>
        <div id="divResult" align="left" runat="server"> </div>
    </form>
</body>
</html>
