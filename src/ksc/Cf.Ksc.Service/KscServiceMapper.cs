using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Ksc.Service
{
    public static class KscServiceMapper
    {
        public static void AddKscMapper(this IMapperConfigurationExpression configAction)
        {
            configAction.AddProfile<KscServiceProfile>();
        }
    }

    public class KscServiceProfile : AutoMapper.Profile
    {
        public KscServiceProfile()
        {
            //CreateMap<Setting, SettingDto>();
        }
    }
}
