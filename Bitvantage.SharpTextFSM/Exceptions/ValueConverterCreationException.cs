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

using System.Runtime.Serialization;

namespace Bitvantage.SharpTextFsm.Exceptions
{
    [Serializable]
    public class ValueConverterCreationException : Exception
    {
        public ValueConverterCreationException(string message) : base(message)
        {
        }

        public ValueConverterCreationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValueConverterCreationException(SerializationInfo info, StreamingContext context)
        {
        }

        public ValueConverterCreationException(Type converterType, Exception innerException) : base($"Failed to create type {converterType.FullName}", innerException)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
