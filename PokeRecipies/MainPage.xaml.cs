using Google.Cloud.Firestore;

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



    [FirestoreData]
    public class SampleModel
    {
        public string Id { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public List<string> Ingredients { get; set; }
        [FirestoreProperty]
        public List<string> Steps { get; set; }
        //[FirestoreProperty(ConverterType = typeof(DateTieToTieSpanConverter))]
        [FirestoreProperty]
        public DateTime CreatedAt { get; set; }
    }

}
