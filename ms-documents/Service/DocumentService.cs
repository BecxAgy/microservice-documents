
using ms_documents.DTOs;
using  ms_documents.Models; 
using  ms_documents.Repository;

namespace  ms_documents .Service
{
    public class DocumentService
    {
        private readonly DocumentRepository _repository;

        public DocumentService(DocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Document> GetDocumentByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Document> CreateDocumentAsync(Document document)
        {
            await _repository.CreateAsync(document);
            return document;
        }

        public async Task UpdateDocumentAsync(string id, Document document)
        {
            await _repository.UpdateAsync(id, document);
        }

        public async Task DeleteDocumentAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task<Document> CreateDocumentByDTOAsync(DocumentUploadDTO model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                throw new ArgumentException("Arquivo inválido ou vazio.");
            }

            byte[] fileBytes = await ProcessFileAsync(model.File);

            var document = new Document
            {
                Name = model.Name,
                Created_at = DateTime.Now,
                File = fileBytes
            };

            await _repository.CreateAsync(document);
            return document;
        }

        private async Task<byte[]> ProcessFileAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
