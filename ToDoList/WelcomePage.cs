
using Xamarin.Forms;

namespace ToDoList
{
    public class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            Title = "Bienvenue sur ToDoList";

            var label = new Label
            {
                Text = "Welcome to ToDo List App",
                FontSize = 24,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var button = new Button
            {
                Text = "Let's Go",
                FontSize = 20,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Orange
            };

            var circle = new AbsoluteLayout()
            {
                BackgroundColor = Color.FromHex("#F5F5DC"),
                WidthRequest = 200,
                HeightRequest = 200,
                Opacity = 0.7,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            circle.Children.Add(button, new Rectangle(0.5, 0.5, 120, 120), AbsoluteLayoutFlags.PositionProportional);

            Content = new StackLayout
            {
                BackgroundColor = Color.Beige,
                Children = {
                    label,
                    circle
                }
            };

            button.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new MainPage());
            };
        }
    }
}