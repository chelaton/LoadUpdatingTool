using LoadUpdatingTool.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadUpdatingTool.Core
{
    public interface ILoadService
    {
        List<string> ParseInputFile(string filePath);
        CurveUpdate VerifyData(List<string> inputList);
    }
}
