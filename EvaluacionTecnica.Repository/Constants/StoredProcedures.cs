using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluacionTecnica.Repository.Constants
{
    public static class StoredProcedures
    {
        //Country CRUD
        public const string SP_COUNTRIES_GET_ALL = "MVFT_GetAllCountries";
        public const string SP_INSERT_COUNTRY = "MVFT_InsertCountry";
        public const string SP_UPDATE_COUNTRY = "MVFT_UpdateCountry";
        public const string SP_DELETE_COUNTRY = "MVFT_DeleteCountry";
        public const string SP_GET_COUNTRY_BY_ID = "MVFT_GetCountryById";

        //Cities CRUD
        public const string SP_CITIES_GET_ALL = "MVFT_GetAllCities";
        public const string SP_INSERT_CITY = "MVFT_InsertCiy";
        public const string SP_UPDATE_CITY = "MVFT_UpdateCity";
        public const string SP_DELETE_CITY = "MVFT_DeleteCity";
        public const string SP_GET_CITY_BY_ID = "MVFT_GetCityById";
    }
}
