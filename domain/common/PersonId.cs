using System;
using System.Collections.Generic;
using System.IO;

namespace domain.common;
public class PersonId
{
    public List<string> Value { get; }
    public PersonId(List<string> value)
    {
        if (value.Count == 2)
        {
            Value = value;
        }
        else
        {
            throw new InvalidDataException();
        }
    }
}