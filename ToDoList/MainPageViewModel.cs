using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Syncfusion.SfChart.XForms;

namespace ToDoList
{
    public class MainPageViewModel
    {
        public ObservableCollection<Task> Tasks { get; set; }

        public MainPageViewModel()
        {
            Tasks = new ObservableCollection<Task>();
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public void DeleteTask(Task task)
        {
            Tasks.Remove(task);
        }

        public void UpdateTaskStatus(TodoTask task, string newStatus)
        {
            task.Status = newStatus;
        }
    }

}
