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
    public partial class AddTaskPage : ContentPage
    {
        public Action<object, object> TaskAdded { get; internal set; }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var task = (TodoTask)BindingContext;
            await App.Database.SaveTaskAsync(task);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var task = (TodoTask)BindingContext;
            await App.Database.DeleteTaskAsync(task);
            await Navigation.PopAsync();
        }
    }
}
