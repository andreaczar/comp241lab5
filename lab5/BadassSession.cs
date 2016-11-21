using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab5 {
    public class BadassSession {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string Key { get; private set; }
        public int CustomerID { get; private set; }

        public BadassSession(int customerId) {
            this.Key = BadassSession.GenerateSessionKey();
            this.CustomerID = customerId;
        }

        public BadassSession(string key) {
            this.Key = key;
            // should probably load session from db or throw 
            // some kind of error if its invalid.
        }

        public static string GenerateSessionKey() {
            Random random = new Random();
            return new string(Enumerable.Repeat(BadassSession.chars, 32)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void Save() {
            // save session in db
        }
    }
}