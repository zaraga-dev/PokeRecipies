namespace zaraga.FirestoreCommunication;

public static class Extensions
{
    public static MauiAppBuilder UseFirestoreCommunication(this MauiAppBuilder builder, string applicationId)
    {
        builder.Services.AddSingleton<Shared>(provider =>
        {
            return new Shared(applicationId);
        });

        return builder;
    }
}
