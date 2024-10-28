using System;
using System.Collections.Generic;

namespace Astro.Core
{
    public class ProgramWriter
    {
        private List<byte> _program = new List<byte>();
        private List<object> _data = new List<object>();

        public int Constant(object data)
        {
            _data.Add(data);
            return _data.Count - 1;
        }

        public void Add()
        {
            _program.Add(Instructions.Add);
        }
        
        public void Move(int data, byte register)
        {
            _program.Add(Instructions.Mov);
            _program.Add(register);
            _program.AddRange(BitConverter.GetBytes(data));
        }
        
        public void Copy(byte fromRegister, byte toRegister)
        {
            _program.Add(Instructions.Cop);
            _program.Add(toRegister);
            _program.Add(fromRegister);
        }
        
        public void Print()
        {
            _program.Add(Instructions.Print);
        }

        public void Return(byte value = 0)
        {
            _program.Add(Instructions.Ret);
            _program.Add(value);
        }

        public void Write(VirtualMachine vm)
        {
            vm.Initialize(_program.ToArray(), _data.ToArray());
        }
    }
}