using Application.Commons;
using Application.DTOs.Users.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApi.Pages.User;

public class LoginModel(IHttpClientFactory factory) : PageModel
{
    private readonly HttpClient _http = factory.CreateClient("api");

    [BindProperty]
    public required UserLoginRequestDto LoginDto { get; set; }

    public string? Message { get; set; }

    public async Task<IActionResult> OnPost()
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/User/login", LoginDto);

            if (!response.IsSuccessStatusCode)
            {
                Message = "Login or password error!";
                return Page();
            }

            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
            if (result?.Data != null)
            {
                Response.Cookies.Append("auth_token", result.Data, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });
                return RedirectToPage("/User/Profile");
            }
            else
            {
                Message = result?.Error ?? "Login invalid";
            }
            return Page();
        }
        catch (Exception ex)
        {
            Message = $" Error: {ex.Message}";
            return Page();
        }
    }
}
