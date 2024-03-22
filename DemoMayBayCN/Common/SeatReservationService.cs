namespace DemoMayBayCN.Common
{
    public class SeatReservationService
    {
        private static readonly object lockObject = new object();
        private static readonly Dictionary<int, List<string>> reservedSeats = new Dictionary<int, List<string>>();
        private static readonly Dictionary<int, DateTime> seatTimeouts = new Dictionary<int, DateTime>();
        private static readonly TimeSpan reservationTimeout = TimeSpan.FromMinutes(2); // Thời gian timeout, ví dụ là 5 phút
        public static bool ReserveSeat(int flightId, List<string> seatNumber)
        {
            lock (lockObject)
            {
                var key = GetSeatKey(flightId, seatNumber);

                if (reservedSeats.ContainsKey(key))
                {
                    // Chỗ ngồi đã được đặt bởi người khác
                    return false;
                }

                reservedSeats.Add(key, seatNumber);
                seatTimeouts[key] = DateTime.UtcNow.Add(reservationTimeout); // Đặt thời điểm timeout

                return true;
            }
        }

        public static void ReleaseSeat(int flightId, List<string> seatNumber)
        {
            lock (lockObject)
            {
                var key = GetSeatKey(flightId, seatNumber);

                if (reservedSeats.ContainsKey(key))
                {
                    reservedSeats.Remove(key);
                    seatTimeouts.Remove(key);
                }
            }
        }

        private static int GetSeatKey(int flightId, List<string> seatNumber)
        {
            // Tạo một khóa duy nhất cho mỗi chỗ ngồi trong một chuyến bay cụ thể
            int seatNumberHashCode = CalculateSeatNumberHashCode(seatNumber);
            return HashCode.Combine(flightId, seatNumberHashCode);
        }
        private static int CalculateSeatNumberHashCode(List<string> seatNumber)
        {
            // Tính toán mã băm cho seatNumber một cách xác định
            unchecked
            {
                int hash = 17;
                foreach (var seat in seatNumber)
                {
                    hash = hash * 23 + seat.GetHashCode();
                }
                return hash;
            }
        }
        public static void CheckSeatTimeouts()
        {
            lock (lockObject)
            {
                var currentTime = DateTime.UtcNow;
                var keysToRemove = seatTimeouts.Where(kvp => currentTime > kvp.Value).Select(kvp => kvp.Key).ToList();

                foreach (var key in keysToRemove)
                {
                    reservedSeats.Remove(key);
                    seatTimeouts.Remove(key);
                }
            }
        }
    }
}
