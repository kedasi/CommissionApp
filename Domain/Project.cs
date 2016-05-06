using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Project
    {
        public int ProjectId { get; set; }
        public DateTime ProjectDate { get; set; }

        //Välisvõtmed
        public virtual List<ProjectStatusReport> ProjectStatusReports { get; set; }

        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
