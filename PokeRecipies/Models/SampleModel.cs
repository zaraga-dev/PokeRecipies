using Google.Cloud.Firestore;

namespace PokeRecipies.Models
{

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
