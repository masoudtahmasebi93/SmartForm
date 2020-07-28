using System;
using System.ComponentModel.DataAnnotations;
using SmartForm.Common.Domain.Models;

namespace SmartForm.Services.Form.Domain.Models
{
    public class FormModel : BaseModel
    {
        public string Code { get; set; }
        public string Title { get; set; } 
        public string Json { get; set; }

        public string ReportJson { get; set; }

        public int PaperType { get; set; }

        public long? LockUserId { get; set; }

        public string LockUserName { get; set; }


        public long? TemplateTypeId { get; set; }

        public string TemplateType { get; set; }

        public bool IsSubcontractor { get; set; }


        public bool IsWidget { get; set; }
        public bool IsFavorite{ get; set; }
        public bool IsArchived{ get; set; }
        
        public int? Version { get; set; }

        public long StatusId { get; set; }

        public string Status { get; set; }

    }
}