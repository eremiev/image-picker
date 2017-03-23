using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImagePicker.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string Path { get; set; }
        public string Base64 { get; set; }

        public int PhoneID { get; set; }
        public virtual Phone Phone { get; set; }
    }
}