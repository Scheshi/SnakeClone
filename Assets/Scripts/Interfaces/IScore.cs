using System;

namespace Interfaces
{
    public interface IScore
    {
        Action DestroyPoint { get; set; }
        int PointCount { get; }

        void SetPointCount(int count);
    }
}