using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentCVScreening.WinForms.Core.Models;
using RecruitmentCVScreening.WinForms.Data.Tables;
namespace RecruitmentCVScreening.WinForms.Business.Services;

public class JobService
{
    private readonly JobData _jobData;

    public JobService()
    {
        _jobData = new JobData();
    }

    /// <summary>
    /// Lấy toàn bộ danh sách Job từ database
    /// </summary>
    public List<Job> GetAll()
    {
        return _jobData.GetAll();
    }

    /// <summary>
    /// Lấy Job theo Id (nếu cần)
    /// </summary>
    public Job? GetById(int jobId)
    {
        return _jobData.GetById(jobId);
    }

    /// <summary>
    /// Thêm Job mới (dùng cho JobForm)
    /// </summary>
    public void Create(Job job)
    {
        _jobData.Insert(job);
    }
}
