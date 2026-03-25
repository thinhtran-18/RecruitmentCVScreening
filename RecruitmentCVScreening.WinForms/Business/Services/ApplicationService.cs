using RecruitmentCVScreening.WinForms.Business.DTOs;
using RecruitmentCVScreening.WinForms.Core.Models;
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

        //Minh
        private readonly ApplicationData _data = new ApplicationData();

        public List<ApplicationDto> GetList(int? jobId, string status)
        {
            var apps = _data.GetApplications(jobId, status);
            // Logic tính Rank dựa trên Score (tùy chọn)
            apps.Sort((x, y) => y.Score.CompareTo(x.Score));
            for (int i = 0; i < apps.Count; i++) apps[i].Rank = i + 1;
            return apps;
        }

        public bool UpdateStatus(int id, string status) => _data.UpdateStatus(id, status);

        public bool Create(int jobId, int candidateId) => _data.AddApplication(jobId, candidateId);
    }

}
