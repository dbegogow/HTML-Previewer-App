﻿using System.Security.Claims;

namespace HTMLPreviewerApp.Infrastructure
{
    public static class ClaimsPrincipalsExtensions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
