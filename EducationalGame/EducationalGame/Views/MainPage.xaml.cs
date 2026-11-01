

namespace EducationalGame
{
    public partial class MainPage : ContentPage
    {
        private HorizontalStackLayout languagelayout;
        private HorizontalStackLayout buttonlayout;
        private HorizontalStackLayout imagelayout;


        private CollectionView gamelayout;

       

        private Image dragimage1;

        private Image dragimage2;

        private Image dragimage3;


        private Button EnglishBtn;
        private Button EstonianBtn;
        private Button RussianBtn;

        private Button StartBtn;
        private Button ThemeBtn;
        private Button StatisticsBtn;

        private VerticalStackLayout mainlayout;

        private string currentlyDraggedAnimal;

        public MainPage()
        {
           

            dragimage1 = new Image
            {
                HeightRequest = 100,
                WidthRequest = 100,
                Source = "cat.jpg"
            };

            dragimage2 = new Image
            {
                HeightRequest = 100,
                WidthRequest = 100,
                Source = "dog.jpg"
            };

            dragimage3 = new Image
            {
                HeightRequest = 100,
                WidthRequest = 100,
                Source = "hamster.png"
            };

            

            

            EnglishBtn = new Button
            {
                Text = "English"
            };

            RussianBtn = new Button
            {
                Text = "Russian"
            };

            EstonianBtn = new Button
            {
                Text = "Estonian"
            };

            StartBtn = new Button
            {
                Text = "Start"
            };

            ThemeBtn = new Button
            {
                Text = "Theme"
            };

            StatisticsBtn = new Button
            {
                Text = "Statistics"
            };

            languagelayout = new HorizontalStackLayout
            {

            };

            gamelayout = new CollectionView
            {
                ItemsLayout = LinearItemsLayout.Horizontal,

                ItemsSource = new List<string> { "Cat", "Dog", "Hamster" },

                ItemTemplate = new DataTemplate(() =>
                {
                    var itemlayout = new VerticalStackLayout { };

                    var image = new Image { HeightRequest = 100, WidthRequest = 100 };
                    var label = new Label { HorizontalOptions = LayoutOptions.Center };

                    label.SetBinding(Label.TextProperty, ".");

                    var dropGesture = new DropGestureRecognizer { AllowDrop = true };
                    dropGesture.Drop += AnimalDropped;
                    itemlayout.GestureRecognizers.Add(dropGesture);

                    itemlayout.Add(image);
                    itemlayout.Add(label);

                    return itemlayout;

                })
            };

            imagelayout = new HorizontalStackLayout
            {
                Spacing = 20
            };

            buttonlayout = new HorizontalStackLayout
            {
                Margin = 20,
                Spacing = 20
            };

            mainlayout = new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var drag1 = new DragGestureRecognizer { CanDrag = true };


            drag1.DragStarting += DraggedCat;


            dragimage1.GestureRecognizers.Add(drag1);



            var drag2 = new DragGestureRecognizer { CanDrag = true };


            drag2.DragStarting += DraggedDog;


            dragimage2.GestureRecognizers.Add(drag2);


            var drag3 = new DragGestureRecognizer { CanDrag = true };


            drag3.DragStarting += DraggedHamster;


            dragimage3.GestureRecognizers.Add(drag3);



            languagelayout.Add(EnglishBtn);
            languagelayout.Add(RussianBtn);
            languagelayout.Add(EstonianBtn);

            

            imagelayout.Add(dragimage1);
            imagelayout.Add(dragimage2);
            imagelayout.Add(dragimage3);

            buttonlayout.Add(StatisticsBtn);
            buttonlayout.Add(StartBtn);
            buttonlayout.Add(ThemeBtn);

            mainlayout.Add(languagelayout);
            mainlayout.Add(gamelayout);
            mainlayout.Add(imagelayout);
            mainlayout.Add(buttonlayout);

            

            this.Content = mainlayout;

        }

        private void DraggedCat(object sender, EventArgs e)
        {
            
            currentlyDraggedAnimal = "Cat";
        }

        private void DraggedDog(object sender, EventArgs e)
        {

            currentlyDraggedAnimal = "Dog";
        }

        private void DraggedHamster(object sender, EventArgs e)
        {

            currentlyDraggedAnimal = "Hamster";
        }

        private async void AnimalDropped(object sender, DropEventArgs e)
        {
            var droppedOnLayout = (VerticalStackLayout)sender;

            
            var rowLabel = (Label)droppedOnLayout.Children[1];

            if (currentlyDraggedAnimal == rowLabel.Text)
            {
               await DisplayAlertAsync("Correct!", "You matched the " + rowLabel.Text, "OK");
            }
            else
            {
               await DisplayAlertAsync("Wrong!", "Try again", "OK");
            }
            currentlyDraggedAnimal = "";
        }


    }
}
