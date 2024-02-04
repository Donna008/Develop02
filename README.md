## Overview

This is a simple journal program that allows users to write, display, save, and load journal entries. The program provides prompts to users and saves their responses along with the date and prompt.

## Features

- Write a new entry: Users can respond to a random prompt and save their entry.
- Display the journal: View all entries in the journal.
- Save the journal to a file: Save the complete list of entries to a specified file.
- Load the journal from a file: Load entries from a specified file, replacing the current journal.
- User-friendly menu: A menu interface allows users to easily choose program options.

## Program Structure

The program is structured into three classes:

1. `JournalEntry`: Represents an individual journal entry with properties for prompt, response, and date.

2. `Journal`: Represents the journal itself, containing a list of `JournalEntry` objects. It includes methods for writing new entries, displaying the journal, saving to a file, and loading from a file.

3. `Program`: The entry point of the application, responsible for handling user input and interacting with the `Journal` class.

'''{python}


'''