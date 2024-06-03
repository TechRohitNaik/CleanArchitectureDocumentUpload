using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Domain.Models
{
    public class DocUploadDto
    {
        public IFormFile file { get; set; }
    }
}
