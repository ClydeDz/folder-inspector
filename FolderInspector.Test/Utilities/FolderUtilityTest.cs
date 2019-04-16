using FolderInspector.Utilities;
using Moq;
using Xunit;

namespace FolderInspector.Test.Utilities
{
    public class FolderUtilityTest
    {
        [Fact]
        public void GetHeaderText_DefaultNoPath_Test()
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.CustomHeaderText).Returns("");
            appSettingsMock.Setup(_ => _.UseCustomHeaderText).Returns(false);
            appSettingsMock.Setup(_ => _.DefaultHeaderText).Returns("header text");
            appSettingsMock.Setup(_ => _.AppendFilePathToHeaderText).Returns(false);
            
            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var headerText = folderUtility.GetHeaderText("c:\\folder");

            Assert.Equal("header text", headerText);
        }

        [Fact]
        public void GetHeaderText_DefaultWithPath_Test()
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.CustomHeaderText).Returns("");
            appSettingsMock.Setup(_ => _.UseCustomHeaderText).Returns(false);
            appSettingsMock.Setup(_ => _.DefaultHeaderText).Returns("header text");
            appSettingsMock.Setup(_ => _.AppendFilePathToHeaderText).Returns(true);

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var headerText = folderUtility.GetHeaderText("c:\\folder");

            Assert.Equal("header text c:\\folder", headerText);
        } 

        [Fact]
        public void GetHeaderText_CustomNoPath_Test()
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.CustomHeaderText).Returns("custom header text");
            appSettingsMock.Setup(_ => _.UseCustomHeaderText).Returns(true);
            appSettingsMock.Setup(_ => _.DefaultHeaderText).Returns("header text");
            appSettingsMock.Setup(_ => _.AppendFilePathToHeaderText).Returns(false);

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var headerText = folderUtility.GetHeaderText("c:\\folder");

            Assert.Equal("custom header text", headerText);
        }

        [Fact]
        public void GetHeaderText_CustomWithPath_Test()
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.CustomHeaderText).Returns("custom header text");
            appSettingsMock.Setup(_ => _.UseCustomHeaderText).Returns(true);
            appSettingsMock.Setup(_ => _.DefaultHeaderText).Returns("header text");
            appSettingsMock.Setup(_ => _.AppendFilePathToHeaderText).Returns(true);

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var headerText = folderUtility.GetHeaderText("c:\\folder");

            Assert.Equal("custom header text c:\\folder", headerText);
        }

        [Theory] 
        [InlineData("", true, "header text c:\\folder")]
        [InlineData(null, true, "header text c:\\folder")]
        [InlineData("", false, "header text")]
        [InlineData(null, false, "header text")]
        public void GetHeaderText_CustomWithNullEmptyPath_Test(string customHeaderText, bool appendPath, string expected)
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.CustomHeaderText).Returns(customHeaderText);
            appSettingsMock.Setup(_ => _.UseCustomHeaderText).Returns(true);
            appSettingsMock.Setup(_ => _.DefaultHeaderText).Returns("header text");
            appSettingsMock.Setup(_ => _.AppendFilePathToHeaderText).Returns(appendPath);

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var headerText = folderUtility.GetHeaderText("c:\\folder");

            Assert.Equal(expected, headerText);
        }

        [Fact]
        public void GetFooterText_DefaultNoPath_Test()
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.CustomFooterText).Returns("");
            appSettingsMock.Setup(_ => _.UseCustomFooterText).Returns(false);
            appSettingsMock.Setup(_ => _.DefaultFooterText).Returns("footer text");
            appSettingsMock.Setup(_ => _.AppendFilePathToFooterText).Returns(false);

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var headerText = folderUtility.GetFooterText("c:\\folder");

            Assert.Equal("footer text", headerText);
        }

        [Fact]
        public void GetFooterText_DefaultWithPath_Test()
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.CustomFooterText).Returns("");
            appSettingsMock.Setup(_ => _.UseCustomFooterText).Returns(false);
            appSettingsMock.Setup(_ => _.DefaultFooterText).Returns("footer text");
            appSettingsMock.Setup(_ => _.AppendFilePathToFooterText).Returns(true);

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var headerText = folderUtility.GetFooterText("c:\\folder");

            Assert.Equal("footer text c:\\folder", headerText);
        }

        [Fact]
        public void GetFooterText_CustomNoPath_Test()
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.CustomFooterText).Returns("custom footer text");
            appSettingsMock.Setup(_ => _.UseCustomFooterText).Returns(true);
            appSettingsMock.Setup(_ => _.DefaultFooterText).Returns("footer text");
            appSettingsMock.Setup(_ => _.AppendFilePathToFooterText).Returns(false);

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var headerText = folderUtility.GetFooterText("c:\\folder");

            Assert.Equal("custom footer text", headerText);
        }

        [Fact]
        public void GetFooterText_CustomWithPath_Test()
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.CustomFooterText).Returns("custom footer text");
            appSettingsMock.Setup(_ => _.UseCustomFooterText).Returns(true);
            appSettingsMock.Setup(_ => _.DefaultFooterText).Returns("footer text");
            appSettingsMock.Setup(_ => _.AppendFilePathToFooterText).Returns(true);

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var headerText = folderUtility.GetFooterText("c:\\folder");

            Assert.Equal("custom footer text c:\\folder", headerText);
        }

        [Theory]
        [InlineData("", true, "footer text c:\\folder")]
        [InlineData(null, true, "footer text c:\\folder")]
        [InlineData("", false, "footer text")]
        [InlineData(null, false, "footer text")]
        public void GetFooterText_NullEmptyCustomWithOrWithoutPath_Test(string customFooterText, bool appendPath, string expected)
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.CustomFooterText).Returns(customFooterText);
            appSettingsMock.Setup(_ => _.UseCustomFooterText).Returns(true);
            appSettingsMock.Setup(_ => _.DefaultFooterText).Returns("footer text");
            appSettingsMock.Setup(_ => _.AppendFilePathToFooterText).Returns(appendPath);

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var headerText = folderUtility.GetFooterText("c:\\folder");

            Assert.Equal(expected, headerText);
        }

        [Theory]
        [InlineData("c:\\folder\\sample.docx")] 
        [InlineData("c:\\folder\\another-folder\\sample.docx")]
        public void IsWordFile_ReturnsTrue_Test(string filePath)
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.WordDocumentExtension).Returns("docx");

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var isWordFile = folderUtility.IsWordFile(filePath);

            Assert.True(isWordFile);
        }

        [Theory]
        [InlineData("c:\\folder\\sample.doc")]
        [InlineData("c:\\folder\\another-folder\\")]
        [InlineData("c:\\folder\\another-folder")]
        public void IsWordFile_ReturnsFalse_Test(string filePath)
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.WordDocumentExtension).Returns("docx");

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var isWordFile = folderUtility.IsWordFile(filePath);

            Assert.False(isWordFile);
        }

        [Theory]
        [InlineData("c:\\folder\\sample.xlsx")]
        [InlineData("c:\\folder\\another-folder\\sample.xlsx")]
        public void IsExcelFile_ReturnsTrue_Test(string filePath)
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.ExcelDocumentExtension).Returns("xlsx");

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var isExcelFile = folderUtility.IsExcelFile(filePath);

            Assert.True(isExcelFile);
        }

        [Theory]
        [InlineData("c:\\folder\\sample.xls")]
        [InlineData("c:\\folder\\another-folder\\")]
        [InlineData("c:\\folder\\another-folder")]
        public void IsExcelFile_ReturnsFalse_Test(string filePath)
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();
            appSettingsMock.Setup(_ => _.ExcelDocumentExtension).Returns("xlsx");

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var isExcelFile = folderUtility.IsExcelFile(filePath);

            Assert.False(isExcelFile);
        }


        [Theory]
        [InlineData("c:\\folder\\sample.docx", "sample.docx")]
        [InlineData("c:\\folder\\sample.doc", "sample.doc")]
        [InlineData("c:\\folder\\another-folder\\test.docx", "test.docx")]
        [InlineData("c:\\folder\\sample.xls", "sample.xls")]
        [InlineData("c:\\folder\\test.xlsx", "test.xlsx")]
        [InlineData("c:\\test.docx", "test.docx")]
        [InlineData("test.docx", "test.docx")]
        public void GetFileName_ReturnsTrue_Test(string filePath, string expected)
        {
            var consoleLogUtilityMock = new Mock<ILogUtility>();
            var appSettingsMock = new Mock<IAppSettingsUtility>();

            var folderUtility = new FolderUtility(appSettingsMock.Object, consoleLogUtilityMock.Object);
            var fileName = folderUtility.GetFileName(filePath);

            Assert.Equal(expected, fileName);
        }
    }
}
