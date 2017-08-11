from tkinter import *
from tkinter import ttk
from tkinter import filedialog
import shutil
import os
import fnmatch
import time



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
source_lbl.grid(row=0, column=1, columnspan=3, pady = 20)
# Source Browse Button
browse_source = ttk.Button(input_frame, text = "Browse")
browse_source.grid(row=1, column=0)
# Source Path Entry
source_entry = ttk.Entry(input_frame, width = 60)
source_entry.grid(row=1, column=1, columnspan=2)
source_entry.state(['disabled'])

# Destination Label
dest_lbl = ttk.Label(input_frame, text = "Please select the folder you wish to copy files to:")
dest_lbl.grid(row=2, column=1, columnspan=3, pady = 20)
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
# Transfer Files Button
transfer_btn = ttk.Button(transfer_frame, text = "Transfer Files")
transfer_btn.grid(row=0,column=1, columnspan=3, pady = 30)

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
	current_time = time.time()
	previous_24hr = current_time - 24*60*60
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

# Button Callbacks
browse_source.config(command = source_file)
browse_dest.config(command = dest_file)
transfer_btn.config(command = lambda: recent_changes(source_entry.get(),dest_entry.get()))


root.mainloop()