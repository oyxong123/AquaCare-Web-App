using AquaCare_Web_App.Database;
using AquaCare_Web_App.Models;
using AquaCare_Web_App.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AquaCare_Web_App.Services
{
    public class SensorService(IDbContextFactory<DatabaseContext> contextFactory) : ISensorService
    {
        private readonly IDbContextFactory<DatabaseContext> _contextFactory = contextFactory;
        private readonly string _textNotInitialized = " Table not initialized.";
        private readonly string _textInvalid = " provided is invalid.";
        private readonly string _textNotProvided = " not provided.";
        private readonly string _textNotFound = " not found.";
        private readonly string _textHasExisted = " has existed.";
        private readonly string _textNotMatch = " does not match with provided ";

        public async Task<List<SensorDto>> GetAllSensorRecords()
        {
            try
            {
                using (var _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.Sensor == null)
                    {
                        throw new Exception("Sensor" + _textNotInitialized);
                    }

                    List<Sensor> sensorModelList = sensorModelList = await _context.Sensor.ToListAsync();
                    List<SensorDto> sensorDtoList = new();
                    foreach (var sensor in sensorModelList)
                    {
                        SensorDto sensorDto = new()
                        {
                            Model = sensor.Model,
                            Timestamp = sensor.Timestamp,
                            Ph = sensor.Ph,
                            Salinity = sensor.Salinity,
                            SunlightIntensity = sensor.SunlightIntensity,
                            Temperature = sensor.Temperature,
                            Turbidity  = sensor.Turbidity
                        };
                        sensorDtoList.Add(sensorDto);
                    }

                    return sensorDtoList; 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
