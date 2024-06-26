﻿using UnityEngine;

namespace Utils
{
    public class KeyValueAttribute : PropertyAttribute
    {
        public readonly string PropertyName;

        public KeyValueAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}