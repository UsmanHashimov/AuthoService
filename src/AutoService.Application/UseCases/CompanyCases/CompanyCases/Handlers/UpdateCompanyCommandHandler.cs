using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.CompanyCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCases.Handlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public UpdateCompanyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyName == request.CompanyName);

            if (company != null)
            {
                _context.Companies.Update(company);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "Changes saved!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "This company not registered yet!",
                StatusCode = 401
            };
        }
    }
}