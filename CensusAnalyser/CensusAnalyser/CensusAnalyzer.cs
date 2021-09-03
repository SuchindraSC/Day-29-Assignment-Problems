using System;
using System.Collections.Generic;
using System.Text;
using CensusAnalyser.DTO;

namespace CensusAnalyser
{
    public class CensusAnalyzer
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, Country country, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(csvFilePath, country, dataHeaders);
            return dataMap;
        }
    }
}
