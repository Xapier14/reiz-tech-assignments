// Given an analog clock, give the lesser angle between its hands in degrees.

Console.Write("Input Hours: ");
var hours = Convert.ToInt32(Console.ReadLine());
Console.Write("Input Minutes: ");
var minutes = Convert.ToInt32(Console.ReadLine());

const double hourAngle = 360.0 / 12.0; // angle per hour-section of clock

// sanitize inputs and keep within valid input range
hours = Math.Max(1, hours) % 12;
minutes = Math.Max(0, Math.Min(59, minutes));

// get initial angle by multiplying 1 clock-hour angle-unit by zero-based hour
var shortHandAngle = hours * hourAngle;
// apply finer offset based on minute/longHand-clock ratio
shortHandAngle += minutes * hourAngle / 60.0;

var longHandAngle = minutes * 360.0 / 60.0;

var lesserAngle = CalculateLesserDifference(shortHandAngle, longHandAngle);
Console.WriteLine("Your sanitized input: hour={0}, minute={1}", hours, minutes);
Console.WriteLine("Lesser angle difference: {0}", lesserAngle);

static double CalculateLesserDifference(double angle1, double angle2)
{
    // get absolute difference
    var difference = Math.Abs(angle1 - angle2);
    // if angle is greater angle, get lesser by subtracting with 360 deg.
    if (difference > 180)
        difference = 360.0 - difference;
    return difference;
}