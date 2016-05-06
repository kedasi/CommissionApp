using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProjectStatusReport
    {
        public int ProjectStatusReportId { get; set; }
        [MaxLength(24)]
        public string ProjectStatus { get; set; }
        public DateTime ProjectStatusDate { get; set; }

        //välisvõtmed

        public virtual List<ProjectStatusReportComment> ProjectStatusReportComments { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
