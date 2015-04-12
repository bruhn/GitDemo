using System;

namespace GitDemo
{
    public class RestaurantReservationService
    {
        private readonly ITableScheduleService _tableScheduleService;

        public RestaurantReservationService(ITableScheduleService tableScheduleService)
        {
            _tableScheduleService = tableScheduleService;
        }

        public Reservation CreateReservation(int numberOfPersons, DateTime startTime)
        {
            var isAvailable = _tableScheduleService.CheckAvailability(numberOfPersons, startTime);

            if (isAvailable)
            {
                return new Reservation { Success = true }; 
            }
            return new Reservation { Success = false };
        }
    }
}
