using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentCVScreening.WinForms.CVProcessing.FileReaders;

public interface ICVReader
{
    string ReadText(string filePath);
}
