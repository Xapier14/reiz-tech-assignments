// Given an analog clock, give the lesser angle between its hands in degrees.

Console.Write("Input Hours: ");
var hours = Convert.ToInt32(Console.ReadLine());
Console.Write("Input Minutes: ");
var minutes = Convert.ToInt32(Console.ReadLine());

const double hourAngle = 360.0 / 12.0; // angle per section of clock

// sanitize inputs and keep within valid input range while offseting hour by 1
hours = Math.Max(1, hours) % 12;
minutes = Math.Max(0, Math.Min(59, minutes));

// get initial angle by multiplying 1 clock-hour angleunit by zero-based hour
var shortHandAngle = hours * hourAngle;
// apply finer offset based on minute/longHand-clock ratio
shortHandAngle += minutes * hourAngle / 60.0;

var longHandAngle = minutes * 360.0 / 60.0;

var lesserAngle = CalculateLesserDifference(shortHandAngle, longHandAngle);
Console.WriteLine("Angle difference: {0}", lesserAngle);

static double CalculateLesserDifference(double angle1, double angle2)
{
    // swap if angle2 is greater or equal
    if (angle1 > angle2)
        (angle1, angle2) = (angle2, angle1);
    // get absolute difference
    var difference = Math.Abs(angle1 - angle2);
    // if angle is greater angle, get lesser by subtracting with 360 deg.
    if (difference > 180)
        difference = 360.0 - difference;
    return difference;
}