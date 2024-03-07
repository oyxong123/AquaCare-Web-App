using AquaCare_Web_App.Database;
using AquaCare_Web_App.Models;
using AquaCare_Web_App.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<List<SensorDto>> GetAllLatestSystemsRecordFromLastSevenDays()
        {
            try
            {
                using (var _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.Sensor == null)
                    {
                        throw new Exception("Sensor" + _textNotInitialized);
                    }

                    DateTime timestampLimit = DateTime.Now.AddDays(-7);
                    List<Sensor> sensorModelList = await _context.Sensor
                       .Where(u => u.Timestamp > timestampLimit)
                       .ToListAsync();

                    List<Sensor> filteredList = [];
                    foreach (var model in sensorModelList.GroupBy(u => u.Model))
                    {
                        var filteredModel = model
                            .Where(u => u.Timestamp > timestampLimit)
                            .GroupBy(u => u.Timestamp.Date)
                            .Select(u => u.OrderByDescending(u => u.Timestamp).First());

                        filteredList.AddRange(filteredModel);
                    }
                    sensorModelList = filteredList;

                    List<SensorDto> sensorDtoList = [];
                    foreach (Sensor sensor in sensorModelList)
                    {
                        SensorDto sensorDto = new()
                        {
                            Model = sensor.Model,
                            Timestamp = sensor.Timestamp,
                            Ph = sensor.Ph,
                            Salinity = sensor.Salinity,
                            SunlightIntensity = sensor.SunlightIntensity,
                            Temperature = sensor.Temperature,
                            Turbidity = sensor.Turbidity
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

        public async Task<List<SensorDto>> GetLatestSystemRecords()
        {
            try
            {
                using (var _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.Sensor == null)
                    {
                        throw new Exception("Sensor" + _textNotInitialized);
                    }

                    var temp = await _context.Sensor.Select(u => u.Model).ToListAsync();
                    var modelList = temp.Distinct().ToList();

                    List<Sensor> sensorModelList = [];
                    foreach (string model in modelList)
                    {
                        Sensor sensorRecord = await _context.Sensor.Where(u => u.Model == model).OrderByDescending(u => u.Timestamp).FirstAsync();
                        sensorModelList.Add(sensorRecord);
                    }

                    List<SensorDto> sensorDtoList = [];
                    foreach (Sensor sensor in sensorModelList)
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

        public async Task<List<SensorDto>> GetSensorRecords(string model)
        {
            try
            {
                using (var _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.Sensor == null)
                    {
                        throw new Exception("Sensor" + _textNotInitialized);
                    }

                    List<Sensor> sensorModelList = sensorModelList = await _context.Sensor.Where(u => u.Model == model).OrderByDescending(u => u.Timestamp).ToListAsync();
                    List<SensorDto> sensorDtoList = [];
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
                            Turbidity = sensor.Turbidity
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
