using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RecruitmentTasksAH.FirstTask.Model;
using RecruitmentTasksAH.FirstTask.Dtos;
using AutoMapper;

[ApiController]
[Route("[controller]")]
public class EntrepreneurController : ControllerBase
{
    private readonly EntrepreneurDbContext _db;
    private readonly IHttpClientFactory _clientFactory;
    private readonly IMapper _mapper;

    public EntrepreneurController(EntrepreneurDbContext db, IHttpClientFactory clientFactory, IMapper mapper)
    {
        _db = db;
        _clientFactory = clientFactory;
        _mapper = mapper;
    }

    [HttpGet("{nip}")]
    public async Task<IActionResult> GetEntrepreneur(string nip)
    {
        var entrepreneur = await _db.Entrepreneurs.FirstOrDefaultAsync(e => e.Nip == nip);

        if (entrepreneur is null)
        {
            var response = await GetEntrepreneurFromApi(nip);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiData = JsonConvert.DeserializeObject<ApiResponse>(responseContent);

                if (apiData is not null)
                {
                    entrepreneur = _mapper.Map<Entrepreneur>(apiData.Result.Subject);

                    _db.Entrepreneurs.Add(entrepreneur);
                    await _db.SaveChangesAsync();

                    return Ok(entrepreneur);
                }
            }

            return NotFound();
        }

        return Ok(entrepreneur);
    }

    private async Task<HttpResponseMessage> GetEntrepreneurFromApi(string nip)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://wl-api.mf.gov.pl/api/search/nip/{nip}?date={DateTime.Now:yyyy-MM-dd}");

        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return await client.SendAsync(request);
    }
}
