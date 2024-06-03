using LearningApp.Application.InfrastructureInterfaces.Persistance;
using LearningApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure.Persistance
{
    public class DocumentDataService : IDocumentDataService
    {
        private readonly DemoAppDbContext _demoAppDbContext;
        public DocumentDataService(DemoAppDbContext demoAppDbContext)
        {
            _demoAppDbContext = demoAppDbContext;
        }
        public async Task<bool> AddDocumentToDb(Document document)
        {
            try
            {
                var createdDocument = await _demoAppDbContext.Documents.AddAsync(document);
                _demoAppDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Document> DownloadDocumentDb(int id)
        {
            try
            {
                var document = await _demoAppDbContext.Documents.SingleOrDefaultAsync(x => x.Id == id);
                if (document != null)
                {
                    return document;
                }
                else
                {
                    throw new Exception($"Document doesnot exist with ID : {id}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
