using System;
using System.Collections.Generic;
using System.Windows;
using System.Threading.Tasks;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadCueSheetAsync();
    }

    private async void LoadCueSheetAsync()
    {
        try
        {
            // Simulate extracted raw text (e.g., from OCR)
            string extractedText = """
            Title: The Grand Finale
            Composer: Michael Giacchino
            Author: Jane Doe
            Publisher: Big Score Music
            Share: 60%
            Share: 40%
            """;

            var cueSheet = await AIService.ExtractCueSheetAsync(extractedText);
            DataContext = new CueSheetViewModel(cueSheet);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"AI Error: {ex.Message}");
        }
    }

    private async void OpenDocument_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new Microsoft.Win32.OpenFileDialog
        {
            Filter = "PDF and Image Files|*.pdf;*.jpg;*.jpeg;*.png",
            Title = "Select Cue Sheet Document"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            try
            {
                string extractedText = string.Empty;
                string path = openFileDialog.FileName;

                if (path.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    extractedText = DocumentProcessor.ExtractTextFromPdf(path);
                }
                else
                {
                    extractedText = DocumentProcessor.ExtractTextFromImage(path);
                }

                var cueSheet = await AIService.ExtractCueSheetAsync(extractedText);
                DataContext = new CueSheetViewModel(cueSheet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing document: {ex.Message}");
            }
        }
    }
}
