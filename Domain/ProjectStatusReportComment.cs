using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class ProjectStatusReportComment
    {
        public int ProjectStatusReportCommentId { get; set; }
        [MaxLength(5000)]
        public string ProjectStatusComment { get; set; }

        //Välisvõtmed
        public int ProjectStatusReportId { get; set; }
        public virtual ProjectStatusReport ProjectStatusReport { get; set; }
    }
}
