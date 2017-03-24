using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImagePicker.Models
{
    public class ImageReceiverViewModel
    {
        public int Code { get; set; }
        public string UniqueID { get; set; }
        public string Name { get; set; }
        public string Base64 { get; set; }
    }
}