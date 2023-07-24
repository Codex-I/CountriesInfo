using CountriesInfo.Country_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Xml.Linq;
using RESTCountries.NET.Services;
using RESTCountries.NET.Models;
using System.Diagnostics.Metrics;
using System.Collections;

namespace CountriesInfo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        public RESTCountries.NET.Models.Country? Country { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LanguageSelect { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public List<Country>? Countries { get; set; }

        // public string RequestUri { get; set; }

        //public List<CountryResponse>? DeserialCountry { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
           try
           {
                if(SearchName != null)
                {
                    try
                    {
                        // Search by country full name
                        Country = RestCountriesService.GetCountryByFullName(SearchName);
                        Console.WriteLine($"Country Name: {Country.Name.Common}");

                        string GetLanguage(Country country, string code)
                        {
                            //check if the language code exist
                            if (country.Languages.ContainsKey(code))
                            {
                                Console.WriteLine($"Country Name: {country.Languages["eng"]}");
                                // Return the language name
                                return country.Languages[code];
                               
                            }

                            // Language not found
                            return ("Language not found");
                        }
                        string languageName = GetLanguage(Country, "eng");
                    }
                    catch (Exception ex)
                    {

                        ModelState.AddModelError("ex", "An Error occured.");
                    }

                }
                else
                {
                    try
                    {
                        // Search by country name containing "a" or "A"
                        Countries = RestCountriesService.GetCountriesByNameContains("a");
                        foreach (var country in Countries)
                        {
                            Console.WriteLine($"Country Name: {country.Name.Common}");
                        }
                        string GetLanguage(IEnumerable<Country> countries, string code)
                        {
                            foreach (var country in countries)
                            {
                                //check if the language code exist
                                if (country.Languages.ContainsKey(code))
                                {
                                    Console.WriteLine($"Country Name: {country.Languages["eng"]}");
                                    // Return the language name
                                    return country.Languages[code];
                                   
                                }
                                //else
                                //{
                                //    // Language not found
                                //    return ("Language not found");
                                //}

                               
                            }
                            return null;
                        }

                       LanguageSelect = GetLanguage(Countries, "eng");

                    }
                    catch (Exception ex)
                    {

                        ModelState.AddModelError("ex", "An Error occured.");
                    }


                }

                // var client = new HttpClient();
                // var defaultName = "a";
                // //if (string.IsNullOrEmpty(SearchName))
                // //{
                // //     RequestUri = $"https://restcountries.eu/rest/v2/name/{defaultName}";
                // //}
                // //else
                // //{
                // //     RequestUri = $"https://restcountries.eu/rest/v2/name/{SearchName}";
                // //}
                // Console.WriteLine(RequestUri);
                //var getResponse = await client.GetAsync(RequestUri);
                //getResponse.EnsureSuccessStatusCode();
                //var contentResponse = await getResponse.Content.ReadAsStringAsync();
                // var deserialCountry = JsonConvert.DeserializeObject<CountryResponse>(contentResponse);
                // Console.WriteLine(deserialCountry);
                // Countries = deserialCountry?.SearchCountries;
                // foreach (var country in Countries)
                // {
                //     Console.WriteLine(country.Name);
                // }

            }
          catch (Exception ex)
           {
               _logger.LogError(ex, "An error occurred while fetching Country data.");
           }
            return Page();
        }
    }







    public class CountryResponse
    {
        public List<Country>? SearchCountries { get; set; }
    }
}