#region Licence

/*
 *   Copyright (c) 2010, Jozef Sevcik <sevcik@styxys.com>
 *   All rights reserved.
 *
 *   Redistribution and use in source and binary forms, with or without
 *   modification, are permitted provided that the following conditions are met:
 *   * Redistributions of source code must retain the above copyright
 *     notice, this list of conditions and the following disclaimer.
 *   * Redistributions in binary form must reproduce the above copyright
 *     notice, this list of conditions and the following disclaimer in the
 *     documentation and/or other materials provided with the distribution.
 *   * Neither the name of the <organization> nor the
 *     names of its contributors may be used to endorse or promote products
 *     derived from this software without specific prior written permission.
 *
 *   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 *   ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 *   WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 *   DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
 *   DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 *   (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 *   LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 *   ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 *   (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 *   SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Collections;
using System.Security;
using System.Collections.Generic;
using log4net.Util;
using MongoDB;
using log4net.Core;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using log4net.Appender;
using log4net.Core;
using System.Configuration;
using Log4Mongo;

namespace log4net.Appender
{
    public class MongoDBAppender : AppenderSkeleton
    {
        private readonly List<MongoAppenderFileld> _fields = new List<MongoAppenderFileld>();

        /// <summary>
        /// MongoDB database connection in the format:
        /// mongodb://[username:password@]host1[:port1][,host2[:port2],...[,hostN[:portN]]][/[database][?options]]
        /// See http://www.mongodb.org/display/DOCS/Connections
        /// If no database specified, default to "log4net"
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// The connectionString name to use in the connectionStrings section of your *.config file
        /// If not specified or connectionString name does not exist will use ConnectionString value
        /// </summary>
        public string ConnectionStringName { get; set; }

        /// <summary>
        /// Name of the collection in database
        /// Defaults to "logs"
        /// </summary>
        public string CollectionName { get; set; }

        #region Deprecated

        /// <summary>
        /// Hostname of MongoDB server
        /// Defaults to localhost
        /// </summary>
        [Obsolete("Use ConnectionString")]
        public string Host { get; set; }

        /// <summary>
        /// Port of MongoDB server
        /// Defaults to 27017
        /// </summary>
        [Obsolete("Use ConnectionString")]
        public int Port { get; set; }

        /// <summary>
        /// Name of the database on MongoDB
        /// Defaults to log4net_mongodb
        /// </summary>
        [Obsolete("Use ConnectionString")]
        public string DatabaseName { get; set; }

        /// <summary>
        /// MongoDB database user name
        /// </summary>
        [Obsolete("Use ConnectionString")]
        public string UserName { get; set; }

        /// <summary>
        /// MongoDB database password
        /// </summary>
        [Obsolete("Use ConnectionString")]
        public string Password { get; set; }

        #endregion

        public void AddField(MongoAppenderFileld fileld)
        {
            _fields.Add(fileld);
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            var collection = GetCollection();
            collection.Insert(BuildBsonDocument(loggingEvent));
        }

        protected override void Append(LoggingEvent[] loggingEvents)
        {
            var collection = GetCollection();
            collection.InsertBatch(loggingEvents.Select(BuildBsonDocument));
        }

        private MongoCollection GetCollection()
        {
            var db = GetDatabase();
            MongoCollection collection = db.GetCollection(CollectionName ?? "logs");
            return collection;
        }

        private string GetConnectionString()
        {
            ConnectionStringSettings connectionStringSetting = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            return connectionStringSetting != null ? connectionStringSetting.ConnectionString : ConnectionString;
        }

        private MongoDatabase GetDatabase()
        {
            string connStr = GetConnectionString();

            if (string.IsNullOrEmpty(connStr))
            {
                return BackwardCompatibility.GetDatabase(this);
            }

            MongoUrl url = MongoUrl.Create(connStr);

            // TODO Should be replaced with MongoClient, but this will change default for WriteConcern.
            // See http://blog.mongodb.org/post/36666163412/introducing-mongoclient
            // and http://docs.mongodb.org/manual/release-notes/drivers-write-concern
            MongoServer conn = MongoServer.Create(url);

            MongoDatabase db = conn.GetDatabase(url.DatabaseName ?? "log4net");
            return db;
        }

        private BsonDocument BuildBsonDocument(LoggingEvent log)
        {
            if (_fields.Count == 0)
            {
                return BackwardCompatibility.BuildBsonDocument(log);
            }
            var doc = new BsonDocument();
            foreach (MongoAppenderFileld field in _fields)
            {
                object value = field.Layout.Format(log);
                var bsonValue = value as BsonValue ?? BsonValue.Create(value);
                doc.Add(field.Name, bsonValue);
            }
            return doc;
        }
    }
}