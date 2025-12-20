namespace PokeRecipies
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            //count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);

            var firestore = Handler?.MauiContext?.Services.GetService<FirestoreCommunication.Shared>();
            if (firestore != null)
                await firestore.Connect();
        }
    }

}
