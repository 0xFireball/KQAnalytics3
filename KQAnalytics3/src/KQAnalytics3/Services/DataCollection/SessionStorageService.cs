﻿using KQAnalytics3.Models.Data;
using KQAnalytics3.Services.Database;
using System.Threading.Tasks;

namespace KQAnalytics3.Services.DataCollection
{
    public class SessionStorageService
    {
        public static string SessionUserCookieStorageKey => "kq_session";

        public static async Task<UserSession> GetSessionFromIdentifier(string identifier)
        {
            UserSession ret = null;

            var db = DatabaseAccessService.OpenOrCreateDefault();

            // Get logged requests collection
            var loggedRequests = db.GetCollection<UserSession>(DatabaseAccessService.LoggedRequestDataKey);
            // Log by descending timestamp

            ret = loggedRequests.FindOne(x => x.SessionId == identifier);

            return ret;
        }

        public static async Task SaveSession(UserSession session)
        {
            var db = DatabaseAccessService.OpenOrCreateDefault();
            // Get logged requests collection
            var loggedRequests = db.GetCollection<UserSession>(DatabaseAccessService.LoggedRequestDataKey);
            // Use ACID transaction
            using (var trans = db.BeginTrans())
            {
                // Insert new session into database
                loggedRequests.Insert(session);

                trans.Commit();
            }
            // Index requests by identifier
            loggedRequests.EnsureIndex(x => x.SessionId);
        }
    }
}