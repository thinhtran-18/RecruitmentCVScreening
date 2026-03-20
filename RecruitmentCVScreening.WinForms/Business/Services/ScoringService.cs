using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentCVScreening.WinForms.Business.DTOs;
using RecruitmentCVScreening.WinForms.Core.Models;
namespace RecruitmentCVScreening.WinForms.Business.Services;

public class ScoringService
{
    public double Calculate(CVExtractResultDto cv, Job job)
    {
        double score = 0;

        // Kinh nghiệm
        if (cv.YearsOfExperience >= job.MinExperience)
        {
            int extraYears = cv.YearsOfExperience - job.MinExperience;

            double experienceScore = 30 + (extraYears * 5);

            // Giới hạn tối đa 50 điểm
           score += Math.Min(experienceScore, 50);

            
        }

        // Skill match
        int matchCount = 0;

        var requiredSkills = job.RequiredSkills.Split(',');

        foreach (var skill in requiredSkills)
        {
            if (cv.Skills.Contains(skill.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                matchCount++;
            }
        }

        double skillScore = matchCount * 10; // mỗi skill 10 điểm

        score += Math.Min(skillScore, 50);

        return Math.Min(score, 100);
    }
}
