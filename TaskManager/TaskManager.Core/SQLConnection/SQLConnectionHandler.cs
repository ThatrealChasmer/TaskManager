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

        // Change the string after @ to connect to your database
        public SqlConnection connection = new SqlConnection(@"Data Source=(local)\TASKMANAGERDB;Initial Catalog=TaskManager;Integrated Security=True;");

        #region Tasks

        /// <summary>
        /// Get all tasks from database
        /// </summary>
        /// <returns>List of tasks</returns>
        public List<Task> GetTasks()
        {
            List<Task> toPass = new List<Task>();

            SqlCommand cmd = new SqlCommand("GetTasks", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                IDataRecord data = (IDataRecord)rdr;
            
                DateTime? CheckedEndDate;
            
                if(data[4] == DBNull.Value)
                {
                    CheckedEndDate = null;
                }
                else
                {
                    CheckedEndDate = data.GetDateTime(4);
                }
            
                Task toAdd = new Task((int)data[0], (string)data[1], (string)data[2], data.GetDateTime(3), CheckedEndDate, (Priority)(data.GetByte(5)), (TaskState)(data.GetByte(6)));
            
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
            int y = task.EndDate.Value.Year;
            connection.Open();

            SqlCommand cmd = new SqlCommand("AddTask", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@title", task.Title);
            cmd.Parameters.AddWithValue("@contents", task.Contents);
            cmd.Parameters.AddWithValue("@add_date", task.StartDate);
            if(task.EndDate.Value.Year > 1753 && task.EndDate.Value.Year < 9999)
            {
                cmd.Parameters.AddWithValue("@end_date", task.EndDate);
            }
            else cmd.Parameters.AddWithValue("@end_date", DBNull.Value);
            cmd.Parameters.AddWithValue("@task_priority", (int)task.Priority);
            cmd.Parameters.AddWithValue("@task_state", (int)task.State);

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
            

            connection.Open();

            SqlCommand cmd = new SqlCommand("EditTask", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@title", task.Title);
            cmd.Parameters.AddWithValue("@contents", task.Contents);
            cmd.Parameters.AddWithValue("@add_date", task.StartDate);
            if (task.EndDate.Value.Year > 1753 && task.EndDate.Value.Year < 9999)
            {
                cmd.Parameters.AddWithValue("@end_date", task.EndDate);
            }
            else cmd.Parameters.AddWithValue("@end_date", DBNull.Value);
            cmd.Parameters.AddWithValue("@task_priority", (int)task.Priority);
            cmd.Parameters.AddWithValue("@Task_state", (int)task.State);
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
            connection.Open();

            SqlCommand cmd = new SqlCommand("DeleteTask", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

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
            connection.Open();

            SqlCommand cmd = new SqlCommand("MoveTask", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@task_state", s);
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

            SqlCommand cmd = new SqlCommand("GetNotes", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

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
            connection.Open();

            SqlCommand cmd = new SqlCommand("AddNote", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@task_id", note.TaskID);
            cmd.Parameters.AddWithValue("@added", note.Added);
            cmd.Parameters.AddWithValue("@contents", note.Contents);

            cmd.ExecuteNonQuery();

            rdr.Close();
            connection.Close();
        }

        /// <summary>
        /// Delete note from database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteNote(int id)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("DeleteNote", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            rdr.Close();
            connection.Close();
        }

        #endregion
    }
}
