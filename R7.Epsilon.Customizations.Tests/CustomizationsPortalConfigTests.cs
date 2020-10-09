//
//  File: CustomizationsPortalConfigTests.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2014-2019 Roman M. Yagodin, R7.Labs
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using R7.Epsilon.Components;
using Xunit;
using System.IO;
using System.Collections.Generic;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace R7.Epsilon.Tests
{
    public class CustomizationsPortalConfigTests
    {
        [Theory]
        [MemberData(nameof (GetPortalConfigs))]
        public void PortalConfigDeserializationTest (string configFile)
        {
            using (var configReader = new StringReader (File.ReadAllText (configFile))) {
                var deserializer = new DeserializerBuilder ().WithNamingConvention (HyphenatedNamingConvention.Instance).Build ();
                Assert.NotNull (deserializer.Deserialize<EpsilonPortalConfig> (configReader));
            }
        }

        public static IEnumerable<object[]> GetPortalConfigs ()
        {
            var configsPath = Path.Combine ("..", "..", "..", "..", "R7.Epsilon.Customizations", "Website");
            var configFiles = Directory.GetFiles (configsPath, "R7.Epsilon.yml", SearchOption.AllDirectories);
            
            foreach (var configFile in configFiles) {
                yield return new object[] { configFile };
            }
        }
    }
}

