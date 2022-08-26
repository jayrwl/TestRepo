# TestRepo

Script.sql file contains the Database script, run the sql script.

Open the Unit Converter Web Api project.

The code converts following conversion,
-cm to inch
-C to F
-Km to miles 
and vice-versa



Input json format:
{
  "FromUnit" : "C",
  "ToUnit" : "F",
  "Input" : "37"
}

output:
{
  result : "98.6"
}
