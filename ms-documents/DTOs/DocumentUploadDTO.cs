namespace ms_documents.DTOs
{
    public class DocumentUploadDTO
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
