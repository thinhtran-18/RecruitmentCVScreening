using Microsoft.Data.SqlClient;
using RecruitmentCVScreening.WinForms.Core.Models;
using RecruitmentCVScreening.WinForms.Data.Connection;
using RecruitmentCVScreening.WinForms.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Data.Tables;

public class JobData : IJobData
{
    private readonly AppDbContext _dbContext;

    public JobData()
    {
        _dbContext = new AppDbContext();
    }

    /// <summary>
    /// Lấy toàn bộ danh sách Job
    /// </summary>
    public List<Job> GetAll()
    {
        var jobs = new List<Job>();

        using SqlConnection conn = AppDbContext.GetConnection();
        conn.Open();

        string sql = @"
                SELECT Id, Title, RequiredSkills, MinExperience
                FROM Jobs";

        using SqlCommand cmd = new SqlCommand(sql, conn);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            jobs.Add(new Job
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                RequiredSkills = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                MinExperience = reader.GetInt32(3)
            });
        }

        return jobs;
    }

    /// <summary>
    /// Lấy Job theo Id
    /// </summary>
    public Job? GetById(int jobId)
    {
        using SqlConnection conn = AppDbContext.GetConnection();
        conn.Open();

        string sql = @"
                SELECT Id, Title, RequiredSkills, MinExperience
                FROM Jobs
                WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", jobId);

        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Job
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                RequiredSkills = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                MinExperience = reader.GetInt32(3)
            };
        }

        return null;
    }

    /// <summary>
    /// Thêm Job mới
    /// </summary>
    public void Insert(Job job)
    {
        using SqlConnection conn = AppDbContext.GetConnection();
        conn.Open();

        string sql = @"
                INSERT INTO Jobs (Title, RequiredSkills, MinExperience)
                VALUES (@Title, @RequiredSkills, @MinExperience)";

        using SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Title", job.Title);
        cmd.Parameters.AddWithValue("@RequiredSkills", job.RequiredSkills ?? string.Empty);
        cmd.Parameters.AddWithValue("@MinExperience", job.MinExperience);

        cmd.ExecuteNonQuery();
    }
}
