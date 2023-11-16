using CsvHelper;
using Levi9_5DaysInCloud.Enum;
using Levi9_5DaysInCloud.Model.PlayersModel;
using System.Globalization;

namespace Levi9_5DaysInCloud.Repository
{
    public class PlayerPerformanceRepository : IPlayerPerformanceRepository
    {
        
        public IReadOnlyList<PlayerPerformanceModel> MapCsvToPlayerPerformances()
        {
            try
            {
                string relativePath = Path.Combine("Data", "L9HomeworkChallengePlayersInput.csv");
                string filePath = Path.GetFullPath(relativePath);

                Console.WriteLine(filePath);

                var reader = new StreamReader(filePath);

                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    if (!csv.Read())//skiping header
                    {
                        return null;
                    }

                    var records = new List<PlayerPerformanceModel>();

                    while (csv.Read())
                    {
                        var record = new PlayerPerformanceModel
                        {
                            Name = csv.GetField<string>(0),
                            Position = PositionExtensions.GetPosition(csv.GetField<string>(1)),
                            FreeThrowMade = csv.GetField<int>(2),
                            FreeThrowAttempted = csv.GetField<int>(3),
                            TwoPointsMade = csv.GetField<int>(4),
                            TwoPointsAttempted = csv.GetField<int>(5),
                            ThreePointsMade = csv.GetField<int>(6),
                            ThreePointsAttempted = csv.GetField<int>(7),
                            Rebounds = csv.GetField<int>(8),
                            Blocks = csv.GetField<int>(9),
                            Assists = csv.GetField<int>(10),
                            Steals = csv.GetField<int>(11),
                            Turnovers = csv.GetField<int>(12),
                        };

                        records.Add(record);
                    }

                    return records;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
                return null;
            }
        }



    }
}
