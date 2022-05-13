var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/customs_duty", (double? price) => Duty(price));

app.Run();

double CalcDuty(double? price)
{
    
    double duty = 0.0;

    if (price > 200)
    {
        duty = Math.Round((double) ((price - 200.0) * 0.15), 2, MidpointRounding.AwayFromZero);
    }

    return duty;
}

string? Duty(double? price)
{
    return $"При сумме заказа: {price}€\nРазмер пошлины: {CalcDuty(price)}€";
}