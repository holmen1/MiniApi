namespace MiniApi.Models;

enum Region
{
    SE,
    NO,
    FI,
    DK
}

enum Portfolio
{
    Low,
    Medium,
    High
}

record SampleDataDto
{
    public List<UserDto> Users { get; set; } = new();
    public List<OrderDto> Orders { get; set; } = new();
}

record UserDto
{
    public string First { get; set; } = string.Empty;
    public string Last { get; set; } = string.Empty;
    public double Age { get; set; }
}

record OrderDto
{
    public string Region { get; set; } = string.Empty;
    public string Portfolio { get; set; } = string.Empty;
    public double Value { get; set; }
}

// Domain Models
class User
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public double Age { get; set; }
}

class Order
{
    public Region Region { get; set; }
    public Portfolio Portfolio { get; set; }
    public double Value { get; set; }
}