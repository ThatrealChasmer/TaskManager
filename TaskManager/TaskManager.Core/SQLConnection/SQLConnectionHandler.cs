using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core
{
    public class SQLConnectionHandler
    {
        public static SQLConnectionHandler Instance = new SQLConnectionHandler();

        public SqlDataReader rdr = null;
        public SqlConnection connection = new SqlConnection(@"Data Source=(local)\TASKMANAGERDB;Initial Catalog=TaskManager;Integrated Security=True;");

        public List<Task> GetTasks()
        {
            List<Task> toPass = new List<Task>();

            SqlCommand cmd = new SqlCommand("use TaskManager;select * from Tasks;", connection);

            connection.Open();

            rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                IDataRecord data = (IDataRecord)rdr;

                Task toAdd = new Task((int)data[0], (string)data[1], (string)data[2], data.GetDateTime(3), data.GetDateTime(4), (Priority)data[5], (TaskState)data[6]);

                toPass.Add(toAdd);
            }

            rdr.Close();

            connection.Close();

            return toPass;
        }

        public void AddTask(Task task)
        {
            string query = "use TaskManager;INSERT INTO TaskManager.dbo.Tasks (title, contents, add_date, end_date, task_priority, task_state)"
                + " VALUES ('" + task.Title + "', '" + task.Contents + "', '" + task.StartDate.ToString() + "', '" + task.EndDate.ToString() + "', '" + (int)task.Priority + "', '" + (int)task.State + "');";

            string testQuery = "USE TaskManager;INSERT INTO TaskManager.dbo.Tasks(title, contents, add_date, end_date, task_priority, task_state) VALUES ('test1', 'test task 1', '20191011', '20191014', '1', '0'); ";

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
