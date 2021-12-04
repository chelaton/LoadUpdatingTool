using LoadUpdatingTool.Data.DTO;

namespace LoadUpdatingTool.Core
{
    public class LoadService : ILoadService
    {
        public LoadService()
        {
        }

        public CurveUpdate VerifyData(List<string> inputList) 
        {
            var curveUpdate = new CurveUpdate();
            foreach (var inputLine in inputList)
            {
                if (inputLine.Contains("Curve:"))
                {
                    var stringNumber = inputLine.Substring(inputLine.LastIndexOf(':') + 1);
                    int number;
                    bool success = Int32.TryParse(stringNumber, out number);
                    if (success)
                    {
                        curveUpdate.Curve=number;
                    }
                    else
                    {
                        var errorText = $"Curve number {stringNumber} isn't in correct format";
                        curveUpdate.VerificationErrors.Add(errorText);
                    }

                }
                else if (inputLine.Contains("Customers:"))
                {
                    var stringNumber = inputLine.Substring(inputLine.LastIndexOf(':') + 1);
                    int number;
                    bool success = Int32.TryParse(stringNumber, out number);
                    if (success)
                    {
                        curveUpdate.CustomersCount = number;
                    }
                    else
                    {
                        var errorText = $"Customers number {stringNumber} isn't in correct format";
                        curveUpdate.VerificationErrors.Add(errorText);
                    }
                }
                else if (inputLine.Contains("Energy MWh:"))
                {
                    var stringNumber = inputLine.Substring(inputLine.LastIndexOf(':') + 1);
                    stringNumber = stringNumber.Replace(".", ","); //asi ne uplne ok reseni .. cultureinfo
                    decimal number;
                    bool success = Decimal.TryParse(stringNumber, out number);
                    if (success)
                    {
                        curveUpdate.EnergyMWh = number;
                    }
                    else
                    {
                        var errorText = $"Energy MWh number {stringNumber} isn't in correct format";
                        curveUpdate.VerificationErrors.Add(errorText);
                    }
                }
                else if (inputLine.Contains("Identifications:"))
                {
                    var stringNumber = inputLine.Substring(inputLine.LastIndexOf(':') + 1);

                    int number;
                    bool success = Int32.TryParse(stringNumber, out number);
                    if (success)
                    {
                        curveUpdate.Identifications = number;
                    }
                    else
                    {
                        var errorText = $"Identifications MWh number {stringNumber} isn't in correct format";
                        curveUpdate.VerificationErrors.Add(errorText);
                    }
                }
            }
            return curveUpdate;
        }

        public List<string> ParseInputFile(string filePath)
        {
            var inputStringList = new List<string>();
            foreach (string line in File.ReadLines(filePath))
            {
                inputStringList.Add(line);
            }
            return inputStringList;
        }
    }
}
