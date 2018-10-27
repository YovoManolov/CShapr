<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="callPostMethod.aspx.cs" Inherits="RESTExercise.callPostMethod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
        <form id="baseForm" runat="server"> </form>
         <form id="addForm" action="http://localhost:52984/Service1.svc/addResource?id=2&value=3"
                                method="post">
                <input type="submit" value="Add"/>
    </form>
     <form id="updateForm" action="http://localhost:52984/Service1.svc/updateResource?id=2&value=4"
                                method="post">
                <input type="submit" value="Update"/>
    </form>
    <form id="deleteForm" action="http://localhost:52984/Service1.svc/updateResource?id=2&value=4&isdel=true"
                                method="post">
                <input type="submit" value="Delete"/>
    </form>
   </div>
</body>
</html>
