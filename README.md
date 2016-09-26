ETL Exercise
Notes

Place the datafile MarketingDataFile.txt into the \bin\Debug\CodingExercise\ directory.

Assumptions:
The data is all numeric.
Line breaks should be ignored.

Design:
The program imports a flat data file and parses it into a list based upon a formating string. 
The list is then checked row by row to see if the data is less than todays date.
Output value to screen and file.

Questions:
Where did the data originate from? 
Does the datafile also contain other information other that just date information?
Might data actually have come from Excel, and a type conversion done i.e. DateValue function?  
I only get one valid value from parsing this dataset. Could that be right? 


~~~~~~~~~~~~~~~~~~~~
Data Given:
Use Case

Marketing has received a data file that may have been corrupted when it was exported. We

need to extract all of the dates that have occurred in the past from this document.

Criteria

1. A date is defined as MMDDYYYY

a. ie: April 3, 2011 would be 03032011.

2. A past date is defined by any date that occurred before today.

a. ie: If today is 09/29/2016, all dates 08282016 or earlier would be valid.

3. The data file does not contain time information.

4. The resulting data output should be a list of dates.​
