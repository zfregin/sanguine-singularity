import shutil
import os
import fnmatch
import time

current_time = time.time()
previous_24hr = current_time - 24*60*60

print("Welcome to the Daily .txt File Mover!")

# Stores paths of source directory and destination directory
source  = str(input("Please enter your source file directory: "))
dest = str(input("Please enter your destination file directory: "))

def txt_move(path, dest):
	# # Checks if filename indicates a .txt file
	# if fnmatch.fnmatch(file, '*.txt'):
	# 	# Joins root path with file name
	# 	file_path = os.path.join(root,file)
	# 	print(file_path)
	# 	# Moves file to destination directory
	shutil.copy(path,dest)
		# os.remove(file_path)

def recent_changes(source, dest):
	for root,directories,filenames in os.walk(source):
		for file in filenames:
			# Checks if filename indicates a .txt file
			if fnmatch.fnmatch(file, '*.txt'):
				# Joins root path with file name
				file_path = os.path.join(root,file)
				if os.path.getmtime(file_path) > previous_24hr:
					print(file_path)
					txt_move(file_path,dest)

recent_changes(source,dest)


