using System;  
using System.IO;  
using System.Data;  
using System.Data.SqlClient;  
using System.Configuration;  
public partial class _Default : System.Web.UI.Page  
{  
     
    SqlConnection conn;  
  
    string sqlconn;  
    protected void Page_Load(object sender, EventArgs e)  
    {  
    
    }    
     
    private void connection()  
    {  
        sqlconn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;  
        conn = new SqlConnection(sqlconn);  
  
    }  
    
    protected void ButtonLoad_Click(object sender, EventArgs e)  
    {            
        DataTable dt = new DataTable(); 

        dt.Columns.Add("TaskNumber");  
        dt.Columns.Add("TaskSubject");  
        dt.Columns.Add("TaskPriority");  
        dt.Columns.Add("TaskStatus");  

        string CSV_Path = Path.GetFullPath("C:/test/tasks.csv");  
        string Read_CSV = File.ReadAllText(CSV_Path);  

        foreach (string CSV_Row in Read_CSV.Split('\n'))  
        {  
            if (!string.IsNullOrEmpty(CSV_Row))  
            {  
                //Adding each row into datatable  
                dt.Rows.Add();  
                int count = 0;  
                foreach (string CSV_Field in CSV_Row.Split(','))  
                {  
                    dt.Rows[dt.Rows.Count - 1][count] = CSV_Field;  
                    count++;  
                }  
            }  
             
            
        } 
        InsertCSVRecords(dt);  
    }  
   

    private void InsertCSVRecords(DataTable dt)  
    {    
        connection();  
        conn.Open(); 

        string sqlExpression = String.Format("truncate table tasks");
        SqlCommand command = new SqlCommand(sqlExpression, conn);
        command.ExecuteNonQuery();
   
        SqlBulkCopy objbulk = new SqlBulkCopy(conn);  
        objbulk.DestinationTableName = "tasks";  
        objbulk.ColumnMappings.Add("TaskNumber", "TaskNumber");  
        objbulk.ColumnMappings.Add("TaskSubject", "TaskSubject");  
        objbulk.ColumnMappings.Add("TaskPriority", "TaskPriority");  
        objbulk.ColumnMappings.Add("TaskStatus", "TaskStatus");         
        objbulk.WriteToServer(dt);  

        GridView1.DataBind();
        conn.Close();    
    } 
}  