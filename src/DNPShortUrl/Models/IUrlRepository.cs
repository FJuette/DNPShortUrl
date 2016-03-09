using System.Collections.Generic;

namespace DNPShortUrl.Models
{
    public interface IUrlRepository
    {
        Entry Add(Entry entry);
        IEnumerable<Entry> GetAll();
        Entry Get(string key);
    }
}
