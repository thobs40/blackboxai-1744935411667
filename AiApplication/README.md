# AI Cue Sheet Application

This is a WPF application that allows users to upload PDF, JPG, and Excel files, extract metadata from cue sheets, and interact with an AI microservice for processing.

## Features
- Upload PDF, JPG, and Excel files.
- Extract metadata using OCR and PDF parsing.
- Autofill cue sheet data using AI.

## Installation
1. Clone the repository.
2. Navigate to the project directory.
3. Install the required dependencies:
   ```bash
   dotnet restore
   ```

## Usage
1. Run the application:
   ```bash
   dotnet run
   ```
2. Use the UI to upload documents and view/edit cue sheet data.

## Technologies Used
- WPF for the frontend.
- ASP.NET Core for the backend.
- Tesseract for OCR.
- PdfPig for PDF processing.
- EPPlus for Excel file handling.
