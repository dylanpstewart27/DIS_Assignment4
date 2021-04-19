using DIS_Assignment4.DataAcess;
using DIS_Assignment4.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Assignment4
{
    public class Manager
    {
        private CrimesDatabase crimesDatabase;

        public Manager(CrimesDatabase crimesDatabase)
        {
            this.crimesDatabase = crimesDatabase;
        }

        public async Task<List<CrimeData>> GetCrimeByRaceId(int raceId)
        {
            var ret = new List<CrimeData>();

            var cmd = this.crimesDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.Parameters.AddWithValue("@RaceId", raceId);
            cmd.CommandText = @" SELECT Total, Year, Month, Race, c.RaceId  FROM CRIMES c JOIN Races r WHERE c.RaceId = r.RaceId AND r.RaceId = @RaceId";

            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var crimeData = new CrimeData()
                    {
                        Total = reader.GetInt32(0),
                        Year = reader.GetInt32(1),
                        Month = reader.GetInt32(2),
                        Race = reader.GetString(3),
                        Key = reader.GetInt32(4)
                    };
                    ret.Add(crimeData);
                }
            return ret;
        }

        public async Task<Key> GetRaceById(int raceId)
        {
            var ret = new List<CrimeData>();

            var cmd = this.crimesDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.Parameters.AddWithValue("@RaceId", raceId);
            cmd.CommandText = @" SELECT *  FROM Races r WHERE r.RaceId = @RaceId";

            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var key = new Key()
                    {
                        race = reader.GetString(1)
                    };
                    return key;
                }
            return null;
        }

        public async Task<List<Key>> GetRaces()
        {
            var ret = new List<Key>();

            var cmd = this.crimesDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @" SELECT * FROM Races";

            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var key = new Key()
                    {
                        ID = reader.GetInt32(0),
                        race = reader.GetString(1)
                    };
                    ret.Add(key);
                }
            return ret;
        }

        public Task UpdateByRaceId(int raceId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRaceById(int raceId)
        {
            throw new NotImplementedException();
        }

    }
}
