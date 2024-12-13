using Microsoft.AspNetCore.Identity;

namespace Book_Store.Authentication
{
    public class BookStoreUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
