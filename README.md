OpenTranslateTool
A lightweight Windows utility for translating between Hex, Base64, and human‑readable word streams using custom dictionaries.

📌 Overview
OpenTranslateTool is a small Windows Forms application designed to convert binary‑encoded data (Hex or Base64) into readable word streams — and back again — using predefined dictionaries stored in the ./Dic folder.

This makes it ideal for:

Sending encoded data through messaging apps or email

Converting cryptographic output into human‑friendly text

Reversibly encoding information using custom wordlists

Formatting output from other tools in the Open Toolset

The tool guarantees bit‑accurate round‑trip conversion:
Hex → Words → Hex → Base64 → Words → Hex — all reversible.

✨ Features
🔹 Automatic format detection  
Detects whether input is Hex, Base64, or a word stream.

🔹 Dictionary‑based encoding  
Uses wordlists stored in ./Dic to map bytes or bit‑chunks to words.

🔹 Reversible translation  
Every transformation is deterministic and fully reversible.

🔹 Optional Base64 output  
When converting words → hex, you can choose to output Base64 instead.

🔹 Simple UI  
Input box, output box, dictionary selector, and a single Translate button.

📁 Dictionary System
Dictionaries are plain text files stored in:

Code
./Dic/
Each file contains one word per line.
The index of each word determines its encoded value.

Examples:

Code
0: apple
1: river
2: stone
...
255: horizon
The tool loads all dictionary files at startup and lists them in the dropdown.

🔍 Input Detection Logic
The app automatically determines what the user typed:

1. Hex
Only characters 0–9, A–F, a–f

No spaces

2. Base64
Must end with = or ==

Must decode cleanly via Convert.FromBase64String()

3. Word Stream
All words must exist in the selected dictionary

If none match, the tool returns:

Code
Unrecognized format
🔄 Translation Rules
Hex → Words
Direct mapping using the selected dictionary.

Base64 → Hex → Words
Base64 is decoded to bytes, converted to hex, then mapped to words.

Words → Hex → (optional Base64)
If the checkbox Output Base64 is checked:

Words → Hex → Base64

If unchecked:

Words → Hex

🖥️ How to Use
Place your dictionary files in the ./Dic folder

Launch the application

Select a dictionary from the dropdown

Paste your input (Hex, Base64, or word stream)

Choose whether output should be Base64 (if applicable)

Click Translate

📦 Project Structure
Code
OpenTranslateTool/
│
├── Dic/                     # Dictionary files (user-provided)
│   ├── english256.txt
│   ├── phrases1024.txt
│   └── ...
│
├── MainForm.cs              # UI logic and translation routing
├── MainForm.Designer.cs     # Auto-generated WinForms layout
├── DictionaryManager.cs     # Loads and manages dictionaries
├── Translator.cs            # Hex/Word/Base64 conversion logic
├── Program.cs               # Application entry point
└── README.md                # This file
🛠️ Requirements
Windows

.NET 6 / .NET 8 (depending on your build)

A ./Dic folder with at least one dictionary file

📜 License
Add your preferred license here (MIT recommended).

🤝 Contributions
Pull requests and dictionary contributions are welcome.

💬 Notes
This tool is intentionally simple, fast, and offline‑friendly.
It is designed for practical, real‑world workflows where binary data must be safely transmitted through systems that mangle or restrict raw hex/Base64.
