using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Core.Models;

public class Candidate
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
}
