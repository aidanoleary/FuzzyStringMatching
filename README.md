# FuzzyStringMatching

FuzzyStringMatching is a library for performing fuzzy matching on strings.

## Installation
The FuzzyStringMatching library can be installed from Nuget https://www.nuget.org/packages/AidanOleary.FuzzyStringMatching/.

## Usage

```csharp

FuzzyStringMatchingService fuzzyService = new FuzzyStringMatchingService();
fuzzyService.CompareStrings(FuzzyStringComparerType.LevenshteinDistancePercentage, "hello", "helloworld"); //returns 50

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)