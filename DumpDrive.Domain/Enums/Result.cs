using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Domain.Enums
{
    public enum Result
    {
        Success,
        Error,
        NoChanges,
        NotFound,
        AlreadyExists
    }
}
