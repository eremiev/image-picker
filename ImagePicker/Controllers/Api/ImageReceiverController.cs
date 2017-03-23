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
using ImagePicker.Models;

namespace ImagePicker.Controllers.Api
{
    public class ImageReceiverController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: api/ImageReceiver
        [ResponseType(typeof(Phone))]
        public async Task<IHttpActionResult> PostPhone(ImageReceiverViewModel imageReceiver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = db.Users.Where(u => u.Code == imageReceiver.Code).FirstOrDefault();
            Phone ph = new Phone();
            ph.UniqueID = imageReceiver.UniqueID;

            user.Phones.Add(ph);
            //Phone test = (Phone)user.Phones;
            //Image im = new Image();
            //im.Base64 = imageReceiver.Base64;
            //im.Path = imageReceiver.Path;
            //test.Images.Add(im);

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = imageReceiver.Code }, imageReceiver);
        }

        private bool PhoneExists(int id)
        {
            return db.Phones.Count(e => e.ID == id) > 0;
        }
    }
}