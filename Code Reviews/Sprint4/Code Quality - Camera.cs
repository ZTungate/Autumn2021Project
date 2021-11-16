Author of the code review: Jonah Silsdorf
Date of the code review: 11/15/21
Sprint number: 4
Name of the .cs file being reviewed:  Camera.cs
Author of the .cs file being reviewed: Mason
Number of minutes taken to complete the review: 15

This class appears to have high cohesion, no methods seem out of place, and every variable seems to be used other than rotation.
The getXXXX() methods for protecting private variables from modification are a nice addition.
Method names are logical, and there is no magic numbering outside of math equations.
There does not appear to be any unnecessary branching or looping occuring in this class.
This class could benefit from some comments for maintainability.
