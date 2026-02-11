using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Business.DTOs;

public class CandidateScoreDto
{
    public string FullName { get; set; } 
    public string Email { get; set; }
    public double Score { get; set; }

    public string Skills { get; set; }
    public string Decision { get; set; }


    public int Rank { get; set; }

}
