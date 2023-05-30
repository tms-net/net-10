using CsvRunner;
using CSVSerializer;
using System.Collections.Generic;

//preparing test data   
var stockTest = new Stock("1_symbol_1")
{
    Price = 99,
    Date = DateTime.Today,
    Indexes = new int[]{ 1, 2, 3 },
};

var stockTest1 = new Stock("2_symbol_2")
{
    Price = 100.44m,
    Date = DateTime.Today,
    Indexes = new int[] { 2, 2, 3, 5}
};

var stockTest2 = new Stock("3_symbol_3")
{
    Price = 200,
    Date = DateTime.Today,
    Indexes = new int[] { 14, 2, 3 }
};

var stockTest3 = new Stock("4_symbol_4")
{
    Price = 300,
    Date = DateTime.Today,
    Indexes = new int[] { 15, 2, 3 }
};

var stockTest4 = new Stock("5_symbol_5")
{
    Price = 10023,
    Date = DateTime.Today,
    Indexes = new int[] { 16, 2, 3 }
};

List<Stock> stocks = new List<Stock>()
{
    stockTest,
    stockTest1,
    stockTest2,
    stockTest3,
    stockTest4
};

//call serialize method
var path = CsvSerializer<List <Stock>, Stock>.Serialize(stocks);

//call deserialize and show in console ToString() method of every deserialized instance
foreach (var instance in CsvSerializer<List<Stock>, Stock>.DeSerialize(path, typeof(Stock)))
{
    Console.WriteLine(instance.ToString());
}
