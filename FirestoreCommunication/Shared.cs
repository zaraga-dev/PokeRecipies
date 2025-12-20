using Google.Cloud.Firestore;

namespace FirestoreCommunication;

public class Shared
{
    private static string projectId = "1058160525028";
    private static string databaseId = "(default)";

    public async Task Connect()
    {
        try
        {
            FirestoreDb db = new FirestoreDbBuilder { ProjectId = projectId, DatabaseId = databaseId }.Build();

            // Create a document with a random ID in the "users" collection.
            CollectionReference collection = db.Collection("recipies");
            DocumentReference document = await collection.AddAsync(new { Name = new { First = "Ada", Last = "Lovelace" }, Born = 1815 });

            // A DocumentReference doesn't contain the data - it's just a path.
            // Let's fetch the current document.
            DocumentSnapshot snapshot = await document.GetSnapshotAsync();

            // We can access individual fields by dot-separated path
            Console.WriteLine(snapshot.GetValue<string>("Name.First"));
            Console.WriteLine(snapshot.GetValue<string>("Name.Last"));
            Console.WriteLine(snapshot.GetValue<int>("Born"));

            // Or deserialize the whole document into a dictionary
            Dictionary<string, object> data = snapshot.ToDictionary();
            Dictionary<string, object> name = (Dictionary<string, object>)data["Name"];
            Console.WriteLine(name["First"]);
            Console.WriteLine(name["Last"]);

            // See the "data model" guide for more options for data handling.

            // Query the collection for all documents where doc.Born < 1900.
            Query query = collection.WhereLessThan("Born", 1900);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot queryResult in querySnapshot.Documents)
            {
                string firstName = queryResult.GetValue<string>("Name.First");
                string lastName = queryResult.GetValue<string>("Name.Last");
                int born = queryResult.GetValue<int>("Born");
                Console.WriteLine($"{firstName} {lastName}; born {born}");
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
