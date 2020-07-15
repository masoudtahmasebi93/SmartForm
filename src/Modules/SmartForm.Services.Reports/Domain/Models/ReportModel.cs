using System;
using SmartForm.Common.Domain.Models;
using SmartForm.Common.Exceptions;

namespace SmartForm.Services.Activities.Domain.Models
{
    public class ReportModel : BaseModel
    {
        protected ReportModel()
        {
        }

        public ReportModel(Guid id, FolderModel folderModel, Guid userId,
            string name, string description, DateTime createdAt)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new SmartFormException("empty_report_name",
                    "Report name can not be empty.");
            Id = id;
            Category = folderModel.Name;
            UserId = userId;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }


        public string Category { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Description { get; protected set; }
    }
}