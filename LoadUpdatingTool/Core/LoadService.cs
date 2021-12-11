using LoadUpdatingTool.Data.DTO;
using LoadUpdatingTool.Data.Entity;
using LoadUpdatingTool.Data.Repository;

namespace LoadUpdatingTool.Core
{
    public class LoadService : ILoadService
    {
        private readonly ILoadRepository _loadRepository;

        public LoadService(ILoadRepository loadRepository)
        {
            _loadRepository = loadRepository;
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
                        curveUpdate.Curve = number;
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
                    var stringNumbers = inputLine.Substring(inputLine.LastIndexOf(':') + 1);

                    int identification;
                    var identificationStringList = stringNumbers.Split(",");
                    foreach (var identificationString in identificationStringList)
                    {
                        bool success = Int32.TryParse(identificationString, out identification);
                        if (success)
                        {
                            curveUpdate.Identifications.Add(identification);
                            continue;
                        }
                        var errorText = $"Identifications {identificationString} isn't in correct format";
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

        public int ProcessUpdateData(List<CurveUpdate> verifiedCurveDataList)
        {
            var servicePointsDb = _loadRepository.GetAllServicePoints();
            var sysLoadDb = _loadRepository.GetAllSysLoads();
            var teeLoadDb = _loadRepository.GetAllTeeLoads();

            var teeLoadToInsert = new List<TeeLoadInformationEvw>();
            var sysLoadToUpdate = new List<SysLoadInformationEvw>();
            var sysLoadToInsert = new List<SysLoadInformationEvw>();
            var teeServicePointToUpdate = new List<TeeServicePointEvw>();

            int updatedCount = 0;

            foreach (var load in verifiedCurveDataList)
            {
                foreach (var servicePointId in load.Identifications)
                {
                    var servicePoint = servicePointsDb.Where(x => x.Id == servicePointId).FirstOrDefault();
                    if (servicePoint != null)
                    {
                        var sysLoad = sysLoadDb.FirstOrDefault(x=>x.RwoGid == servicePoint.Gid);
                        if (sysLoad != null)  //sysload exists
                        {
                            teeLoadToInsert.Add(new TeeLoadInformationEvw() 
                            { 
                                Gid = sysLoad.Gid,
                                EnergyMwh = sysLoad.EnergyMwh,
                                InsertionTime = sysLoad.InsertionTime,
                                NumberOfCustomers = sysLoad.NumberOfCustomers,
                                RwoGid= sysLoad.RwoGid,
                            });

                            sysLoad.NumberOfCustomers = load.CustomersCount;
                            sysLoad.EnergyMwh = load.EnergyMWh;
                            sysLoad.InsertionTime = DateTime.UtcNow;
                            sysLoadToUpdate.Add(sysLoad);

                            servicePoint.ConversionInfo = $"-LoadSet -{servicePoint.ConversionInfo}";
                            teeServicePointToUpdate.Add(servicePoint);
                        }
                        else //sysload not exists
                        {
                            sysLoadToInsert.Add(new SysLoadInformationEvw()
                            {
                                InsertionTime = DateTime.UtcNow,
                                EnergyMwh = load.EnergyMWh,
                                NumberOfCustomers = load.CustomersCount,
                                RwoGid = servicePoint.Gid
                            });
                        }
                        updatedCount++;
                    }
                }
            }

            _loadRepository.InsertTeeLoads(teeLoadToInsert);
            _loadRepository.UpdateSysLoads(sysLoadToUpdate);
            _loadRepository.InsertSysLoads(sysLoadToInsert);
            _loadRepository.UpdateServicePoints(teeServicePointToUpdate);

            return updatedCount;
        }


        public int Clear()
        {
            var deletedRecordCount = _loadRepository.DeleteAllTeeLoads();
            return deletedRecordCount;
        }
    }
}
