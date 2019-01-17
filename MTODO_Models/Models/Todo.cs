using MTODO_Models.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MTODO_Models.Models
{
    public class Todo : ModelBase
    {
        public static int Last_Id = 0;

        private int _id;
        public int ID
        {
            get { return _id; }
            set { SetValue(ref _id, value); }
        }


        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetValue(ref _title, value); }
        }

        private DateTime _dueDate;

        public DateTime DueDate
        {
            get { return _dueDate; }
            set { SetValue(ref _dueDate, value); }
        }

        public Todo()
        {
            ID = Interlocked.Increment(ref Last_Id);
        }

        //TODO: Property für Bild/Datei anlegen

    }
}
