namespace LinkShortener.Interfaces
{
    public interface ILinkRepository
    {
        public Task<string> AddShortLink(string longLink);

        public Task<string?> GetLongLink(string shortLink);
        public Task<List<string>> GetAllLinks();

        public Task saveAsync(); 



    }
}
