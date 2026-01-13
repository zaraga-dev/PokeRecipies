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
        private const string COLLECTION_NAME = "Recipe";
        private const string COLLECTION_RECIPETYPE_NAME = "RecipeType";

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



        public async Task GenerateRecipes()
        {
            try
            {
                if (firestore != null)
                {
                    await firestore.DeleteCollection(COLLECTION_NAME);
                    await firestore.DeleteCollection(COLLECTION_RECIPETYPE_NAME);
                    //Recipe Types
                    RecipeTypeModel curryModel = new RecipeTypeModel(1, "Curry");
                    RecipeTypeModel saladModel = new RecipeTypeModel(2, "Ensalada");
                    RecipeTypeModel desserModel = new RecipeTypeModel(3, "Postre");

                    var curryRef = await firestore.AddData(COLLECTION_RECIPETYPE_NAME, 1, curryModel);
                    var saladRef = await firestore.AddData(COLLECTION_RECIPETYPE_NAME, 2, saladModel);
                    var desserRef = await firestore.AddData(COLLECTION_RECIPETYPE_NAME, 3, desserModel);

                    //Curry Recipes
                    List<RecipeModel> recipes = new()
                    {
                        new RecipeModel(
                             recipeName:"Curri Mixto",
                             recipeDescription:"Plato genérico de categoría curri.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1000.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName: "Curri de Manzana Selecta",
                             recipeDescription: "Curri sencillo en el que destaca el dulzor natural de la manzana",
                             recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1001_1.png",
                             recipeType: curryRef,
                             recipeTypeOrder: curryModel.RecipeTypeOrder,
                             createdAt: DateTime.Now,
                             recipeIngredients: null),
                        new RecipeModel(
                             recipeName:"Sopa Cremosa",
                             recipeDescription:"Crema sencilla en la que destaca el sabor de la leche.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1010.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri Meloso",
                             recipeDescription:"Una generosa cantidad de miel hace de este curri un favorito entre los niños.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1012.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri de Hamburguesa Vegetariana",
                             recipeDescription:"Las hamburguesas de origen vegetal son las estrellas indiscutibles de este curri.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1011_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri de Hamburguesa con Queso",
                             recipeDescription:"Un plato tan enorme que dejaría anonadado hasta a un Snorlax.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1008_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri con Escalope \"Sequía\"",
                             recipeDescription:"El brillo del rebozado recién frito hace la boca agua solo con verlo.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1014_1.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri de Tomate \"Poder Solar\"",
                             recipeDescription:"En su elaboración se emplean tomates madurados al sol.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1003_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri de Tortilla Jugosa",
                             recipeDescription:"La tortilla de este curri está cocinada en su punto y se deshace en la boca.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1015_1.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Estofado de Patata",
                             recipeDescription:"Su densa textura se logra hirviendo las patatas hasta que se deshacen.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1009.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri de Habas \"Corpulencia\"",
                             recipeDescription:"Un plato enorme que aporta todos los nutrientes para ganar corpulencia",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1016_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri de Setas \"Espora\"",
                             recipeDescription:"Curri que adormece con la misma eficacia que el movimiento Espora.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1006_1.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri \"Bomba Huevo\"",
                             recipeDescription:"Un plato para los más pequeños, y preparado con mucho amor.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1007.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Guiso de Maíz \"Flexibilidad\"",
                             recipeDescription:"Guiso suave y cremoso con un toque dulce por la leche y el maíz.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1017_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri Picante \"Puño Mareo\"",
                             recipeDescription:"Un golpe de sabores dulces y picantes directo a tus papilas gustativas, para acabar con un toque de amargor.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1019_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri de Puerro Picante",
                             recipeDescription:"El dulzor del puerro caramelizado equilibra el picante de la salsa.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1005.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri de Cola a la Parrilla",
                             recipeDescription:"El sabor de la cola eleva el plato a nuevas cotas de exquisitez.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1002.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri Cremoso \"Comesueños\"",
                             recipeDescription:"Curri elaborado con ingredientes de propiedades relajantes.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1004.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri Ninja",
                             recipeDescription:"Se dice que este curri a base de tofu es el preferido de los ninjas.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1013_1.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri Keema de Maíz \"Infierno\"",
                             recipeDescription:"Tras la inicial dulzura del maíz se pasa a niveles infernales de picante.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1018_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Guiso Pumpkaboo \"Imitación\"",
                             recipeDescription:"Este adorable guiso es también un plato equilibrado.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1022_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Crema Vigorizante \"Poder Oculto\"",
                             recipeDescription:"Crema de tomate para empezar el día de la mejor forma posible.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1020_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Curri Sukiyaki \"Corte\"",
                             recipeDescription:"Curri agridulce con huevo duro y trozos de puerro como guarnición.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1021_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null),
                        new RecipeModel(
                             recipeName:"Aguacates Gratinados \"Espesura\"",
                             recipeDescription:"La deliciosa salsa y el suave aguacate combinan a la perfección.",
                             recipeImage:"https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_1023_0.png",
                             recipeType: curryRef,
                             recipeTypeOrder:curryModel.RecipeTypeOrder,
                             createdAt:DateTime.Now,
                             recipeIngredients:null)
                };


                    //Salar Recipes
                    List<RecipeModel> saladRecipes = new()
                    {
                        new RecipeModel(
                            recipeName: "Ensalada Mixta",
                            recipeDescription: "Plato genérico de categoría ensalada",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2000.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Manzana Selecta",
                            recipeDescription: "Sencilla ensalada con aderezo a base de puré de manzana",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2012.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Jamón Vegetariano",
                            recipeDescription: "Sencilla ensalada preparada con Fiambre Vegetariano.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2007.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Siestomate",
                            recipeDescription: "Elaborada con una variedad de tomate que ayuda a conciliar el sueño",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2008_0.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada César \"Manto Níveo\"",
                            recipeDescription: "Ensalada de panceta cubierta por una generosa capa de queso rallado",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2003.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Tofu \"Onda Ígnea\"",
                            recipeDescription: "Ensalada de tofu cubierta de salsa picante de color rojo intenso",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2016.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Manzana y Queso \"Atracción\"",
                            recipeDescription: "El sencillo aderezo resalta la sublime combinación de ingredientes",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2014_1.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Maíz \"Ataque Furia\"",
                            recipeDescription: "Se recomienda empezar atacando el montículo de maíz",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2019_0.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Puerro \"Inmunidad\"",
                            recipeDescription: "El puerro crujiente de esta ensalada refuerza el sistema inmunitario",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2013_1.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada con Mozzarella de Leche Mu-mu",
                            recipeDescription: "Sencilla ensalada a base de queso, tomates y un chorrito de aceite",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2009.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensaladón \"Fuerza Bruta\"",
                            recipeDescription: "Generosa porción de ensalada que alimenta para un día entero",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2006_0.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Tofu \"Velo Agua\"",
                            recipeDescription: "Ensalada con una guarnición a base de cubos de tofu gelatinoso.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2005_0.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Carne al Cacao \"Respondón\"",
                            recipeDescription: "Ofrece un contraste de sabores entre la salsa salada y la de chocolate.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2010.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Patata \"Gula\"",
                            recipeDescription: "Ensalada de patata con ligeras notas de Manzana Selecta",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2004_1.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Jengibre \"Sofoco\"",
                            recipeDescription: "El aderezo especial a base de jengibre aporta calidez al plato y al cuerpo.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2011_1.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Setas \"Espora\"",
                            recipeDescription: "Ensalada rica en ingredientes que ayudan a mejorar la calidad del sueño.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2002.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Aguacate \"Armadura Frágil\"",
                            recipeDescription: "Los tiernos ingredientes se deshacen en el paladar",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2024_0.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Fruta \"Paz Mental\"",
                            recipeDescription: "Macedonia de un dulzor refrescante que reconforta el espíritu.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2018_0.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada de Cola de Slowpoke a la Pimienta",
                            recipeDescription: "El picante de la especia resalta el sabor dulce de la cola.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2001_1.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada \"Tajo Cruzado\"",
                            recipeDescription: "Ensalada en la que todos los ingredientes se han mezclado tras haberlos picado de forma muy fina.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2020_0.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada Verdegal",
                            recipeDescription: "Ensalada elaborada con ingredientes frescos de Isla Verdegal.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2017_0.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada Ninja",
                            recipeDescription: "Ningún ninja puede resistirse a esta ensalada de tofu. Visto y no visto",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2015_1.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Corona de Ensalada \"Tormenta Floral\"",
                            recipeDescription: "El punto del huevo, con la ligereza de los pétalos florales, le aporta una textura suave",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2022_1.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada con Aliño de Yogur \"Ácido Málico\"",
                            recipeDescription: "La acidez del vinagre de manzana y el yogur hacen de esta ensalada un plato de lo más exquisito.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2023_1.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Ensalada con Aliño de Café \"Competitivo\"",
                            recipeDescription: "Un chef trabajó sin descanso para mejorar la receta de esta ensalada aliñada con café hasta perfeccionarla.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2021_0.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Nachos con Guacamole \"Terratemblor\"",
                            recipeDescription: "Los crujientes totopos son el acompañamiento perfecto para la textura cremosa de la salsa.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_2025_0.png",
                            recipeType: saladRef,
                            recipeTypeOrder: saladModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null)
                    };

                    //dessert Recipes
                    List<RecipeModel> dessertRecipes = new()
                    {
                        new RecipeModel(
                            recipeName: "Zumo Mixto",
                            recipeDescription: "Plato genérico de categoría postre.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3000.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Leche Mu-mu Caliente",
                            recipeDescription: "Calentar la Leche Mu-mu resalta todavía más su dulzor natural",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3011_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Zumo de Manzana Selecta",
                            recipeDescription: "Un zumo con cuerpo hecho a partir de las mejores manzanas",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3003_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Refresco Casero",
                            recipeDescription: "Chispeante bebida gaseosa de elaboración casera",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3004_1.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Tarta de Manzana \"Deseo\"",
                            recipeDescription: "Algunas porciones llevan trozos de manzana, es cuestión de suerte",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3008.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Boniatos \"Peluche\"",
                            recipeDescription: "Los boniatos maduros aportan todo el dulzor sin necesidad de añadir miel.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3001_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Té de Jengibre \"Ascuas\"",
                            recipeDescription: "La manzana rebaja el jengibre y hace que sea más agradable al paladar.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3005.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Bizcocho de Soja \"Liviano\"",
                            recipeDescription: "Bizcocho de soja de textura ligera",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3012_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Zumo de Verduras \"Acérrimo\"",
                            recipeDescription: "Zumo de sencilla elaboración con toques naturales dulces y ácidos.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3014_1.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Malasada Maxi",
                            recipeDescription: "Pan frito especial elaborado según una receta de Alola.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3015.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Batido de Proteínas \"Entusiasmo\"",
                            recipeDescription: "Bebida dulce con la que premiarse tras un duro entrenamiento",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3013.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Tartaleta de Chocolate \"Danza Pétalo\"",
                            recipeDescription: "Alegre tartaleta con la que al comerla se esparcen pétalos.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3019_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Tarta de Chocolate \"Dulce Aroma\"",
                            recipeDescription: "Ni humanos ni Pokémon pueden resistirse a su dulce olor.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3010.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Batido \"Beso Amoroso\"",
                            recipeDescription: "Bebida relajante que alivia la fatiga y ayuda a conciliar el sueño.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3007_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Galletas de Jengibre \"Impasible\"",
                            recipeDescription: "Galletas que dan fuerzas para afrontar cualquier adversidad.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3002_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Té Reparador de Neroli",
                            recipeDescription: "Bebida reconstituyente, receta original del Profesor Neroli",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3009_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Dónuts de Soja \"Potencia\"",
                            recipeDescription: "Los culturistas adoran estos roscos de soja en su punto ideal de fritura.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3016_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Palomitas \"Explosión\"",
                            recipeDescription: "Preparadas al instante aplicando un calor suficiente como para provocar una explosión",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3017_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Gelatina de Café \"Madrugar\"",
                            recipeDescription: "Gelatina de café algo amarga que puede ayudarte a despertar más rápido.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3021_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Tiramisú de Maíz \"Rompemoldes\"",
                            recipeDescription: "Esta receta de tiramisú se aleja de la tradición empleando el maíz como único endulzante.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3023_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Flan con Frutas de Jigglypuff",
                            recipeDescription: "Flan muy especial, de consistencia elástica como la de un globo.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3006_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Batido \"Ciclón de Hojas\"",
                            recipeDescription: "Con ingredientes cargados de nutrientes gracias al sol, este plato es ideal para la primera comida del día",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3026_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Panecillos de Maíz \"Hora del Té\"",
                            recipeDescription: "Bollo crujiente que combina a la perfección con mermelada de manzana al jengibre en proporciones iguales.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3018_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Macarons \"Don Floral\"",
                            recipeDescription: "El regalo ideal. Con ellos, el éxito y la sonrisa están asegurados",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3020_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Cola Especiada \"Chispa\"",
                            recipeDescription: "El fuerte sabor de este refresco de cola te despertará de golpe.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3022_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Petisú Clodsire",
                            recipeDescription: "Un petisú con relleno generoso y toque amargo en forma de Clodsire",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3024_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                        new RecipeModel(
                            recipeName: "Tortitas \"Cara Susto\"",
                            recipeDescription: "Dulce al gusto, pero al mirarlo te da un susto.",
                            recipeImage: "https://www.pokexperto.net/pokemonsleep/objetos/cooking_food_3025_0.png",
                            recipeType: desserRef,
                            recipeTypeOrder: desserModel.RecipeTypeOrder,
                            createdAt: DateTime.Now,
                            recipeIngredients: null),
                    };

                    //foreach (var recipe in recipes)
                    //    await firestore.AddData(COLLECTION_NAME, recipe);

                    //foreach (var recipe in saladRecipes)
                    //    await firestore.AddData(COLLECTION_NAME, recipe);

                    //foreach (var recipe in dessertRecipes)
                    //    await firestore.AddData(COLLECTION_NAME, recipe);

                    int counter = 0;
                    foreach (var recipe in recipes.Concat(saladRecipes).Concat(dessertRecipes))
                    {
                        counter++;
                        await firestore.AddData(COLLECTION_NAME, counter, recipe);
                    }

                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public async Task<List<RecipeModel>?> GetRecipes()
        {
            try
            {
                if (firestore == null)
                    return null;

                List<RecipeModel>? recipes = await firestore.GetList<RecipeModel>(COLLECTION_NAME);
                if (recipes == null)
                    return null;

                return recipes;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                return null;
            }
        }

        public async Task<RecipeModel?> GetRecipe(string itemId)
        {
            try
            {
                if (firestore == null)
                    return null;

                RecipeModel? recipe = await firestore.GetItem<RecipeModel>(COLLECTION_NAME, itemId);
                if (recipe == null || recipe?.RecipeType == null)
                    return null;

                var id = recipe.RecipeType.Id;
                var path = recipe.RecipeType.Path;

                var item = await recipe.RecipeType.GetSnapshotAsync();
                var converted = item.ConvertTo<RecipeTypeModel>();

                return recipe;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                return null;
            }
        }

    }

    [FirestoreData]
    public class RecipeModel
    {
        public RecipeModel() { }

        public RecipeModel(string? recipeName, string? recipeDescription, string? recipeImage, DocumentReference? recipeType, int recipeTypeOrder, DateTime createdAt, List<string>? recipeIngredients)
        {
            RecipeName = recipeName;
            RecipeDescription = recipeDescription;
            RecipeImage = recipeImage;
            RecipeType = recipeType;
            RecipeTypeOrder = recipeTypeOrder;
            CreatedAt = createdAt;
            RecipeIngredients = recipeIngredients;
        }

        [FirestoreDocumentId]
        public string? Id { get; set; }

        [FirestoreProperty]
        public string? RecipeName { get; set; }

        [FirestoreProperty]
        public string? RecipeDescription { get; set; }

        [FirestoreProperty]
        public string? RecipeImage { get; set; }

        [FirestoreProperty]
        public DocumentReference? RecipeType { get; set; }

        [FirestoreProperty]
        public int RecipeTypeOrder { get; set; }

        [FirestoreProperty]
        public DateTime CreatedAt { get; set; }

        [FirestoreProperty]
        public List<string>? RecipeIngredients { get; set; }
    }

    [FirestoreData]
    public class RecipeTypeModel
    {
        public RecipeTypeModel() { }

        public RecipeTypeModel(int recipeTypeOrder, string? recipeTypeName)
        {
            RecipeTypeOrder = recipeTypeOrder;
            RecipeTypeName = recipeTypeName;
        }

        public RecipeTypeModel(string recipeTypeId, int recipeTypeOrder, string? recipeTypeName)
        {
            Id = recipeTypeId;
            RecipeTypeOrder = recipeTypeOrder;
            RecipeTypeName = recipeTypeName;
        }

        [FirestoreDocumentId]
        public string? Id { get; set; }

        [FirestoreProperty]
        public int RecipeTypeOrder { get; set; }

        [FirestoreProperty]
        public string? RecipeTypeName { get; set; }

    }

}
