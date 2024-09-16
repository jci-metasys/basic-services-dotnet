using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace JohnsonControls.Metasys.BasicServices;

public class MetasysObjectTests
{


    [Test]
    public void Test()
    {
        // Arrange
        var objectTree = JsonConvert.DeserializeObject<JToken>(ObjectTreeThreeLevels);

        // Act
        var metasysObject = new MetasysObject(objectTree, ApiVersion.v4);

        // Assertions
        Assert.That(metasysObject.ChildrenCount == 2);
        Assert.That(metasysObject.Children.First().ChildrenCount == 3);
    }



    private const string ObjectTreeThreeLevels = @"
        {
            ""itemReference"": ""R12AdsDaily:R12AdsDaily/Graphics"",
            ""name"": ""Graphics"",
            ""id"": ""76609398-fa4b-51e0-bfa3-eab94d289241"",
            ""objectType"": ""objectTypeEnumSet.containerClass"",
            ""classification"": ""folder"",
            ""items"": [
                {
                    ""itemReference"": ""R12AdsDaily:R12AdsDaily/Graphics.Common"",
                    ""name"": ""Common"",
                    ""id"": ""55bd3987-6e6a-567d-8894-59684d2358d9"",
                    ""objectType"": ""objectTypeEnumSet.containerClass"",
                    ""classification"": ""folder"",
                    ""items"": [
                        {
                            ""itemReference"": ""R12AdsDaily:R12AdsDaily/Graphics.Common.Lighting"",
                            ""name"": ""Lighting"",
                            ""id"": ""ccaf1ca6-4ad5-5d07-a177-c38f68ae8235"",
                            ""objectType"": ""objectTypeEnumSet.xamlGraphicClass"",
                            ""classification"": """",
                            ""items"": []
                        },
                        {
                            ""itemReference"": ""R12AdsDaily:R12AdsDaily/Graphics.Common.Lighting_Alt"",
                            ""name"": ""Lighting_Alt"",
                            ""id"": ""f80ba7bb-6f9e-571f-a8c1-e1162ff20870"",
                            ""objectType"": ""objectTypeEnumSet.xamlGraphicClass"",
                            ""classification"": """",
                            ""items"": []
                        },
                        {
                            ""itemReference"": ""R12AdsDaily:R12AdsDaily/Graphics.Common.Weather Data"",
                            ""name"": ""Weather Data"",
                            ""id"": ""a7a4bd74-a4c4-53cb-b316-2c14f627e8bc"",
                            ""objectType"": ""objectTypeEnumSet.xamlGraphicClass"",
                            ""classification"": """",
                            ""items"": []
                        }
                    ]
                },
                {
                    ""itemReference"": ""R12AdsDaily:R12AdsDaily/Graphics.Hospital"",
                    ""name"": ""Hospital"",
                    ""id"": ""dca754ae-811e-5e7a-896c-f9fee7446b82"",
                    ""objectType"": ""objectTypeEnumSet.containerClass"",
                    ""classification"": ""folder"",
                    ""items"": [
                        {
                            ""itemReference"": ""R12AdsDaily:R12AdsDaily/Graphics.Hospital.AHU-2"",
                            ""name"": ""AHU-2"",
                            ""id"": ""22a56b58-f5b6-55fb-9828-c7f0ce96ae2e"",
                            ""objectType"": ""objectTypeEnumSet.xamlGraphicClass"",
                            ""classification"": """",
                            ""items"": []
                        },
                        {
                            ""itemReference"": ""R12AdsDaily:R12AdsDaily/Graphics.Hospital.2ND_FLR"",
                            ""name"": ""2ND_FLR"",
                            ""id"": ""61839195-b443-56d4-a768-5bc7c0e61416"",
                            ""objectType"": ""objectTypeEnumSet.xamlGraphicClass"",
                            ""classification"": """",
                            ""items"": []
                        }
                    ]
                }
            ]
        }";

}
