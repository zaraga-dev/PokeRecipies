using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Java.Util.Jar.Attributes;

namespace PokeRecipies.Routes.Ingredients
{
    internal class IngredientsDataStore
    {
        private const string COLLECTION_NAME = "Ingredient";
        private static IngredientsDataStore? _instance;
        private static zaraga.FirestoreCommunication.Shared? firestore;

        internal static IngredientsDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IngredientsDataStore();
                    firestore = IPlatformApplication.Current?.Services.GetService<zaraga.FirestoreCommunication.Shared>();
                }
                return _instance;
            }
        }

        internal async Task GenerateIngredients()
        {
            try
            {
                if (firestore != null)
                {
                    await firestore.DeleteCollection(COLLECTION_NAME);

                    await firestore.AddData(COLLECTION_NAME, new IngredientModel()
                    {
                        IngredientName = "",
                        IngredientDescription = "",
                        IngredientImage = "",
                        IngredientIngredients = new List<string> { "Rice", "Raw Fish", "Avocado", "Seaweed", "Soy Sauce" },
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

    [FirestoreData]
    internal class IngredientModel
    {
        public IngredientModel() { }

        public IngredientModel(string? ingredientName, string? ingredientDescription, string? ingredientImage, DateTime createdAt, List<string>? ingredientIngredients)
        {
            IngredientName = ingredientName;
            IngredientDescription = ingredientDescription;
            IngredientImage = ingredientImage;
            CreatedAt = createdAt;
            IngredientIngredients = ingredientIngredients;
        }

        [FirestoreDocumentId]
        internal string? Id { get; set; }

        [FirestoreProperty]
        internal string? IngredientName { get; set; }

        [FirestoreProperty]
        internal string? IngredientDescription { get; set; }

        [FirestoreProperty]
        internal string? IngredientImage { get; set; }

        [FirestoreProperty]
        internal DateTime CreatedAt { get; set; }

        [FirestoreProperty]
        internal List<string>? IngredientIngredients { get; set; }
    }
}
