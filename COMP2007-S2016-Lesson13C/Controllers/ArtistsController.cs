﻿using System;
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
using COMP2007_S2016_Lesson13C.Models;

namespace COMP2007_S2016_Lesson13C.Controllers
{
    public class ArtistsController : ApiController
    {
        private MVCMusicStoreContext db = new MVCMusicStoreContext();

        // GET: api/Artists
        public IQueryable<Artist> GetArtists()
        {
            return db.Artists;
        }

        // GET: api/Artists/5
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> GetArtist(int id)
        {
            Artist artist = await db.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/Artists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.ArtistId)
            {
                return BadRequest();
            }

            db.Entry(artist).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/Artists
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> PostArtist(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Artists.Add(artist);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = artist.ArtistId }, artist);
        }

        // DELETE: api/Artists/5
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> DeleteArtist(int id)
        {
            Artist artist = await db.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            db.Artists.Remove(artist);
            await db.SaveChangesAsync();

            return Ok(artist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistExists(int id)
        {
            return db.Artists.Count(e => e.ArtistId == id) > 0;
        }
    }
}