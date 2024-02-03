using System.Collections.Generic;
using Atomic.Elements;
using Game.Engine;

namespace Functions
{
    public class AndExpression : IAtomicExpression<bool>
    {
        private List<IAtomicValue<bool>> members = new List<IAtomicValue<bool>>();

        public bool Invoke()
        {
            for (int i = 0, count = members.Count; i < count; i++)
            {
                if (!members[i].Value)
                {
                    return false;
                }
            }
            
            return true;
        }

        public void Append(IAtomicValue<bool> member)
        {
            members.Add(member);
        }

        public void Remove(IAtomicValue<bool> member)
        {
            if (members.Contains(member))
            {
                members.Remove(member);
            }
        }
    }
}