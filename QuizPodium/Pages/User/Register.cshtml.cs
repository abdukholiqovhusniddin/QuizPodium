using Application.DTOs.Users.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Register : PageModel
{
    private readonly HttpClient _http;

    public Register(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("api");
    }

    [BindProperty]
    public UserRegisterRequestDto RegisterDto { get; set; }

    public string? Message { get; set; }

    public async Task<IActionResult> OnPost()
    {
        var response = await _http.PostAsJsonAsync("api/User/register", RegisterDto);

        Message = await response.Content.ReadAsStringAsync();
        return Page();
    }
}
