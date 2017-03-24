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
using System.IO;
using System.Web;



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
            try
            {
                ApplicationUser user = db.Users.Where(u => u.Code == imageReceiver.Code).FirstOrDefault();
                if (user == null)
                    return NotFound();

                string imageName = imageReceiver.Name;
                var uploadDir = "~/Content/uploads/" + user.Id + "/" + imageReceiver.UniqueID + "/";
                var imagePath = Path.Combine(HttpContext.Current.Server.MapPath(uploadDir), imageName);
                var imageUrl = Path.Combine(uploadDir, imageName);
                if (!Directory.Exists(uploadDir))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(uploadDir));

                File.WriteAllBytes(imagePath, Convert.FromBase64String(imageReceiver.Base64));

                List<Phone> phone = user.Phones.Where(p => p.UniqueID == imageReceiver.UniqueID).ToList();
                Image image = new Image() { Path = imagePath };
                List<Image> imageList = new List<Image>();
                imageList.Add(image);

                //if phone not exist
                if (phone.Count() == 0)
                {
                    Phone phoneModel = new Phone() { UniqueID = imageReceiver.UniqueID, Images = imageList };
                    user.Phones.Add(phoneModel);
                }
                else
                {
                    phone.FirstOrDefault()
                        .Images
                        .Add(new Image()
                        {
                            Path = imagePath,
                            PhoneID = phone.FirstOrDefault().ID
                        });
                }

                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest("Error: " + e.Message + " StackTrace: " + e.StackTrace);
            }
            return Ok();
        }

        private bool PhoneExists(int id)
        {
            return db.Phones.Count(e => e.ID == id) > 0;
        }
    }
}