using Models;
using DataTransferObject;

namespace Repositories{
    public interface IDataRepos{
        public IEnumerable<DataPackage> GetDataPackages(); 
        public IEnumerable<DataPackage> GetHubDataPackagesExpanded(int id);
        public chart_DataPackageDto GetChartData(int id, int? days = null, int? dataPoints = null);
        public chart_DataPackageDto GetDaysChartData(int id, int days);
        public Task<StatisticsDto> GetStatisticsData(int id);
        public DataPackage GetDataPackage(int id); 
        public DataPackage CreateDataPackage(Entry_DataPackageDto _input);
        public DataPackage DeleteDataPackage(int id);
        public DataPackage UpdateDataPackage(int id,Base_Entry_DataPackageDto _input);
        public bool DataPackageExists(int id);
    }
}
