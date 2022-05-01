using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3___API.Models
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? PersonId { get; set; }
        public Person Person { get; set; }

        public int? InterestId { get; set; }
        public Interest Interest { get; set; }


        public string WebsiteLink { get; set; }

    }
}
