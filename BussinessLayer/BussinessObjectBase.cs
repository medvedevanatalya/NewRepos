using AutoMapper;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public abstract class BusinessObjectBase
    {
        protected IMapper mapper;
        protected UnitOfWorkFactory unitOfWorkFactory;

        public BusinessObjectBase(IMapper mapper, UnitOfWorkFactory unitOfWorkFactory)
        {
            this.mapper = mapper;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }

}
