# Dictionary API Integration in Unity

## Unity Version
Unity 2020.3 or higher

---

## Overview
This project demonstrates a simple Unity application that fetches the meaning of a word using a public Dictionary API and logs the result in the Unity Console.

The implementation focuses on clean architecture, input validation, API integration, and proper error handling.

---

## Features

- User input field for entering a single word
- Input validation (alphabetic characters only, no spaces or symbols)
- API integration using UnityWebRequest
- Console output of the first definition
- Error handling for invalid input, word not found, and network issues
- Basic request control to prevent multiple simultaneous API calls

---

## Architecture

The project is structured with separation of concerns:

### UI Layer
- Handles user input and button interaction
- Triggers API requests

### Service Layer
- Manages API communication
- Processes HTTP requests and responses

### Validation Layer
- Ensures input is valid before making API calls

---

## API Used

Public Dictionary API:
https://api.dictionaryapi.dev/api/v2/entries/en/<word>

Example:
https://api.dictionaryapi.dev/api/v2/entries/en/hello

---

## How to Test

1. Open the project in Unity
2. Load the main scene
3. Enter Play Mode
4. Enter a valid word in the input field (e.g., "hello")
5. Click the "Search" button
6. Check the Unity Console for:
   - The definition (on success)
   - Warning messages (invalid input)
   - Error messages (API failure or word not found)

---

## Error Handling

- Invalid input → Console warning
- Word not found → Error message
- Network/API failure → Error message
- Prevents multiple API calls while a request is in progress

---

## Limitations

- Only the first definition is displayed
- Output is limited to the Unity Console (no UI display)
- No caching of previous results

---

## Author
Shobhit
