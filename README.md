# Sedol
Sedol with Nunit coverage
1. SedolTest.cs is for NUnit coverage.
2. SedolBL.cs is used for controlling business flow for sedol system
3. SedolCommon.cs has all common functions written.

Below scenario are covered via NUnit test attributes
**Scenario:**  Null, empty string or string other than 7 characters long
InputString Test Value|IsValidSedol|IsUserDefined|ValidationDetails
---|--|--|--|
Null|False|False|Input string was not 7-characters long
""|False|False|Input string was not 7-characters long
12|False|False|Input string was not 7-characters long
123456789|False|False|Input string was not 7-characters long


**Scenario:**  Invalid Checksum non user defined SEDOL
InputString Test Value|IsValidSedol|IsUserDefined|ValidationDetails
---|--|--|--|
1234567|False|False|Checksum digit does not agree with the rest of the input


**Scenario:**  Valid non user define SEDOL
InputString Test Value|IsValidSedol|IsUserDefined|ValidationDetails
---|--|--|--|
0709954|True|False|Null
B0YBKJ7|True|False|Null

**Scenario** Invalid Checksum user defined SEDOL
InputString Test Value|IsValidSedol|IsUserDefined|ValidationDetails
---|--|--|--|
9123451|False|True|Checksum digit does not agree with the rest of the input
9ABCDE8|False|True|Checksum digit does not agree with the rest of the input

**Scenario** Invaid characters found
InputString Test Value|IsValidSedol|IsUserDefined|ValidationDetails
---|--|--|--|
9123_51|False|False|SEDOL contains invalid characters
VA.CDE8|False|False|SEDOL contains invalid characters

**Scenario:** Valid user defined SEDOL
InputString Test Value|IsValidSedol|IsUserDefined|ValidationDetails
---|--|--|--|
9123458|True|True|Null
9ABCDE1|True|True|Null


