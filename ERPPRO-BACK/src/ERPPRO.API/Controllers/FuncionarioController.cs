using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.API.Data;
using ERPPRO.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPPRO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly DataContext _context;
        public FuncionarioController(DataContext context)
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