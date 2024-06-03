using LearningApp.Application.InfrastructureInterfaces.Persistance;
using LearningApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentDataService _documentDataService;
        public DocumentService(IDocumentDataService documentDataService)
        {
            _documentDataService = documentDataService;
        }
        public async Task<bool> AddDocument(Document document)
        {
            return await _documentDataService.AddDocumentToDb(document);
        }

        public async Task<Document> Download(int id)
        {
            return await _documentDataService.DownloadDocumentDb(id);
        }
    }
}
