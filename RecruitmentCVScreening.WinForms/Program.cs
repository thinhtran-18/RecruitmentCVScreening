using RecruitmentCVScreening.WinForms.UI.Forms;


namespace RecruitmentCVScreening.WinForms;

public static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
       
            // 1. Lệnh này của .NET mới đã tự động bao gồm cấu hình giao diện
            ApplicationConfiguration.Initialize();

            // 2. Khởi chạy trực tiếp MainForm của chúng ta
            Application.Run(new UI.Forms.MainForm());
        
    }
}

