using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Plugins.Sqlite;
using SQLite;

namespace CollectABull.Core.Services.DataStore
{
    public class Repository : IRepository
    {
        private readonly SQLiteConnection _connection;
		private readonly IMvxSqliteConnectionFactory _sqliteConnectionFactory;

        public Repository(IMvxSqliteConnectionFactory sqliteConnectionFactory)
        {
			_sqliteConnectionFactory = sqliteConnectionFactory;
			//_connection = _sqliteConnectionFactory.GetConnection("/data/data/CollectABull.Droid/files/mydb.sqlite");
            //_connection = _sqliteConnectionFactory.GetConnection("/sdcard/Download/collect.sql");//root path of app
            _connection = _sqliteConnectionFactory.GetConnection("collect.sql");//root path of app
			System.Diagnostics.Debug.WriteLine("Full DB Path: " + _connection.DatabasePath) ;
			//_connection = factory.Create("collect.sql");
            _connection.CreateTable<CollectedItem>();
        }

        public List<CollectedItem> All()
        {
            return _connection
                .Table<CollectedItem>()
                .OrderByDescending(x => x.WhenUtc)
                .ToList();
        }

        public CollectedItem Latest
        {
            get
            {
                return _connection
                    .Table<CollectedItem>()
                    .OrderByDescending(x => x.WhenUtc)
                    .FirstOrDefault();
            }
        }

        public void Add(CollectedItem collectedItem)
        {
            _connection.Insert(collectedItem);
        }

        public void Delete(CollectedItem collectedItem)
        {
            _connection.Delete(collectedItem);
        }

        public void Update(CollectedItem collectedItem)
        {
            _connection.Update(collectedItem);
        }

        public CollectedItem Get(int id)
        {
            return _connection.Get<CollectedItem>(id);
        }
    }
}
