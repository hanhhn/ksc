using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Common.BaseEntity
{
    public interface IChangeableEntity
    {
        DateTime CreateDate { get; set; }
        string CreateUser { get; set; }
        DateTime ModifiedDate { get; set; }
        string ModifyUser { get; set; }
        string UpdatedToken { get; set; }
    }
}