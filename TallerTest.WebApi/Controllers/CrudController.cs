using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TallerTest.Domain.Seedwork;


namespace TallerTest.WebApi.Controllers
{
    public class Int32CrudController<TRepository, TEntity, TDto> : ControllerBase
        where TRepository : class, IRepository<TEntity, int>
        where TEntity : class
        where TDto : class

    {
        protected IMapper mapper;
        protected IUnitOfWork unitOfWork = null;
        protected TRepository repository = null;

        //public Int32CrudController(IUnitOfWork uow, TRepository rep)
        //{
        //    this.unitOfWork = uow;
        //    this.repository = rep;
        //}

        public Int32CrudController(IUnitOfWork uow, TRepository rep, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = uow;
            this.repository = rep;
        }


        [HttpGet]
        public virtual async Task<IEnumerable<TDto>> List()
        {
            var result = await repository.ListAsync();
            return mapper.Map<IEnumerable<TDto>>(result);
        }


        [HttpGet("{id}")]
        public virtual async Task<TDto> Get(int id)
        {
            var result = await this.repository.GetByIdAsync(id);
            return result != null ? mapper.Map<TDto>(result) : null;
        }

        [HttpPost]
        [HttpPut("{id}")]
        public virtual OperationResult Save([FromBody] TDto value, int id)
        {
            var e = mapper.Map<TEntity>(value);
            repository.Save(e);
            unitOfWork.Commit();
            return OperationResult.Ok(value);
        }

        [HttpDelete("{id}")]
        public virtual OperationResult Delete(int id)
        {
            repository.DeleteById(id);
            unitOfWork.Commit();
            return OperationResult.Ok();
        }
    }
}
