import datetime
from datetime import datetime
from datetime import time
import pytz

# Creates the opening and closing times of the banks
opentime = time(9,0,0)
closetime = time(21,0,0)

# Stores the current datetime in UTC, with no timezone info
naive_utc = datetime.utcnow()
# Adds timezone information to UTC time
aware_utc = naive_utc.replace(tzinfo=pytz.utc)
# Stores the current time in Portland with timezone info
pdx_time = aware_utc.astimezone(pytz.timezone('America/Los_Angeles'))
# Prints just the time portion of Portland datetime
print("Current time in Portland, OR is: " + str(pdx_time.time()))

print()

# Stores current time in New York with timezone info
ny_time = aware_utc.astimezone(pytz.timezone('America/New_York'))
# Prints just the time portion of NY datetime
print("Current time in New York, NY is: " + str(ny_time.time()))
# Checks if current time in NY is within operating bank hours and prints whether bank is open or closed
if ny_time.time() > opentime and ny_time.time() < closetime:
        print("New York branch is open")
else:
        print("New York branch is closed")

print()

# Stores current time in London with timezone info
london_time = aware_utc.astimezone(pytz.timezone('Europe/London'))
# Prints just the time portion of London datetime
print("Current time in London is: " + str(london_time.time()))
# Checks if current time in London is within operating bank hours and prints whether bank is open or closed
if london_time.time() > opentime and london_time.time() < closetime:
        print("London branch is open")
else:
        print("London branch is closed")
