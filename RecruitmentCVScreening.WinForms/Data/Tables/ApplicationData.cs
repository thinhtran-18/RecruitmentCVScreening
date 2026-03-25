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
    public class ApplicationData
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
            a.Status,
            a.JobId,        -- Lấy thêm để hỗ trợ lọc
            a.CandidateId

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

        //Minh
        // Sử dụng chuỗi kết nối linh hoạt
        private readonly string _connectionString = @"Server=.;Database=RecruitmentCVScreeningDB;Integrated Security=True;TrustServerCertificate=True;";

        public List<ApplicationDto> GetApplications(int? jobId, string status)
        {
            var list = new List<ApplicationDto>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                // SQL JOIN 3 bảng: Applications (a), Candidates (c), Jobs (j)
                string query = @"
                    SELECT a.Id AS ApplicationId, c.FullName, c.Email, j.Title AS JobTitle, 
                           a.Score, a.Status, a.JobId, a.CandidateId
                    FROM Applications a
                    JOIN Candidates c ON a.CandidateId = c.Id
                    JOIN Jobs j ON a.JobId = j.Id
                    WHERE 1=1 ";

                if (jobId.HasValue && jobId.Value > 0) query += " AND a.JobId = @JobId ";
                if (!string.IsNullOrEmpty(status) && status != "All") query += " AND a.Status = @Status ";

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (jobId.HasValue && jobId.Value > 0) cmd.Parameters.AddWithValue("@JobId", jobId.Value);
                    if (!string.IsNullOrEmpty(status) && status != "All") cmd.Parameters.AddWithValue("@Status", status);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ApplicationDto
                            {
                                ApplicationId = (int)reader["ApplicationId"],
                                FullName = reader["FullName"].ToString(),
                                Email = reader["Email"].ToString(),
                                JobTitle = reader["JobTitle"].ToString(),
                                Score = Convert.ToDouble(reader["Score"]),
                                Status = reader["Status"].ToString(),
                                JobId = (int)reader["JobId"],
                                CandidateId = (int)reader["CandidateId"]
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool UpdateStatus(int id, string newStatus)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Applications SET Status = @Status WHERE Id = @Id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddApplication(int jobId, int candidateId, double score = 0)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Applications (JobId, CandidateId, Score, Status) VALUES (@JobId, @CandidateId, @Score, 'Pending')";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@JobId", jobId);
                    cmd.Parameters.AddWithValue("@CandidateId", candidateId);
                    cmd.Parameters.AddWithValue("@Score", score);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}

