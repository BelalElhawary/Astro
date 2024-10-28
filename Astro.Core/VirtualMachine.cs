using System;

namespace Astro.Core
{
    public class VirtualMachine
    {
        public const byte AReg = 0;
        public const byte BReg = 1;
        public const byte CReg = 2;
        
        private readonly object[] _registers = new object[32];
        private byte[] _program = Array.Empty<byte>();
        private object[] _data = Array.Empty<object>();
        private int _index;
        
        private byte ReadByte => _program[_index++];

        private int ReadInt
        {
            get
            {
                var result = BitConverter.ToInt32(_program, _index);
                _index += sizeof(int);
                return result;
            }
        }

        public void Initialize(byte[] program, object[] data)
        {
            _program = program;
            _data = data;
            _index = 0;
        }

        public int Interpret()
        {
            return Run();
        }
        
        public int Run()
        {
            while (true)
            {
                switch (ReadByte)
                {
                    case Instructions.Mov:
                    {
                        _registers[ReadByte] = _data[ReadInt];
                        break;
                    }
                    case Instructions.Cop:
                    {
                        _registers[ReadByte] = _registers[ReadByte];
                        break;
                    }
                    case Instructions.Add:
                    {
                        _registers[CReg] = Convert.ToDouble(_registers[AReg]) + Convert.ToDouble(_registers[BReg]);
                        break;
                    }
                    case Instructions.Sub:
                    {
                        _registers[CReg] = Convert.ToDouble(_registers[AReg]) - Convert.ToDouble(_registers[BReg]);
                        break;
                    }
                    case Instructions.Mul:
                    {
                        _registers[CReg] = Convert.ToDouble(_registers[AReg]) * Convert.ToDouble(_registers[BReg]);
                        break;
                    }
                    case Instructions.Div:
                    {
                        _registers[CReg] = Convert.ToDouble(_registers[AReg]) / Convert.ToDouble(_registers[BReg]);
                        break;
                    }
                    case Instructions.Print:
                    {
                        Console.Write(_registers[AReg]);
                        break;
                    }
                    case Instructions.Ret:
                        return ReadByte;
                }
            }
        }
    }
}