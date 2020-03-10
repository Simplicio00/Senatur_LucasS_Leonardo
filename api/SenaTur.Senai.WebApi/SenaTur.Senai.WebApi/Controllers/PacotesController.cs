using Microsoft.AspNetCore.Mvc;
using SenaTur.Senai.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaTur.Senai.WebApi.Controllers
{
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacotesRepository;
    }
}
