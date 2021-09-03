using NUnit.Framework;
using CensusAnalyser;
using System.Collections.Generic;
using static CensusAnalyser.CensusAnalyzer;
using CensusAnalyser.DTO;

namespace IndianCensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";        
        static string indianStateCensusFilePath = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianStateCensusFile.csv";       
        static string WrongDataFilePath = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianDataFile.csv";
        static string IndianStateCensusWrongFileType = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianCensusFile.txt";
        static string WrongIndianStateCensusFileHeader = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianStateCensusWrongHeader.csv";
        static string IndianStateCesusFilePathWithWrongDelimeter = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianStateCensusWrongDelimiter.csv";


        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodeFilePath = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianStateCodeFile.csv";
        static string WrongIndianStateCodeFilePath = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianStateCodeData.csv";
        static string WrongIndianStateCodeFileTypePath = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianStateCode.txt";
        static string IndianStateCodeFileWrongDelimeter = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianStateCodeWrongDelimiter.csv";
        static string IndianStateCodeFilePathWrongHeader = @"C:\Users\ADVANCED\Desktop\Day 29 Assignments\CensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianStateCodeFileWrongHeader.csv";

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
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecords.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongDataFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);

        }
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensusWrongFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCensusFileHeader, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCesusFilePathWithWrongDelimeter, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateRecords = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecords.Count);
        }
        [Test]
        public void GivenWrongStateCodeFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFileTypePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFileWrongDelimeter, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongHeader, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}