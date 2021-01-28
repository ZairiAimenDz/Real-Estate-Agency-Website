using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REstate.Models
{
    public class PropertyImage
    {
        public Guid Id { get; set; }
        public string ImageFile { get; set; }

        [NotMapped]
        public IFormFile File{ get; set; }
        public Guid PropertyID { get; set; }
        public Property Property { get; set; }
    }
}
