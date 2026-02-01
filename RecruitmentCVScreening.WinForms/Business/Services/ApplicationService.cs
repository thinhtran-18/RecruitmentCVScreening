using RecruitmentCVScreening.WinForms.Business.DTOs;
using RecruitmentCVScreening.WinForms.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Business.Services
{
    internal class ApplicationService
    {
        private readonly CVProcessingService _cvProcessing = new();

        public CandidateScoreDto UploadAndProcessCV(
            
            string fullName,
            string email,
            string filePath,
            Job job)
        {
            // GỌI NGUYÊN CVProcessing CỦA BẠN
            return _cvProcessing.Process( fullName, email, filePath, job);
        }
    }
}
