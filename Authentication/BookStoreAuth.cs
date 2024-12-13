using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Authentication
{
    public class BookStoreAuth : IdentityDbContext
    {
        public BookStoreAuth(DbContextOptions<BookStoreAuth> options) : base(options)
        {

        }
    }
}
