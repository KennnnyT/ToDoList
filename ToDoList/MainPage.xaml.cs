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
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<TodoTask> _tasks;
        public Button AddTaskButton { get; set; }

        public ObservableCollection<TodoTask> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }
        public MainPage()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TodoTask>();
            BindingContext = this;
            AddTaskButton = new Button { Text = "Ajouter une tâche" };

            Tasks = new ObservableCollection<TodoTask>()
        {
            new TodoTask() { TaskName = "Faire les courses", IsCompleted = false, Status = "Not Started" },
            new TodoTask() { TaskName = "Aller chez le dentiste", IsCompleted = true, Status = "Complete" },
            new TodoTask() { TaskName = "Appeler maman", IsCompleted = false, Status = "In Progress" }
        };

            TaskListView.ItemsSource = Tasks;
            AddTaskButton.Clicked += AddTaskButton_Clicked;
            TaskListView.ItemTapped += TaskListView_ItemTapped;
        }

        private async void TaskListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            var task = (TodoTask)e.Item;
            if (task.Status == "Not Started")
            {
                task.Status = "In Progress";
            }
            else if (task.Status == "In Progress")
            {
                task.Status = "Complete";
            }
            else
            {
                task.Status = "Not Started";
            }
            await UpdateTaskAsync(task);
        }

        private async void DeleteTaskButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var task = (TodoTask)button.CommandParameter;

            _tasks.Remove(task);
        }

        private async Task DeleteTaskAsync(TodoTask task)
        {
            if (App.Database != null)
            {
                await App.Database.DeleteTaskAsync(task);
            }
            else
            {
                // Gérer l'erreur ou afficher un message d'erreur
            }

            // Vérifier si la tâche est encore dans la collection avant de l'enlever
            if (Tasks.Contains(task))
            {
                Tasks.Remove(task);
            }
        }



        private async void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            string taskName = await DisplayPromptAsync("Nouvelle tâche", "Entrez le nom de la tâche :");
            if (!string.IsNullOrEmpty(taskName))
            {
                var newTask = new TodoTask() { TaskName = taskName, IsCompleted = false, Status = "Not Started" };
                if (App.Database != null)
                {
                    await App.Database.SaveTaskAsync(newTask);
                }
                else
                {
                    // gérer l'erreur ou afficher un message d'erreur
                }
                Tasks.Add(newTask);
            }
        }

        private async Task UpdateTaskAsync(TodoTask task)
        {
            if (App.Database != null)
            {
                await App.Database.SaveTaskAsync(task);
            }
            else
            {
            
                // rien a dire sinon hello 

            }
        }
    }
}
