#!/home/mark/.dotnet/dotnet run

   // ===== Example 1: Using DiagramSource =====
        var ds = new DiagramSource(101);

        var t1 = new Ticker2("BTC", 60000m);
        var t2 = new Ticker2("ETH", 4000m);
        var t3 = new Ticker2("DOGE", 0.25m);

        ds.Add(t1);
        ds.Add(t2, t3);

        Console.WriteLine("DiagramSource tickers added.");
        Console.WriteLine("\r\n");
        // ===== Example 2: Using Ticker1 (Immutable Record Class) =====
        var ticker = new Ticker1("FB", 250m);
        Console.WriteLine($"Original Ticker1 price: {ticker.lastPrice}");

        var updated = ticker.Change(20m);
        Console.WriteLine($"Updated Ticker1 price: {updated.lastPrice}");
        Console.WriteLine("\r\n");
        var furtherUpdated = updated.Change(30m);
        Console.WriteLine($"Further updated Ticker1 price: {furtherUpdated.lastPrice}");
        Console.WriteLine("\r\n");
        // ===== Example 3: Using Ticker2 (Record Class - Reference Type) =====
        var tickerA = new Ticker2("NFLX", 500m);
        var tickerB = new Ticker2("NFLX", 500m);

        Console.WriteLine($"Ticker2 value equality: {tickerA == tickerB}"); // True
        Console.WriteLine($"Ticker2 reference equality: {ReferenceEquals(tickerA, tickerB)}"); // False

        // ===== Example 4: Using Ticker3 (Record Struct - Value Type) =====
        var tOriginal = new Ticker3("SOL", 150m);
        var tCopy = tOriginal;

        Console.WriteLine($"Ticker3 Original: {tOriginal.LastPrice}, Copy: {tCopy.LastPrice}");

        tCopy = new Ticker3(tCopy.Symbol, 200m);

        Console.WriteLine($"After change - Ticker3 Original: {tOriginal.LastPrice}, Copy: {tCopy.LastPrice}");
 
// Entity
class DiagramSource(int id)
{
    private readonly int _id = id;
    private readonly List<Ticker2> _tickers = new();

    public void Add(Ticker2 ticker, params Ticker2[] others)
    {
        _tickers.Add(ticker);
        _tickers.AddRange(others);
    }
}

// Immutable reference type
record class Ticker1(string symbol, decimal lastPrice)
{
    public Ticker1 Change(decimal difference) =>
        new Ticker1(symbol, lastPrice + difference);
}

// Value object (reference type)
record class Ticker2(string Symbol, decimal LastPrice);

// Value object (value type)
record struct Ticker3(string Symbol, decimal LastPrice);
