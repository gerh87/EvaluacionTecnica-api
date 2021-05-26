using Dapper;
using EvaluacionTecnica.Repository.Constants;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EvaluacionTecnica.Repository.Historical
{
    public class HistoricalRepository
    {
        private readonly string conn;
        public HistoricalRepository() { }

        public HistoricalRepository(IConfiguration config)
        {
            conn = config.GetConnectionString("MVFactory");
        }

        public int Save(HistoricalDto historical)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@cityId", historical.CityID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add("@temp", historical.Temperature, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                parameters.Add("@thermalSensation", historical.ThermalSensation, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                parameters.Add("@historicalId", historical.CityID, dbType: DbType.Int32, direction: ParameterDirection.Output);

                db.Query(StoredProcedures.SP_INSERT_HISTORICAL, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("@historicalId");
            }
        }

        public List<HistoricalInfo> GetHistoricalByCity(int cityId)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@cityId", cityId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                return db.Query<HistoricalInfo>(StoredProcedures.SP_GET_HISTORICAL_BY_CITY, param: parameters, commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}
