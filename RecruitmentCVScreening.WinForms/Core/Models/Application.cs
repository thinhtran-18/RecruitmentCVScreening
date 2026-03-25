using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentCVScreening.WinForms.Core.Enums;
namespace RecruitmentCVScreening.WinForms.Core.Models
{
    public class Application
    {
        public int Id { get; set; }

        // FK
        public int JobId { get; set; }
        public int CandidateId { get; set; }   // có thể = 0 nếu chưa lưu candidate

        // Kết quả xử lý
        public double Score { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
