namespace Levi9_5DaysInCloud.Enum
{
    public enum Position
    {
        PG,
        SG,
        SF,
        PF,
        C
    }

    public static class PositionExtensions
    {
        public static Position GetPosition(this string postion)
        {
            return postion switch
            {

                "PG" => Position.PG,
                "SG" => Position.SG,
                "SF" => Position.SF,
                "PF" => Position.PF,
                "C" => Position.C,
                _ => throw new ArgumentOutOfRangeException("Position not allowed")
            };
        }

    }

}
