# SHAE F# Data Processing

A data processing CLI written in F#.

## Features
- Parse CSV files into typed records
- Filter by category
- Aggregate statistics by category
- Strongly typed with type inference

## Install
```bash
./scripts/install.sh
# Or manually:
dotnet build -c Release
dotnet run -- src/data_processor.fs <csv-file> [category]
```

## Usage
```bash
dotnet run -- project data.csv
dotnet run -- project data.csv Finance
```

## Design
Follows SHAE Field Manual: warm paper #F2EEE5, ink #191712, oxide #B3341B, 0px radius, 1px borders.
