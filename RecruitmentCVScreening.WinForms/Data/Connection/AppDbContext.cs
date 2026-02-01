using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Data.Connection;

public   class AppDbContext
{
    private static readonly string _connectionString =
        "Server=localhost\\SQLEXPRESS;Database=RecruitmentCVScreeningDB;Trusted_Connection=True;TrustServerCertificate=True;";


    public static SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}

