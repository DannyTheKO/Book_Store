// C:\Users\Danny\Desktop\Personal Project\CSharp\Book_Store\Controllers\AccountController.cs
using Book_Store.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
	private readonly UserManager<BookStoreUser> _userManager;
	private readonly SignInManager<BookStoreUser> _signInManager;

	public AccountController(
		UserManager<BookStoreUser> userManager,
		SignInManager<BookStoreUser> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}

	public class LoginModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}

	public class RegisterModel
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string FullName { get; set; }
	}

	[HttpGet]
	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(LoginModel model)
	{
		if (ModelState.IsValid)
		{
			var result = await _signInManager.PasswordSignInAsync(
				model.Username, model.Password, model.RememberMe, false);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}

			ModelState.AddModelError("", "Invalid login attempt");
		}
		return View(model);
	}

	[HttpGet]
	public IActionResult Register()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(RegisterModel model)
	{
		if (ModelState.IsValid)
		{
			var user = new BookStoreUser
			{
				UserName = model.Username,
				Email = model.Email,
				FullName = model.FullName
			};

			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				await _signInManager.SignInAsync(user, isPersistent: false);
				return RedirectToAction("Index", "Home");
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
		}
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Logout()
	{
		await _signInManager.SignOutAsync();
		return RedirectToAction("Index", "Home");
	}
}
