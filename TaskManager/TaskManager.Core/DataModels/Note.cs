using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core
{
    public class Note
    {
        public int ID { get; set; }
        public int TaskID { get; set; }
        public DateTime Added { get; set; }
        public string Contents { get; set; }

        public Note(int id, int taskid, string contents, DateTime added)
        {
            ID = id;
            TaskID = taskid;
            Added = added;
            Contents = contents;
        }
    }
}
