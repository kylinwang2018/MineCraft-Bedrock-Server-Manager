using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineCraft_Bedrock_Server_Manager.ServerControlHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineCraft_Bedrock_Server_Manager.ServerControlHelpers.Tests
{
    [TestClass()]
    public class HttpAnalyserTests
    {
        [TestMethod()]
        public void GetDownloadUrlTest_ValidUrl_ShouldReturnValidDownloadUrl()
        {
            var url = "https://www.minecraft.net/en-us/download/server/bedrock";
            var analyser = HttpAnalyser.GetDownloadUrl(url).Result;

            Assert.IsTrue(analyser.Contains("https"));
            Assert.IsTrue(analyser.Contains("zip"));
            Assert.IsTrue(analyser.Contains("linux"));
        }

        [TestMethod()]
        public void GetDownloadUrlTest_InvalidUrl_ShouldReturnNull()
        {
            var url = "https://www.minecraft.net/";
            var analyser = HttpAnalyser.GetDownloadUrl(url).Result;

            Assert.IsNull(analyser);
        }

        [TestMethod()]
        public void GetDownloadUrlTest_EmptyUrl_ShouldReturnNull()
        {
            var url = "";
            var analyser = HttpAnalyser.GetDownloadUrl(url).Result;

            Assert.IsNull(analyser);
        }

        [TestMethod()]
        public void GetLatestVersionNum_ValidUrl_ShouldReturnVersionNumber()
        {
            var url = "https://minecraft.azureedge.net/bin-linux/bedrock-server-1.16.40.02.zip";
            var analyser = HttpAnalyser.GetLatestVersionNum(url);

            Assert.IsTrue(analyser.Contains("."));
            Assert.IsTrue(analyser.LastIndexOf(".") < analyser.Length - 1);
        }

        [TestMethod()]
        public void GetLatestVersionNum_InValidUrl_ShouldReturnNull()
        {
            var url = "https://www.minecraft.net/en-us/sssss";
            var analyser = HttpAnalyser.GetLatestVersionNum(url);

            Assert.IsNull(analyser);
        }
    }
}