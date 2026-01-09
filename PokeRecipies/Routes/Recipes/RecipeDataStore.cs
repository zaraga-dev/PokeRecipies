using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRecipies.Routes.Recipes
{
    public class RecipeDataStore
    {
        private static string COLLECTION_NAME = "Recipe";

        private static RecipeDataStore? _instance;
        private static zaraga.FirestoreCommunication.Shared? firestore;

        public static RecipeDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RecipeDataStore();
                    firestore = IPlatformApplication.Current?.Services.GetService<zaraga.FirestoreCommunication.Shared>();
                }
                return _instance;
            }
        }


        public RecipeDataStore() { }

        public async Task AddRecipe(string name, string description, string image)
        {

            if (firestore != null)
                await firestore.AddData(COLLECTION_NAME, new RecipeModel()
                {
                    RecipeName = name,
                    RecipeDescription = description,
                    RecipeImage = image,
                    RecipeIngredients = new List<string> { "Rice", "Raw Fish", "Avocado", "Seaweed", "Soy Sauce" },
                    CreatedAt = DateTime.UtcNow
                });

        }

        public async Task<List<RecipeModel>?> GetRecipes()
        {
            if (firestore == null)
                return null;

            return await firestore.GetList<RecipeModel>(COLLECTION_NAME);
        }

        public async Task<RecipeModel?> GetRecipe(string itemId)
        {
            if (firestore == null)
                return null;

            return await firestore.GetItem<RecipeModel>(COLLECTION_NAME, itemId);
        }

    }

    [FirestoreData]
    public class RecipeModel
    {
        [FirestoreDocumentId]
        public string? Id { get; set; }
        [FirestoreProperty]
        public string? RecipeName { get; internal set; }
        [FirestoreProperty]
        public string? RecipeDescription { get; internal set; }
        [FirestoreProperty]
        public string? RecipeImage { get; set; }

        //[FirestoreProperty]
        //public RecipeTypeModel? RecipeType { get; set; }

        [FirestoreProperty]
        public List<string>? RecipeIngredients { get; internal set; }
        [FirestoreProperty]
        public DateTime CreatedAt { get; internal set; }
    }

    [FirestoreData]
    public class RecipeTypeModel
    {
        [FirestoreDocumentId]
        public string? Id { get; set; }
        [FirestoreProperty]
        public int RecipeTypeOrder { get; set; }
        [FirestoreProperty]
        public string? RecipeTypeName { get; set; }

    }

}
