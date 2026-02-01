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
            score += 30;

        // Skill match
        foreach (var skill in job.RequiredSkills.Split(','))
        {
            if (cv.Skills.Contains(skill.Trim(), StringComparison.OrdinalIgnoreCase))
                score += 30;
        }

        return score;
    }
}
