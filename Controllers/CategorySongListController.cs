using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBSBahrainMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBSBahrainMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorySongListController : ControllerBase
    {
        // GET: api/CategorySongList
        private readonly CBSBahrainContext _context;

        public CategorySongListController(CBSBahrainContext context)
        {
            _context = context;
        }
        // GET: api/CategorySongList/5
        [HttpGet("{id}", Name = "Get2")]
        public IEnumerable<SongBankCategory> Get(int id)
        {
            return _context.SongBankCategory.Where(x => x.CategoryId == id).OrderBy(x=>x.Category).ThenBy(x=>x.Title).ToList();
        }
    }
}
