using LearningApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Services
{
    public interface IDocumentService
    {
        Task<bool> AddDocument(Document document);
        Task<Document> Download(int id);
    }
}
