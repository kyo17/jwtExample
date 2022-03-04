using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwt.Interfaces;
using jwt.Models;
using Microsoft.AspNetCore.Mvc;

namespace jwt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccount repo;

        public AccountsController(IAccount repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> register([FromBody] Credentials credentials){
            var result = await repo.register(credentials);
            return Created("Created", result);
        }
    }
}