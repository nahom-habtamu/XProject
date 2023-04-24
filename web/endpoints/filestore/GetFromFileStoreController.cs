using Minio;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.filestore;

[ApiController]
public class GetFromFileStoreController : ControllerBase
{
    private readonly FileStoreInstanceFactory _fileStoreFactory;

    public GetFromFileStoreController(FileStoreInstanceFactory fileStoreFactory)
    {
        _fileStoreFactory = fileStoreFactory;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<FileStreamResult> Call(string fileId)
    {
        MemoryStream memoryStream = new MemoryStream();

        var client = _fileStoreFactory.Call();
        var bucketName = "project-x-files";
        var args = new GetObjectArgs()
            .WithBucket(bucketName)
            .WithObject(fileId)
            .WithCallbackStream(async s =>
            {
                await s.CopyToAsync(memoryStream);
            });

        var result = await client.GetObjectAsync(args);
        memoryStream.Position = 0;
        return new FileStreamResult(memoryStream, result.ContentType);
    }
}
