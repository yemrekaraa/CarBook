using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repoistory;

        public RemoveBannerCommandHandler(IRepository<Banner> repoistory)
        {
            _repoistory = repoistory;
        }
        public async Task Handle(RemoveBannerCommand command)
        {
            var value = await _repoistory.GetByIdAsync(command.Id);
            await _repoistory.RemoveAsync(value);
        }
    }
}
