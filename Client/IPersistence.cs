using Client.Shared;

namespace Client
{
    interface IPersistence
    {
        public Task<string> SaveAsync(ArtifactFileInfo fileInfo, Stream sourceStream);
    }
}
