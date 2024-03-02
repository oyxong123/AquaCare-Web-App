﻿using AquaCare_Web_App.Models.Dtos;

namespace AquaCare_Web_App.Services
{
    public interface ISensorService
    {
        Task<List<SensorDto>> GetAllSensorRecords();
    }
}