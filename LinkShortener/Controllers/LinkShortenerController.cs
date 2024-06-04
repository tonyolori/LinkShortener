using LinkShortener.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkShortenerController(ILinkRepository linkRepository) : Controller
    {
        private readonly ILinkRepository _linkRepository = linkRepository;

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetAllLinks()
        {
            var links = await _linkRepository.GetAllLinks();

            return Ok(links);
        }

        [HttpPost("create")]
        public async Task<ActionResult<string>> CreateShortlink([FromBody]string longLink)
        {
            var link = await _linkRepository.AddShortLink(longLink);
            return Ok(link);
        }

        [HttpGet("{shortlink}")]
        public async Task<ActionResult> GetLong(string shortLink)
        {
            var longLink = await _linkRepository.GetLongLink(shortLink);
            return Redirect(longLink);
        }
    }
}
