namespace DemoMayBayCN.ModelsView
{
    public class SeatReturnSelectionRequest
    {
        public int FlightId { get; set; }
        public List<string> SeatNumbers { get; set; }
    }
}
