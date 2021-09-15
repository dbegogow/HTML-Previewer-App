using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HTMLPreviewerApp.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Sample> Samples { get; init; } = new HashSet<Sample>();
    }
}
