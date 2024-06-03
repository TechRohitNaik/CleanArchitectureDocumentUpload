using LearningApp.Application.Services;
using LearningApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        [HttpPost]
        [Route("UploadDocument")]
        public async Task<ActionResult<bool>> UploadDocument([FromForm] DocUploadDto documentdata)
        {
            try
            {
                if (documentdata == null)
                {
                    return StatusCode(400, "Mandatory data missing");
                }
                var document = new Document();
                document.DocumentName = documentdata.file.FileName;
                using (var filecontect = new MemoryStream())
                {
                    documentdata.file.CopyTo(filecontect);
                    document.Content = filecontect.ToArray();
                    var isUploaded = await _documentService.AddDocument(document);
                    return Ok(isUploaded);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Download/{id}")]
        public async Task<ActionResult> Download(int id)
        {
            try
            {
                var document = await _documentService.Download(id);
                if (document != null)
                {
                    return File(document.Content, "application/octet-stream", document.DocumentName);
                }
                return StatusCode(404, $"Document not found with ID : {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
