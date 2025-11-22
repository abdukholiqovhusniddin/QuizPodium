using Application.DTOs.Users.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApi.Pages.User;
public class RegisterModel(IHttpClientFactory factory) : PageModel
{
    private readonly HttpClient _http = factory.CreateClient("api");

    [BindProperty]
    public required UserRegisterRequestDto RegisterDto { get; set; }

    public string? Message { get; set; }

    public async Task<IActionResult> OnPost()
    {
        var response = await _http.PostAsJsonAsync("api/User/register", RegisterDto);

        Message = await response.Content.ReadAsStringAsync();
        return Page();
    }
}
