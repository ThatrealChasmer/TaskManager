using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core
{
    /// <summary>
    /// Class handling connection with database and queries
    /// </summary>
    public class SQLConnectionHandler
    {
        // Static instance accessible from every place in a code
        public static SQLConnectionHandler Instance = new SQLConnectionHandler();

        // Initializing reader and connection
        public SqlDataReader rdr = null;
        public SqlConnection connection = new SqlConnection(@"Data Source=(local)\TASKMANAGERDB;Initial Catalog=TaskManager;Integrated Security=True;");

        #region Tasks

        /// <summary>
        /// Get all tasks from database
        /// </summary>
        /// <returns>List of tasks</returns>
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

        /// <summary>
        /// Adding task to database using SQLParameter
        /// </summary>
        /// <param name="task">Task to add</param>
        public void AddTask(Task task)
        {
            string query = "USE TaskManager;INSERT INTO TaskManager.dbo.Tasks(title, contents, add_date, end_date, task_priority, task_state) VALUES (@title, @contents, @start, @end, @priority, @state);";

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@title", task.Title);
            cmd.Parameters.AddWithValue("@contents", task.Contents);
            cmd.Parameters.AddWithValue("@start", task.StartDate);
            cmd.Parameters.AddWithValue("@end", task.EndDate);
            cmd.Parameters.AddWithValue("@priority", (int)task.Priority);
            cmd.Parameters.AddWithValue("@state", (int)task.State);

            cmd.ExecuteNonQuery();

            rdr.Close();
            connection.Close();
        }

        /// <summary>
        /// Editing task
        /// </summary>
        /// <param name="task">Task to edit</param>
        public void EditTask(Task task)
        {
            string query = "USE TaskManager;UPDATE TaskManager.dbo.Tasks SET title=@title, contents=@contents, add_date=@start, end_date=@end, task_priority=@priority, task_state=@state WHERE id=@id;";

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@title", task.Title);
            cmd.Parameters.AddWithValue("@contents", task.Contents);
            cmd.Parameters.AddWithValue("@start", task.StartDate);
            cmd.Parameters.AddWithValue("@end", task.EndDate);
            cmd.Parameters.AddWithValue("@priority", (int)task.Priority);
            cmd.Parameters.AddWithValue("@state", (int)task.State);
            cmd.Parameters.AddWithValue("@id", task.ID);

            cmd.ExecuteNonQuery();

            rdr.Close();
            connection.Close();
        }

        /// <summary>
        /// Delete task from database by given id
        /// </summary>
        /// <param name="id">ID to delete</param>
        public void DeleteTask(int id)
        {
            string query = "USE TaskManager;DELETE FROM TaskManager.dbo.Tasks WHERE id=@id";

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            rdr.Close();
            connection.Close();
        }

        /// <summary>
        /// Change the state of task
        /// </summary>
        /// <param name="id">ID of the task</param>
        /// <param name="s">New task state</param>
        public void MoveTask(int id, TaskState s)
        {
            string query = "USE TaskManager;UPDATE TaskManager.dbo.Tasks SET task_state=@ts WHERE id=@id;";

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ts", s);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            rdr.Close();
            connection.Close();
        }

        #endregion

        #region Notes

        /// <summary>
        /// Get list of all notes for a given task id
        /// </summary>
        /// <param name="ID">Task id</param>
        /// <returns>List of all notes for given task</returns>
        public List<Note> GetNotes(int ID)
        {
            List<Note> toPass = new List<Note>();

            SqlCommand cmd = new SqlCommand("use TaskManager;select * from Notes where task_id = @t_id;", connection);

            cmd.Parameters.AddWithValue("@t_id", ID);

            connection.Open();

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                IDataRecord data = (IDataRecord)rdr;
                
                Note toAdd = new Note(data.GetInt32(0), data.GetInt32(1), data.GetString(2), data.GetDateTime(3));

                toPass.Add(toAdd);
            }

            rdr.Close();

            connection.Close();

            return toPass;
        }

        /// <summary>
        /// Add note to database
        /// </summary>
        /// <param name="note">Note to add</param>
        public void AddNote(Note note)
        {
            string query = "USE TaskManager;INSERT INTO TaskManager.dbo.Notes(task_id, added, contents) VALUES (@task_id, @added, @contents);";

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@task_id", note.TaskID);
            cmd.Parameters.AddWithValue("@added", note.Added);
            cmd.Parameters.AddWithValue("@contents", note.Contents);

            cmd.ExecuteNonQuery();

            rdr.Close();
            connection.Close();
        }

        #endregion
    }
}
