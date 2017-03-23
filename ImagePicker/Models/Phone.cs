using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImagePicker.Models
{
    public class Phone
    {
        public int ID { get; set; }
        public string UniqueID { get; set; }
        public string NameHolder { get; set; }
        public string Model { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual List<Image> Images { get; set; }
    }
}