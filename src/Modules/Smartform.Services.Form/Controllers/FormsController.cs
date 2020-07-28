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
    public class FormsController : GenericController<FormModel>
    {
        private readonly IFormService _formService;

        public FormsController(IFormService _formService) : base(_formService)
        {

        }

    }
}