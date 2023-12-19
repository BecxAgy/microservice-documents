using System.Collections.Generic;
using System.Threading.Tasks;
using ms_documents.Models; // Importe os modelos necessários
using ms_documents.Service;
using Microsoft.AspNetCore.Mvc;
using ms_documents.DTOs;

namespace ms_documents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentService _documentService;

        public DocumentController(DocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> Get()
        {
            var documents = await _documentService.GetAllDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetById(string id)
        {
            var document = await _documentService.GetDocumentByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpPost]
        public async Task<ActionResult<Document>> Create([FromForm] DocumentUploadDTO document)
        {
            var createdDocument = await _documentService.CreateDocumentByDTOAsync(document);
            return CreatedAtAction(nameof(GetById), new { id = createdDocument.id }, createdDocument);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Document document)
        {
            await _documentService.UpdateDocumentAsync(id, document);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _documentService.DeleteDocumentAsync(id);
            return NoContent();
        }
    }
}
