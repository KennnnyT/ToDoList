using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace ToDoList
{
    public class TodoTask : ObservableObject
    {
        private string taskName;
        public string TaskName
        {
            get { return taskName; }
            set
            {
                if (taskName != value)
                {
                    taskName = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isCompleted;
        public bool IsCompleted
        {
            get { return isCompleted; }
            set
            {
                if (isCompleted != value)
                {
                    isCompleted = value;
                    OnPropertyChanged();
                }
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Id { get; internal set; }
    }

}