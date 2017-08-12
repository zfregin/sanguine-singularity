import tkinter as tk
from tkinter import *
from tkinter import ttk
from tkinter import filedialog
from tkinter import messagebox
from datetime import datetime
import shutil
import os
import fnmatch
import time
import sqlite3


root = Tk()
root.title("Daily .Txt Transfer")
root.minsize(width=600, height=400)

# Welcome Frame
welcome_frame = ttk.Frame(root)
welcome_frame.pack()
# Welcome Label
welcome = ttk.Label(welcome_frame, text = "Welcome to the Daily .Txt Transfer")
welcome.grid(row=0, column=1, columnspan=3, pady=10)
welcome.config(font=("Arial", 20))

# Input Frame
input_frame = ttk.Frame(root)
input_frame.pack()
# Source Label
source_lbl = ttk.Label(input_frame, text = "Please select the folder you wish to transfer from:")
source_lbl.grid(row=0, column=0, columnspan=3, pady = 20)
# Source Browse Button
browse_source = ttk.Button(input_frame, text = "Browse")
browse_source.grid(row=1, column=0)
# Source Path Entry
source_entry = ttk.Entry(input_frame, width = 60)
source_entry.grid(row=1, column=1, columnspan=2)
source_entry.state(['disabled'])

# Destination Label
dest_lbl = ttk.Label(input_frame, text = "Please select the folder you wish to copy files to:")
dest_lbl.grid(row=2, column=0, columnspan=3, pady = 20)
# Destination Browse Button
browse_dest = ttk.Button(input_frame, text = "Browse")
browse_dest.grid(row=3, column=0)
# Destination Path Entry
dest_entry = ttk.Entry(input_frame, width = 60)
dest_entry.grid(row=3, column=1, columnspan=2)
dest_entry.state(['disabled'])

# Transfer Frame
transfer_frame = ttk.Frame(root)
transfer_frame.pack()
# File Check Label
file_check = ttk.Label(transfer_frame, text = "Last file check run: ")
file_check.grid(row=0,column=0, columnspan = 2, pady = 20)
file_check.config(font=("Arial", 14))
# Time Stamp Label
stamp = ttk.Label(transfer_frame)
stamp.grid(row=0,column=3, columnspan = 2, pady = 20)
stamp.config(font=("Arial", 14))
# Transfer Files Button
transfer_btn = ttk.Button(transfer_frame, text = "Transfer Files")
transfer_btn.grid(row=1,column=1, columnspan=3, pady = 30)

def createDB():
	with sqlite3.connect("file_transfer_database.db") as connection:
		c = connection.cursor()
		# Create Table
		c.executescript("""
			DROP TABLE IF EXISTS Transfers;
			CREATE TABLE Transfers(FileCheck REAL);
			""")
		# c.execute("SELECT COUNT(*) FROM Transfers")
		transfer_count = c.fetchone()
		# Sets message for 1st time initialization with no entries
		if transfer_count == None:
			stamp.config(text = "No previous records")

def source_file():
	# Enables entry field for editing
	source_entry.state(['!disabled'])
	# Clears entry field
	source_entry.delete(0,END)
	# Copies folder path to entry field
	source_entry.insert(0,filedialog.askdirectory())
	# Sets entry field back to disabled
	source_entry.state(['disabled'])

def dest_file():
	# Enables entry field for editing
	dest_entry.state(['!disabled'])
	# Clears entry field
	dest_entry.delete(0,END)
	# Copies folder path to entry field
	dest_entry.insert(0,filedialog.askdirectory())
	# Sets entry field back to disabled
	dest_entry.state(['disabled'])

def recent_changes(source, dest):
	# Checks to make sure both folders have been specified before updating file check database
	if (source_entry.get() == "" or dest_entry.get() == ""):
		messagebox.showinfo("Error", "Error: You must provide both a source folder and a destination folder")
	else:
		with sqlite3.connect("file_transfer_database.db") as connection:
			c = connection.cursor()

			current_time = time.time()
			previous_24hr = current_time - 24*60*60
			c.execute("INSERT INTO Transfers VALUES(" + str(current_time) + ")")
			# Walks through tree of source directory
			for root,directories,filenames in os.walk(source):
				for file in filenames:
					# Checks if filename indicates a .txt file
					if fnmatch.fnmatch(file, '*.txt'):
						# Joins root path with file name
						file_path = os.path.join(root,file)
						# Checks if file was modified within last 24 hours
						if os.path.getmtime(file_path) > previous_24hr:
							print(file_path)
							shutil.copy(file_path,dest)
			# Queries for most recent filecheck timestamp
			c.execute("SELECT MAX(FileCheck) FROM Transfers")
			last_check = c.fetchone()
			# Converts Unix timestamp to readable datetime and updates filecheck message
			stamp.config(text = datetime.fromtimestamp(int(last_check[0])).strftime('%Y-%m-%d %H:%M:%S'))

# Button Callbacks
browse_source.config(command = source_file)
browse_dest.config(command = dest_file)
transfer_btn.config(command = lambda: recent_changes(source_entry.get(),dest_entry.get()))

createDB()
root.mainloop()