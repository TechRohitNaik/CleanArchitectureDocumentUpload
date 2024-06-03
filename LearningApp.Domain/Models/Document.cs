using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LearningApp.Domain.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string DocumentName { get; set; }
        public byte[] Content { get; set; }
    }
}
