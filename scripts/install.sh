#!/usr/bin/env bash
set -euo pipefail
echo "Installing shae-fsharp-data-processing (F# language tool)"
echo "Build: dotnet build -c Release"
echo "Run: dotnet run -- src/data_processor.fs <csv-file> [category]"
echo "Usage: shae-data-processor <csv-file> [category]"
