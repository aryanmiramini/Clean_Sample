using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Contracts.Authentication
{
    public record LoginRequest(
        string Email,
        string Password);

}
