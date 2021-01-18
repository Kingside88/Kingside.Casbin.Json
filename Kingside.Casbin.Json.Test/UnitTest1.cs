using NetCasbin;
using NUnit.Framework;
using System.IO;

namespace Kingside.Casbin.Json.Test {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        /// <summary>
        ///Model erbt von Policy
        /// Policy hat ein Property: public Dictionary<string, Dictionary<string, Assertion>> Model { get; }
        /*
            public string Key { get; set; }
            public string Value { get; set; }
            public IDictionary<string, int> Tokens { get; set; }
            public IRoleManager RoleManager { get; }
            public List<List<string>> Policy { get; set; }             
         */
        /// </summary>
        [Test]       
        public void SerializeModelToJsonAndBackAgain() {
            // Working Example
            string basePath = @"C:\Users\andre\source\repos\Kingside.Core\Kingside.Core.Tests\Casbin";
            Enforcer workingEnforcer = new Enforcer(Path.Combine(basePath, "model.conf"));
            NetCasbin.Model.Model workingModel = workingEnforcer.GetModel();

            // Working Model wird in Json konvertiert
            string jsonModel = Newtonsoft.Json.JsonConvert.SerializeObject(workingModel);

            // Json wird wieder zu einem Model konvertiert
            NetCasbin.Model.Model model = Newtonsoft.Json.JsonConvert.DeserializeObject<NetCasbin.Model.Model>(jsonModel);
            Enforcer enforcer = new Enforcer(model);

            Assert.NotNull(enforcer);
        }
    }
}