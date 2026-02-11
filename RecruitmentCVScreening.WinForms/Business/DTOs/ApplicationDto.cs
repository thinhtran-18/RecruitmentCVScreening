using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Business.DTOs
{
    internal class ApplicationDto
    {
        public int ApplicationId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public double Score { get; set; }
        public string Status { get; set; } = string.Empty;

        public int Rank { get; set; }
    }
}
