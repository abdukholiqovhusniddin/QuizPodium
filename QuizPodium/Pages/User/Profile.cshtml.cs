using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApi.Pages.User;

public class ProfileModel : PageModel
{
    public required string Username { get; set; }

    public void OnGet()
    {
        // cookie’dagi token bo‘lsa -> user kirgan
        if (!Request.Cookies.TryGetValue("auth_token", out var token))
            Response.Redirect("/User/Login");

        // token decoding qilsa username chiqariladi, ammo hozircha mock
        Username = "Authorized User";
    }
}
