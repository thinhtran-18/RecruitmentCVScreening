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
            text = NormalizeText(text);

            return new CVExtractResultDto
            {
                FullName = ExtractName(text),
                Email = ExtractEmail(text),
                Skills = ExtractSkills(text),
                YearsOfExperience = ExtractExperience(text)
            };
        }
        private string NormalizeText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            string normalized = text;

            // Chèn khoảng trắng trước các keyword hay bị dính
            string[] keywords = { "Email", "Skills", "Experience", "Education" };

            foreach (var k in keywords)
            {
                normalized = Regex.Replace(
                    normalized,
                    k,
                    " " + k,
                    RegexOptions.IgnoreCase
                );
            }

            // Chuẩn hóa khoảng trắng
            normalized = Regex.Replace(normalized, @"\s+", " ").Trim();

            return normalized;
        }

        private string ExtractName(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
        return string.Empty;

    // Chuẩn hóa text
    var cleanText = text
        .Replace("\r", " ")
        .Replace("\n", " ")
        .Replace("\t", " ");

    // Tách theo từ khóa
    var parts = Regex.Split(
        cleanText,
        @"Email\s*:|Skills\s*:|Experience\s*:",
        RegexOptions.IgnoreCase
    );

    // Phần đầu tiên thường là tên
    var name = parts[0].Trim();

    // Loại bỏ ký tự lạ
    name = Regex.Replace(name, @"[^a-zA-ZÀ-ỹ\s]", "").Trim();

    return name;
        }

        private string ExtractEmail(string text)
        {
            var match = Regex.Match(
        text,
        @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\b"
    );

            return match.Success ? match.Value.Trim() : string.Empty;
        }

        private string ExtractSkills(string text)
        {
            string[] keywords = { "C#", ".NET", "SQL", "Java", "Python" , "C++" };
            var found = keywords.Where(k => text.Contains(k));
            return string.Join(", ", found);
        }

        private int ExtractExperience(string text)
        {
            var match = Regex.Match(text, @"(\d+)\s+years");
            return match.Success ? int.Parse(match.Groups[1].Value) : 0;
        }
    }
}
