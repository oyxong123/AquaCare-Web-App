﻿using AquaCare_Web_App.Models.Dtos;

namespace AquaCare_Web_App.Services
{
    public interface ISensorService
    {
        Task<List<SensorDto>> GetAllLatestSystemsRecordFromLastSevenDays();
        Task<List<SensorDto>> GetAllSystemsRecordFromLastSevenDays();
        Task<List<SensorDto>> GetLatestSystemRecordsAsync();
        List<SensorDto> GetLatestSystemRecords();
        Task<List<SensorDto>> GetSensorRecords(string model);
    }
}
