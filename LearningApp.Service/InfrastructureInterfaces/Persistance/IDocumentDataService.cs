using LearningApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.InfrastructureInterfaces.Persistance
{
    public interface IDocumentDataService
    {
        Task<bool> AddDocumentToDb(Document document);
        Task<Document> DownloadDocumentDb(int id);
    }
}
