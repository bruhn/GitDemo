using System;

namespace GitDemo
{
    public class Reservation
    {
        public bool Success { get; set; }
        public int NumberOfPersons { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; } 
    }
}