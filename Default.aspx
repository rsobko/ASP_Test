<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"%>  

<!DOCTYPE html>  
 
<html xmlns="http://www.w3.org/1999/xhtml">  
<head id="Head1" runat="server">    
    <title>ASP_Test</title>    
</head>    
<body>       
    <form id="form1" runat="server">    
    <div>    
       <h>Load Data</h>
       <asp:Button ID="ButtonLoad" runat="server" Text="Load" OnClick="ButtonLoad_Click" /> 
        <br></br>
    </div> 
    <div>  
        <asp:SqlDataSource ID="Task_Source" runat="server"
             ConnectionString="Data Source=localhost;Initial Catalog=ASP_Test;Integrated Security=True;" providerName="System.Data.SqlClient"
             SelectCommand="SELECT TaskNumber, TaskSubject, TaskPriority, TaskStatus FROM tasks order by TaskNumber" />
        
        <asp:GridView ID="GridView1" runat="server"
            DataSourceID="Task_Source" PageSize="5" AllowPaging="True" AllowSorting="true" EnablePersistedSelection="true" DataKeyNames="TaskNumber" AutoGenerateColumns="False" HorizontalAlign="Center" >
            <Columns>
                <asp:BoundField DataField="TaskNumber" HeaderText="TaskNumber" SortExpression="TaskNumber" />
                <asp:BoundField DataField="TaskSubject" HeaderText="TaskSubject" SortExpression="TaskSubject" />
                <asp:BoundField DataField="TaskPriority" HeaderText="TaskPriority" SortExpression="TaskPriority" />
                <asp:BoundField DataField="TaskStatus" HeaderText="TaskStatus" SortExpression="TaskStatus" />
            </Columns>
        </asp:GridView>                
      </div>  
    </form>   
</body>    
</html>  