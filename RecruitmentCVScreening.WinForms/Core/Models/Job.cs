using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.Core.Models;

public class Job
{
    // Khóa chính
    public int Id { get; set; }

    // Thông tin cơ bản
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Tiêu chí tuyển dụng                   ( từ dòng 18 đến 20  tao dùng cái này để code đấy cấm xóa )
    public string RequiredSkills { get; set; } = string.Empty;
    public int MinExperience { get; set; }

    // Thông tin quản lý
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
}
