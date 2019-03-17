# Reservoir Volume Calculator

Calculates the volume of oil & gas between the 2 horizons and above the fluid contact.

## Getting Started

Clone this repository and open the "ReservoirCalculator". Compile and run. The provided data set is included in the project and loaded when application initializes.

## Prerequisites

Project targets .NET Framework 4.6.1 using Visual Studio 2017. All dependencies are resolved automatically by NuGet.

## Running the tests

Automated unit and integration tests are executed by MSTest and can be executed directly by the IDE.

## Quality note

Although the provided solution currently does not allow it, the developed architecture is prepared for:

* Load additional data sets with different horizon dimensions, grid cell sizes, tolerance and units;
* Load data sets from different data sources (database, text files, etc.);
* Specify custom values and units for base horizon and fluid contact depth;

## Built With

* [MVVM Light](http://www.mvvmlight.net/) - MVVM Toolkit
