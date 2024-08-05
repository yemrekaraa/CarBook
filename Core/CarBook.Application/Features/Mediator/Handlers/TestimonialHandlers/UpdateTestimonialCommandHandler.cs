﻿using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TestimonialID);
            values.Comment = request.Comment;
            values.Title = request.Title;
            values.Name = request.Name;
            values.ImageUrl= request.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
