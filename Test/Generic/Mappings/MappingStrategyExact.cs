﻿/*
   SharpTextFSM
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

using Bitvantage.SharpTextFSM;
using Bitvantage.SharpTextFSM.Attributes;

namespace Test.Generic.Mappings
{
    [TemplateRecord(MappingStrategy.Exact)]
    internal class MappingStrategyExact : ITemplate
    {
        public long ValueProperty { get; set; }
        public long ValueField { get; set; }

        string ITemplate.TextFsmTemplate =>
            """
            Value ValueProperty (\d+)
            Value ValueField (\d+)

            Start
             ^P${ValueProperty}
             ^F${ValueField}
            """;

        [Test]
        public void Test()
        {
            var template = Template.FromType<MappingStrategyExact>();
            var data = """
                P100
                F200
                """;

            var results = template.Parse<MappingStrategyExact>(data).ToList();

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results[0].ValueProperty, Is.EqualTo(100));
            Assert.That(results[0].ValueField, Is.EqualTo(200));
        }
    }


}
