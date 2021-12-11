using LoadUpdatingTool.Data.DTO;

namespace LoadUpdatingTool.Core
{
    public interface ILoadService
    {
        List<string> ParseInputFile(string filePath);
        CurveUpdate VerifyData(List<string> inputList);
        int ProcessUpdateData(List<CurveUpdate> verifiedCurveDataList);
        int Clear();
    }
}
