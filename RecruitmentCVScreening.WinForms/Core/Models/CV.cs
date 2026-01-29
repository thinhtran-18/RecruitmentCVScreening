using RecruitmentCVScreening.WinForms.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Core.Models;

public class CV
{
 
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public required string FilePath { get; set; }
        public CVStatus Status { get; set; }
    
}
