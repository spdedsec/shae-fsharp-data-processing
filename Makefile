.PHONY: build test release clean install help
DOTNET ?= dotnet

build:
	@$(DOTNET) build -c Release

test: build
	@echo "Build verified (F# source compiled)"

release: build
	@tar czf dist/shae-fsharp-data-processing-v0.1.0-src.tar.gz src/ scripts/ Makefile README.md DESIGN.md LICENSE docs/

install: build
	@echo "Run with: dotnet run -- project"

clean:
	@rm -rf dist/ bin/ obj/

help:
	@echo "Targets: build test release install clean help"
