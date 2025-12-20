namespace FirestoreCommunication;

public static class Extensions
{
    public static MauiAppBuilder UseFirestoreCommunication(this MauiAppBuilder builder)
    {
        // Register services related to Firestore communication here.
        // For example:
        // builder.Services.AddSingleton<IFirestoreService, FirestoreService>();
        return builder;
    }
}
