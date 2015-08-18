namespace Frameworkone.ThirdParty.PostageApp
{
    public class PostageAttachment
    {
        public PostageAttachment(byte[] file, string fileName)
        {
            File = file;
            FileName = fileName;
        }

        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}