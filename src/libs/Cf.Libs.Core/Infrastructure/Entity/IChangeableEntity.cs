using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.Entity
{
    public interface IChangeableEntity
    {
        DateTime CreateDate { get; set; }
        string CreateUserId { get; set; }
        DateTime ModifiedDate { get; set; }
        string ModifyUserId { get; set; }
        string UpdatedToken { get; set; }
    }
}