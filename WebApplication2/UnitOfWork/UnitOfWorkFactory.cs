using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.UnitOfWork
{
    public class UnitOfWorkFactory
    {
        public virtual IUnitOfWork Create()
        {
            return new UnitOfWork(new Model1());
        }

        public virtual IUnitOfWork CreateForOracle()
        {
            return new UnitOfWork(new Model1());
        }

    }
}