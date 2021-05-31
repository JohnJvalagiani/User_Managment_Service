using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Abstraction
{
   public interface IJWTClaimParserService
    {
      
            Task<IEnumerable<Claim>> ParseAsync(string jwtToken);
        
    }
}
