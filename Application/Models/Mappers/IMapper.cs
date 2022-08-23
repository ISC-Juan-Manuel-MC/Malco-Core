using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Mappers
{
    internal interface IMapper<DomainEntity,ApplicationEntity>
    {
        ApplicationEntity GetApplicationEntity(DomainEntity domainEntity);
        DomainEntity GetDomainEntity(ApplicationEntity applicationEntity);
    }
}
