using Dapper;
using EvaluacionTecnica.Repository.Constants;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EvaluacionTecnica.Repository.Cities
{
    public class CitiesRepository
    {
        private readonly string conn;

        public CitiesRepository() { }
        public CitiesRepository(IConfiguration config) {
            conn = config.GetConnectionString("MVFactory");
        }

        public int Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@cityId", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                db.Query(StoredProcedures.SP_DELETE_CITY, param: parameters, commandType: CommandType.StoredProcedure);

                return Id;
            }
        }

        public List<CityDto> GetAll()
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                return db.Query<CityDto>(StoredProcedures.SP_CITIES_GET_ALL, commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public CityDto GetById(int Id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@cityId", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                return db.QueryFirstOrDefault<CityDto>(StoredProcedures.SP_GET_CITY_BY_ID, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Save(CityDto city)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@cityName", city.CityName, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add("@countryId", city.CountryID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add("@cityId", city.CityID, dbType: DbType.Int32, direction: ParameterDirection.Output);

                db.Query(StoredProcedures.SP_INSERT_CITY, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("@cityId");
            }
        }

        public CityDto Update(CityDto city)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@cityName", city.CityName, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add("@countryId", city.CountryID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add("@cityId", city.CityID, dbType: DbType.Int32, direction: ParameterDirection.Input);

                return db.QueryFirstOrDefault<CityDto>(StoredProcedures.SP_UPDATE_CITY, param: parameters, commandType: CommandType.StoredProcedure);


            }
        }

    }
}
