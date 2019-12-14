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
    public class researchesAPIController : ApiController
    {
        private projectContext db = new projectContext();

        // GET: api/researchesAPI
        public IQueryable<researchDTO> GetResearch()
        {

            var researches = from b in db.researches
                              select new researchDTO()
                              {
                                  reID = b.reID,
                                  Name = b.Name,
                                  Date = b.Date,
                                  Topic = b.Topic,
                                  Details = b.Details
                              };
            return researches;
        }

        // GET: api/researchesAPI/5
        [ResponseType(typeof(research))]
        public async Task<IHttpActionResult> GetResearch(int id)
        {
            research re = await db.researches.FindAsync(id);

            if (re == null)
            {
                return NotFound();
            }

            researchDTO research = new researchDTO
            {
                reID = re.reID,
                Name = re.Name,
                Date = re.Date,
                Topic = re.Topic,
                Details = re.Details

            };

            return Ok(research);
        }

        // PUT: api/researchesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putresearch(int id, research research)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != research.reID)
            {
                return BadRequest();
            }

            db.Entry(research).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!researchExists(id))
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

        // POST: api/researchesAPI
        [ResponseType(typeof(research))]
        public IHttpActionResult Postresearch(research research)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.researches.Add(research);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = research.reID }, research);
        }

        // DELETE: api/researchesAPI/5
        [ResponseType(typeof(research))]
        public IHttpActionResult Deleteresearch(int id)
        {
            research research = db.researches.Find(id);
            if (research == null)
            {
                return NotFound();
            }

            db.researches.Remove(research);
            db.SaveChanges();

            return Ok(research);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool researchExists(int id)
        {
            return db.researches.Count(e => e.reID == id) > 0;
        }
    }
}