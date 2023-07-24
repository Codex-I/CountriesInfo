using System.Transactions;

namespace CountriesInfo.Country_Data
{
    public class Country
    {
        /// <summary>
        /// Country name
        /// </summary>
        public CountryName Name { get; set; }

        /// <summary>
        /// Top Level Domain of the country.
        /// </summary>
        public string[]? Tld { get; set; }


        /// <summary>
        /// Currencies used in the country.
        /// The dictionary is the currency code, the value is a Currency
        /// object: {name: string, symbol: string}.
        /// </summary>
        public Dictionary<string, Currency>? Currencies { get; set; }

       
        /// <summary>
        /// Capital(s) of the country.
        /// </summary>
        public string[] Capital { get; set; }

       

        /// <summary>
        /// Region of the country (eg. Africa, Americas, Asia, Europe, Oceania, Antarctic).
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The subregion of the country(eg. Western Africa, Western Europe, ...)
        /// <remarks>Can be null.</remarks>
        /// </summary>
        public string? Subregion { get; set; }

        /// <summary>
        /// Languages spoken in the country.
        /// The key of the dictionary is the language code, the value is a
        /// the language name in english.
        /// </summary>
        public Dictionary<string, string>? Languages { get; set; }

        
        /// <summary>
        /// Neighboring countries.
        /// </summary>
        public string[] Borders { get; set; }

        /// <summary>
        /// Flag(Url) of the country in png and svg format.
        /// </summary>
        public CountryFlag Flag { get; set; }

        

        /// <summary>
        /// Capital details. (eg. latitude, longitude, ...)
        /// </summary>
       // public CapitalInformation CapitalInformation { get; set; }

        
    }
}
