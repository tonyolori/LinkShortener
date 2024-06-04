using LinkShortener.Database;
using LinkShortener.Interfaces;
using LinkShortener.Model;
using LinkShortener.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinkShortener.Repository
{
    public class LinkRepository(DataContext dbContext,IHelper helper) : ILinkRepository
    {
        private DataContext _dbContext = dbContext;
        private readonly IHelper _helper = helper;
        public async Task<string> AddShortLink(string longLink)
        {
            var shortlink = _helper.GenerateRandomString();

            Link newLink = new()
            {
                ShortenedUrl = shortlink,
                OriginalUrl = longLink,
            };

            _dbContext.Add(newLink);
            await saveAsync();
            return shortlink;
        }

        public async Task<string?> GetLongLink(string shortLink)
        {
            var link = await _dbContext.Links.FirstOrDefaultAsync(x=>x.ShortenedUrl == shortLink);
            if (link == null)
                return null; 

            return link.OriginalUrl;
        }

        public async Task<List<string>> GetAllLinks()
        {
            var links = await _dbContext.Links.ToListAsync();

            return links.Select(x => x.ShortenedUrl).ToList();
        }

        public async Task saveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
