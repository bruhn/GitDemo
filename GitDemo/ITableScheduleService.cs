using System;

namespace GitDemo
{
    public interface ITableScheduleService
    {
        bool CheckAvailability(int numberOfPersons, DateTime startTime);
        void ExecuteBooking(int numberOfPersons, DateTime startTime);
    }
}