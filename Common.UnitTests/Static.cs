using System;

namespace Depra.Common.UnitTests
{
    public static class Static
    {
        public static Action Call(Action of) => of;
    }
}