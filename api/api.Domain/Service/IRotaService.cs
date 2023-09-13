using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Domain.Commands;

namespace api.Domain.Service
{
    public interface IRotaService
    {
        Task<Guid> Add(AddRotaCommand command);
    }
}
