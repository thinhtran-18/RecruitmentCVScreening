using RecruitmentCVScreening.WinForms.Business.DTOs;
using RecruitmentCVScreening.WinForms.Core.Models;
using RecruitmentCVScreening.WinForms.Data.Contracts;
using RecruitmentCVScreening.WinForms.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Business.Services
{
    public class ApplicationService
    {
        private readonly CVProcessingService _cvProcessing = new();
        private readonly ApplicationData _applicationData = new ApplicationData();
        public CandidateScoreDto UploadAndProcessCV(
            
            string fullName,
            string email,
            string filePath,
            Job job)
        {
            // GỌI NGUYÊN CVProcessing đã có 
            return _cvProcessing.Process( fullName, email, filePath, job);
        }
        public List<ApplicationDto> GetCandidateScores()
        {
            var data = new ApplicationData();
            return data.GetAllForRanking();
        }

        public void DeleteApplication(int applicationId)
        {
            _applicationData.Delete(applicationId);
        }
    }

}
