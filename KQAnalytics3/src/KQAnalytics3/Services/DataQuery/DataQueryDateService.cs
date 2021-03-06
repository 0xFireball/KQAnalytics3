﻿using KQAnalytics3.Models.Data;
using KQAnalytics3.Services.Database;
using System;
using System.Collections.Generic;

namespace KQAnalytics3.Services.DataQuery
{
    public class DataQueryDateService
    {
        public IEnumerable<LogRequest> GetAllRequestsAfterDate(DateTime startDate)
        {
            var db = KQRegistry.DatabaseAccessService.OpenOrCreateDefault();
            var loggedRequests = db.GetCollection<LogRequest>(DatabaseConstants.LoggedRequestDataKey);
            return loggedRequests.Find(x => x.Timestamp > startDate);
        }
    }
}