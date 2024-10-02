using Microsoft.EntityFrameworkCore;

namespace Book_Store.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
    }
}
