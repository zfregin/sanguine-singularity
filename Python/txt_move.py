import shutil
import os
import fnmatch

print("Welcome to the .txt File Mover!")

# Stores paths of source directory and destination directory
source  = str(input("Please enter your source file directory: "))
dest = str(input("Please enter your destination file directory: "))

def txt_move(source, dest):
	# Walks through tree of source directory
	for root,directories,filenames in os.walk(source):
		for file in filenames:
			# Checks if filename indicates a .txt file
			if fnmatch.fnmatch(file, '*.txt'):
				# Joins root path with file name
				file_path = os.path.join(root,file)
				print(file_path)
				# Moves file to destination directory
				shutil.move(file_path,dest)

txt_move(source,dest)

print("Files have been successfully moved!")