using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cike.Scheduler.Application.JobAppResources.MapperConfig;

public class JobAppResourceProfile : Profile
{
    public JobAppResourceProfile()
    {
        CreateMap<JobAppResource, JobAppResourceGetListOutput>();

        CreateMap<JobAppResourceCreateUpdateInput, JobAppResource>()
            .Ignore(e=>e.TenantId)
            .IgnoreFullAuditedObjectProperties()
            .Ignore(e=>e.Id);
    }
}
