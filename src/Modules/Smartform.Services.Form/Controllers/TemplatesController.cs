using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using SmartForm.Common.Controllers;
using SmartForm.Common.Services;
using SmartForm.Services.Form.Commands;
using SmartForm.Services.Form.Domain.Models;
using SmartForm.Services.Form.Services;

namespace SmartForm.Services.Form.Controllers
{
    [Route("[controller]")]
    public class TemplatesController : GenericController<TemplateModel>
    {
        private readonly ITemplateService _templateService;

        public TemplatesController(ITemplateService templateService) : base(templateService)
        {

        }

    }
}