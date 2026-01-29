using RecruitmentCVScreening.WinForms.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Data.Contracts;

internal interface ICandidateData
{
    int Insert(Candidate candidate);
    Candidate? GetByEmail(string email);
}
