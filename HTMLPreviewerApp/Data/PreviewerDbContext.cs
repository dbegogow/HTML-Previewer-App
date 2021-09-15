using HTMLPreviewerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HTMLPreviewerApp.Data
{
    public class PreviewerDbContext : IdentityDbContext<User>
    {
        public PreviewerDbContext(DbContextOptions<PreviewerDbContext> options)
            : base(options)
        {
        }
    }
}
