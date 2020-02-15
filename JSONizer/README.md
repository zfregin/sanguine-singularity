### JSONizer Utility
***

The purpose of this application is to convert a variable width, flat csv file to a hierarchical JSON file.

Example .csv files are included for reference

To use the application, clone the project folder and open the main solution file (.sln) using Visual Studio. Click the green Start arrow and the application will start running. A window will display with a button to select the desired csv file for conversion. Clicking the "Convert" button will parse through the csv file and structure it into JSON format, displaying the converted JSON data in the textbox. A new .txt file with the JSON conversion is also produced in the same directory as the selected CSV file, with "\_JSON" appended to the original filename.

Quick notes on implementation:
	* The input is not validated for the sake of simplicity, as this was just a quick solution to the challenge
	* The csv file is read line by line to reduce memory consumption and facilitate formatting of large data files
	* The use of StringBuilder.AppendLine() instead of \n for new lines is intended, as AppendLine() is platform agnostic
	* To keep the formatting open to future changes, I tried to modularize the formatting for each record type and used switch cases that facilitate the addition of new fields
