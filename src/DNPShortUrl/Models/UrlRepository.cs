using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace DNPShortUrl.Models
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ConcurrentBag<Entry> _urlList;

        public UrlRepository()
        {
            _urlList = new ConcurrentBag<Entry>();
        }

        public Entry Add(Entry entry)
        {
            if (_urlList.Any(e => e.Hash == entry.Hash))
            {
                entry.Key = _urlList.First(e => e.Hash == entry.Hash).Key;
            }
            else
            {
                entry.CreateKey();
            }
            _urlList.Add(entry);
            return entry;
        }

        public IEnumerable<Entry> GetAll()
        {
            return _urlList;
        }

        public Entry Get(string key)
        {
            return _urlList.FirstOrDefault(u => u.Key == key);
        }
    }
}
