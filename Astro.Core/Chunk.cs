using System;
using System.Collections.Generic;
using System.Text;

namespace Astro.Core
{
    public class Chunk : List<byte>
    {
        public void Add(string value)
        {
            AddRange(BitConverter.GetBytes(value.Length));
            AddRange(Encoding.ASCII.GetBytes(value));
        }
        public void Add(int value) => AddRange(BitConverter.GetBytes(value));
        public void Add(float value) => AddRange(BitConverter.GetBytes(value));
    }
}