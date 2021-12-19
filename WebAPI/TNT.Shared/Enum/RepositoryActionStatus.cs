using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Shared.Enum
{
    public enum RepositoryActionStatus
    {
        None,
        Ok,
        Created,
        Updated,
        Deleted,
        NotFound,
        Forbidden,
        Fail
    }
}
