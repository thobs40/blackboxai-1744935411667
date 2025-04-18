import pandas as pd
import PyPDF2
from PIL import Image
import pytesseract

def extract_metadata_from_pdf(file_path):
    metadata = {}
    with open(file_path, 'rb') as file:
        reader = PyPDF2.PdfReader(file)
        metadata['title'] = reader.metadata.get('/Title', 'Unknown Title')
        metadata['author'] = reader.metadata.get('/Author', 'Unknown Author')
        metadata['subject'] = reader.metadata.get('/Subject', 'Unknown Subject')
        metadata['producer'] = reader.metadata.get('/Producer', 'Unknown Producer')
    return metadata

def extract_metadata_from_jpg(file_path):
    metadata = {}
    image = Image.open(file_path)
    text = pytesseract.image_to_string(image)
    # Assuming the text contains metadata in a specific format
    lines = text.split('\n')
    for line in lines:
        if 'Title:' in line:
            metadata['title'] = line.split('Title:')[1].strip()
        elif 'Composer:' in line:
            metadata['composer'] = line.split('Composer:')[1].strip()
        elif 'Publisher:' in line:
            metadata['publisher'] = line.split('Publisher:')[1].strip()
        elif 'Shares:' in line:
            metadata['shares'] = line.split('Shares:')[1].strip()
    return metadata

def extract_metadata_from_excel(file_path):
    metadata = {}
    df = pd.read_excel(file_path)
    if 'Title' in df.columns:
        metadata['title'] = df['Title'].iloc[0]
    if 'Composer' in df.columns:
        metadata['composer'] = df['Composer'].iloc[0]
    if 'Publisher' in df.columns:
        metadata['publisher'] = df['Publisher'].iloc[0]
    if 'Shares' in df.columns:
        metadata['shares'] = df['Shares'].iloc[0]
    return metadata
