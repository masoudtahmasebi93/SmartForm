using SmartForm.Common.Domain.Models;
using System;

namespace SmartForm.Services.Activities.Domain.Models
{
    public class FolderModel:BaseModel
    {
        protected FolderModel()
        {
        }

        public FolderModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name.ToLowerInvariant();
        }

    }
}