using Microsoft.Data.SqlClient;
using RecruitmentCVScreening.WinForms.Business.DTOs;
using RecruitmentCVScreening.WinForms.Core.Enums;
using RecruitmentCVScreening.WinForms.Core.Models;
using RecruitmentCVScreening.WinForms.Data.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Data.Tables
{
    internal class ApplicationData
    {
        public void Insert(RecruitmentCVScreening.WinForms.Core.Models.Application application)
        {
            using var conn = AppDbContext.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                @"INSERT INTO Applications (JobId, CandidateId, Score, Status)
                  VALUES (@jobId, @candidateId, @score, @status)",
                conn
            );

            cmd.Parameters.AddWithValue("@jobId", application.JobId);
            cmd.Parameters.AddWithValue("@candidateId", application.CandidateId);
            cmd.Parameters.AddWithValue("@score", application.Score);
            cmd.Parameters.AddWithValue("@status", application.Status.ToString());

            cmd.ExecuteNonQuery();
        }

        // 👉 Dùng cho ApplicationsForm / CandidateListForm
        public List<RecruitmentCVScreening.WinForms.Core.Models.Application> GetByJob(int jobId)
        {
            var list = new List<RecruitmentCVScreening.WinForms.Core.Models.Application>();

            using var conn = AppDbContext.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT * FROM Applications WHERE JobId = @jobId",
                conn
            );
            cmd.Parameters.AddWithValue("@jobId", jobId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new RecruitmentCVScreening.WinForms.Core.Models.Application
                {
                    Id = (int)reader["Id"],
                    JobId = (int)reader["JobId"],
                    CandidateId = (int)reader["CandidateId"],
                    Score = (double)reader["Score"],
                    Status = Enum.Parse<ApplicationStatus>(reader["Status"].ToString()!)
                });
            }

            return list;
        }
        public List<ApplicationDto> GetAllForRanking()//lấy danh sách ứng viên đã ứng tuyển kèm thông tin cần thiết để xếp hạng (chỉ đọc và gửi dữ liệu cho ui)

        {
            var list = new List<ApplicationDto>();

            using var conn = AppDbContext.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
        SELECT 
            a.Id AS ApplicationId,
            c.FullName,
            c.Email,
            j.Title AS JobTitle,
            a.Score,
            a.Status
        FROM Applications a
        JOIN Candidates c ON a.CandidateId = c.Id
        JOIN Jobs j ON a.JobId = j.Id
        ORDER BY a.Score DESC
    ", conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ApplicationDto
                {
                    ApplicationId = (int)reader["ApplicationId"],
                    FullName = reader["FullName"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    JobTitle = reader["JobTitle"].ToString()!,
                    Score = (double)reader["Score"],
                    Status = reader["Status"].ToString()!
                });
            }

            return list;
        }
    }
}

