using Google.Api.Gax.Grpc.Rest;
using Google.Cloud.Firestore;
using System.Collections;

namespace zaraga.FirestoreCommunication;

public class Shared
{
    private static string _projectId = "";
    private const string _fileName = "firebase-adminsdk.json";

    private FirestoreDb? firestoreDb;

    public Shared(string projectId)
    {
        _projectId = projectId;
    }

    private async Task ConnectDb()
    {
        try
        {
            if (firestoreDb != null)
                return;

            if (!await FileSystem.AppPackageFileExistsAsync(_fileName))
                throw new ArgumentException($"File {_fileName} not found in app package.");

            var stream = await FileSystem.OpenAppPackageFileAsync(_fileName);
            var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();

            firestoreDb = await new FirestoreDbBuilder
            {
                ProjectId = _projectId,
                ConverterRegistry = new ConverterRegistry
                {
                  new DateTimeToTimeSpanConverter()
                },
                // *** Key fix ***
                GrpcAdapter = RestGrpcAdapter.Default,
                JsonCredentials = content,
            }.BuildAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Clear a complete Firestore collection 
    /// </summary>
    /// <param name="collectionName"></param>
    /// <returns></returns>
    public async Task DeleteCollection(string collectionName)
    {
        //open DatastoreConnection
        await ConnectDb();
        if (firestoreDb == null)
            return;

        //opcion 2
        QuerySnapshot snapshot = await firestoreDb.Collection(collectionName).GetSnapshotAsync();
        IReadOnlyList<DocumentSnapshot> documents = snapshot.Documents;

        foreach (DocumentSnapshot document in documents)
        {
            Console.WriteLine("Deleting document {0}", document.Id);
            await document.Reference.DeleteAsync();
        }

        Console.WriteLine("Finished deleting all documents from the collection.");

    }

    /// <summary>
    /// Add data to Firestore collection
    /// </summary>
    /// <param name="collectionName"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<DocumentReference?> AddData(string collectionName, object data)
    {
        //open DatastoreConnection
        await ConnectDb();
        if (firestoreDb == null)
            return null;

        DocumentReference reference = await firestoreDb.Collection(collectionName).AddAsync(data);
        return reference;
    }


    /// <summary>
    /// Add data to Firestore collection wit specific document id
    /// </summary>
    /// <param name="collectionName"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<DocumentReference> AddData(string collectionName, int documentId, object data)
    {
        //open DatastoreConnection
        await ConnectDb();
        if (firestoreDb == null)
            return null;

        WriteResult reference = await firestoreDb.Collection(collectionName).Document(documentId.ToString()).SetAsync(data);
        return firestoreDb.Collection(collectionName).Document(documentId.ToString());
    }

    /// <summary>
    /// Get list of data from Firestore collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collectionName"></param>
    /// <returns></returns>
    public async Task<List<T>?> GetList<T>(string collectionName) where T : class
    {
        //open DatastoreConnection
        await ConnectDb();
        if (firestoreDb == null)
            return null;

        var data = await firestoreDb.Collection(collectionName).GetSnapshotAsync();
        var sampleModel = data.Documents.Select(doc =>
        {
            var model = doc.ConvertTo<T>();
            return model;
        }).ToList();

        return sampleModel;
    }

    /// <summary>
    /// Get item by id from Firestore collection if exists otherwise return null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collectionName"></param>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public async Task<T?> GetItem<T>(string collectionName, string itemId) where T : class
    {
        //open DatastoreConnection
        await ConnectDb();
        if (firestoreDb == null)
            return null;

        DocumentReference docRef = firestoreDb.Collection(collectionName).Document(itemId);
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
        if (snapshot.Exists)
        {
            T model = snapshot.ConvertTo<T>();
            return model;
        }
        else
        {
            return null;
        }
    }

}


public class DateTimeToTimeSpanConverter : IFirestoreConverter<DateTime>
{
    public object ToFirestore(DateTime value) => Timestamp.FromDateTime(value.ToUniversalTime());
    public DateTime FromFirestore(object value)
    {
        Timestamp timestamp = (Timestamp)value;
        return timestamp.ToDateTime();
    }
}