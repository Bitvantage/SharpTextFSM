﻿/*
   Bitvantage.SharpTextFsm
   Copyright (C) 2024 Michael Crino
   
   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU Affero General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.
   
   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU Affero General Public License for more details.
   
   You should have received a copy of the GNU Affero General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using Bitvantage.SharpTextFsm;
using Bitvantage.SharpTextFsm.Attributes;

namespace Test.Generic.Mappings
{
    [Template(MappingStrategy.SnakeCase)]
    internal class MappingStrategySnakeCase : ITemplate
    {
        public long ValueProperty { get; set; }
        public long ValueField { get; set; }

        string ITemplate.TextFsmTemplate =>
            """
            Value Value_Property (\d+)
            Value Value_Field (\d+)

            Start
             ^P${Value_Property}
             ^F${Value_Field}
            """;

        [Test]
        public void Test()
        {
            var template = Template.FromType<MappingStrategySnakeCase>();
            var data = """
                P100
                F200
                """;

            var results = template.Parse<MappingStrategySnakeCase>(data).ToList();

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results[0].ValueProperty, Is.EqualTo(100));
            Assert.That(results[0].ValueField, Is.EqualTo(200));
        }
    }


}
