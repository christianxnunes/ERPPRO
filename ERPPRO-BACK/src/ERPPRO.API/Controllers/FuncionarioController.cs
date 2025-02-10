using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Persistence;
using ERPPRO.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ERPPRO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly ERPPROContext _context;
        public FuncionarioController(ERPPROContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Funcionario> Get()
        {
            return _context.Funcionarios;
        }
    }
}