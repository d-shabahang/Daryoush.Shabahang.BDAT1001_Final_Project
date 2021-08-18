using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Basics_Final_Project_InformationEncoding.Transformer
{
    public class ClaimsTransformation : IClaimsTransformation
    {
        // every time the user is authenticated, this will be used multiple times
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var hasFriendClaim = principal.Claims.Any(x => x.Type == "Friend");

            if (!hasFriendClaim)
            {
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim("Friend", "Bad"));
            }

            return Task.FromResult(principal);
        }
    }
}