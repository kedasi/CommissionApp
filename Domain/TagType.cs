using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TagType
    {
        public int TagTypeId { get; set; }
        [MaxLength(24)]
        public string TagTypeValue { get; set; }

        //välisvõtmed (list)
        public virtual List<Tag> Tags { get; set; }
    }
}
