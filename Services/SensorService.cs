﻿using AquaCare_Web_App.Database;
using AquaCare_Web_App.Models;
using AquaCare_Web_App.Models.Dtos;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;
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

                    var firebaseDb = GetFirebaseDatabase();

                    DateTime timestampLimit = DateTime.Now.AddDays(-7);
                    List<Sensor> sensorModelList = firebaseDb
                       .Where(u => u.Timestamp > timestampLimit)
                       .ToList();

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

                    var firebaseDb = GetFirebaseDatabase();

                    var temp = firebaseDb.Select(u => u.Model).ToList();
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

                    var firebaseDb = GetFirebaseDatabase();

                    List<Sensor> sensorModelList = sensorModelList = firebaseDb.Where(u => u.Model == model).OrderByDescending(u => u.Timestamp).ToList();
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

        private List<Sensor> GetFirebaseDatabase()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = " AIzaSyDrT5nfyJL-OjM7PxoMEyQVfX0AGgR_o34",
                BasePath = "https://aquacare-6f91b-default-rtdb.asia-southeast1.firebasedatabase.app/"
            };
            IFirebaseClient client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("System1");
            dynamic systems = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var systemsDataList = new List<Sensor>();
            if (systems != null)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                foreach (var system in systems)
                {
                    string model = JsonConvert.DeserializeObject<string>(((JProperty)system).Name.ToString());

                    foreach (var timestamp in system)
                    {

                        Sensor sensor = new()
                        {
                            Model = model
                        };

                        string datetimeString = JsonConvert.DeserializeObject<string>(((JProperty)timestamp).Name.ToString());
                        sensor.Timestamp = DateTime.ParseExact(datetimeString, "yyyy-M-d, HH-mm-ss", provider);
                        sensor.SunlightIntensity = JsonConvert.DeserializeObject<decimal>(((JProperty)timestamp[0]).Value.ToString());
                        sensor.Salinity = JsonConvert.DeserializeObject<decimal>(((JProperty)timestamp[1]).Value.ToString());
                        sensor.Temperature = JsonConvert.DeserializeObject<decimal>(((JProperty)timestamp[2]).Value.ToString());
                        sensor.Turbidity = JsonConvert.DeserializeObject<decimal>(((JProperty)timestamp[3]).Value.ToString());
                        sensor.Ph = JsonConvert.DeserializeObject<decimal>(((JProperty)timestamp[5]).Value.ToString());

                        systemsDataList.Add(sensor);
                    }
                }
            }

            return systemsDataList;
        }
    }
}
