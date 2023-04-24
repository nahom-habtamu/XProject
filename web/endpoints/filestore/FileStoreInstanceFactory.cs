using Minio;

namespace web.filestore;

public class FileStoreInstanceFactory
{
    private string AccessKey { get; set; }
    private string SecretKey { get; set; }
    private string EndPoint { get; set; }

    public FileStoreInstanceFactory(
        string accessKey,
        string secretKey,
        string endPoint
    )
    {
        AccessKey = accessKey;
        SecretKey = secretKey;
        EndPoint = endPoint;
    }

    public MinioClient Call()
    {
        var minio = new MinioClient()
            .WithEndpoint(EndPoint)
            .WithCredentials(AccessKey, SecretKey)
            // .WithSSL()
            .Build();
        return minio;
    }
}