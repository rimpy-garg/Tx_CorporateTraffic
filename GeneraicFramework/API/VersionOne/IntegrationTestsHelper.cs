using System;
using System.Configuration;
using VersionOne.SDK.APIClient;

namespace GenericFramework.API.VersionOne
{
    class IntegrationTestsHelper
    {
		readonly static string TestProjectName = "VL_TX";

        private static Oid _testProjectId;


		public static Oid GetTestProjectOid(bool useOAuthendpoints = false)
        {
                if (_testProjectId == null)
                    CreateTestProject(useOAuthendpoints);

                return _testProjectId;
        }
        
        private static void CreateTestProject(bool useOAuthEndpoints)
        {
            V1Connector connector;
            if (useOAuthEndpoints)
            {
                connector = V1Connector.WithInstanceUrl(ConfigurationManager.AppSettings.Get("V1Url"))
                    .WithUserAgentHeader("VL_TX", "1.0")
                    .WithAccessToken(ConfigurationManager.AppSettings.Get("V1AccessToken"))
                    .UseOAuthEndpoints()
                    .Build();
            }
            else
            {
                connector = V1Connector.WithInstanceUrl(ConfigurationManager.AppSettings.Get("V1Url"))
                    .WithUserAgentHeader("VL_TX", "1.0")
                    .WithAccessToken(ConfigurationManager.AppSettings.Get("V1AccessToken"))
                    .Build();
            }
            var services = new Services(connector);
            var assetType = services.Meta.GetAssetType("Scope");
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            var projectId = services.GetOid("Scope:1535");
			//Scope:1535
			var newAsset = services.New(assetType, projectId);
            newAsset.SetAttributeValue(nameAttribute, TestProjectName);
            services.Save(newAsset);
            _testProjectId = newAsset.Oid.Momentless;
        }
    }
}
