using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Core.Entity
{
    public interface IChangeableEntity
    {
        DateTime CreateDate { get; set; }
        string CreateUserId { get; set; }
        DateTime ModifiedDate { get; set; }
        string ModifyUserId { get; set; }
        Guid UpdatedToken { get; set; }
    }
}
