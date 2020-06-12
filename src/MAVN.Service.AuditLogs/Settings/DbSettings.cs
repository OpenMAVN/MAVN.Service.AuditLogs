﻿using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.AuditLogs.Settings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }

        [SqlCheck]
        public string SqlDbConnString { get; set; }
    }
}
