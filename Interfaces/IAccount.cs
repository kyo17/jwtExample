using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwt.Models;

namespace jwt.Interfaces
{
    public interface IAccount
    {
        Task<ResponseAuthentication> register(Credentials credentials);
    }
}