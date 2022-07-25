using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TallerTest.Domain.Seedwork
{
    public interface IEntity
    {
        bool IsTransient();
    }
}
