using NUnit.Framework;
using CensusAnalyser;
using System.Collections.Generic;
using static CensusAnalyser.CensusAnalyzer;
using CensusAnalyser.DTO;

namespace USCensusAdapter
{
    public class Tests
    {
        static string USCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string USCensusFilePath = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\USCensusAdapter\CSVFiles\USCensusFile.csv";
        static string WrongDataFilePath = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\USCensusAdapter\CSVFiles\CSVFiles\USDataFile.csv";
        static string USCensusWrongFileType = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\USCensusAdapter\CSVFiles\USCodeFile.txt";
        static string USCensusWrongFileHeader = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\USCensusAdapter\CSVFiles\USCensusWrongHeader.csv";
        static string USCesusFilePathWithWrongDelimeter = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\USCensusAdapter\CSVFiles\USCensusWrongDelimiter.csv";


        static string USCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string USCodeFilePath = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\USCensusAdapter\CSVFiles\USCodeFile.csv";
        static string WrongUSCodeFilePath = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\USCensusAdapter\CSVFiles\USCodeData.csv";
        static string WrongUSCodeFileTypePath = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianStateCode.txt";
        static string USCodeFileWrongDelimeter = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\USCensusAdapter\CSVFiles\USCodeWrongDelimiter.csv";
        static string USCodeFilePathWrongHeader = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\USCensusAdapter\CSVFiles\USCodeWrongHeader.csv";

        CensusAnalyzer censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyzer();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenUSCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(USCensusFilePath, Country.US, USCensusHeaders);
            Assert.AreEqual(29, totalRecords.Count);
        }
        [Test]
        public void GivenWrongUSCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongDataFilePath, Country.US, USCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);

        }
        [Test]
        public void GivenWrongUSCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(USCensusWrongFileType, Country.US, USCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]
        public void GivenUSCensusDataFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(USCensusWrongFileHeader, Country.INDIA, USCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        [Test]
        public void GivenUSCensusDataFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(USCesusFilePathWithWrongDelimeter, Country.US, USCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]
        public void GivenUSStateCodeFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateRecords = censusAnalyser.LoadCensusData(USCodeFilePath, Country.US, USCodeHeaders);
            Assert.AreEqual(37, stateRecords.Count);
        }
        [Test]
        public void GivenWrongUSCodeFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongUSCodeFilePath, Country.US, USCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongUSCodeFileType_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongUSCodeFileTypePath, Country.US, USCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        [Test]
        public void GivenUSCodeFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(USCodeFileWrongDelimeter, Country.US, USCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        [Test]
        public void GivenUSCodeFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(USCodeFilePathWrongHeader, Country.US, USCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}