from flask import Flask, request, jsonify
import os
from utils.extractors import extract_metadata_from_pdf, extract_metadata_from_jpg, extract_metadata_from_excel
import pandas as pd
import PyPDF2
from PIL import Image
import pytesseract
import os

app = Flask(__name__)

@app.route('/')
def home():
    return "Welcome to the AI Application! Use the /upload endpoint to upload files."
    
@app.route('/upload', methods=['POST'])
def upload_file():
    if 'file' not in request.files:
        return jsonify({'error': 'No file part'}), 400
    file = request.files['file']
    if file.filename == '':
        return jsonify({'error': 'No selected file'}), 400
    file.save(os.path.join('data', file.filename))
    
    if file.filename.endswith('.pdf'):
        metadata = extract_metadata_from_pdf(os.path.join('data', file.filename))
    elif file.filename.endswith('.jpg') or file.filename.endswith('.jpeg'):
        metadata = extract_metadata_from_jpg(os.path.join('data', file.filename))
    elif file.filename.endswith('.xlsx'):
        metadata = extract_metadata_from_excel(os.path.join('data', file.filename))
    else:
        return jsonify({'error': 'Unsupported file type'}), 400
    
    return jsonify({'message': 'File uploaded successfully', 'metadata': metadata}), 200
    if file.filename.endswith('.pdf'):
        # Logic to extract metadata from PDF
        pass
    elif file.filename.endswith('.jpg') or file.filename.endswith('.jpeg'):
        # Logic to extract metadata from JPG
        pass
    elif file.filename.endswith('.xlsx'):
        # Logic to extract metadata from Excel
        pass
    else:
        return jsonify({'error': 'Unsupported file type'}), 400
    return jsonify({'message': 'File uploaded successfully'}), 200

if __name__ == '__main__':
    app.run(debug=True)
