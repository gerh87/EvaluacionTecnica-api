using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using EvaluacionTecnica.Repository.Constants;

namespace EvaluacionTecnica.Repository.Countries
{
    public class CountriesRepository
    {
        private readonly string conn;
        public CountriesRepository() { }

        public CountriesRepository(IConfiguration config)
        {
            conn = config.GetConnectionString("MVFactory");
        }

        public int Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@countryId", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                db.Query(StoredProcedures.SP_DELETE_COUNTRY, param: parameters, commandType: CommandType.StoredProcedure);

                return Id;
            }
        }

        public List<CountryDto> GetAll()
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                return db.Query<CountryDto>(StoredProcedures.SP_COUNTRIES_GET_ALL, commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public CountryDto GetById(int Id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@countryId", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                return db.QueryFirstOrDefault<CountryDto>(StoredProcedures.SP_GET_COUNTRY_BY_ID, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Save(CountryDto country)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@countryName", country.CountryName, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add("@countryId", country.CountryID, dbType: DbType.Int32, direction: ParameterDirection.Output);

                db.Query(StoredProcedures.SP_INSERT_COUNTRY, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("@countryId");
            }
        }

        public CountryDto Update(CountryDto country)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@countryName", country.CountryName, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add("@countryId", country.CountryID, dbType: DbType.Int32, direction: ParameterDirection.Input);

                return db.QueryFirstOrDefault<CountryDto>(StoredProcedures.SP_UPDATE_COUNTRY, param: parameters, commandType: CommandType.StoredProcedure);


            }
        }
    }
}
