using RecruitmentCVScreening.WinForms.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentCVScreening.WinForms.Data.Connection;
using Microsoft.Data.SqlClient;
using RecruitmentCVScreening.WinForms.Core.Models;
namespace RecruitmentCVScreening.WinForms.Data.Tables;

public class CandidateData : ICandidateData
{
    public int Insert(Candidate c)
    {
        using var conn = AppDbContext.GetConnection();
        conn.Open();

        var cmd = new SqlCommand(@"
            INSERT INTO Candidates (FullName, Email)
            OUTPUT INSERTED.Id
            VALUES (@FullName, @Email)", conn);

        cmd.Parameters.AddWithValue("@FullName", c.FullName);
        cmd.Parameters.AddWithValue("@Email", c.Email);
        
              return (int)cmd.ExecuteScalar();
    }

    public Candidate? GetByEmail(string email)
    {
        using var conn = AppDbContext.GetConnection();
        conn.Open();

        var cmd = new SqlCommand(
            "SELECT * FROM Candidates WHERE Email = @Email", conn);
        cmd.Parameters.AddWithValue("@Email", email);

        using var reader = cmd.ExecuteReader();
        if (!reader.Read()) return null;

        return new Candidate
        {
            Id = (int)reader["Id"],
            FullName = reader["FullName"].ToString()!,
            Email = reader["Email"].ToString()!
        };
    }
    public int GetOrCreate(string fullName, string email)
    {
        var existing = GetByEmail(email);
        if (existing != null)
            return existing.Id;

        return Insert(new Candidate
        {
            FullName = fullName,
            Email = email
        });
    }
}
