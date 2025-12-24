# MathGame.MAUI

MathGame.MAUI is a small educational .NET MAUI application that presents basic arithmetic games (addition, subtraction, multiplication, division) and stores previous game results in a local SQLite database.

## Features

- Play simple arithmetic quizzes with configurable rounds.
- Persist game results locally using SQLite.
- View and delete previously played games.

## Requirements

- .NET 10 SDK
- .NET MAUI workload installed (Visual Studio 2022/2023 or later with MAUI support recommended)
- Windows (project targets Windows via `net10.0-windows10.0.19041.0` in the provided project)

## Getting started

1. Clone the repository:

   ```bash
   git clone https://github.com/devjayswal/MathGame.MAUI.git
   cd MathGame.MAUI
   ```

2. Open the solution in Visual Studio (recommended) or use the `dotnet` CLI.

3. Build and run:

   - Visual Studio: Open the solution and run the project using the Windows target.
   - CLI (build only):

     ```bash
     dotnet build MathGame.MAUI/MathGame.MAUI.csproj
     ```

     Note: Running a MAUI app from the CLI is limited; using Visual Studio with MAUI tooling is the standard approach for deployment and debugging.

## Local database

The app stores results in a SQLite database file located in the application data directory. The database file name is `mathgame.db3` and is created automatically at runtime. The exact path is platform-dependent; on Windows it is typically under the current user's AppData directory. The app initializes the database schema on startup, so no manual setup is required.

To reset stored results, stop the app and delete the `mathgame.db3` file from the app data directory.

## Project structure

- `MathGame.MAUI/` - main .NET MAUI project
- `MathGame.MAUI/Data` - repository and data access code (SQLite)
- `MathGame.MAUI` contains XAML pages for gameplay and viewing previous games

## Contributing

Contributions and fixes are welcome. Please open an issue or submit a pull request.

## License

No license specified in this repository. Check the repository for a `LICENSE` file or add one if needed.