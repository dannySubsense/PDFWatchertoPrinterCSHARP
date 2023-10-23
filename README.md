# PDFWatchertoPrinter_CSHARP

## Overview

This application continuously watches a specified directory for new PDF files. When a new PDF is detected, the application uses `PDFtoPrinter.exe` to send the PDF to the default printer.

## Prerequisites

- .NET 7.0 or later
- `PDFtoPrinter.exe` should be included in the project directory.

## Setup

1. **Clone the repository:**
    ```bash
    git clone https://github.com/dannySubsense/PDFWatchertoPrinterCSHARP/tree/master
    ```

2. **Navigate to the project directory:**
    ```bash
    cd PDFWatchertoPrinter
    ```

3. **Build the project:**
    ```bash
    dotnet build
    ```

4. **Run the application:**
    ```bash
    dotnet run
    ```

## Usage

Upon running, the application will prompt you to specify the directory you'd like to watch. Enter the full path of the directory.

The application will then start monitoring the specified directory for any new PDF files. If a new PDF is detected, it will automatically be sent to the default printer using `PDFtoPrinter.exe`.

## Notes

- Ensure that the machine does not enter sleep mode for uninterrupted monitoring. You can adjust your Windows power management settings to prevent the computer from sleeping.

- If the application is unable to find `PDFtoPrinter.exe` in the project directory, ensure that the file is present and the path is correctly set in the application.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you'd like to change.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.
