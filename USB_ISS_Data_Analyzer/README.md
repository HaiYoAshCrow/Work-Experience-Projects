=====================================
USB ISS/CMPS10 Data Analyzer/Logger
=====================================

Source Files
----------------
-	There are two C# Project files within the solution. USB_READER contains a basic data viewer
	while the USB_ISS_DATA_ANALYZER contains a data logger with an implementation of a step-filtering
	algorithm. I created the viewer first as a diagnostic tool for testing the device while the second
	program was created for data collection for my supervisors.

-	It should be noted that there is no port selection available in the GUI yet. 
  The default is set at port 0. If the user wishes to change they must do so in 
	the code in the CMPS10_INTERFACE.cs file at the bool Open() function.
	
Executable & Usage
-----------------
-	All log files according to tab will be saved to folders with according names.
-	During record mode the user will not be able to change any tabs. "Record All"
	will log data from all tabs.
-	The user can adjust/calibrate the device through the settings tab.

Previews of programs
--------------------
- The Logger program

![alt tag](https://raw.githubusercontent.com/LunarOwl/Work-Experience-Projects/master/USB_ISS_Data_Analyzer/Logger.png)

- The Viewer program

![alt tag](https://raw.githubusercontent.com/LunarOwl/Work-Experience-Projects/master/USB_ISS_Data_Analyzer/Viewer.png)
