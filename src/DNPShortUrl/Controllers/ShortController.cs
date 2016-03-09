using System.Collections.Generic;
using DNPShortUrl.Models;
using Microsoft.AspNet.Mvc;

namespace DNPShortUrl.Controllers
{
    [Route("[controller]")]
    public class ShortController : Controller
    {
        [FromServices]
        public IUrlRepository Repository { get; set; }

        // GET key/5
        [HttpGet("{key}")]
        public string Get(string key)
        {
            var entry = Repository.Get(key);
            return entry != null ? entry.Url : "";
        }

        // POST key // Create
        [HttpPost]
        public Entry Create([FromBody]Entry entry)
        {
            Repository.Add(entry);
            return entry;
        }

        // GET: values
        [HttpGet]
        public IEnumerable<Entry> Get()
        {
            return Repository.GetAll();
        }
    }
}
