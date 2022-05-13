using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/customs_duty", (double? price) => Duty(price));
app.MapGet("/date", (string? language) => DateInLanguage(language));

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

string Duty(double? price)
{
    return $"При сумме заказа: {price}€\nРазмер пошлины: {CalcDuty(price)}€";
}

string DateInLanguage(string? language)
{
    DateTime dateTime = DateTime.Now;
    CultureInfo culture = CultureInfo.CurrentCulture;
    if (language != null)
    {
        culture = new CultureInfo(language);
    }
    
    //  Формирование строки с нужным значением даты и времени
    string result = dateTime.ToString("dddd, d MMMM yyyy, hh:mm:ss", culture);
    //  У наименования дня недели и месяца, первую букву делаем заглавной
    result = culture.TextInfo.ToTitleCase(culture.TextInfo.ToLower(result));
    result += dateTime.ToString(" tt", culture); 
    
    return result;
}