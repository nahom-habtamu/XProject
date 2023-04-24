using Microsoft.AspNetCore.Mvc;
using Minio;

namespace web.endpoints.filestore;

[ApiController]
public class AddToFileStoreController : ControllerBase
{
    private readonly FileStoreInstanceFactory _fileStoreFactory;

    public AddToFileStoreController(FileStoreInstanceFactory fileStoreFactory)
    {
        _fileStoreFactory = fileStoreFactory;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<string> Call([FromForm] IFormFile file)
    {
        var fileExtension = file.FileName.Split('.').LastOrDefault();
        var fileNameToUse = Guid.NewGuid().ToString("N") + "-" + file.FileName;

        var client = _fileStoreFactory.Call();
        var bucketName = "project-x-files";

        var bucketArgs = new BucketExistsArgs().WithBucket(bucketName);
        bool found = await client.BucketExistsAsync(bucketArgs).ConfigureAwait(false);
        if (!found)
        {
            var mbArgs = new MakeBucketArgs().WithBucket(bucketName);
            await client.MakeBucketAsync(mbArgs).ConfigureAwait(false);
        }
        var putObjectArgs = new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(fileNameToUse)
            .WithStreamData(file.OpenReadStream())
            .WithObjectSize(file.Length)
            .WithContentType(file.ContentType);
        await client.PutObjectAsync(putObjectArgs).ConfigureAwait(false);

        return fileNameToUse;
    }
}
