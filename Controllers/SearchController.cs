using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBSBahrainMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CBSBahrainMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly CBSBahrainContext _context;

        public SearchController(CBSBahrainContext context)
        {
            _context = context;
        }
        // GET: api/Search/5
        [HttpGet("{title}", Name = "Get")]
        public IEnumerable<SongBankCategory> Get(string title)
        {
            return _context.SongBankCategory.Where(x => x.Title.Contains(title)).ToList();
        }

        
    }
}
