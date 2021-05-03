using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcProductModal
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string PrductName { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string ProductDesc { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public Nullable<double> Rate { get; set; }


        public Nullable<int> Quantity { get; set; }

        public Nullable<int> MinQuantity { get; set; }
    }
}