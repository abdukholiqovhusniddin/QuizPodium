using Application.DTOs.Users.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Login : PageModel
{
    private readonly HttpClient _http;

    public Login(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("api");
    }

    [BindProperty]
    public UserLoginRequestDto LoginDto { get; set; }

    public string? Message { get; set; }

    public async Task<IActionResult> OnPost()
    {
        var response = await _http.PostAsJsonAsync("api/User/login", LoginDto);

        Message = await response.Content.ReadAsStringAsync();
        return Page();
    }
}
