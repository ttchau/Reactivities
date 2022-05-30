using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Activities;
// using MediatR;


namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        // private readonly IMediator _mediator;

        // public ActivitiesController(IMediator mediator)
        // {
        //     _mediator = mediator;
        // }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
            // return await _mediator.Send(new List.Query());
            // return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]   //activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
            //return await _context.Activities.FindAsync(id);
        }

    }
}