def sort_ascend(list):
	# Starts at end of list and iterates down
	for sort_slot in range(len(list)-1,0,-1):
		max_index = 0
		# Compares values, stores index of largest value to max_index
		for element in range(1,sort_slot + 1):
			if list[element] > list[max_index]:
				max_index = element
		# Switches the value at max_index with value at sort_slot
		list[sort_slot],list[max_index] = list[max_index],list[sort_slot]
	print(list)

list1 = [67,45,2,13,1,998]
list2 = [89,23,33,45,10,12,45,45,45]

sort_ascend(list1)
sort_ascend(list2)