using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Project.Models;

namespace Project.Controllers.WebAPI
{
    public class resolutionsAPIController : ApiController
    {
        private projectContext db = new projectContext();

        // GET: api/resolutionsAPI
        public IQueryable<resolutionDTO> GetResolution()
        {

            var resolutions = from b in db.resolutions
                          select new resolutionDTO()
                          {
                              resID = b.resID,
                              Name = b.Name,
                              Date = b.Date,
                              Topic = b.Topic,
                              Details = b.Details
                          };
            return resolutions;
        }

        // GET: api/resolutionsAPI/5
        [ResponseType(typeof(resolution))]
        public async Task<IHttpActionResult> GetResolution(int id)
        {
            resolution r = await db.resolutions.FindAsync(id);

            if (r == null)
            {
                return NotFound();
            }

            resolutionDTO resolution = new resolutionDTO
            {
                resID = r.resID,
                Name = r.Name,
                Date = r.Date,
                Topic = r.Topic,
                Details = r.Details

            };

            return Ok(resolution);
        }

        // PUT: api/resolutionsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putresolution(int id, resolution resolution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resolution.resID)
            {
                return BadRequest();
            }

            db.Entry(resolution).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!resolutionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/resolutionsAPI
        [ResponseType(typeof(resolution))]
        public IHttpActionResult Postresolution(resolution resolution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.resolutions.Add(resolution);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resolution.resID }, resolution);
        }

        // DELETE: api/resolutionsAPI/5
        [ResponseType(typeof(resolution))]
        public IHttpActionResult Deleteresolution(int id)
        {
            resolution resolution = db.resolutions.Find(id);
            if (resolution == null)
            {
                return NotFound();
            }

            db.resolutions.Remove(resolution);
            db.SaveChanges();

            return Ok(resolution);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool resolutionExists(int id)
        {
            return db.resolutions.Count(e => e.resID == id) > 0;
        }
    }
}