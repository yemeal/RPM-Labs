using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab4.Interfaces
{
    public interface ICopiable<T>
    {
        T ShallowCopy();
        T DeepCopy();
    }
}
