using System;
using System.Collections.Generic;
using System.Text;

namespace TallerTest.Domain.Seedwork
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
