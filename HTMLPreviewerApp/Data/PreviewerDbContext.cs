using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HTMLPreviewerApp.Data
{
    public class PreviewerDbContext : IdentityDbContext
    {
        public PreviewerDbContext(DbContextOptions<PreviewerDbContext> options)
            : base(options)
        {
        }
    }
}
