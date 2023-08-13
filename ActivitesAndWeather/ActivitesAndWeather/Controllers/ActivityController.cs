using ActivitesAndWeather.EfCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActivitesAndWeather.Controllers
{
    [Route("api/[controller]/GetActivities")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly EfDataContext _dbContext;
        public ActivityController(EfDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetActivities()
        {
            var data = _dbContext.Activities.ToList();
            return Ok(data);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivitiesByGuidId(Guid id)
        {
            var entity = await _dbContext.Activities.FindAsync(id);

            if (entity == null) { return NotFound(); }

            return Ok(entity);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _dbContext.Activities.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _dbContext.Activities.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Activity entity)
        {
            _dbContext.Activities.Add(entity);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivitiesByGuidId), new { id = entity.Id }, entity);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Activity updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(updatedEntity).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Activities.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
