using Data;

namespace Client.Shared
{
    public class ArtifactFileInfo
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string Key { get; set; }
        public Artifact Artifact { get; set; }
    }
}
