using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Business.DTOs;

public class CVExtractResultDto
{
    public required string FullName { get; set; }
    public required string Email { get; set; }

    public required string Skills { get; set; }
    public int YearsOfExperience { get; set; }

}
