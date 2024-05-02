using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Queries;
using AutoService.Domain.Entities.Models.CompanyModels;
using AutoService.Domain.Entities.ViewModels.CompanyCategoryViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Handlers.QueryHandlers
{
    public class GetAllCompanyCategoryQueryHandler : IRequestHandler<GetAllCompanyCategoryQuery, List<CompanyCategoryViewModel>>
    {
        private readonly IAppDbContext _context;

        public GetAllCompanyCategoryQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyCategoryViewModel>> Handle(GetAllCompanyCategoryQuery request, CancellationToken cancellationToken)
        {
            var ctgs = await _context.CompanyCategories.ToListAsync(cancellationToken);

            var Categories = ctgs.Select(x => new CompanyCategoryViewModel
            {
                Name = x.CategoryName
            }).ToList();

            return Categories;
        }
    }
}