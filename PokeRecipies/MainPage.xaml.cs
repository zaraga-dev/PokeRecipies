using PokeRecipies.Models;

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
            var firestore = Handler?.MauiContext?.Services.GetService<zaraga.FirestoreCommunication.Shared>();
            if (firestore != null)
                await firestore.AddData("sample", new SampleModel()
                {
                    Name = "Poke Bowl",
                    Description = "A delicious poke bowl with fresh ingredients.",
                    Ingredients = new List<string> { "Rice", "Raw Fish", "Avocado", "Seaweed", "Soy Sauce" },
                    Steps = new List<string> { "Cook the rice.", "Prepare the fish.", "Assemble the bowl." },
                    CreatedAt = DateTime.UtcNow
                });

        }
    }

}
