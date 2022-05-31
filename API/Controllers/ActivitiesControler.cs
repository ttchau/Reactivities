using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Activities;
using System.Threading;

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
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        {
            return await Mediator.Send(new List.Query(), ct);
            // return await _mediator.Send(new List.Query());
            // return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]   //activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
            //return await _context.Activities.FindAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command {Activity = activity}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));

        }
    }
}