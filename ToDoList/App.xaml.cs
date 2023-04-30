using System;
using System.IO;
using Xamarin.Forms;


namespace ToDoList
{
    public partial class App : Application
    {
        static TodoItemDatabase database;

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3");
                    database = new TodoItemDatabase(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            try
            {
                // Créer les tables dans la base de données
                await Database.CreateTableAsync<TodoTask>();

                // Vérifier si la base de données contient des tâches
                var tasks = await Database.GetTasksAsync();
                if (tasks == null || tasks.Count == 0)
                {
                    // Ajouter des tâches par défaut si la base de données est vide
                    await Database.SaveTaskAsync(new TodoTask { TaskName = "Tâche 1", IsCompleted = false, Status = "Not Started" });
                    await Database.SaveTaskAsync(new TodoTask { TaskName = "Tâche 2", IsCompleted = false, Status = "Not Started" });
                    await Database.SaveTaskAsync(new TodoTask { TaskName = "Tâche 3", IsCompleted = false, Status = "Not Started" });
                }
            }
            catch (Exception ex)
            {
                // Gérer l'erreur ou afficher un message d'erreur
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
