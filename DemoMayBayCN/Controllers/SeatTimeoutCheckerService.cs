using DemoMayBayCN.Common;

namespace DemoMayBayCN.Controllers
{
    public class SeatTimeoutCheckerService:BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                SeatReservationService.CheckSeatTimeouts();
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
