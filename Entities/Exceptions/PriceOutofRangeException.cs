namespace Entities.Exceptions;

public class PriceOutofRangeException:BadRequestException
{
    public PriceOutofRangeException() : base("Maximum price should be less then 1000 and greater than 10")
    {
    }
}