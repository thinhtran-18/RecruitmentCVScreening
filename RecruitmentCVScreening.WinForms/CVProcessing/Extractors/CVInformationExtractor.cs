using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using RecruitmentCVScreening.WinForms.Business.DTOs;
namespace RecruitmentCVScreening.WinForms.CVProcessing.Extractors
{
    public class CVInformationExtractor
    {
        public CVExtractResultDto Extract(string text)
        {
            return new CVExtractResultDto
            {
                FullName = ExtractName(text),
                Email = ExtractEmail(text),
                Skills = ExtractSkills(text),
                YearsOfExperience = ExtractExperience(text)
            };
        }

        private string ExtractName(string text)
        {
            // Giả sử tên nằm ở 2 dòng đầu
            var lines = text.Split('\n');
            return lines.Length > 0 ? lines[0].Trim() : "Unknown";
        }

        private string ExtractEmail(string text)
        {
            var match = Regex.Match(
                text,
                @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}"
            );
            return match.Success ? match.Value : "";
        }

        private string ExtractSkills(string text)
        {
            string[] keywords = { "C#", ".NET", "SQL", "Java", "Python" };
            var found = keywords.Where(k => text.Contains(k));
            return string.Join(", ", found);
        }

        private int ExtractExperience(string text)
        {
            var match = Regex.Match(text, @"(\d+)\s+year");
            return match.Success ? int.Parse(match.Groups[1].Value) : 0;
        }
    }
}
