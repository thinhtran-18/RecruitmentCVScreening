using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
namespace RecruitmentCVScreening.WinForms.CVProcessing.FileReaders
{
   
    public class DocxCVReader : ICVReader
    {
        public string ReadText(string filePath)
        {
            var text = new StringBuilder();

            using (WordprocessingDocument doc =
                   WordprocessingDocument.Open(filePath, false))
            {
                var body = doc.MainDocumentPart.Document.Body;
                text.Append(body.InnerText);
            }

            return text.ToString();
        }
    }
}
