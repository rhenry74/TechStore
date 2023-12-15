using Client.Shared;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;

namespace Client
{
    public class FileSystemPersistence : IPersistence
    {
        async Task<string> IPersistence.SaveAsync(ArtifactFileInfo fileInfo, Stream sourceStream)
        {
            var fileName = Path.GetTempFileName();
            var ext = Path.GetExtension(fileInfo.FileName);
            var target = Path.ChangeExtension(fileName, ext);

            var targetStream = new FileStream(target, FileMode.Create);
            fileInfo.Key = target;
            await sourceStream.CopyToAsync(targetStream);
            targetStream.Close();

            return target;
        }
    }
}
