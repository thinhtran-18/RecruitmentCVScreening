using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentCVScreening.WinForms.Business.DTOs;
namespace RecruitmentCVScreening.WinForms.Business.Services;


    public class RankingService
    {
        public List<CandidateScoreDto> Rank(List<CandidateScoreDto> candidates)
        {
            return candidates
                .OrderByDescending(c => c.Score)
                .ToList();
        }
    }

