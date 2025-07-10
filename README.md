# .NET 10 Preview: Stock Tickers Example

This project demonstrates different C# record types and their behaviors using stock ticker examples.

## Examples

### 1. Using `DiagramSource`

Demonstrates adding multiple [`Ticker2`](StockTickersExample.cs) instances to a [`DiagramSource`](StockTickersExample.cs) collection.

```csharp
var ds = new DiagramSource(101);
var t1 = new Ticker2("BTC", 60000m);
var t2 = new Ticker2("ETH", 4000m);
var t3 = new Ticker2("DOGE", 0.25m);

ds.Add(t1);
ds.Add(t2, t3);
```

### 2. Using `Ticker1` (Immutable Record Class)

Shows how to use an immutable record class and its `Change` method.

```csharp
var ticker = new Ticker1("FB", 250m);
var updated = ticker.Change(20m);
var furtherUpdated = updated.Change(30m);
```

### 3. Using `Ticker2` (Record Class - Reference Type)

Demonstrates value equality vs reference equality for record classes.

```csharp
var tickerA = new Ticker2("NFLX", 500m);
var tickerB = new Ticker2("NFLX", 500m);

Console.WriteLine(tickerA == tickerB); // True (value equality)
Console.WriteLine(ReferenceEquals(tickerA, tickerB)); // False (reference equality)
```

### 4. Using `Ticker3` (Record Struct - Value Type)

Shows value-type semantics (copying) with record structs.

```csharp
var tOriginal = new Ticker3("SOL", 150m);
var tCopy = tOriginal;

tCopy = new Ticker3(tCopy.Symbol, 200m);

// tOriginal.LastPrice is still 150m, tCopy.LastPrice is 200m
```

## Types

- [`DiagramSource`](StockTickersExample.cs): Holds a collection of [`Ticker2`](StockTickersExample.cs) objects.
- [`Ticker1`](StockTickersExample.cs): Immutable record class (reference type) with a `Change` method.
- [`Ticker2`](StockTickersExample.cs): Record class (reference type), demonstrates value equality.
- [`Ticker3`](StockTickersExample.cs): Record struct (value type), demonstrates value-type copying.

See [StockTickersExample.cs](StockTickersExample.cs) for full code.