using CarBook.Application.Features.CQRS.Queries.BrandQueris;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
       public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetBrandByIdQueryResult
            {
                BrandID = value.BrandID,
                Name = value.Name
            };
        }
    }
}
