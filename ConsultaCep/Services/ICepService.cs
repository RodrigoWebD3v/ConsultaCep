using ConsultaCep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCep.Services
{
    public interface ICepService
    {
        Task<Cep> GetCep(int cep);
    }
}
